Public Class Argument

    Public ArgumentName As String = String.Empty
    Public ArgumentType As String = String.Empty
    Public IsAction As Boolean

    Private Sub Argument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TypeDropper.Items.Clear()
        If IsAction Then
            For X As Byte = 1 To 16
                TypeDropper.Items.Add(ArgumentTypeToString(X))
            Next
            TypeDropper.Text = ArgumentTypeToString(ArgumentType)
        Else
            For X As Byte = 0 To VariableTypes.Count - 1
                TypeDropper.Items.Add(VariableTypes(X))
            Next
            TypeDropper.Text = ArgumentType
        End If
        NameTextBox.Text = ArgumentName
    End Sub

    Private Sub DOkayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOkayButton.Click
        ArgumentName = NameTextBox.Text
        If IsAction Then
            ArgumentType = ArgumentStringToType(TypeDropper.Text)
        Else
            ArgumentType = TypeDropper.Text
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Argument_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        NameTextBox.Focus()
    End Sub
End Class