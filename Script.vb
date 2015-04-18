Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Script

    Public ScriptName As String
    Dim ScriptContent As String
    Dim DoIt As Boolean = False
    Dim CanInsert As Boolean = False
    Dim WhatsDone As String = String.Empty

    Dim ArgumentNames As New List(Of String)
    Dim ArgumentTypes As New List(Of String)

    Sub SaveChanges()
        If Not ScriptName = NameTextBox.Text Then
            File.Move(SessionPath + "Scripts\" + ScriptName + ".dbas", SessionPath + "Scripts\" + NameTextBox.Text + ".dbas")
        End If
        XDSChangeLine(GetXDSLine("SCRIPT " + ScriptName + ","), "SCRIPT " + NameTextBox.Text + "," + If(ParseDBASChecker.Checked, "1", "0"))
        XDSRemoveFilter("SCRIPTARG " + ScriptName + ",")
        If ArgumentNames.Count > 0 Then
            For P As Byte = 0 To ArgumentNames.Count - 1
                XDSAddLine("SCRIPTARG " + NameTextBox.Text + "," + ArgumentNames(P) + "," + ArgumentTypes(P))
            Next
        End If
        IO.File.WriteAllText(SessionPath + "Scripts\" + NameTextBox.Text + ".dbas", MainTextBox.Text)
        For Each X As TreeNode In MainForm.ResourcesTreeView.Nodes(ResourceIDs.Script).Nodes
            If X.Text = ScriptName Then X.Text = NameTextBox.Text
        Next
    End Sub

    Private Sub UndoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoButton.Click
        If MainTextBox.UndoRedo.CanUndo Then MainTextBox.UndoRedo.Undo()
    End Sub

    Private Sub RedoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoButton.Click
        If MainTextBox.UndoRedo.CanRedo Then MainTextBox.UndoRedo.Redo()
    End Sub

    Public Sub GoToLine(ByVal LineNumber As Int16, ByVal Position As Int16, ByVal SelLength As Int16)
        If LineNumber >= MainTextBox.Lines.Count Then Exit Sub
        MainTextBox.Caret.LineNumber = LineNumber
        MainTextBox.Selection.Start += Position
        MainTextBox.Selection.Length = SelLength
    End Sub

    Private Sub Script_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'With MainTextBox.AutoComplete
        '    .List.Clear()
        '    .ListString = "Stylus_X,Stylus_Y"
        '    .ListSeparator = ","
        '    '.AutoHide = True
        '    '.AutomaticLengthEntered = True
        '    '.CancelAtStart = True
        '    '.DropRestOfWord = True
        '    '.FillUpCharacters = String.Empty
        '    '.ImageSeparator = Nothing
        '    .IsCaseSensitive = True
        '    '.SingleLineAccept = False
        '    '.StopCharacters = String.Empty
        'End With
        MainToolStrip.Renderer = New clsToolstripRenderer
        MainTextBox.AcceptsTab = True
        MainTextBox.Caret.HighlightCurrentLine = (Convert.ToByte(GetOption("HIGHLIGHT_CURRENT_LINE")) = 1)
        'MsgError("""" + ScriptName + """")
        ScriptContent = PathToString(SessionPath + "Scripts\" + ScriptName + ".dbas")
        MainTextBox.Text = ScriptContent
        Me.Text = ScriptName
        NameTextBox.Text = ScriptName
        TidyUp()
        Dim XDSLine As String = GetXDSLine("SCRIPT " + ScriptName + ",")
        XDSLine = XDSLine.Substring(XDSLine.LastIndexOf(",") + 1)
        ParseDBASChecker.Checked = (XDSLine = "1")
        For Each X As String In GetXDSFilter("SCRIPTARG " + ScriptName + ",")
            Dim TheName As String = iGet(X, 1, ",")
            Dim TheType As String = iGet(X, 2, ",")
            ArgumentNames.Add(TheName)
            ArgumentTypes.Add(TheType)
        Next
        ArrayToControl()
        UpdateLineStats()
    End Sub

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        'TODO LATER - after renaming, update references to this in:
        'Other scripts, actions in events.
        Dim NewName As String = NameTextBox.Text
        If Not ScriptName = NewName Then
            If GUIResNameChecker(NameTextBox.Text) Then Exit Sub
        End If
        SaveChanges()
        Me.Close()
    End Sub

    Sub UpdateLineStats()
        StatsLabel.Text = "Ln " + MainTextBox.Caret.LineNumber.ToString + " : "
        StatsLabel.Text += MainTextBox.Lines.Count.ToString + "   Col " + MainTextBox.GetColumn(MainTextBox.CurrentPos).ToString
        StatsLabel.Text += "   Sel " + MainTextBox.Selection.Start.ToString
    End Sub

    Private Sub NameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NameTextBox.TextChanged
        If DoIt Then
            Dim NewText As String = DirectCast(sender, TextBox).Text
            NewText = ResurrectResourceName(NewText)
            Dim LengthDifference As Int16 = DirectCast(sender, TextBox).Text.Length - NewText.Length
            Dim BackupCaret As Byte = NameTextBox.SelectionStart
            DirectCast(sender, TextBox).Text = NewText
            NameTextBox.SelectionStart = BackupCaret - LengthDifference
        Else
            DoIt = True
        End If
    End Sub

    Private Sub MainTextBox_LineStatCaller(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainTextBox.KeyDown, MainTextBox.MouseClick, MainTextBox.TextChanged
        UpdateLineStats()
    End Sub

    Private Sub MainTextBox_KeyUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainTextBox.KeyUp
        'Dim TheLine As String = MainTextBox.Lines.Current.Text.Replace(vbcrlf, String.Empty)
        'If TheLine.Length > 0 Then
        '    For i As Byte = 0 To 200
        '        If TheLine(0).ToString = " " Then TheLine = TheLine.Substring(1) Else Exit For
        '    Next
        'Else
        '    WhatsDone = String.Empty
        '    UpdateFunctionAssist()
        '    Exit Sub
        'End If
        'If TheLine.StartsWith("If Not ") Then TheLine = TheLine.Substring(7)
        'If TheLine.StartsWith("If ") Then TheLine = TheLine.Substring(3)
        'If TheLine.Contains("(") Then
        '    'Bracketed off, so remember what they did.
        '    WhatsDone = TheLine.Substring(0, TheLine.LastIndexOf("("))
        '    UpdateFunctionAssist()
        'End If
        'FunctionsList.Items.Clear()
        'For Each X As String In FunctionNames
        '    If TheLine.Length > 0 Then
        '        If X.StartsWith(TheLine) Then FunctionsList.Items.Add(X)
        '    Else
        '        FunctionsList.Items.Add(X)
        '    End If
        'Next
        'If FunctionsList.Items.Count > 0 Then
        '    FunctionsList.SelectedIndex = 0
        'Else
        '    FunctionDescriptionLabel.Text = String.Empty
        'End If
    End Sub

    Sub TidyUp()
        ArgumentNames.Clear()
        ArgumentTypes.Clear()
        ArgumentsList.Items.Clear()
    End Sub

    Sub ArrayToControl()
        ArgumentsList.Items.Clear()
        If ArgumentNames.Count > 0 Then
            For P As Byte = 0 To ArgumentNames.Count - 1
                ArgumentsList.Items.Add(P)
            Next
        End If
    End Sub

    Private Sub LoadInButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadInButton.Click
        Dim MsgResponse As Byte = MessageBox.Show("Importing a Script will erase and replace the current code." + vbcrlf + vbcrlf + "Would you like to Continue?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Not MsgResponse = MsgBoxResult.Yes Then Exit Sub
        Dim Response As String = OpenFile(String.Empty, "Dynamic Basic Files|*.dbas")
        If Response.Length = 0 Then Exit Sub
        Dim Content As String = PathToString(Response)
        Dim FinalContent As String = String.Empty
        TidyUp()
        For Each X As String In StringToLines(Content)
            If X.StartsWith("SCRIPTARG ") Then
                X = X.Substring(10)
                Dim TheName As String = X.Substring(0, X.IndexOf(","))
                Dim TheType As String = X.Substring(X.IndexOf(",") + 1)
                ArgumentNames.Add(TheName)
                ArgumentTypes.Add(TheType)
            Else
                FinalContent += X + vbcrlf
            End If
        Next
        ArrayToControl()
        'If FinalContent.Length > 0 Then FinalContent = FinalContent.Substring(0, FinalContent.Length - 1)
        MainTextBox.Text = FinalContent
    End Sub

    Private Sub SaveOutButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveOutButton.Click
        Dim Response As String = SaveFile(String.Empty, "Dynamic Basic Files|*.dbas", ScriptName + ".dbas")
        If Response.Length = 0 Then Exit Sub
        Dim ToWrite As String = MainTextBox.Text + vbcrlf
        For P As Byte = 0 To ArgumentNames.Count - 1
            ToWrite += "SCRIPTARG " + ArgumentNames(P) + "," + ArgumentTypes(P) + vbcrlf
        Next
        If ToWrite.Length > 0 Then ToWrite = ToWrite.Substring(0, ToWrite.Length - 1)
        IO.File.WriteAllText(Response, ToWrite)
    End Sub

    'Private Sub PreviewCButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim ArgumentsString As String = String.Empty
    '    Dim ArgumentTypesString As String = String.Empty
    '    If ArgumentNames.Count > 0 Then
    '        For P As Byte = 0 To ArgumentNames.Count - 1
    '            ArgumentsString += ArgumentNames(P) + ","
    '            ArgumentTypesString += ArgumentTypes(P) + ","
    '        Next
    '        ArgumentsString = ArgumentsString.Substring(0, ArgumentsString.Length - 1)
    '        ArgumentTypesString = ArgumentTypesString.Substring(0, ArgumentTypesString.Length - 1)
    '    End If
    '    For Each X As Form In MainForm.MdiChildren
    '        If Not X.Text = "Outputted C Preview for " + ScriptName Then Continue For
    '        For Each SC As Control In X.Controls
    '            If Not SC.Name = "MainTextBox" Then Continue For
    '            If ParseDBASChecker.Checked Then
    '                DirectCast(SC, ScintillaNet.Scintilla).Text = ScriptParseFromContent(ScriptName, MainTextBox.Text, ArgumentsString, ArgumentTypesString, True, False)
    '            Else
    '                DirectCast(SC, ScintillaNet.Scintilla).Text = ScriptParseFromContent(ScriptName, MainTextBox.Text, ArgumentsString, ArgumentTypesString, True, False)
    '            End If
    '        Next
    '        X.Focus()
    '        Exit Sub
    '    Next
    '    Dim CodeForm As New EditCode
    '    With CodeForm
    '        .Text = "Outputted C Preview for " + ScriptName
    '        .ReturnableCode = ScriptParseFromContent(ScriptName, MainTextBox.Text, ArgumentsString, ArgumentTypesString, True, False)
    '        .StartPosition = FormStartPosition.WindowsDefaultLocation
    '        .CodeMode = CodeMode.C
    '    End With
    '    ShowInternalForm(CodeForm)
    'End Sub

    Private Sub InsertIntoCodeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertIntoCodeButton.Click
        If ArgumentsList.SelectedIndices.Count = 0 Then Exit Sub
        'Dim BackupPosition = MainTextBox.Caret.Position + ArgumentsListBox.Text.Length
        MainTextBox.InsertText(ArgumentNames(ArgumentsList.SelectedIndex))
        MainTextBox.Focus()
        'MainTextBox.Caret.Position = BackupPosition
    End Sub

    Private Sub AddArgumentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddArgumentButton.Click
        Dim ArgumentForm As New Argument
        With ArgumentForm
            .ArgumentName = String.Empty
            .ArgumentType = "Integer"
            .Text = "Add Argument"
            .IsAction = False
            If Not .ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
            If .ArgumentName.Length = 0 Then Exit Sub
        End With
        Dim NewName As String = ArgumentForm.ArgumentName
        Dim NewType As String = ArgumentForm.ArgumentType
        ArgumentForm.Dispose()
        If Not ValidateSomething(NewName, ValidateLevel.Tight) Then
            MsgWarn("You must enter a valid name for the new Argument.")
            Exit Sub
        End If
        If Not ValidateSomething(NewName, ValidateLevel.NumberStart) Then
            MsgWarn("An Argument name may not start with a number.")
            Exit Sub
        End If
        Dim AlreadyDone As Boolean = False
        For Each X As String In ArgumentNames
            If X = NewName Then AlreadyDone = True
        Next
        If AlreadyDone Then
            MsgError("There is already an Argument called '" + NewName + "'." + vbcrlf + vbcrlf + "You must choose another name.")
            Exit Sub
        End If
        ArgumentNames.Add(NewName)
        ArgumentTypes.Add(NewType)
        ArrayToControl()
    End Sub

    Private Sub EditArgumentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditArgumentButton.Click
        If ArgumentsList.SelectedIndices.Count = 0 Then Exit Sub
        Dim ID As Byte = ArgumentsList.SelectedIndex
        Dim ArgumentForm As New Argument
        With ArgumentForm
            .ArgumentName = ArgumentNames(ID)
            .ArgumentType = ArgumentTypes(ID)
            .Text = "Edit Argument"
            .IsAction = False
            If Not .ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
            If .ArgumentName.Length = 0 Then Exit Sub
        End With
        Dim NewName As String = ArgumentForm.ArgumentName
        Dim NewType As String = ArgumentForm.ArgumentType
        ArgumentForm.Dispose()
        If Not ValidateSomething(NewName, ValidateLevel.Tight) Then
            MsgWarn("You must enter a valid name for the Argument.") : Exit Sub
        End If
        If Not NewName = ArgumentNames(ID) Then
            Dim AlreadyDone As Boolean = False
            For Each X As String In ArgumentNames
                If X = NewName Then AlreadyDone = True
            Next
            If AlreadyDone Then MsgError("There is already an Argument called '" + NewName + "'." + vbcrlf + vbcrlf + "You must choose another name.") : Exit Sub
        End If
        ArgumentNames(ID) = NewName
        ArgumentTypes(ID) = NewType
        ArgumentsList.Refresh()
        MsgInfo(Application.ProductName + " cannot update your code to use the new Argument name." + vbcrlf + vbcrlf + "You must do this yourself.")
    End Sub

    Private Sub DeleteArgumentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteArgumentButton.Click
        If ArgumentsList.SelectedIndices.Count = 0 Then Exit Sub
        ArgumentNames.RemoveAt(ArgumentsList.SelectedIndex)
        ArgumentTypes.RemoveAt(ArgumentsList.SelectedIndex)
        ArrayToControl()
        'UX?
        'MsgInfo("You must update your code so that it no longer uses or references the deleted argument.")
    End Sub

    Private Sub MainTextBox_CharAdded(ByVal sender As System.Object, ByVal e As ScintillaNet.CharAddedEventArgs) Handles MainTextBox.CharAdded
        If Not e.Ch = ChrW(Keys.Return) Then Exit Sub
        IntelliSense(sender)
        'Dim pos As Int32 = MainTextBox.NativeInterface.GetCurrentPos()
        'Dim length As Int32 = pos - MainTextBox.NativeInterface.WordStartPosition(pos, True)
        'MainTextBox.AutoComplete.Show(length)
    End Sub

    Private Sub ArgumentsList_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ArgumentsList.DrawItem
        If e.Index < 0 Then Exit Sub
        Dim IsSelected As Boolean = False
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then IsSelected = True
        e.Graphics.FillRectangle(Brushes.White, e.Bounds)
        Dim TheName As String = ArgumentNames(e.Index)
        Dim TheType As String = ArgumentTypes(e.Index)
        Dim TF As New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim TW As Byte = e.Graphics.MeasureString(TheType, TF, e.Bounds.Size, StringFormat.GenericDefault, TheType.Length, 1).Width
        If IsSelected Then
            Dim x As New Drawing2D.LinearGradientBrush(New Rectangle(0, e.Bounds.X, e.Bounds.Width, 16), Color.FromArgb(64, 64, 64), Color.Black, LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(x, e.Bounds)
            e.Graphics.DrawString(TheName, TF, Brushes.White, 16, e.Bounds.Y + 1)
            e.Graphics.DrawString(TheType, TF, Brushes.LightGray, e.Bounds.Width - TW - 3, e.Bounds.Y + 1)
        Else
            e.Graphics.DrawString(TheName, TF, Brushes.Black, 16, e.Bounds.Y + 1)
            e.Graphics.DrawString(TheType, TF, Brushes.LightGray, e.Bounds.Width - TW - 3, e.Bounds.Y + 1)
        End If
        e.Graphics.DrawImageUnscaled(My.Resources.ArgumentIcon, New Point(0, e.Bounds.Y))
    End Sub

    Private Sub ArgumentsList_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles ArgumentsList.MeasureItem
        e.ItemHeight = 16
    End Sub

End Class