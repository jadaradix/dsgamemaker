Public Class Newsline

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub VisitForumButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisitForumButton.Click
        URL(Domain + "dsgmforum")
    End Sub

    Private Sub MainWebBrowser_Navigating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles MainWebBrowser.Navigating
        If Not e.Url.ToString.Contains("dsgamemaker.com/newsline") Then
            URL(e.Url.ToString)
            e.Cancel = True
        End If
    End Sub

    Private Sub LoadanExampleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadanExampleButton.Click
        Dim Result As String = OpenFile(AppPath + "Examples", Application.ProductName + " Projects|*.dsgm")
        If Result.Length = 0 Then Exit Sub
        OpenProject(Result)
    End Sub

    Private Sub Newsline_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class