Public Class TransformSprite

    Public ImagePaths As New List(Of String)

    Private Sub OriginalColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OriginalColorButton.Click
        OriginalColorButton.BackColor = SelectColor(OriginalColorButton.BackColor)
    End Sub

    Private Sub ReplaceButtonColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceColorButton.Click
        ReplaceColorButton.BackColor = SelectColor(ReplaceColorButton.BackColor)
    End Sub

    Private Sub DOkayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOkayButton.Click
        For Each X As String In ImagePaths
            Dim TheImage As Bitmap = PathToImage(X)
            If MainTabControl.SelectedIndex = 1 Then
                Dim TheSize As Size = PathToImage(X).Size
                TheImage = New Bitmap(TheSize.Width, TheSize.Height)
                Dim GFX As Graphics = Graphics.FromImage(TheImage)
                GFX.Clear(ReplaceColorButton.BackColor)
                GFX.DrawImage(MakeBMPTransparent(PathToImage(X), OriginalColorButton.BackColor), New Point(0, 0))
                GFX.Dispose()
                TheImage.Save(X)
                Continue For
            End If
            If NoneRadioButton.Checked Then
                If RotationDropper.Text = "90" Then
                    TheImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
                ElseIf RotationDropper.Text = "180" Then
                    TheImage.RotateFlip(RotateFlipType.Rotate180FlipNone)
                ElseIf RotationDropper.Text = "270" Then
                    TheImage.RotateFlip(RotateFlipType.Rotate270FlipNone)
                ElseIf RotationDropper.Text = "0" Then
                    TheImage.RotateFlip(RotateFlipType.RotateNoneFlipNone)
                End If
            ElseIf BothRadioButton.Checked Then
                If RotationDropper.Text = "90" Then
                    TheImage.RotateFlip(RotateFlipType.Rotate90FlipXY)
                ElseIf RotationDropper.Text = "180" Then
                    TheImage.RotateFlip(RotateFlipType.Rotate180FlipXY)
                ElseIf RotationDropper.Text = "270" Then
                    TheImage.RotateFlip(RotateFlipType.Rotate270FlipXY)
                ElseIf RotationDropper.Text = "0" Then
                    TheImage.RotateFlip(RotateFlipType.RotateNoneFlipXY)
                End If
            ElseIf HorizontalRadioButton.Checked Then
                If RotationDropper.Text = "90" Then
                    TheImage.RotateFlip(RotateFlipType.Rotate90FlipX)
                ElseIf RotationDropper.Text = "180" Then
                    TheImage.RotateFlip(RotateFlipType.Rotate180FlipX)
                ElseIf RotationDropper.Text = "270" Then
                    TheImage.RotateFlip(RotateFlipType.Rotate270FlipX)
                ElseIf RotationDropper.Text = "0" Then
                    TheImage.RotateFlip(RotateFlipType.RotateNoneFlipX)
                End If
            ElseIf VerticalRadioButton.Checked Then
                If RotationDropper.Text = "90" Then
                    TheImage.RotateFlip(RotateFlipType.Rotate90FlipY)
                ElseIf RotationDropper.Text = "180" Then
                    TheImage.RotateFlip(RotateFlipType.Rotate180FlipY)
                ElseIf RotationDropper.Text = "270" Then
                    TheImage.RotateFlip(RotateFlipType.Rotate270FlipY)
                ElseIf RotationDropper.Text = "0" Then
                    TheImage.RotateFlip(RotateFlipType.RotateNoneFlipY)
                End If
            End If
            TheImage.Save(X)
        Next
        Me.Close()
    End Sub

    Private Sub TransformSprite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class