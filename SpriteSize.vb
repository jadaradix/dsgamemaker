Public Class SpriteSize

    Public SpritePath As String = String.Empty

    Private Sub DOkayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOkayButton.Click
        Me.Close()
    End Sub

    Private Sub OpenEditorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenEditorButton.Click
        Dim X As String = SpritePath
        X = X.Substring(X.LastIndexOf("\") + 1)
        X = X.Substring(0, X.IndexOf("."))
        EditImage(SpritePath, X, False)
        Me.Close()
    End Sub

End Class