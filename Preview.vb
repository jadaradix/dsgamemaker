Public Class Preview

    Public TheImage As Image
    Public ImageSize As New Size
    Public Speed As Byte
    Dim FrameOn As Byte = 0
    Dim FrameCount As Byte = 0

    Function GetFrame(ByVal FrameNumber As Int16) As Bitmap
        Dim Returnable As New Bitmap(ImageSize.Width, ImageSize.Height)
        Dim NewGFX As Graphics = Graphics.FromImage(Returnable)
        NewGFX.DrawImage(TheImage, New Point(0, FrameNumber * ImageSize.Height * -1))
        NewGFX.Dispose()
        If Convert.ToByte(GetSetting("TRANSPARENT_ANIMATIONS")) = 1 Then Returnable = MakeBMPTransparent(Returnable, Color.Magenta)
        Return Returnable
    End Function

    Private Sub DCloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MainTimer.Enabled = False
        Me.Close()
    End Sub

    Private Sub Preview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FrameOn = 0
        Dim WaitTime As Byte = 60 / Speed
        MainTimer.Interval = (WaitTime / 60) * 1000
        FrameCount = TheImage.Height / ImageSize.Height
        MainTimer.Enabled = True
    End Sub

    Private Sub MainTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainTimer.Tick
        FrameOn += 1
        'MsgError("Showing " + FrameOn.ToString)
        If FrameOn = FrameCount Then FrameOn = 0
        PreviewPanel.BackgroundImage = GetFrame(FrameOn)
    End Sub
End Class