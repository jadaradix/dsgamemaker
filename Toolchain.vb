Imports System.IO

Module Toolchain

    Public Function IsInstallerRunning() As Boolean
        Dim EXECount As Byte = 0
        Dim ProcessesList() As Process = Process.GetProcesses()
        For Each TheProcess As Process In ProcessesList
            If TheProcess.ProcessName.StartsWith("devkitProUpdater") Then EXECount += 1
        Next
        Return (EXECount > 0)
    End Function

    Public Sub MessageThing()
        MsgInfo("The installer is running. Once it is complete, you can return to " + Application.ProductName)
        If IsInstallerRunning() Then
            MessageThing()
        Else
            ReinstallPAlib()
        End If
    End Sub

    Public Sub RundevkitProUpdater()
        System.Diagnostics.Process.Start(DevPath + "devkitProUpdater-1.5.0.exe")
        Threading.Thread.Sleep(750)
        MessageThing()
    End Sub

    Public Sub ReinstallPAlib()
        Directory.CreateDirectory(CDrive + "devkitPro\PAlib")
        File.Copy(DevPath + "PAlib.7z", CDrive + "devkitPro\PAlib\PAlib.7z", True)
        RunBatchString("zip.exe x PAlib.7z -y" + vbcrlf + "exit", CDrive + "devkitPro\PAlib\", True)
        File.Delete(CDrive + "devkitPro\PAlib\PAlib.7z")
        MsgInfo("Thank you for installing devkitARM and PAlib!")
    End Sub

    Sub ReplaceMakefile(ByVal FromName As String)
        File.Copy(DevPath + FromName, CDrive + "devkitPro\PAlib\lib\PA_Makefile", True)
    End Sub

    'Sub SetSystemVariable(ByVal name As String, ByVal value As String, ByVal UseElevatedPermissions As Boolean)
    '    If UseElevatedPermissions Then
    '        Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.Machine)
    '    Else
    '        Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.User)
    '    End If
    'End Sub

End Module
