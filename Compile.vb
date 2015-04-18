Public Class Compile

    Public HasDoneIt As Boolean
    Public Success As Boolean

    Public Sub CustomPerformStep(ByVal Stage As String)
        Threading.Thread.Sleep(100)
        'ProgressLabel.Text = Stage
        MainProgressBar.PerformStep()
        'ProgressLabel.Invalidate()
        MainProgressBar.Invalidate()
        Threading.Thread.Sleep(100)
    End Sub

    Private Sub Compile_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        CompileWrapper()
        Success = CompileGame()
        Me.Close()
    End Sub
End Class