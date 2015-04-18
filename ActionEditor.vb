Imports System.IO

Public Class ActionEditor

    Public Editing As String = String.Empty

    Private Sub ActionEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainToolStrip.Renderer = New clsToolstripRenderer
        SubToolStrip.Renderer = New clsToolstripRenderer
        MainImageList.Images.Add("ActionIcon", My.Resources.ActionIcon)
        ActionsTreeView.ImageList = MainImageList
        TypeDropper.Items.Clear()
        ImageDropper.Items.Clear()
        For X As Byte = 0 To 5
            TypeDropper.Items.Add(ActionTypeToString(X))
        Next
        For Each X As String In Directory.GetFiles(AppPath + "ActionIcons")
            Dim ToAdd As String = X.Substring(X.LastIndexOf("\") + 1)
            ToAdd = ToAdd.Substring(0, ToAdd.IndexOf("."))
            ImageDropper.Items.Add(ToAdd)
        Next
        Dim ActionCount As Int16 = 0
        For Each X As String In Directory.GetFiles(AppPath + "Actions", "*.action")
            Dim ActionName As String = X.Substring(X.LastIndexOf("\") + 1)
            ActionName = ActionName.Substring(0, ActionName.LastIndexOf("."))
            ActionsTreeView.Nodes.Add(New TreeNode(ActionName, 0, 0))
            ActionCount += 1
        Next
        'If ActionCount = 0 Then MsgWarn("You haven't got any actions on your system.")
        ActionsTreeView_NodeMouseDoubleClick(New Object, New TreeNodeMouseClickEventArgs(ActionsTreeView.Nodes(0), Windows.Forms.MouseButtons.Left, 1, 0, 0))
        'If Not ActionCount = 0 Then ActionsTreeView.SelectedNode = ActionsTreeView.Nodes(0)
    End Sub

    Private Sub ActionsTreeView_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles ActionsTreeView.NodeMouseDoubleClick
        If Not File.Exists(AppPath + "Actions\" + e.Node.Text + ".action") Then Exit Sub
        Dim ActionType As Byte = 6
        Dim ActionDisplay As String = String.Empty
        Dim ArgNames As New List(Of String)
        Dim ArgTypes As New List(Of String)
        Dim FinalString As String = String.Empty
        Dim IndentSet As Boolean = False
        Dim NoApplies As Boolean = False
        DontRequestApplicationChecker.Checked = False
        ConditionalDisplayChecker.Checked = False
        For Each ActLine As String In File.ReadAllLines(AppPath + "Actions\" + e.Node.Text + ".action")
            If ActLine.StartsWith("TYPE ") Then ActionType = ActLine.Substring(5) : Continue For
            If ActLine.StartsWith("DISPLAY") Then ActionDisplay = ActLine.Substring(8) : Continue For
            If ActLine = "INDENT" Then IndentRadioButton.Checked = True : IndentSet = True : Continue For
            If ActLine = "DEDENT" Then InvertRadioButton.Checked = True : IndentSet = True : Continue For
            If ActLine = "NOAPPLIES" Then DontRequestApplicationChecker.Checked = True : Continue For
            If ActLine.StartsWith("CONDITION ") Then
                ActLine = ActLine.Substring(("CONDITION").Length + 1)
                ConditionalDisplayChecker.Checked = (ActLine = "1")
                Continue For
            End If
            If ActLine.StartsWith("ICON ") Then Continue For
            If ActLine.StartsWith("ARG ") Then
                ActLine = ActLine.Substring(4)
                ArgNames.Add(ActLine.Substring(0, ActLine.IndexOf(",")))
                ArgTypes.Add(ActLine.Substring(ActLine.IndexOf(",") + 1))
                Continue For
            End If
            FinalString += ActLine + vbCrLf
        Next
        If Not IndentSet Then GenericRadioButton.Checked = True
        Dim IsError As Boolean = False
        If ActionType = 6 Then IsError = True
        If ActionDisplay.Length = 0 Then IsError = True
        If IsError Then MsgError("'" + e.Node.Text + "' is not a valid action file.") : Exit Sub
        Editing = e.Node.Text
        NameTextBox.Text = e.Node.Text
        ListDisplayTextBox.Text = ActionDisplay
        TypeDropper.Text = ActionTypeToString(ActionType)
        ImageDropper.Text = ActionGetIconPath(e.Node.Text, False)
        ImageDropper.Text = ImageDropper.Text.Substring(0, ImageDropper.Text.LastIndexOf("."))
        ArgumentsListView.Items.Clear()
        If ArgNames.Count > 0 Then
            For X As Byte = 0 To ArgNames.Count - 1
                Dim ToAdd As New ListViewItem
                ToAdd.Text = ArgNames(X)
                ToAdd.SubItems.Add(ArgumentTypeToString(ArgTypes(X)))
                ArgumentsListView.Items.Add(ToAdd)
            Next
        End If
        MainTextBox.Text = FinalString
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        If Editing.Length = 0 Then MsgWarn("No action is selected.") : Exit Sub
        If Not File.Exists(AppPath + "ActionIcons\" + ImageDropper.Text + ".png") Then MsgWarn("The action icon does not exist.") : Exit Sub
        'TODO LATER
        'Update references to this action. Scripts, and in Events.

        'TODO LATER
        'Loop through Object forms - update
        'Actions collection, action images, action displays.
        'Shit, action arguments
        'Repopulate the tab control

        'TODO LATER
        'actions in arguments - knock offs and add ons
        SaveButton.Enabled = False
        Dim NameChanged As Boolean = True
        If Editing = NameTextBox.Text Then NameChanged = False
        Dim ActionExists As Boolean = False
        If Not NameTextBox.Text = Editing Then
            For Each Action As TreeNode In ActionsTreeView.Nodes
                If NameTextBox.Text = Action.Text Then ActionExists = True : Exit For
            Next
        End If
        If ActionExists Then MsgError("There is already an action called '" + NameTextBox.Text + "'.") : Exit Sub
        Dim FinalString As String = "TYPE " + TypeDropper.SelectedIndex.ToString + vbCrLf
        FinalString += "DISPLAY " + ListDisplayTextBox.Text + vbCrLf
        FinalString += "ICON " + ImageDropper.Text + ".png" + vbCrLf
        FinalString += "CONDITION " + If(ConditionalDisplayChecker.Checked, "1", "0") + vbCrLf
        For Each X As ListViewItem In ArgumentsListView.Items
            FinalString += "ARG " + X.Text + "," + ArgumentStringToType(X.SubItems(1).Text).ToString + vbCrLf
        Next
        For Each X As ScintillaNet.Line In MainTextBox.Lines
            FinalString += X.Text
        Next
        If IndentRadioButton.Checked Then FinalString += vbCrLf + "INDENT"
        If InvertRadioButton.Checked Then FinalString += vbCrLf + "DEDENT"
        If DontRequestApplicationChecker.Checked Then FinalString += vbCrLf + "NOAPPLIES"
        IO.File.WriteAllText(AppPath + "Actions\" + Editing + ".action", FinalString)
        If NameChanged Then IO.File.Move(AppPath + "Actions\" + Editing + ".action", AppPath + "Actions\" + NameTextBox.Text + ".action")
        For Each X As TreeNode In ActionsTreeView.Nodes
            If X.Text = Editing Then X.Text = NameTextBox.Text
        Next
        For Each X As String In GetXDSFilter("ACT ")
            If iGet(X, 3, ",") = Editing Then
                Dim NewLine As String = iGet(X, 0, ",") + ","
                NewLine += iGet(X, 1, ",") + ","
                NewLine += iGet(X, 2, ",") + ","
                NewLine += NameTextBox.Text + "," + iGet(X, 4, ",") + "," + iGet(X, 5, ",")
                XDSChangeLine(X, NewLine)
            End If
        Next
        For Each X As Form In MainForm.MdiChildren
            If GetXDSFilter("OBJECT " + X.Text + ",").Length = 0 Then Continue For
            For Y As Int16 = 0 To DirectCast(X, DObject).Actions.Count - 1
                If DirectCast(X, DObject).Actions(Y) = Editing Then
                    DirectCast(X, DObject).Actions(Y) = NameTextBox.Text
                    DirectCast(X, DObject).ActionImages(Y) = ActionGetIconPath(NameTextBox.Text, False)
                    DirectCast(X, DObject).ActionDisplays(Y) = ActionEquateDisplay(DirectCast(X, DObject).Actions(Y), DirectCast(X, DObject).ActionArguments(Y))
                End If
            Next
            DirectCast(X, DObject).RepopulateLibrary()
            'For Each Y As Control In X.Controls
            '    If Y.Name = "ActionsToAddTabControl" Then
            '        DObject.PopulateActionsTabControl(DirectCast(Y, TabControl))
            '    ElseIf Y.Name = "ActionsList" Then
            '        DirectCast(Y, ListBox).Refresh()
            '    End If
            'Next
        Next
        Editing = NameTextBox.Text
        SaveButton.Enabled = True
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        SaveButton_Click(New Object, New System.EventArgs)
        Me.Close()
    End Sub

    Private Sub DeleteArgumentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteArgumentButton.Click
        If ArgumentsListView.SelectedItems.Count = 0 Then Exit Sub
        Dim TheName As String = ArgumentsListView.SelectedItems(0).Text
        ArgumentsListView.SelectedItems(0).Remove()
        Dim NeedsBinning As Boolean = False
        Dim DisplayNeedsBinning As Boolean = If(ListDisplayTextBox.Text.Contains("$" + TheName + "$"), True, False)
        If ListDisplayTextBox.Text.Contains("%" + TheName + "%") Then DisplayNeedsBinning = True
        For Each X As ScintillaNet.Line In MainTextBox.Lines
            If X.Text.Contains("!" + TheName + "!") Then NeedsBinning = True
        Next
        Dim BothMessages As Boolean = If(NeedsBinning And DisplayNeedsBinning, True, False)
        If BothMessages Then
            MsgWarn("You must removal all references to !" + TheName + "! and $" + TheName + "$.")
        Else
            If NeedsBinning Then
                MsgWarn("You must removal all references to !" + TheName + "!.")
            End If
            If DisplayNeedsBinning Then
                MsgWarn("You must removal all references to $" + TheName + "$ and %" + TheName + "%.")
            End If
        End If
    End Sub

    Private Sub AddArgumentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddArgumentButton.Click
        If Editing.Length = 0 Then MsgWarn("No action is selected.") : Exit Sub
        Dim ArgumentForm As New Argument
        With ArgumentForm
            .ArgumentName = String.Empty
            .ArgumentType = 0
            .Text = "Add Argument"
            .IsAction = True
            If Not .ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
            If .ArgumentName.Length = 0 Then Exit Sub
        End With
        Dim NewName As String = ArgumentForm.ArgumentName
        Dim NewType As String = ArgumentTypeToString(ArgumentForm.ArgumentType)
        ArgumentForm.Dispose()
        If Not ValidateSomething(NewName, ValidateLevel.Loose) Then
            MsgWarn("You must enter a valid name for the new Argument.") : Exit Sub
        End If
        Dim AlreadyDone As Boolean = False
        For Each X As ListViewItem In ArgumentsListView.Items
            If X.Text = NewName Then AlreadyDone = True
        Next
        If AlreadyDone Then
            MsgError("There is already an Argument called '" + NewName + "'." + vbCrLf + vbCrLf + "You must choose another name.")
            Exit Sub
        End If
        Dim Y As New ListViewItem
        Y.Text = ArgumentForm.ArgumentName
        Y.SubItems.Add(ArgumentTypeToString(ArgumentForm.ArgumentType))
        ArgumentsListView.Items.Add(Y)
    End Sub

    Private Sub EditArgumentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditArgumentButton.Click
        If ArgumentsListView.SelectedItems.Count = 0 Then Exit Sub
        Dim ArgumentForm As New Argument
        With ArgumentForm
            .ArgumentName = ArgumentsListView.SelectedItems(0).Text
            .ArgumentType = ArgumentStringToType(ArgumentsListView.SelectedItems(0).SubItems(1).Text)
            .Text = "Edit Argument"
            .IsAction = True
            If Not .ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
            If .ArgumentName.Length = 0 Then Exit Sub
        End With
        Dim NewName As String = ArgumentForm.ArgumentName
        Dim NewType As String = ArgumentTypeToString(ArgumentForm.ArgumentType)
        If Not ValidateSomething(NewName, ValidateLevel.Loose) Then
            MsgWarn("You must enter a valid name for the Argument.") : Exit Sub
        End If
        If Not NewName = ArgumentsListView.SelectedItems(0).Text Then
            Dim AlreadyDone As Boolean = False
            For Each X As ListViewItem In ArgumentsListView.Items
                If X.Text = NewName Then AlreadyDone = True
            Next
            If AlreadyDone Then MsgError("There is already an Argument called '" + NewName + "'." + vbCrLf + vbCrLf + "You must choose another name.") : Exit Sub
        End If
        ArgumentsListView.SelectedItems(0).Text = NewName
        ArgumentsListView.SelectedItems(0).SubItems(1).Text = NewType
        ArgumentForm.Dispose()
    End Sub

    Private Sub DeleteActionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteActionButton.Click
        If Editing.Length = 0 Then MsgWarn("No action is selected.") : Exit Sub
        Dim ActionName As String = ActionsTreeView.SelectedNode.Text
        Dim Response As Byte = MessageBox.Show("Are you sure you want to delete '" + ActionName + "'?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Not Response = MsgBoxResult.Yes Then Exit Sub
        IO.File.Delete(AppPath + "Actions\" + ActionName + ".action")
        ActionsTreeView.SelectedNode.Remove()
        If ActionsTreeView.Nodes.Count = 0 Then
            'Deleted the last action
            ClearStuff()
        Else
            'Can select another!!
            ActionsTreeView.SelectedNode = ActionsTreeView.Nodes(0)
        End If
    End Sub

    Sub ClearStuff()
        NameTextBox.Text = String.Empty
        ListDisplayTextBox.Text = String.Empty
        TypeDropper.SelectedIndex = 0
        ArgumentsListView.Items.Clear()
        Editing = String.Empty
    End Sub

    Private Sub InsertArgumentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertArgumentButton.Click
        If ArgumentsListView.SelectedItems.Count = 0 Then Exit Sub
    End Sub

    Private Sub AddActionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddActionButton.Click
        Dim Response As String = GetInput("Please enter a name for the new action", String.Empty, ValidateLevel.Loose)
        If Response.Length = 0 Then Exit Sub
        Dim FinalString As String = "TYPE 5" + vbCrLf
        FinalString += "DISPLAY " + Response + vbCrLf
        IO.File.WriteAllText(AppPath + "Actions\" + Response + ".action", FinalString)
        ActionsTreeView.Nodes.Add(New TreeNode(Response, 0, 0))
        For Each X As TreeNode In ActionsTreeView.Nodes
            If X.Text = Response Then ActionsTreeView_NodeMouseDoubleClick(New Object, New TreeNodeMouseClickEventArgs(X, Windows.Forms.MouseButtons.Left, 1, 0, 0))
        Next
    End Sub
End Class