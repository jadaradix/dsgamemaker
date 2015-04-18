
Public Class SetCoOrdinates

    Public X As Int16
    Public Y As Int16

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        X = XTextBox.Text.ToString
        Y = YTextBox.Text.ToString
        Me.Close()
    End Sub

    Private Sub SetCoOrdinates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        XTextBox.Text = X.ToString
        YTextBox.Text = Y.ToString
    End Sub

    Private Sub TextBoxs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YTextBox.TextChanged, XTextBox.TextChanged
        Dim Enabled As Boolean = True
        If XTextBox.Text.Length = 0 Or YTextBox.Text.Length = 0 Then Exit Sub
        Dim XCount As Byte = 0
        Dim YCount As Byte = 0
        For Each X As String In Numbers
            XCount += HowManyChar(XTextBox.Text, X)
        Next
        For Each Y As String In Numbers
            YCount += HowManyChar(YTextBox.Text, Y)
        Next
        If Not XCount = XTextBox.Text.Length Then Enabled = False
        If Not YCount = YTextBox.Text.Length Then Enabled = False
        DAcceptButton.Enabled = Enabled
    End Sub

    Private Sub SetCoOrdinates_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        XTextBox.Focus()
    End Sub

    Private Sub XTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles YTextBox.KeyPress, XTextBox.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            DAcceptButton_Click(New Object, New System.EventArgs)
        End If
    End Sub
End Class