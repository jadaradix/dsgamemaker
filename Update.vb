Public Class DUpdate

    Dim HasShown As Boolean = False

    Private Sub NeverMindButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeverMindButton.Click
        Me.Close()
    End Sub

    Private Sub InstallButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstallButton.Click
        URL(Domain + "downloads/Install" + UpdateVersion.ToString + ".exe")
        MsgInfo("Thanks for choosing to keep " + Application.ProductName + " up to date." + vbcrlf + vbcrlf + "The program will now exit so that the update may install.")
        End
    End Sub

    Private Sub Update_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        If HasShown Then Exit Sub
        InstallButton.Focus()
        MainWebBrowser.Navigate(Domain + "DSGM5RegClient/" + UpdateVersion.ToString + ".php")
        HasShown = True
    End Sub

    Private Sub Update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim VersionString As String = UpdateVersion.ToString
        TitleLabel.Text = "Version " + VersionString.Substring(0, 1) + "." + VersionString.Substring(1, 2) + " is Available"
    End Sub

    Private Sub MainWebBrowser_Navigating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles MainWebBrowser.Navigating
        If e.Url.ToString.Contains("dsgmforum") Then
            URL(e.Url.ToString)
            e.Cancel = True
        End If
    End Sub

End Class