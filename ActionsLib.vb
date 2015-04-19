Imports System.IO
Module ActionsLib

    Function ActionEquateDisplay(ByVal ActionName As String, ByVal ActionArguments As String) As String
        Dim Returnable As String = String.Empty
        For Each Y As String In IO.File.ReadAllLines(AppPath + "Actions\" + ActionName + ".action")
            If Y.StartsWith("DISPLAY ") Then Returnable = Y.Substring(8) : Exit For
        Next
        If Returnable.Length = 0 Then Return ActionName
        For Each Y As String In IO.File.ReadAllLines(AppPath + "Actions\" + ActionName + ".action")
            For Z = 0 To HowManyChar(ActionArguments, ";")
                Dim Argument As String = iGet(ActionArguments, Z, ";")
                Dim StringThing As String = Argument
                If StringThing = "1" Then StringThing = "true"
                If StringThing = "0" Then StringThing = "false"
                If StringThing = "<" Or StringThing = ">" Or StringThing = ">=" Or StringThing = "<=" Or StringThing = "==" Then
                    StringThing = ComparativeToString(StringThing)
                End If
                Dim ScreenThing As String = Argument
                If ScreenThing = "1" Then ScreenThing = "Top Screen"
                If ScreenThing = "0" Then ScreenThing = "Bottom Screen"
                Returnable = Returnable.Replace("$" + (Z + 1).ToString + "$", StringThing)
                Returnable = Returnable.Replace("%" + (Z + 1).ToString + "%", ScreenThing)
                Returnable = Returnable.Replace("!" + (Z + 1).ToString + "!", Argument)
            Next
        Next
        Returnable = Returnable.Replace("<com>", ",")
        Return Returnable
    End Function

    Function ActionIsConditional(ByVal ActionName) As Boolean
        For Each X As String In IO.File.ReadAllLines(AppPath + "Actions\" + ActionName + ".action")
            If X.StartsWith("CONDITION ") Then
                X = X.Substring(("CONDITION").Length + 1)
                Return (X = "1")
            End If
        Next
        Return False
    End Function

    Function ActionGetIconPath(ByVal ActionName As String, ByVal UseFullPath As Boolean) As String
        Dim Returnable As String = "Empty.png"
        For Each X As String In IO.File.ReadAllLines(AppPath + "Actions\" + ActionName + ".action")
            If X.StartsWith("ICON ") Then Returnable = X.Substring(5)
        Next
        If Not File.Exists(AppPath + "ActionIcons\" + Returnable) Then Returnable = "Empty.png"
        If UseFullPath Then Returnable = AppPath + "ActionIcons\" + Returnable
        Return Returnable
    End Function

    Function ActionGetIcon(ByVal ActionName As String) As Bitmap
        Dim TBMP As New Bitmap(32, 32)
        Dim TBMPGFX As Graphics = Graphics.FromImage(TBMP)
        Dim TIcon As Bitmap = PathToImage(ActionGetIconPath(ActionName, True))
        If TIcon.Width = 32 Then
            TBMPGFX.DrawImageUnscaled(My.Resources.ActionBacker, 0, 0)
            TBMPGFX.DrawImageUnscaled(TIcon, New Point(0, 0))
        Else
            If ActionIsConditional(ActionName) Then
                TBMPGFX.DrawImageUnscaled(ActionConditionalBG, 0, 0)
            Else
                TBMPGFX.DrawImageUnscaled(ActionBG, 0, 0)
            End If
            TBMPGFX.DrawImageUnscaled(TIcon, New Point(8, 8))
        End If
        TBMPGFX.Dispose()
        TIcon.Dispose()
        Return TBMP
    End Function

End Module
