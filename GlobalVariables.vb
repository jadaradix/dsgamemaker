Imports System.Drawing.Drawing2D

Public Class GlobalVariables

    Dim Variables As New List(Of String)
    Dim MyVariableTypes As New List(Of String)
    Dim VariableValues As New List(Of String)
    Dim CurrentName As String = String.Empty
    Dim AllowClose As Boolean = True

    Private Sub Globals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetEnablity(False)
        TypeList.Items.Clear()
        For Each X As String In VariableTypes
            TypeList.Items.Add(X)
        Next
        For Each P As String In GetXDSFilter("STRUCT ")
            TypeList.Items.Add(P.Substring(7))
        Next
        Variables.Clear()
        MyVariableTypes.Clear()
        VariableValues.Clear()
        For Each X As String In GetXDSFilter("GLOBAL ")
            X = X.Substring(7)
            Variables.Add(iGet(X, 0, ","))
            MyVariableTypes.Add(iGet(X, 1, ","))
            VariableValues.Add(iGet(X, 2, ","))
        Next
        VariablesList.Items.Clear()
        If Variables.Count > 0 Then
            For i As Int16 = 0 To Variables.Count - 1
                VariablesList.Items.Add(Variables(i))
            Next
        End If
        NameTextBox.BackColor = Color.FromArgb(64, 64, 64)
        ValueTextBox.Text = String.Empty
        If VariablesList.Items.Count > 0 Then VariablesList.SelectedIndex = 0
        AllowClose = True
    End Sub

    Private Sub RemoveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveButton.Click
        If CurrentName.Length = 0 Then Exit Sub
        Dim DOn As Int16 = 0
        For i As Int16 = 0 To VariablesList.Items.Count - 1
            If VariablesList.Items(i) = CurrentName Then DOn = i : Exit For
        Next
        'For Each X As String In VariablesList.Items
        '    If X = CurrentName Then Exit For
        '    DOn += 1
        'Next
        VariablesList.Items.RemoveAt(DOn)
        Variables.RemoveAt(DOn)
        MyVariableTypes.RemoveAt(DOn)
        VariableValues.RemoveAt(DOn)
        NameTextBox.Text = String.Empty
        ValueTextBox.Text = String.Empty
        Dim Message As String = "You have just deleted '" + CurrentName + "'." + vbcrlf + vbcrlf
        If VariablesList.Items.Count > 0 Then
            VariablesList.SelectedIndex = 0
        Else
            SetEnablity(False)
        End If
        Message += "Be sure to update any logic that uses this Variable."
        MsgInfo(Message)
        CurrentName = String.Empty
    End Sub

    Private Sub AddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton.Click
        Dim ToUse As Int16 = 1
        For i = 1 To 100
            If Not Variables.Contains("Variable_" + i.ToString) Then ToUse = i : Exit For
        Next
        Variables.Add("Variable_" + ToUse.ToString)
        MyVariableTypes.Add("Integer")
        VariableValues.Add("0")
        VariablesList.Items.Add("Variable_" + ToUse.ToString)
        VariablesList.SelectedIndex = VariablesList.Items.Count - 1
    End Sub

    Private Sub VariablesList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VariablesList.SelectedIndexChanged
        If Variables.Count = 0 Then Exit Sub
        Dim Position As Int16 = VariablesList.SelectedIndex
        Try
            Dim X As String = MyVariableTypes(Position)
        Catch : Exit Sub : End Try
        TypeList.Text = MyVariableTypes(Position)
        ValueTextBox.Text = VariableValues(Position)
        CurrentName = Variables(Position)
        NameTextBox.Text = CurrentName
        SetEnablity(True)
        NameTextBox.Focus()
        NameTextBox.SelectionStart = NameTextBox.Text.Length
        NameTextBox.SelectionLength = 0
    End Sub

    Private Sub TypeList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TypeList.SelectedIndexChanged
        If Variables.Count = 0 Then Exit Sub
        Dim Returnable As String = "<No description>"
        TypeTitleLabel.Text = TypeList.Text
        Select Case TypeList.Text
            Case "Integer"
                Returnable = "An integer is a numerical value that does not have a decimal point."
            Case "Boolean"
                Returnable = "A boolean holds one of two values: true or false."
            Case "Signed Byte"
                Returnable = "A numerical value ranging from -127 to 127."
            Case "Unsigned Byte"
                Returnable = "A numerical value ranging from 0 to 255."
            Case "Float"
                Returnable = "A float is a numerical value which may possess a decimal point."
            Case "String"
                Returnable = "A word or phrase; a linear sequence of symbols (characters)."
        End Select
        TypeDescriptionLabel.Text = Returnable
        MyVariableTypes(VariablesList.SelectedIndex) = TypeList.Text
    End Sub

    Sub SetEnablity(ByVal Enabled As Boolean)
        TypeList.Enabled = Enabled
        ValueTextBox.Enabled = Enabled
        NameTextBox.Enabled = Enabled
        TypeTitleLabel.Enabled = Enabled
        TypeDescriptionLabel.Enabled = Enabled
    End Sub

    Private Sub NameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NameTextBox.TextChanged
        If Variables.Count = 0 Then Exit Sub
        If ValidateSomething(NameTextBox.Text, ValidateLevel.Tight) Then
            NameTextBox.BackColor = Color.FromArgb(64, 64, 64)
            Variables(VariablesList.SelectedIndex) = NameTextBox.Text
            VariablesList.Items(VariablesList.SelectedIndex) = NameTextBox.Text
            AllowClose = True
        Else
            NameTextBox.BackColor = Color.FromArgb(192, 0, 0)
            AllowClose = False
        End If
    End Sub

    Private Sub ValueTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValueTextBox.TextChanged
        If Variables.Count = 0 Then Exit Sub
        Try
            VariableValues(VariablesList.SelectedIndex) = ValueTextBox.Text
        Catch : End Try
    End Sub

    Private Sub VariablesList_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles VariablesList.MeasureItem
        e.ItemHeight = 20
    End Sub

    Private Sub VariablesList_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles VariablesList.DrawItem
        If e.Index < 0 Then Exit Sub
        Dim IsSelected As Boolean = False
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then IsSelected = True
        e.Graphics.FillRectangle(Brushes.White, e.Bounds)
        Dim FinalText As String = Variables(e.Index)
        Dim TF As New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel)
        If IsSelected Then
            Dim x As New Drawing2D.LinearGradientBrush(New Rectangle(0, e.Bounds.X, e.Bounds.Width, 20), Color.FromArgb(64, 64, 64), Color.Black, LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(x, New Rectangle(0, e.Bounds.Y, e.Bounds.Width, 20))
            e.Graphics.DrawString(FinalText, TF, Brushes.White, 20, e.Bounds.Y + 3)
        Else
            e.Graphics.DrawString(FinalText, TF, Brushes.Black, 20, e.Bounds.Y + 3)
        End If
        e.Graphics.DrawImageUnscaled(My.Resources.VariableIcon, New Point(4, e.Bounds.Y + 4))
    End Sub

    Private Sub TypeList_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles TypeList.MeasureItem
        e.ItemHeight = 16
    End Sub

    Private Sub TypeList_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TypeList.DrawItem
        If e.Index < 0 Then Exit Sub
        Dim IsSelected As Boolean = False
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then IsSelected = True
        e.Graphics.FillRectangle(Brushes.White, e.Bounds)
        Dim FinalText As String = TypeList.Items(e.Index)
        If IsSelected Then
            Dim x As New Drawing2D.LinearGradientBrush(New Rectangle(0, e.Bounds.X, e.Bounds.Width, e.Bounds.Height), Color.FromArgb(192, 192, 192), Color.FromArgb(80, 80, 80), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(x, New Rectangle(0, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
            e.Graphics.DrawString(FinalText, New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.White, 3, e.Bounds.Y + 1)
        Else
            e.Graphics.DrawString(FinalText, New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, 3, e.Bounds.Y + 1)
        End If
    End Sub

    Private Sub GlobalVariables_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not AllowClose Then e.Cancel = True : Exit Sub
        XDSRemoveFilter("GLOBAL ")
        For i As Int16 = 0 To Variables.Count - 1
            Dim NewLine As String = "GLOBAL " + Variables(i) + ","
            NewLine += MyVariableTypes(i) + ","
            NewLine += VariableValues(i)
            XDSAddLine(NewLine)
        Next
    End Sub
End Class