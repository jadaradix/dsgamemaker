Imports System.IO
Module SettingsLib

    Public SettingNames As New List(Of String)
    Public SettingValues As New List(Of String)
    Public SettingsPath As String = String.Empty

    Public Sub LoadSettings()
        SettingNames.Clear()
        SettingValues.Clear()
        For Each SettingLine As String In File.ReadAllLines(SettingsPath)
            Dim SettingName As String = SettingLine.Substring(0, SettingLine.IndexOf(" "))
            Dim SettingValue As String = SettingLine.Substring(SettingLine.IndexOf(" ") + 1)
            SettingNames.Add(SettingName)
            SettingValues.Add(SettingValue)
        Next
    End Sub

    Public Sub SaveSettings()
        Dim FinalString As String = String.Empty
        For SettingNo As Byte = 0 To SettingNames.Count - 1
            FinalString += SettingNames(SettingNo) + " " + SettingValues(SettingNo) + vbcrlf
        Next
        File.WriteAllText(SettingsPath, FinalString)
    End Sub

    Public Function GetSetting(ByVal SettingName As String) As String
        For SettingNo As Byte = 0 To SettingNames.Count - 1
            If SettingNames(SettingNo) = SettingName Then Return SettingValues(SettingNo)
        Next
        Return String.Empty
    End Function

    Public Sub SetSetting(ByVal SettingName As String, ByVal SettingValue As String)
        Dim BackupValues As New List(Of String)
        For SettingNo As Byte = 0 To SettingNames.Count - 1
            If SettingNames(SettingNo) = SettingName Then
                BackupValues.Add(SettingValue)
            Else
                BackupValues.Add(SettingValues(SettingNo))
            End If
        Next
        SettingValues.Clear()
        For SettingNo As Byte = 0 To BackupValues.Count - 1
            SettingValues.Add(BackupValues(SettingNo))
        Next
        BackupValues.Clear()
    End Sub

End Module
