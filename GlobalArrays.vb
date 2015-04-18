Public Class GlobalArrays

    Dim SN As Byte = 200

    'Number 0
    'TrueFalse 1

    Sub ClearShizzle()
        SN = 200
        NameTextBox.Text = String.Empty
        ValuesListBox.Items.Clear()
        TypeDropper.Text = "Number"
        MainGroupBox.Text = "<No Array Selected>"
        SaveButton.Enabled = False
        AddValueButton.Enabled = False
        EditValueButton.Enabled = False
        DeleteValueButton.Enabled = False
    End Sub

    Private Sub Globals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainToolStrip.Renderer = New clsToolstripRenderer
        Dim TMPList As New ImageList
        With TMPList
            .ImageSize = New Size(16, 16)
            .ColorDepth = ColorDepth.Depth32Bit
            .Images.Add(My.Resources.ArrayIcon)
        End With
        ArraysList.ImageList = TMPList
        ArraysList.Nodes.Clear()
        For Each X As String In GetXDSFilter("ARRAY ")
            X = X.Substring(6)
            Dim ArrayName As String = iGet(X, 0, ",")
            ArraysList.Nodes.Add(String.Empty, ArrayName, 0)
        Next
        ClearShizzle()
    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        If SN = 200 Then Exit Sub
        Dim ArrayName As String = ArraysList.Nodes(SN).Text
        XDSRemoveLine(GetXDSLine("ARRAY " + ArrayName + ","))
        ArraysList.Nodes.Remove(ArraysList.Nodes(SN))
        Dim Message As String = "You have just deleted '" + ArrayName + "'." + vbcrlf + vbcrlf
        Message += "Be sure to update any logic that uses this Array."
        MsgInfo(Message)
        ClearShizzle()
    End Sub

    Private Sub VariablesList_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles ArraysList.NodeMouseDoubleClick
        SN = e.Node.Index
        NameTextBox.Text = e.Node.Text
        MainGroupBox.Text = e.Node.Text
        Dim XDSLine As String = GetXDSLine("ARRAY " + e.Node.Text + ",")
        Dim Type As Byte = Convert.ToByte(iGet(XDSLine, 1, ","))
        TypeDropper.Text = "Number"
        If Type = 1 Then TypeDropper.Text = "TrueFalse"
        Dim ValuesString As String = iGet(XDSLine, 2, ",")
        ValuesListBox.Items.Clear()
        If ValuesString.Length > 0 Then
            For i As Int16 = 0 To HowManyChar(ValuesString, ";")
                Dim Value As String = iGet(ValuesString, i, ";")
                ValuesListBox.Items.Add(Value)
            Next
        End If
        AddValueButton.Enabled = True
        EditValueButton.Enabled = True
        DeleteValueButton.Enabled = True
        SaveButton.Enabled = True
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        'If SN = 200 Then MsgWarn("No Variable is selected.") : Exit Sub
        If Not ValidateSomething(NameTextBox.Text, ValidateLevel.Tight) Then MsgWarn("You must provide a valid name.") : Exit Sub
        If TypeDropper.Text.Length = 0 Then MsgWarn("You must select a Type.") : Exit Sub
        If Not TypeDropper.Text = "TrueFalse" And Not TypeDropper.Text = "Number" Then MsgWarn("A Variable can only be a 'TrueFalse' or a 'Number'.") : Exit Sub
        If TypeDropper.Text = "TrueFalse" Then
            Dim AllTrueFalse As Boolean = True
            'Dim ThisTime As Boolean = False
            For Each X As String In ValuesListBox.Items
                If X.ToLower = "true" Or X.ToLower = "false" Then
                Else
                    AllTrueFalse = False
                End If
            Next
            If Not AllTrueFalse Then
                MsgWarn("With a TrueFalse Array, all Values must be 'true' or 'false'.")
                Exit Sub
            End If
        End If
        Dim TheType As Byte = If(TypeDropper.Text = "TrueFalse", 1, 0)
        Dim ValuesString As String = String.Empty
        For Each X As String In ValuesListBox.Items
            ValuesString += X + ";"
        Next
        If ValuesString.Length > 0 Then ValuesString = ValuesString.Substring(0, ValuesString.Length - 1)
        XDSChangeLine(GetXDSLine("ARRAY " + ArraysList.Nodes(SN).Text + ","), "ARRAY " + NameTextBox.Text + "," + TheType.ToString + "," + ValuesString)
        ArraysList.SelectedNode.Text = NameTextBox.Text
        MainGroupBox.Text = NameTextBox.Text
    End Sub

    Private Sub AddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton.Click
        Dim ToUse As Int16 = 1
        For i = 1 To 1000
            If GetXDSFilter("ARRAY Array_" + i.ToString + ",").Length = 0 Then ToUse = i : Exit For
        Next
        XDSAddLine("ARRAY Array_" + ToUse.ToString + ",0,")
        ArraysList.Nodes.Add(String.Empty, "Array_" + ToUse.ToString, 0)
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub DeleteValueButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteValueButton.Click
        If ValuesListBox.SelectedIndices.Count = 0 Then Exit Sub
        ValuesListBox.Items.RemoveAt(ValuesListBox.SelectedIndices(0))
    End Sub

    Private Sub AddValueButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddValueButton.Click
        If TypeDropper.SelectedIndex = 0 Then ValuesListBox.Items.Add("0") Else ValuesListBox.Items.Add("true")
    End Sub

    Private Sub EditValueButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditValueButton.Click
        If ValuesListBox.SelectedIndices.Count = 0 Then Exit Sub
        Dim Response As String = GetInput("Please enter a new Value", ValuesListBox.Text, ValidateLevel.None)
        If Response.Length = 0 Then Exit Sub
        ValuesListBox.Items(ValuesListBox.SelectedIndices(0)) = Response
    End Sub
End Class