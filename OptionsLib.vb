Imports System.IO
Module OptionsLib

    Public OptionNames As New List(Of String)
    Public OptionValues As New List(Of String)
    Public OptionPath As String = String.Empty

    Public Sub LoadOptions()
        OptionNames.Clear()
        OptionValues.Clear()
        For Each OL As String In File.ReadAllLines(OptionPath)
            Dim OName As String = OL.Substring(0, OL.IndexOf(" "))
            Dim OValue As String = OL.Substring(OL.IndexOf(" ") + 1)
            OptionNames.Add(OName)
            OptionValues.Add(OValue)
        Next
    End Sub

    Public Sub SaveOptions()
        Dim FinalString As String = String.Empty
        For I As UInt16 = 0 To OptionNames.Count - 1
            FinalString += OptionNames(I) + " " + OptionValues(I) + vbCrLf
        Next
        File.WriteAllText(OptionPath, FinalString)
    End Sub

    Public Function GetOption(ByVal SettingName As String) As String
        For SettingNo As Byte = 0 To OptionNames.Count - 1
            If OptionNames(SettingNo) = SettingName Then Return OptionValues(SettingNo)
        Next
        Return String.Empty
    End Function

    Public Sub SetOption(ByVal OptionName As String, ByVal OptionValue As String)
        Dim BackupValues As New List(Of String)
        For SettingNo As Byte = 0 To OptionNames.Count - 1
            If OptionNames(SettingNo) = OptionName Then
                BackupValues.Add(OptionValue)
            Else
                BackupValues.Add(OptionValues(SettingNo))
            End If
        Next
        OptionValues.Clear()
        For I As UInt16 = 0 To BackupValues.Count - 1
            OptionValues.Add(BackupValues(I))
        Next
        BackupValues.Clear()
    End Sub

    Sub PatchOption(ByVal OName As String, ByVal OValue As String)
        Dim DoTheAdd As Boolean = True
        Dim FS As String = String.Empty
        For Each OL As String In File.ReadAllLines(OptionPath)
            If OL.StartsWith(OName + " ") Then DoTheAdd = False
            FS += OL + vbcrlf
        Next
        If DoTheAdd Then
            FS += OName + " " + OValue
            File.WriteAllText(OptionPath, FS)
        End If
    End Sub


End Module
