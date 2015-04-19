Imports System.IO

Module Toolchain

    Public Function IsInstallerRunning() As Boolean
        Dim EXECount As Byte = 0
        Dim ProcessesList() As Process = Process.GetProcesses()
        For Each TheProcess As Process In ProcessesList
            If TheProcess.ProcessName.StartsWith("devkitProUpdater") Then EXECount += 1
        Next
        If EXECount > 0 Then Return True Else Return False
    End Function

    Public Sub MessageThing()
        MsgInfo("Please wait patiently while the installer is running. Press OK to continue.")
        If IsInstallerRunning() Then
            MessageThing()
        Else
            ReinstallPAlib()
        End If
    End Sub

    Public Sub RundevkitProUpdater()
        MsgInfo("When presented with the option to choose components, select only 'devkitARM'.")
        System.Diagnostics.Process.Start(AppPath + "devkitProUpdater-1.5.0.exe")
        Threading.Thread.Sleep(1000)
        MessageThing()
    End Sub

    Public Sub ReinstallPAlib()
        System.IO.File.Copy(AppPath + "devkitPro32.zip", CDrive + "devkitPro32.zip")
        System.IO.File.Copy(AppPath + "zip.exe", CDrive + "zip.exe")
        Dim BatchText As String = "zip.exe x devkitPro32.zip"
        Dim BatchProcess As New Process
        System.IO.File.WriteAllText(CDrive + "Generate.bat", BatchText)
        Dim BatchProcessInfo As New ProcessStartInfo(CDrive + "Generate.bat")
        With BatchProcessInfo
            .WorkingDirectory = CDrive
            .WindowStyle = ProcessWindowStyle.Normal
        End With
        BatchProcess.StartInfo = BatchProcessInfo
        BatchProcess.Start()
        BatchProcess.WaitForExit()
        System.IO.File.Delete(CDrive + "Generate.bat")
        System.IO.File.Delete(CDrive + "devkitPro32.zip")
        System.IO.File.Delete(CDrive + "zip.exe")
        My.Computer.FileSystem.MoveDirectory(CDrive + "devkitPro", System.IO.Path.GetTempPath + "Toolchain")
        My.Computer.FileSystem.RenameDirectory(CDrive + "devkitPro32", "devkitPro")
        MsgInfo("Thank you for installing devkitARM and PAlib!")
    End Sub

    'Sub SetSystemVariable(ByVal name As String, ByVal value As String, ByVal UseElevatedPermissions As Boolean)
    '    If UseElevatedPermissions Then
    '        Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.Machine)
    '    Else
    '        Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.User)
    '    End If
    'End Sub

End Module
