Public Class SoundType

    Public IsSoundEffect As Boolean

    Private Sub SoundEffectRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoundEffectRadioButton.CheckedChanged, BackgroundSoundRadioButton.CheckedChanged
        If SoundEffectRadioButton.Checked Then
            InfoLabel.Text = "A WAV sound file that can play along side other effects and on top of background sound (MP3)."
        Else
            InfoLabel.Text = "A streamed MP3 sound file that plays underneath sound effects."
        End If
    End Sub

    Private Sub DOkayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOkayButton.Click
        IsSoundEffect = SoundEffectRadioButton.Checked
        Me.Close()
    End Sub

    Private Sub SoundType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SoundEffectRadioButton.Checked = True
    End Sub
End Class