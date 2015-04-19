Public Class HelpViewer

    Private Sub HelpViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainTreeView.Nodes.Clear()
        Dim FContent As String = PathToString(AppPath + "help\topics.dat")
        For Each P As String In StringToLines(FContent)
            Dim ID As Byte = Convert.ToByte(P.Substring(0, P.IndexOf(",")))
            Dim Name As String = P.Substring(P.IndexOf(",") + 1)
            MainTreeView.Nodes.Add(ID.ToString, Name, 0, 0)
        Next
        For Each P As String In StringToLines(PathToString(AppPath + "help\files.dat"))
            Dim ID As Byte = Convert.ToByte(P.Substring(0, P.IndexOf(",")))
            Dim Name As String = P.Substring(P.IndexOf(",") + 1)
            Name = Name.Substring(0, Name.LastIndexOf(","))
            MainTreeView.Nodes(ID).Nodes.Add(ID.ToString, Name, 1, 1)
        Next
        GoToPage("Introduction", "intro")
    End Sub

    Sub GoToPage(ByVal Title As String, ByVal FName As String)
        Dim FString As String = PathToString(AppPath + "Help\head.html").Replace("$TITLE$", Name) + vbcrlf + vbcrlf
        If IO.File.Exists(AppPath + "Help\" + FName + ".html") Then
            FString += PathToString(AppPath + "Help\" + FName + ".html") + vbcrlf + vbcrlf
        Else
            FString += PathToString(AppPath + "Help\todo.html").Replace("$TITLE$", Name) + vbcrlf + vbcrlf + vbcrlf + vbcrlf
        End If
        FString += PathToString(AppPath + "Help\foot.html")
        IO.File.WriteAllText(AppPath + "Help\display.html", FString)
        DocBrowser.Navigate(AppPath + "Help\display.html")
    End Sub

    Private Sub MainTreeView_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles MainTreeView.NodeMouseDoubleClick
        If e.Node.Parent Is Nothing Then Exit Sub
        Dim Name As String = e.Node.Text
        Dim ID As Byte = e.Node.Parent.Index
        Dim FName As String = String.Empty
        For Each P As String In StringToLines(PathToString(AppPath + "help\files.dat"))
            If P.StartsWith(ID.ToString + "," + Name + ",") Then FName = P.Substring(ID.ToString.Length + 1 + Name.Length + 1)
        Next
        GoToPage(Name, FName)
    End Sub

    Private Sub DocBrowser_Navigating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles DocBrowser.Navigating
        If e.Url.ToString.Contains("&ext") Or e.Url.ToString.Contains("?ext") Then
            e.Cancel = True
            URL(e.Url.ToString.Replace("&ext", String.Empty).Replace("?ext", String.Empty))
        End If
    End Sub
End Class