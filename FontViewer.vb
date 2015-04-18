Public Class FontViewer

    Dim CurrentFont As Byte = 0
    Dim FontCount As Byte = 0

    Private Sub RebuildCacheButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RebuildCacheButton.Click
        RebuildFontCache()
        InitialDisplayShizzle()
        CurrentFont = 0
        DisplayShizzle()
    End Sub

    Private Sub PreviousButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousButton.Click
        NextButton.Enabled = True
        If CurrentFont = 1 Then PreviousButton.Enabled = False
        CurrentFont -= 1
        DisplayShizzle()
    End Sub

    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click
        PreviousButton.Enabled = True
        If CurrentFont = FontCount - 2 Then NextButton.Enabled = False
        CurrentFont += 1
        DisplayShizzle()
    End Sub

    Private Sub RebuildCacheButton_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RebuildCacheButton.MouseEnter, PreviousButton.MouseEnter, NextButton.MouseEnter
        Select Case sender.Name
            Case "RebuildCacheButton"
                MainInfoLabel.Text = "Rebuild Font Cache"
            Case "PreviousButton"
                MainInfoLabel.Text = "Previous Font"
            Case "NextButton"
                MainInfoLabel.Text = "Next Font"
        End Select
    End Sub

    Sub DisplayShizzle()
        NameLabel.Text = Fonts(CurrentFont)
        MainImagePanel.BackgroundImage = PathToImage(AppPath + "Fonts\" + Fonts(CurrentFont) + ".png")
    End Sub

    Private Sub RebuildCacheButton_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RebuildCacheButton.MouseLeave, PreviousButton.MouseLeave, NextButton.MouseLeave
        MainInfoLabel.Text = String.Empty
    End Sub

    Sub InitialDisplayShizzle()
        NameLabel.Text = Fonts(CurrentFont)
        PreviousButton.Enabled = False
        NextButton.Enabled = False
        If Fonts.Count = 1 Then Exit Sub
        NextButton.Enabled = True
        DisplayShizzle()
    End Sub

    Private Sub FontEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RebuildFontCache()
        FontCount = Fonts.Count
        If FontCount = 0 Then MsgError("There are no Fonts on this machine.") : Me.Close() : Exit Sub
        CurrentFont = 0
        InitialDisplayShizzle()
    End Sub
End Class