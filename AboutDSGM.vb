Public Class AboutDSGM

    Private Sub WebAddressLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebAddressLabel.Click
        URL(Domain)
    End Sub

    Private Sub DOkayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOkayButton.Click
        Me.Close()
    End Sub

    Private Sub AboutDSGM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim VersionString As String = IDVersion.ToString
        VersionLabel.Text = "Version " + VersionString.Substring(0, 1) + "." + If(VersionString.Substring(1).EndsWith("0"), VersionString.Substring(1).Substring(0, 1), VersionString.Substring(1)) + " (Release " + VersionString + ")"
    End Sub
End Class