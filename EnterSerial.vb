Public Class EnterSerial

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Dim Email As String = EmailTextBox.Text
        Dim Serialcode As String = SerialCodeTextBox.Text
        'Validation
        If Email.Length = 0 Then MsgError("No email address was entered.") : EmailTextBox.Focus() : Exit Sub
        If Email.Contains(" ") Then MsgError("The entered Email address cannot contain a space character.") : EmailTextBox.Focus() : Exit Sub
        If Email.Length > 320 Then MsgError("The entered Email address is too long.") : EmailTextBox.Focus() : Exit Sub
        If Email.Length < 3 Then MsgError("The entered Email address is too short.") : EmailTextBox.Focus() : Exit Sub
        If Serialcode.Length = 0 Then MsgError("No Serial code was entered.") : SerialCodeTextBox.Focus() : Exit Sub
        If Serialcode.Contains(" ") Then MsgError("The entered Serial code cannot contain a space character.") : SerialCodeTextBox.Focus() : Exit Sub
        If Serialcode.Length > 64 Then MsgError("The entered Serial code is too long.") : SerialCodeTextBox.Focus() : Exit Sub
        If Serialcode.Length < 4 Then MsgError("The entered Serial code is too short.") : SerialCodeTextBox.Focus() : Exit Sub
        Email = SQLSanitize(Email, True)
        Serialcode = SQLSanitize(Serialcode, True)
        Dim WC As New System.Net.WebClient
        Dim MachineInfo As String = Environment.UserName + "," + Environment.OSVersion.VersionString + "," + Environment.MachineName
        If IO.Directory.Exists("C:\DSGameMaker") Then MachineInfo += ",DSGM4"
        Dim URL As String = Domain + "DSGM5RegClient/work.php?data1=" + Email + "&data2=" + Serialcode + "&data3=" + MachineInfo
        Dim Response As String = WC.DownloadString(URL)
        Dim KeyExists As Boolean = If(Response.StartsWith("1"), True, False)
        If Not KeyExists Then
            MsgError("Your details were not found in the database.")
            EmailTextBox.Focus()
            Exit Sub
        End If
        Dim Entries As Int16 = iGet(Response, 1, ",")
        Dim EntryLimit As Int16 = iGet(Response, 2, ",")
        If Entries >= EntryLimit Then
            MsgError("This Serial code has been entered a maximum of " + EntryLimit.ToString + " times." + vbcrlf + vbcrlf + "Please contact us to receive more possible entries.")
            EmailTextBox.Focus()
            Exit Sub
        End If
        Dim IsBanned As Boolean = If(iGet(Response, 3, ",") = "1", True, False)
        If IsBanned Then
            MsgError("Your Serial code has been banned." + vbcrlf + vbcrlf + "Please mail piracy@dsgamemaker.com.")
            EmailTextBox.Focus()
            Exit Sub
        End If
        My.Settings.ProEmail = Email
        My.Settings.ProSerial = Serialcode
        My.Settings.ProActivated = True
        My.Settings.Save()
        SetSetting("PRO_EMAIL", Email)
        SetSetting("PRO_SERIAL", Serialcode)
        SetSetting("PRO", "1")
        SaveSettings()
        MsgInfo("Activation was successful." + vbcrlf + vbcrlf + "Thank you for using a licensed copy.")
        IsPro = True
        MainForm.Text = TitleDataWorks()
        ' MainForm.EquateProButton()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub DCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EnterSerial_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        EmailTextBox.Focus()
    End Sub
End Class