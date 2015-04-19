Imports System.IO
Imports System.Media

Public Class Sound

    Public SoundName As String
    Dim SoundType As Boolean
    Dim XDSLine As String
    Dim OldPath As String
    Dim NewPath As String
    Dim SoundTypeString As String
    Dim P As New SoundPlayer
    Dim Proc As Process
    Dim SProc As ProcessStartInfo

    Private Sub Sound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainToolStrip.Renderer = New clsToolstripRenderer
        Me.Text = SoundName
        NameTextBox.Text = SoundName
        XDSLine = GetXDSLine("SOUND " + SoundName + ",")
        If iGet(XDSLine, 1, ",") = "1" Then SoundType = True Else SoundType = False
        SoundTypeString = "." + If(SoundType, "mp3", "wav")
        OldPath = SessionPath + "Sounds\" + SoundName + SoundTypeString
        NewPath = OldPath
        InfoLabel.Text = If(SoundType, "Background Sound", "Sound Effect")
        If Not SoundType Then
            P.SoundLocation = NewPath
        Else
            Proc = New Process
            SProc = New ProcessStartInfo("wmplayer", """" + NewPath + """")
            Proc.StartInfo = SProc
        End If
    End Sub

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        Dim NewName As String = NameTextBox.Text
        If Not NewName = SoundName Then
            If GUIResNameChecker(NewName) Then Exit Sub
        End If
        If Not SoundType Then P.Stop()
        Try
            Proc.Dispose()
        Catch : End Try
        P.Dispose()
        If Not NewName = SoundName Then
            Dim NewLine As String = "SOUND " + NewName + "," + If(SoundType, "1", "0")
            XDSChangeLine(XDSLine, NewLine)
        End If
        If Not OldPath = NewPath Then
            File.Delete(OldPath)
            File.Copy(NewPath, OldPath)
        End If
        Dim SoundTypeString As String = "." + If(SoundType, "mp3", "wav")
        If Not NewName = SoundName Then
            File.Move(SessionPath + "Sounds\" + SoundName + SoundTypeString, SessionPath + "Sounds\" + NewName + SoundTypeString)
            If SoundType Then
                If File.Exists(CompilePath + "nitrofiles\" + SoundName + ".mp3") Then
                    File.Move(CompilePath + "nitrofiles\" + SoundName + ".mp3", CompilePath + "nitrofiles\" + NewName + ".mp3")
                End If
            Else
                If File.Exists(CompilePath + "data\" + SoundName + ".raw") Then
                    File.Move(CompilePath + "data\" + SoundName + ".raw", CompilePath + "nitrofiles\" + NewName + ".raw")
                End If
            End If
            If SoundsToRedo.Contains(SoundName) Then
                SoundsToRedo.Remove(SoundName)
                SoundsToRedo.Add(NewName)
            End If
        End If
        For Each X As TreeNode In MainForm.ResourcesTreeView.Nodes(ResourceIDs.Sound).Nodes
            If X.Text = SoundName Then X.Text = NewName
        Next
        Me.Close()
    End Sub

    Private Sub LoadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadButton.Click
        Dim Filter As String = If(SoundType, "MP3", "WAV") + " Files|*." + If(SoundType, "mp3", "wav")
        Dim Result As String = OpenFile(String.Empty, Filter)
        If Result.Length = 0 Then Exit Sub
        NewPath = Result
        If Not SoundType Then P.SoundLocation = Result
        AddSoundToRedo(SoundName)
        If SoundType Then
            SProc.Arguments = """" + NewPath + """"
        End If
    End Sub

    Private Sub EditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditButton.Click
        Dim FinalEXE As String = GetSetting("SOUND_EDITOR_PATH")
        If FinalEXE.Length = 0 Then
            MsgWarn("No Sound Editor has been defined. See 'Options'.")
            Exit Sub
        End If
        If Not File.Exists(FinalEXE) Then
            MsgWarn("Your Sound Editor EXE is not present. See 'Options'.")
            Exit Sub
        End If
        Dim ThePath As String = SessionPath + "Sounds\" + SoundName + SoundTypeString
        Dim CopyPath As String = SessionPath + "Sounds\" + SoundName + "_Copy" + SoundTypeString
        Try
            If File.Exists(CopyPath) Then File.Delete(CopyPath)
            File.Copy(ThePath, CopyPath)
        Catch ex As Exception
            MsgError("This sound cannot be edited because its file is locked." + vbcrlf + vbcrlf + "(" + ex.Message + ")")
            Exit Sub
        End Try
        If Not EditSound(CopyPath, SoundName) Then
            IO.File.Delete(CopyPath)
            Exit Sub
        End If
        IO.File.Delete(ThePath)
        IO.File.Move(CopyPath, ThePath)
        AddSoundToRedo(SoundName)
    End Sub

    Private Sub PlayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayButton.Click
        If Not SoundType Then
            P.Play()
        Else
            Proc.Start()
        End If
    End Sub

    Private Sub StopButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopButton.Click
        If Not SoundType Then
            P.Stop()
        Else
            Try
                Proc.Kill()
            Catch : End Try
        End If
    End Sub

End Class