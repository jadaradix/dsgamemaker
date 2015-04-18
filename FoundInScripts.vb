Imports System.IO
Public Class FoundInScripts

    Public ScriptNames As New List(Of String)
    Public ScriptLines As New List(Of Int16)
    Public ScriptPositions As New List(Of Int16)
    Public Term As String = String.Empty

    Private Sub FoundInScripts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainToolStrip.Renderer = New clsToolstripRenderer
        If Term.Length = 0 Then Exit Sub
        FindInScriptsDoIt()
    End Sub

    Sub FindInScriptsDoIt()
        Dim TermLength As Int16 = Term.Length
        MainListBox.Items.Clear()
        ScriptNames.Clear()
        ScriptLines.Clear()
        ScriptPositions.Clear()
        Dim DOn As Int16 = 0
        For Each X As String In GetXDSFilter("SCRIPT ")
            DOn = 0
            Dim ScriptName As String = X.Substring(7)
            ScriptName = ScriptName.Substring(0, ScriptName.LastIndexOf(","))
            For Each ThisLine As String In StringToLines(PathToString(SessionPath + "Scripts\" + ScriptName + ".dbas"))
                Dim FullLength As Int16 = ThisLine.Length
                'MsgError("Line: " + ThisLine + vbcrlf + vbcrlf + "Length: " + FullLength.ToString)
                If TermLength > FullLength Then DOn += 1 : Continue For
                If ThisLine = Term Then
                    ScriptNames.Add(ScriptName)
                    ScriptLines.Add(DOn + 1)
                    ScriptPositions.Add(0)
                    DOn += 1
                    'MsgError("Term equal to line length")
                    Continue For
                End If
                'MsgError("Loop from 0 to " + (FullLength - TermLength).ToString)
                For i As Int16 = 0 To FullLength - TermLength
                    'MsgError(i.ToString + ": Observing: " + ThisLine.Substring(i))
                    If ThisLine.Substring(i).StartsWith(Term) Then
                        MsgError(i.ToString + " - '" + ThisLine.Substring(i) + "' starts with '" + Term + "' so I'm addin' it")
                        ScriptNames.Add(ScriptName)
                        ScriptLines.Add(DOn + 1)
                        ScriptPositions.Add(i)
                        'MsgError("Added line " + (DOn + 1).ToString)
                        'MsgError("Added pos " + i.ToString)
                    End If
                Next
                DOn += 1
            Next
        Next
        For i As Int16 = 0 To ScriptNames.Count - 1
            MainListBox.Items.Add(ScriptNames(i))
        Next
    End Sub

    Private Sub RefreshButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshButton.Click
        FindInScriptsDoIt()
    End Sub

    Private Sub MainListBox_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles MainListBox.MeasureItem
        e.ItemHeight = 22
    End Sub

    Private Sub MainListBox_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MainListBox.DrawItem
        Dim i As Int16 = e.Index
        If e.Index < 0 Then Exit Sub
        Dim IsSelected As Boolean = False
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then IsSelected = True
        e.Graphics.FillRectangle(Brushes.White, New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
        If IsSelected Then e.Graphics.DrawImage(My.Resources.BarBG, New Rectangle(0, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
        e.Graphics.DrawImageUnscaled(My.Resources.ScriptIcon, New Point(e.Bounds.X + 4, e.Bounds.Y + 3))
        e.Graphics.DrawString(ScriptNames(i) + ": Line " + ScriptLines(i).ToString + ", Pos: " + ScriptPositions(i).ToString, New Font("Tahoma", 8), Brushes.Black, e.Bounds.X + 21, e.Bounds.Y + 4)
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub MainListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainListBox.SelectedIndexChanged
        Dim ScriptName As String = ScriptNames(MainListBox.SelectedIndex)
        Dim HasDone As Boolean = False
        For Each X As Form In MainForm.MdiChildren
            If X.Name = "Script" And X.Text = ScriptName Then
                DirectCast(X, Script).GoToLine(ScriptLines(MainListBox.SelectedIndex) - 1, ScriptPositions(MainListBox.SelectedIndex), Term.Length)
                X.BringToFront()
                HasDone = True
            End If
        Next
        If Not HasDone Then
            Dim P As New Script
            P.ScriptName = ScriptName
            ShowInternalForm(P)
            P.GoToLine(ScriptLines(MainListBox.SelectedIndex) - 1, ScriptPositions(MainListBox.SelectedIndex), Term.Length)
        End If
    End Sub
End Class