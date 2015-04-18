Public Class EditCode

    Public ReturnableCode As String = String.Empty
    Public CodeMode As Byte = 0
    Public ImportExport As Boolean = False

    Private Sub EditCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainToolStrip.Renderer = New clsToolstripRenderer
        LoadInButton.Enabled = ImportExport
        SaveOutButton.Enabled = ImportExport
        Dim NewCode As String = ReturnableCode
        NewCode = NewCode.Replace("<br|>", vbcrlf).Replace("<com>", ",").Replace("<sem>", ";")
        MainTextBox.Text = NewCode
        UpdateLineStats()
    End Sub

    Sub UpdateLineStats()
        InfoLabel.Text = "Ln " + MainTextBox.Caret.LineNumber.ToString + " : "
        InfoLabel.Text += MainTextBox.Lines.Count.ToString + "   Col " + MainTextBox.GetColumn(MainTextBox.CurrentPos).ToString
        InfoLabel.Text += "   Sel " + MainTextBox.Selection.Start.ToString
    End Sub

    Private Sub MainTextBox_KeyDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainTextBox.KeyDown, MainTextBox.MouseClick, MainTextBox.TextChanged
        UpdateLineStats()
    End Sub

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        WindowState = FormWindowState.Normal
        ReturnableCode = MainTextBox.Text.Replace(vbCrLf, "<br|>").Replace(",", "<com>").Replace(";", "<sem>")
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub UndoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoButton.Click
        If MainTextBox.UndoRedo.CanUndo Then MainTextBox.UndoRedo.Undo()
    End Sub

    Private Sub RedoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoButton.Click
        If MainTextBox.UndoRedo.CanRedo Then MainTextBox.UndoRedo.Redo()
    End Sub

    Private Sub LoadInButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadInButton.Click
        Dim MsgResponse As Byte = MessageBox.Show("Importing a Script will erase and replace the current code." + vbcrlf + vbcrlf + "Would you like to Continue?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Not MsgResponse = MsgBoxResult.Yes Then Exit Sub
        Dim Response As String = OpenFile(String.Empty, "Dynamic Basic Files|*.dbas")
        If Response.Length = 0 Then Exit Sub
        Dim Content As String = PathToString(Response)
        Dim FinalContent As String = String.Empty
        For Each X As String In StringToLines(Content)
            If X.StartsWith("SCRIPTARG ") Then Continue For
            FinalContent += X
        Next
        'If FinalContent.Length > 0 Then FinalContent = FinalContent.Substring(0, FinalContent.Length - 1)
        MainTextBox.Text = FinalContent
    End Sub

    Private Sub SaveOutButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveOutButton.Click
        Dim Response As String = SaveFile(String.Empty, "Dynamic Basic Files|*.dbas", "Expoted Code.dbas")
        If Response.Length = 0 Then Exit Sub
        Dim ToWrite As String = MainTextBox.Text
        'If ToWrite.Length > 0 Then ToWrite = ToWrite.Substring(0, ToWrite.Length - 1)
        IO.File.WriteAllText(Response, ToWrite)
    End Sub

    Private Sub MainTextBox_CharAdded(ByVal sender As System.Object, ByVal e As ScintillaNet.CharAddedEventArgs) Handles MainTextBox.CharAdded
        If Not e.Ch = ChrW(Keys.Return) Then Exit Sub
        IntelliSense(sender)
    End Sub

End Class