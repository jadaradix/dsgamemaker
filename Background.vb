Imports System.IO

Public Class Background

    Public BackgroundName As String
    Dim RealPath As String
    Dim TempPath As String
    Dim ImageChanged As Boolean

    Private Sub Background_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainToolStrip.Renderer = New clsToolstripRenderer
        NameTextBox.Text = BackgroundName
        Text = BackgroundName
        RealPath = SessionPath + "Backgrounds\" + BackgroundName + ".png"
        TempPath = SessionPath + "Backgrounds\" + BackgroundName + "_Copy.png"
        File.Delete(TempPath)
        File.Copy(RealPath, TempPath)
        ImageChanged = False
        MakePreview()
        'Me.Width = 300
        'Me.Height = 300
        'Dim BGWidth As Int16 = PreviewPanel.BackgroundImage.Width
        'Dim BGHeight As Int16 = PreviewPanel.BackgroundImage.Height
        'Me.Width = 24 + BGWidth
        'Me.Height = 100 + BGHeight
    End Sub

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        Dim NewName As String = NameTextBox.Text
        If Not BackgroundName = NewName Then
            If GUIResNameChecker(NewName) Then Exit Sub
        End If
        File.Delete(RealPath)
        File.Move(TempPath, RealPath)
        If Not NewName = BackgroundName Then
            XDSChangeLine("BACKGROUND " + BackgroundName, "BACKGROUND " + NewName)
            SilentMoveFile(RealPath, SessionPath + "Backgrounds\" + NewName + ".png")
            'File.Move(RealPath, SessionPath + "Backgrounds\" + NewName + ".png")
            For Each X As Form In MainForm.MdiChildren
                If X.Name = "Room" Then
                    Dim DForm As Room = DirectCast(X, Room)
                    DForm.RenameBackground(BackgroundName, NewName)
                ElseIf X.Name = "DObject" Then
                    Dim DForm As DObject = DirectCast(X, DObject)
                    DForm.MyXDSLines = UpdateActionsName(DForm.MyXDSLines, "Background", BackgroundName, NewName, False)
                End If
            Next
            If BGsToRedo.Contains(BackgroundName) Then
                Dim P As Byte = 0
                For Each D As String In BGsToRedo
                    If D = BackgroundName Then Exit For
                    P += 1
                Next
                BGsToRedo.Item(P) = NewName
            End If
            UpdateArrayActionsName("Background", BackgroundName, NewName, False)
            CurrentXDS = UpdateActionsName(CurrentXDS, "Background", BackgroundName, NewName, False)
            For Each X As String In GetXDSFilter("ROOM ")
                Dim Backup As String = X
                X = X.Substring(5)
                Dim TopChange As Boolean = False
                Dim BottomChange As Boolean = False
                If iGet(X, 4, ",") = BackgroundName Then TopChange = True
                If iGet(X, 8, ",") = BackgroundName Then BottomChange = True
                If TopChange And BottomChange Then
                    Dim NewLine As String = "ROOM "
                    For I As Byte = 0 To 3
                        NewLine += iGet(X, I, ",") + ","
                    Next
                    NewLine += NewName + ","
                    For I As Byte = 5 To 7
                        NewLine += iGet(X, I, ",") + ","
                    Next
                    NewLine += NewName
                    XDSChangeLine(Backup, NewLine)
                Else
                    If TopChange Then
                        Dim NewLine As String = "ROOM "
                        For I As Byte = 0 To 3
                            NewLine += iGet(X, I, ",") + ","
                        Next
                        NewLine += NewName + ","
                        For I As Byte = 5 To 8
                            NewLine += iGet(X, I, ",") + ","
                        Next
                        NewLine = NewLine.Substring(0, NewLine.Length - 1)
                        XDSChangeLine(Backup, NewLine)
                    End If
                    If BottomChange Then
                        Dim NewLine As String = "ROOM "
                        For I As Byte = 0 To 7
                            NewLine += iGet(X, I, ",") + ","
                        Next
                        NewLine += NewName
                        XDSChangeLine(Backup, NewLine)
                    End If
                End If
            Next
        End If
        If ImageChanged Then
            If BGsToRedo.Contains(BackgroundName) Then BGsToRedo.Remove(BackgroundName)
            BGsToRedo.Add(NewName)
            For Each X As Form In MainForm.MdiChildren
                If Not X.Name = "Room" Then Continue For
                If DirectCast(X, Room).TopBG = NewName Then
                    DirectCast(X, Room).RefreshRoom(True)
                End If
                If DirectCast(X, Room).BottomBG = NewName Then
                    DirectCast(X, Room).RefreshRoom(False)
                End If
            Next
            'Remove the old files (no use!!!!!)
            File.Delete(CompilePath + "gfx\" + BackgroundName + ".png")
            If Directory.Exists(CompilePath + "gfx\bin") Then
                File.Delete(CompilePath + "gfx\bin\" + BackgroundName + ".c")
                File.Delete(CompilePath + "gfx\bin\" + BackgroundName + "_Tiles.bin")
                File.Delete(CompilePath + "gfx\bin\" + BackgroundName + "_Map.bin")
                File.Delete(CompilePath + "gfx\bin\" + BackgroundName + "_Pal.bin")
            End If
        End If
        If Not BackgroundName = NewName Then
            If File.Exists(CompilePath + "gfx\bin\" + BackgroundName + ".c") Then
                Dim BackupDate As Date = File.GetLastWriteTime(CompilePath + "gfx\bin\" + BackgroundName + ".c")
                'SilentMoveFile(CompilePath + "gfx\bin\" + BackgroundName + ".c", CompilePath + "gfx\bin\" + NewName + ".c")
                File.Move(CompilePath + "gfx\bin\" + BackgroundName + ".c", CompilePath + "gfx\bin\" + NewName + ".c")
                Dim ToWrite As String = String.Empty
                Dim ToPaste As String = String.Empty
                For Each X As String In StringToLines(PathToString(CompilePath + "gfx\bin\" + NewName + ".c"))
                    ToPaste = X
                    Select Case X
                        Case "extern const char " + BackgroundName + "_Tiles[];"
                            ToPaste = "extern const char " + NewName + "_Tiles[];"
                        Case "extern const char " + BackgroundName + "_Map[];"
                            ToPaste = "extern const char " + NewName + "_Map[];"
                        Case "extern const char " + BackgroundName + "_Pal[];"
                            ToPaste = "extern const char " + NewName + "_Pal[];"
                        Case "const PA_BgStruct " + BackgroundName + " = {"
                            ToPaste = "const PA_BgStruct " + NewName + " = {"
                        Case "	" + BackgroundName + "_Tiles,"
                            ToPaste = "	" + NewName + "_Tiles,"
                        Case "	" + BackgroundName + "_Map,"
                            ToPaste = "	" + NewName + "_Map,"
                        Case "	{" + BackgroundName + "_Pal},"
                            ToPaste = "	{" + NewName + "_Pal},"
                    End Select
                    ToWrite += ToPaste + vbCrLf
                Next
                File.WriteAllText(CompilePath + "gfx\bin\" + NewName + ".c", ToWrite)
                File.SetLastWriteTime(CompilePath + "gfx\bin\" + NewName + ".c", BackupDate)
            End If
            If File.Exists(CompilePath + "gfx\bin\" + BackgroundName + "_Map.bin") Then
                SilentMoveFile(CompilePath + "gfx\bin\" + BackgroundName + "_Map.bin", CompilePath + "gfx\bin\" + NewName + "_Map.bin")
            End If
            If File.Exists(CompilePath + "gfx\bin\" + BackgroundName + "_Tiles.bin") Then
                SilentMoveFile(CompilePath + "gfx\bin\" + BackgroundName + "_Tiles.bin", CompilePath + "gfx\bin\" + NewName + "_Tiles.bin")
            End If
            If File.Exists(CompilePath + "gfx\bin\" + BackgroundName + "_Pal.bin") Then
                SilentMoveFile(CompilePath + "gfx\bin\" + BackgroundName + "_Pal.bin", CompilePath + "gfx\bin\" + NewName + "_Pal.bin")
            End If
            If File.Exists(CompilePath + "gfx\" + BackgroundName + ".png") Then
                SilentMoveFile(CompilePath + "gfx\" + BackgroundName + ".png", CompilePath + "gfx\" + NewName + ".png")
            End If
            Dim NewString As String = String.Empty
            For Each X As String In StringToLines(PathToString(CompilePath + "gfx\dsgm_gfx.h"))
                If X = "extern const PA_BgStruct " + BackgroundName + ";" Then X = "extern const PA_BgStruct " + NewName + ";"
                NewString += X + vbCrLf
            Next
            File.WriteAllText(CompilePath + "gfx\temp_gfx.h", NewString)
            File.Delete(CompilePath + "gfx\dsgm_gfx.h")
            SilentMoveFile(CompilePath + "gfx\temp_gfx.h", CompilePath + "gfx\dsgm_gfx.h")
        End If
        For Each X As TreeNode In MainForm.ResourcesTreeView.Nodes(ResourceIDs.Background).Nodes
            If X.Text = BackgroundName Then X.Text = NewName
        Next
        Me.Close()
    End Sub

    Sub MakePreview()
        PreviewPanel.BackgroundImage = PathToImage(TempPath)
    End Sub

    Private Sub LoadfromFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadfromFileButton.Click
        Dim Result As String = OpenFile(String.Empty, ImageFilter)
        If Result.Length = 0 Then Exit Sub
        Dim NewSize As Size = PathToImage(Result).Size
        If Not NewSize.Width Mod 256 = 0 Then
            MsgError("The width of the Background must be a multiple of 256 pixels.")
            Exit Sub
        End If
        If Not NewSize.Height Mod 256 = 0 And Not NewSize.Height = 192 Then
            MsgError("The height of the Background must be either 192 pixels high or a multiple of 256 pixels.")
            Exit Sub
        End If
        File.Delete(TempPath)
        File.Copy(Result, TempPath, True)
        ImageChanged = True
        MakePreview()
    End Sub

    Private Sub EditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditButton.Click
        If Not EditImage(TempPath, BackgroundName, False) Then Exit Sub
        ImageChanged = True
        MakePreview()
    End Sub
End Class