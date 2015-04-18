Imports System.IO
Module SessionsLib

    Public Session As String = String.Empty
    Public SessionPath As String = String.Empty
    Public CompileName As String = String.Empty
    Public CompilePath As String = String.Empty

    Function MakeSessionName()
        Dim ProcessCount As Byte = 0
        For Each p As Process In System.Diagnostics.Process.GetProcesses()
            If p.ProcessName.StartsWith(Application.ProductName) Then ProcessCount += 1
        Next
        Dim Returnable As String = String.Empty
        Returnable += Now.Minute.ToString + Now.Second.ToString + Now.Millisecond.ToString
        Returnable += ProcessCount.ToString
        Return Returnable
    End Function

    Public Sub FormSession(ByVal SessionName As String)
        Session = SessionName
        SessionPath = AppPath + "ProjectTemp\" + Session + "\"
        CompileName = "DSGMTemp" + Session
        CompilePath = CDrive + CompileName + "\"
    End Sub

    Public Sub FormSessionFS()
        Directory.CreateDirectory(SessionPath)
        Directory.CreateDirectory(SessionPath + "Sprites")
        Directory.CreateDirectory(SessionPath + "Backgrounds")
        Directory.CreateDirectory(SessionPath + "Sounds")
        Directory.CreateDirectory(SessionPath + "Scripts")
        Directory.CreateDirectory(SessionPath + "NitroFSFiles")
        Directory.CreateDirectory(SessionPath + "IncludeFiles")
        File.CreateText(SessionPath + "XDS.xds").Dispose()
        Directory.CreateDirectory(CompilePath)
        Directory.CreateDirectory(CompilePath + "data")
        Directory.CreateDirectory(CompilePath + "nitrofiles")
        Directory.CreateDirectory(CompilePath + "gfx")
        File.WriteAllBytes(CompilePath + "gfx\PAGfx.exe", My.Resources.PAGfx)
        Directory.CreateDirectory(CompilePath + "include")
        File.WriteAllBytes(CompilePath + "include\ActionWorks.h", My.Resources.ActionWorks)
        File.WriteAllBytes(CompilePath + "include\ExtraDBAS.h", My.Resources.ExtraDBAS)
        File.WriteAllText(CompilePath + "include\ActionWorks.h", PathToString(CompilePath + "include\ActionWorks.h") + vbCrLf + PathToString(CompilePath + "include\ExtraDBAS.h"))
        File.Delete(CompilePath + "include\ExtraDBAS.h")
        Directory.CreateDirectory(CompilePath + "source")
        Dim Writeable As String = "make" + vbCrLf + "pause"
        File.WriteAllText(CompilePath + "build.bat", Writeable)
        Writeable = "make clean"
        File.WriteAllText(CompilePath + "clean.bat", Writeable)
        File.CreateText(CompilePath + "source\main.c").Dispose()
        File.CreateText(CompilePath + "gfx\dsgm_gfx.h").Dispose()
    End Sub

End Module
