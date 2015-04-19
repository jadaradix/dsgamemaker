Imports System.IO
Public Class Options

    Private Sub DOkayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOkayButton.Click
        If DefaultRoomWidthTB.Text.Length = 0 Or DefaultRoomHeightTB.Text.Length = 0 Then
            MsgWarn("You must enter values for the Default Room Width and Height.")
            If DefaultRoomHeightTB.Text.Length = 0 Then DefaultRoomHeightTB.Focus()
            If DefaultRoomWidthTB.Text.Length = 0 Then DefaultRoomWidthTB.Focus()
            Exit Sub
        End If
        Dim IsNumber As Boolean = True
        For Each X As String In DefaultRoomWidthTB.Text
            If Not Numbers.Contains(X) Then IsNumber = False
        Next
        If Not IsNumber Then
            MsgWarn("Default Room Width must be a number.")
            DefaultRoomWidthTB.Focus()
            Exit Sub
        End If
        IsNumber = True
        For Each X As String In DefaultRoomHeightTB.Text
            If Not Numbers.Contains(X) Then IsNumber = False
        Next
        If Not IsNumber Then
            MsgWarn("Default Room Height must be a number.")
            DefaultRoomHeightTB.Focus()
            Exit Sub
        End If
        If Convert.ToInt16(DefaultRoomWidthTB.Text) < 256 Or Convert.ToInt16(DefaultRoomWidthTB.Text) > 4096 Then
            MsgWarn("Default Room Width must be between 256 and 4096.")
            DefaultRoomWidthTB.Focus()
            Exit Sub
        End If
        If Convert.ToInt16(DefaultRoomHeightTB.Text) < 192 Or Convert.ToInt16(DefaultRoomWidthTB.Text) > 4096 Then
            MsgWarn("Default Room Height must be between 192 and 4096.")
            DefaultRoomHeightTB.Focus()
            Exit Sub
        End If
        SetSetting("CLOSE_NEWS", If(CloseNewslineCheckBox.Checked, "1", "0"))
        SetSetting("OPEN_LAST_PROJECT_STARTUP", If(OpenLastProjectCheckBox.Checked, "1", "0"))
        SetSetting("SHOW_NEWS", If(ShowNewsCheckBox.Checked, "1", "0"))
        SetSetting("TRANSPARENT_ANIMATIONS", If(TransparentAnimationsCheckBox.Checked, "1", "0"))
        SetSetting("USE_NOGBA", If(UseNOGBARadioButton.Checked, "1", "0"))
        SetSetting("IMAGE_EDITOR_PATH", ImageEditorTextBox.Text)
        SetSetting("SOUND_EDITOR_PATH", SoundEditorTextBox.Text)
        SetSetting("USE_EXTERNAL_SCRIPT_EDITOR", If(UseExternalScriptEditorRadioButton.Checked, "1", "0"))
        SetSetting("HIGHLIGHT_CURRENT_LINE", If(HighlightCurrentLineCheckBox.Checked, "1", "0"))
        SetSetting("MATCH_BRACES", If(MatchBracesCheckBox.Checked, "1", "0"))
        SetSetting("HIDE_OLD_ACTIONS", If(HideOldActionsChecker.Checked, "1", "0"))
        SetSetting("SHRINK_ACTIONS_LIST", If(ShrinkActionsListChecker.Checked, "1", "0"))
        SetSetting("SCRIPT_EDITOR_PATH", ScriptEditorTextBox.Text)
        SetSetting("DEFAULT_ROOM_WIDTH", DefaultRoomWidthTB.Text)
        SetSetting("DEFAULT_ROOM_HEIGHT", DefaultRoomHeightTB.Text)
        SetSetting("EMULATOR_PATH", CustomEmulatorTextBox.Text)
        SaveSettings()
        For Each X As Form In MainForm.MdiChildren
            Dim TheText As String = X.Text
            If TheText.StartsWith("Outputted C Preview for ") Then
                TheText = TheText.Substring(24)
            End If
            If Not DoesXDSLineExist("SCRIPT " + TheText) Then Continue For
            For Each SC As Control In X.Controls
                If SC.Name = "MainTextBox" Then
                    DirectCast(SC, ScintillaNet.Scintilla).Caret.HighlightCurrentLine = HighlightCurrentLineCheckBox.Checked
                    DirectCast(SC, ScintillaNet.Scintilla).MatchBraces = MatchBracesCheckBox.Checked
                End If
            Next
        Next
        Me.Close()
    End Sub

    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CloseNewslineCheckBox.Checked = (GetSetting("CLOSE_NEWS") = "1")
        OpenLastProjectCheckBox.Checked = (GetSetting("OPEN_LAST_PROJECT_STARTUP") = "1")
        ShowNewsCheckBox.Checked = (GetSetting("SHOW_NEWS") = "1")
        HighlightCurrentLineCheckBox.Checked = (GetSetting("HIGHLIGHT_CURRENT_LINE") = "1")
        MatchBracesCheckBox.Checked = (GetSetting("MATCH_BRACES") = "1")
        TransparentAnimationsCheckBox.Checked = (GetSetting("TRANSPARENT_ANIMATIONS") = "1")
        UseNOGBARadioButton.Checked = (GetSetting("USE_NOGBA") = "1")
        ImageEditorTextBox.Text = GetSetting("IMAGE_EDITOR_PATH")
        SoundEditorTextBox.Text = GetSetting("SOUND_EDITOR_PATH")
        CustomEmulatorTextBox.Text = GetSetting("EMULATOR_PATH")
        If GetSetting("USE_EXTERNAL_SCRIPT_EDITOR") = "1" Then
            UseExternalScriptEditorRadioButton.Checked = True
            UseInternalScriptEditorRadioButton.Checked = False
        Else
            UseExternalScriptEditorRadioButton.Checked = False
            UseInternalScriptEditorRadioButton.Checked = True
        End If
        ScriptEditorTextBox.Text = GetSetting("SCRIPT_EDITOR_PATH")
        DefaultRoomWidthTB.Text = GetSetting("DEFAULT_ROOM_WIDTH")
        DefaultRoomHeightTB.Text = GetSetting("DEFAULT_ROOM_HEIGHT")
        HideOldActionsChecker.Checked = (GetSetting("HIDE_OLD_ACTIONS") = "1")
        ShrinkActionsListChecker.Checked = (GetSetting("SHRINK_ACTIONS_LIST") = "1")
    End Sub

    Private Sub ImageEditorBrowseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageEditorBrowseButton.Click
        ImageEditorTextBox.Text = OpenFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles, "Executables|*.exe")
    End Sub

    Private Sub SoundEditorBowseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoundEditorBrowseButton.Click
        SoundEditorTextBox.Text = OpenFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles, "Executables|*.exe")
    End Sub

    Private Sub ScriptEditorBowseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScriptEditorBrowseButton.Click
        ScriptEditorTextBox.Text = OpenFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles, "Executables|*.exe")
    End Sub

    Private Sub CustomEmulatorBrowseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomEmulatorBrowseButton.Click
        CustomEmulatorTextBox.Text = OpenFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles, "Executables|*.exe")
    End Sub
End Class