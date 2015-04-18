Imports Microsoft.Win32

Module RegistryLib

    Public Sub SetFileType(ByVal extension As String, ByVal FileType As String)
        Dim ext As RegistryKey = Registry.ClassesRoot.CreateSubKey(extension, RegistryKeyPermissionCheck.ReadWriteSubTree)
        ext.SetValue("", FileType)
    End Sub

    Public Sub SetFileDescription(ByVal FileType As String, ByVal Description As String)
        Dim ext As RegistryKey = Registry.ClassesRoot.CreateSubKey(FileType, RegistryKeyPermissionCheck.ReadWriteSubTree)
        ext.SetValue("", Description)
    End Sub

    Public Sub SetDefaultIcon(ByVal FileType As String, ByVal Icon As String)
        Dim ext As RegistryKey = Registry.ClassesRoot.OpenSubKey(FileType, True)
        ext.SetValue("DefaultIcon", Icon)
    End Sub

    Public Sub AddAction(ByVal FileType As String, ByVal Verb As String, ByVal ActionDescription As String)
        Dim ext As RegistryKey = Registry.ClassesRoot.OpenSubKey(FileType, True).CreateSubKey("Shell").CreateSubKey(Verb)
        ext.SetValue("", ActionDescription)
    End Sub

    Public Sub SetExtensionCommandLine(ByVal Command As String, ByVal FileType As String, ByVal CommandLine As String, Optional ByVal Name As String = "")
        Dim rk As RegistryKey = Registry.ClassesRoot
        Dim ext As RegistryKey = rk.OpenSubKey(FileType, True).OpenSubKey("Shell", True).OpenSubKey(Command, True).CreateSubKey("Command", RegistryKeyPermissionCheck.ReadWriteSubTree)
        ext.SetValue(Name, CommandLine)
    End Sub

End Module
