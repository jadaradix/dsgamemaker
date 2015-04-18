Imports System.Drawing.Drawing2D

Public Class GlobalStructures

    Dim Structures As New List(Of String)
    Dim Names As New List(Of String)
    Dim Types As New List(Of String)
    Dim Values As New List(Of String)
    'Dim CurrentName As String = String.Empty
    Dim AllowChangeOrQuit As Boolean = True
    Dim OldIndex As Int16 = 0
    Dim SaveOnChange As Boolean = False
    'Dim InUse As Boolean = False

    Private Sub GlobalStructures_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetEnablity(False)
        MembersList.Items.Clear()
        Structures.Clear()
        StructuresList.Items.Clear()
        Names.Clear()
        Types.Clear()
        Values.Clear()
        For Each X As String In GetXDSFilter("STRUCT ")
            X = X.Substring(7)
            Structures.Add(X)
            StructuresList.Items.Add(X)
            'For Each Y As String In GetXDSFilter("STRUCTMEMBER " + X + ",")
            '    Y = Y.Substring(("STRUCTMEMBER " + X).Length + 1)
            '    Names.Add(iGet(Y, 0, ","))
            '    Types.Add(iGet(Y, 1, ","))
            '    Values.Add(iGet(Y, 2, ","))
            'Next
        Next
        NameTextBox.BackColor = Color.FromArgb(64, 64, 64)
        SaveOnChange = False
        If StructuresList.Items.Count > 0 Then StructuresList.SelectedIndex = 0
        AllowChangeOrQuit = True
        OldIndex = 0
    End Sub

    Private Sub StructuresList_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles StructuresList.MeasureItem
        e.ItemHeight = 20
    End Sub

    Private Sub StructuresList_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles StructuresList.DrawItem
        If e.Index < 0 Then Exit Sub
        Dim IsSelected As Boolean = False
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then IsSelected = True
        e.Graphics.FillRectangle(Brushes.White, e.Bounds)
        Dim FinalText As String = Structures(e.Index)
        Dim TF As New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel)
        If IsSelected Then
            Dim x As New Drawing2D.LinearGradientBrush(New Rectangle(0, e.Bounds.X, e.Bounds.Width, 20), Color.FromArgb(64, 64, 64), Color.Black, LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(x, New Rectangle(0, e.Bounds.Y, e.Bounds.Width, 20))
            e.Graphics.DrawString(FinalText, TF, Brushes.White, 20, e.Bounds.Y + 3)
        Else
            e.Graphics.DrawString(FinalText, TF, Brushes.Black, 20, e.Bounds.Y + 3)
        End If
        e.Graphics.DrawImageUnscaled(My.Resources.StructureIcon, New Point(4, e.Bounds.Y + 4))
    End Sub

    Sub SetEnablity(ByVal Enabled As Boolean)
        MembersList.Enabled = Enabled
        NameTextBox.Enabled = Enabled
        AddMemberButton.Enabled = Enabled
        EditMemberButton.Enabled = Enabled
        DeleteMemberButton.Enabled = Enabled
    End Sub

    Private Sub AddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton.Click
        Dim ToUse As Int16 = 1
        For i = 1 To 1000
            If Not DoesXDSLineExist("STRUCT Structure_" + i.ToString) Then ToUse = i : Exit For
        Next
        Dim TheName As String = "Structure_" + ToUse.ToString
        XDSAddLine("STRUCT " + TheName)
        XDSAddLine("STRUCTMEMBER " + TheName + ",Item_1,Integer,0")
        Structures.Add(TheName)
        SaveOnChange = (StructuresList.SelectedIndices.Count = 1)
        StructuresList.Items.Add(TheName)
    End Sub

    Private Sub RemoveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveButton.Click
        If StructuresList.SelectedIndices.Count = 0 Then Exit Sub
        Dim CurrentName As String = Structures(OldIndex)
        Structures.RemoveAt(OldIndex)
        StructuresList.Items.RemoveAt(OldIndex)
        Names.Clear()
        Types.Clear()
        Values.Clear()
        MembersList.Items.Clear()
        NameTextBox.Text = String.Empty
        XDSRemoveLine("STRUCT " + CurrentName)
        XDSRemoveFilter("STRUCTMEMBER " + CurrentName + ",")
        Dim Message As String = "You have just deleted '" + CurrentName + "'." + vbcrlf + vbcrlf
        Message += "Be sure to update any logic that uses this Structure."
        MsgInfo(Message)
        SaveOnChange = False
        If StructuresList.Items.Count > 0 Then
            StructuresList.SelectedIndex = 0
        Else
            SetEnablity(False)
        End If
    End Sub

    Private Sub NameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NameTextBox.TextChanged
        If Structures.Count = 0 Then Exit Sub
        If ValidateSomething(NameTextBox.Text, ValidateLevel.Tight) Then
            NameTextBox.BackColor = Color.FromArgb(64, 64, 64)
            AllowChangeOrQuit = True
        Else
            NameTextBox.BackColor = Color.FromArgb(192, 0, 0)
            AllowChangeOrQuit = False
        End If
    End Sub

    Private Sub GlobalStructures_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not AllowChangeOrQuit Then e.Cancel = True : Exit Sub
        If Structures.Count = 0 Then Exit Sub
        Dim OldName As String = Structures(OldIndex)
        'Structures(OldIndex) = NameTextBox.Text
        'StructuresList.Items(OldIndex) = NameTextBox.Text
        XDSChangeLine("STRUCT " + OldName, "STRUCT " + NameTextBox.Text)
        XDSRemoveFilter("STRUCTMEMBER " + OldName + ",")
        If Names.Count > 0 Then
            For P As Byte = 0 To Names.Count - 1
                Dim FS As String = "STRUCTMEMBER " + NameTextBox.Text + ","
                FS += Names(P) + ","
                FS += Types(P) + ","
                FS += Values(P).Replace(",", "<comma>")
                XDSAddLine(FS)
            Next
        End If
      
    End Sub

    Private Sub StructuresList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StructuresList.SelectedIndexChanged
        If Structures.Count = 0 Then Exit Sub
        If Not AllowChangeOrQuit Then Exit Sub
        Dim Position As Int16 = StructuresList.SelectedIndex
        Try
            Dim X As String = Structures(Position)
        Catch : Exit Sub : End Try
        If SaveOnChange Then
            Dim OldName As String = Structures(OldIndex)
            Structures(OldIndex) = NameTextBox.Text
            StructuresList.Items(OldIndex) = NameTextBox.Text
            XDSChangeLine("STRUCT " + OldName, "STRUCT " + NameTextBox.Text)
            XDSRemoveFilter("STRUCTMEMBER " + OldName + ",")
            If Names.Count > 0 Then
                For P As Byte = 0 To Names.Count - 1
                    Dim FS As String = "STRUCTMEMBER " + NameTextBox.Text + ","
                    FS += Names(P) + ","
                    FS += Types(P) + ","
                    FS += Values(P).Replace(",", "<comma>")
                    XDSAddLine(FS)
                Next
            End If
            'For Each X As String In GetXDSFilter("STRUCTMEMBER " + OldName + ",")
            '    Dim Tach As String = X.Substring(("STRUCTMEMBER ").Length + OldName.Length)
            '    XDSChangeLine(X, "STRUCTMEMBER " + NameTextBox.Text + Tach)
            'Next
        End If
        Dim CurrentName As String = Structures(Position)
        Names.Clear()
        Types.Clear()
        Values.Clear()
        MembersList.Items.Clear()
        For Each P As String In GetXDSFilter("STRUCTMEMBER " + CurrentName + ",")
            P = P.Substring(("STRUCTMEMBER " + CurrentName).Length + 1)
            Dim Name As String = P.Substring(0, P.IndexOf(","))
            Names.Add(Name)
            Dim Type As String = P.Substring(Name.Length + 1)
            Type = Type.Substring(0, Type.IndexOf(","))
            Types.Add(Type)
            Dim Value As String = P.Substring(P.LastIndexOf(",") + 1).Replace("<comma>", ",")
            Values.Add(Value)
            MembersList.Items.Add(String.Empty)
        Next
        NameTextBox.Text = CurrentName
        SetEnablity(True)
        NameTextBox.Focus()
        NameTextBox.SelectionStart = NameTextBox.Text.Length
        NameTextBox.SelectionLength = 0
        OldIndex = StructuresList.SelectedIndex
    End Sub

    Private Sub AddMemberButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMemberButton.Click
        Dim ToUse As Int16 = 1
        For i = 1 To 1000
            If Not Names.Contains("Item_" + i.ToString) Then ToUse = i : Exit For
        Next
        Dim TheName As String = "Item_" + ToUse.ToString
        'XDSAddLine("STRUCTMEMBER " + CurrentName + "," + TheName + ",Item_1,Integer,0")
        Names.Add(TheName)
        Types.Add("Integer")
        Values.Add("0")
        MembersList.Items.Add(String.Empty)
    End Sub

    Private Sub EditMemberButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMemberButton.Click
        If MembersList.SelectedIndices.Count = 0 Then Exit Sub
        Dim ID As Byte = MembersList.SelectedIndex
        With StructureItem
            .MemberName = Names(ID)
            .MemberType = Types(ID)
            .MemberValue = Values(ID)
            .ShowDialog()
            If Not .UseData Then Exit Sub
            Names(ID) = .MemberName
            Types(ID) = .MemberType
            Values(ID) = .MemberValue
        End With
        MembersList.Refresh()
    End Sub

    Private Sub DeleteMemberButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMemberButton.Click
        If MembersList.SelectedIndices.Count = 0 Then Exit Sub
        Dim TI As Byte = MembersList.SelectedIndex
        Names.RemoveAt(TI)
        Types.RemoveAt(TI)
        Values.RemoveAt(TI)
        MembersList.Items.RemoveAt(TI)
    End Sub

    Private Sub MembersList_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles MembersList.MeasureItem
        e.ItemHeight = 16
    End Sub

    Private Sub MembersList_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MembersList.DrawItem
        If e.Index < 0 Then Exit Sub
        Dim IsSelected As Boolean = False
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then IsSelected = True
        e.Graphics.FillRectangle(Brushes.White, e.Bounds)
        Dim TheName As String = Names(e.Index)
        Dim TheType As String = Types(e.Index)
        Dim TheValue As String = Values(e.Index)
        Dim TF As New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel)
        If IsSelected Then
            Dim x As New Drawing2D.LinearGradientBrush(New Rectangle(0, e.Bounds.X, e.Bounds.Width, 16), Color.FromArgb(64, 64, 64), Color.Black, LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(x, e.Bounds)
            e.Graphics.DrawString(TheName, TF, Brushes.White, 16, e.Bounds.Y + 1)
            e.Graphics.DrawString(TheType, TF, Brushes.LightGray, 66, e.Bounds.Y + 1)
            e.Graphics.DrawString(TheValue, TF, Brushes.LightGray, 138, e.Bounds.Y + 1)
        Else
            e.Graphics.DrawString(TheName, TF, Brushes.DarkGray, 16, e.Bounds.Y + 1)
            e.Graphics.DrawString(TheType, TF, Brushes.DarkGray, 66, e.Bounds.Y + 1)
            e.Graphics.DrawString(TheValue, TF, Brushes.DarkGray, 138, e.Bounds.Y + 1)
        End If
        e.Graphics.DrawImageUnscaled(My.Resources.ArgumentIcon, New Point(0, e.Bounds.Y))
    End Sub

End Class