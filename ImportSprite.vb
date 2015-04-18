Imports System.IO
Public Class ImportSprite

    Public FileName As String = String.Empty
    Public ToDirectory As String
    Public DidIt As Boolean = False
    Public ImportedCount As Int16 = 0
    Public FrameWidth As Int16 = 32
    Public FrameHeight As Int16 = 32
    Dim CustomHRow As Boolean = False
    Dim CustomVRow As Boolean = False

    Function RenderImage() As Bitmap
        Dim TheSize As Size = PathToImage(FileName).Size
        Dim Returnable As New Bitmap(TheSize.Width, TheSize.Height)
        Dim RGFX As Graphics = Graphics.FromImage(Returnable)
        RGFX.DrawImage(PathToImage(FileName), New Point(0, 0))
        Dim XStartWhite As Boolean = True
        For Y As Int16 = 0 To ImagesPerColumnDropper.Value - 1
            Dim ThePen As Pen = If(XStartWhite, Pens.LightGray, Pens.Black)
            Dim DrawInWhite As Boolean = XStartWhite
            For X As Int16 = 0 To ImagesPerRowDropper.Value - 1
                If DrawInWhite Then ThePen = Pens.LightGray Else ThePen = Pens.Black
                If DrawInWhite Then DrawInWhite = False Else DrawInWhite = True
                Dim TP As New Point(X * FrameWidth, Y * FrameHeight)
                RGFX.DrawRectangle(ThePen, New Rectangle(TP.X, TP.Y, FrameWidth - 1, FrameHeight - 1))
            Next
            If XStartWhite = True Then XStartWhite = False Else XStartWhite = True
        Next
        Return Returnable
    End Function

    Function EquateHRow() As Int16
        If FileName.Length = 0 Then Return 1
        Dim HRow As Int16 = PathToImage(FileName).Width
        If HRow Mod FrameWidth = 0 Then
            Return HRow / FrameWidth
        Else
            HRow += FrameWidth - (PathToImage(FileName).Width Mod FrameWidth)
            HRow /= FrameWidth
        End If
        Return HRow
    End Function

    Function EquateVRow() As Int16
        If FileName.Length = 0 Then Return 1
        Dim VRow As Int16 = PathToImage(FileName).Height
        If VRow Mod FrameHeight = 0 Then
            Return VRow / FrameHeight
        Else
            VRow += FrameHeight - (VRow Mod FrameHeight)
            VRow /= FrameHeight
        End If
        Return VRow
    End Function

    Private Sub ImportSprite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ImportedCount = 0
        CustomHRow = False
        CustomVRow = False
    End Sub

    Sub RefreshPreview()
        If FileName.Length = 0 Then Exit Sub
        PreviewPanel.BackgroundImage = RenderImage()
    End Sub

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        'TODO LATER Rows beyond the image width = bad frames!
        'Limit on selector, or ignore extra value?
        Dim TheImage As Bitmap = PathToImage(FileName)
        Dim DOn As Int16 = 0
        For Y As Int16 = 0 To ImagesPerColumnDropper.Value - 1
            For X As Int16 = 0 To ImagesPerRowDropper.Value - 1
                Dim LittleImage As New Bitmap(FrameWidth, FrameHeight)
                Dim RGFX As Graphics = Graphics.FromImage(LittleImage)
                Dim TP As New Point(-1 * X * FrameWidth, -1 * Y * FrameHeight)
                RGFX.DrawImage(TheImage, TP)
                RGFX.Dispose()
                LittleImage.Save(ToDirectory + "\" + DOn.ToString + ".png")
                DOn += 1
            Next
        Next
        DidIt = True
        ImportedCount = DOn
        Me.Close()
    End Sub

    Private Sub ImagesPerRowDropper_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagesPerRowDropper.ValueChanged
        CustomHRow = True
        RefreshPreview()
    End Sub

    Private Sub Droppers_ValuesChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrameWidthDropper.SelectedIndexChanged, FrameHeightDropper.SelectedIndexChanged
        If FrameWidthDropper.Text.Length > 0 Then FrameWidth = Convert.ToByte(FrameWidthDropper.Text)
        If FrameHeightDropper.Text.Length > 0 Then FrameHeight = Convert.ToByte(FrameHeightDropper.Text)
        If FrameWidthDropper.Text.Length > 0 And FrameHeightDropper.Text.Length > 0 Then
            If Not CustomHRow Then ImagesPerRowDropper.Value = EquateHRow()
            If Not CustomVRow Then ImagesPerColumnDropper.Value = EquateVRow()
        End If
        RefreshPreview()
    End Sub

    Private Sub ImportSprite_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        ImagesPerRowDropper.Value = EquateHRow()
        ImagesPerColumnDropper.Value = EquateVRow()
        RefreshPreview()
    End Sub

    Private Sub ImagesPerColumnDropper_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagesPerColumnDropper.ValueChanged
        CustomVRow = True
        RefreshPreview()
    End Sub
End Class