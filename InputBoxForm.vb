Public Class InputBoxForm

    Public Descriptor As String
    Public TheInput As String
    Public Validation As Byte = 0

    Private Sub InputBoxForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DescriptionLabel.Text = Descriptor
        MainTextBox.Text = TheInput
        If MainTextBox.Text.Length = 0 Then DOkayButton.Enabled = False
    End Sub

    Private Sub InputBoxForm_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MainTextBox.Focus()
    End Sub

    Private Sub DCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DCancelButton.Click
        Me.Close()
    End Sub

    Private Sub DOkayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOkayButton.Click
        TheInput = MainTextBox.Text
        Me.Close()
    End Sub

    Private Sub MainTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainTextBox.TextChanged
        DOkayButton.Enabled = ValidateSomething(MainTextBox.Text, Validation)
    End Sub
End Class