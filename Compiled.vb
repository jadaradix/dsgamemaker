Imports System.IO

Public Class Compiled

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub OpenCompileFolderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenCompileFolderButton.Click
        System.Diagnostics.Process.Start("explorer", CompilePath)
    End Sub

    Private Sub PlayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayButton.Click
        NOGBAShizzle()
    End Sub

    Private Sub SaveNDSFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveNDSFileButton.Click
        Dim Response As String = SaveFile(String.Empty, "NDS Binaries|*.nds", CacheProjectName + ".nds")
        If Response.Length = 0 Then Exit Sub
        IO.File.Copy(CompilePath + CompileName + ".nds", Response, True)
    End Sub

    Private Sub SavetoKitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavetoKitButton.Click
        Dim HBKitDrive As String = String.Empty
        For Each X As String In Directory.GetLogicalDrives()
            If File.Exists(X + "_DS_MENU.DAT") Or File.Exists(X + "Redant.DAT") Then HBKitDrive = X : Exit For
        Next
        If HBKitDrive.Length = 0 Then
            MsgWarn("There is no USB Reader for a DS Homebrew Kit connected.")
            Exit Sub
        End If
        IO.File.Copy(CompilePath + CompileName + ".nds", HBKitDrive + CacheProjectName + ".nds", True)
        Dim Response As Byte = MessageBox.Show("'" + CacheProjectName + "' was copied successfully." + vbCrLf + vbCrLf + "Safely disconnect USB Reader now?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Not Response = MsgBoxResult.Yes Then Exit Sub
        RunBatchString("EjectMedia " + HBKitDrive + vbCrLf + "RemoveDrive " + HBKitDrive, AppPath, False)
    End Sub
End Class