Public Class StructureItem

    Public UseData As Boolean = False

    Public MemberName As String
    Public MemberType As String
    Public MemberValue As String

    Private Sub StructureItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainToolStrip.Renderer = New clsToolstripRenderer
        TypeDropper.Items.Clear()
        For X As Byte = 0 To VariableTypes.Count - 1
            TypeDropper.Items.Add(VariableTypes(X))
        Next
        NameTextBox.Text = MemberName
        TypeDropper.Text = MemberType
        ValueTextBox.Text = MemberValue
    End Sub

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        UseData = True
        MemberName = NameTextBox.Text
        MemberType = TypeDropper.Text
        MemberValue = ValueTextBox.Text
        Me.Close()
    End Sub

    Private Sub TextBoxs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NameTextBox.TextChanged, TypeDropper.TextChanged
        DAcceptButton.Enabled = (NameTextBox.Text.Length > 0 And TypeDropper.Text.Length > 0)
    End Sub

    Private Sub StructureItem_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        NameTextBox.Focus()
    End Sub
End Class