<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Options))
        Me.OpenLastProjectCheckBox = New System.Windows.Forms.CheckBox
        Me.MainTabControl = New System.Windows.Forms.TabControl
        Me.GeneralTabPage = New System.Windows.Forms.TabPage
        Me.HideOldActionsChecker = New System.Windows.Forms.CheckBox
        Me.CloseNewslineCheckBox = New System.Windows.Forms.CheckBox
        Me.RoomsGroupBox = New System.Windows.Forms.GroupBox
        Me.DefaultRoomHeightTB = New System.Windows.Forms.TextBox
        Me.DefaultRoomWidthTB = New System.Windows.Forms.TextBox
        Me.DefaultRoomHeightLabel = New System.Windows.Forms.Label
        Me.DefaultRoomWidthLabel = New System.Windows.Forms.Label
        Me.TransparentAnimationsCheckBox = New System.Windows.Forms.CheckBox
        Me.CodeEditorGroupBox = New System.Windows.Forms.GroupBox
        Me.MatchBracesCheckBox = New System.Windows.Forms.CheckBox
        Me.HighlightCurrentLineCheckBox = New System.Windows.Forms.CheckBox
        Me.EditorsTabPage = New System.Windows.Forms.TabPage
        Me.ScriptEditorGroupBox = New System.Windows.Forms.GroupBox
        Me.ScriptEditorBrowseButton = New System.Windows.Forms.Button
        Me.ScriptEditorTextBox = New System.Windows.Forms.TextBox
        Me.UseExternalScriptEditorRadioButton = New System.Windows.Forms.RadioButton
        Me.UseInternalScriptEditorRadioButton = New System.Windows.Forms.RadioButton
        Me.SoundEditorGroupBox = New System.Windows.Forms.GroupBox
        Me.SoundEditorBrowseButton = New System.Windows.Forms.Button
        Me.SoundEditorTextBox = New System.Windows.Forms.TextBox
        Me.ImageEditorGroupBox = New System.Windows.Forms.GroupBox
        Me.ImageEditorBrowseButton = New System.Windows.Forms.Button
        Me.ImageEditorTextBox = New System.Windows.Forms.TextBox
        Me.EmulatorTabPage = New System.Windows.Forms.TabPage
        Me.EmulatorInfoLabel = New System.Windows.Forms.Label
        Me.CustomEmulatorBrowseButton = New System.Windows.Forms.Button
        Me.CustomEmulatorTextBox = New System.Windows.Forms.TextBox
        Me.RunCustomExecutableRadioButton = New System.Windows.Forms.RadioButton
        Me.UseNOGBARadioButton = New System.Windows.Forms.RadioButton
        Me.StartupTabPage = New System.Windows.Forms.TabPage
        Me.ShowNewsCheckBox = New System.Windows.Forms.CheckBox
        Me.DOkayButton = New System.Windows.Forms.Button
        Me.ShrinkActionsListChecker = New System.Windows.Forms.CheckBox
        Me.MainTabControl.SuspendLayout()
        Me.GeneralTabPage.SuspendLayout()
        Me.RoomsGroupBox.SuspendLayout()
        Me.CodeEditorGroupBox.SuspendLayout()
        Me.EditorsTabPage.SuspendLayout()
        Me.ScriptEditorGroupBox.SuspendLayout()
        Me.SoundEditorGroupBox.SuspendLayout()
        Me.ImageEditorGroupBox.SuspendLayout()
        Me.EmulatorTabPage.SuspendLayout()
        Me.StartupTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenLastProjectCheckBox
        '
        Me.OpenLastProjectCheckBox.AutoSize = True
        Me.OpenLastProjectCheckBox.Location = New System.Drawing.Point(16, 16)
        Me.OpenLastProjectCheckBox.Name = "OpenLastProjectCheckBox"
        Me.OpenLastProjectCheckBox.Size = New System.Drawing.Size(198, 17)
        Me.OpenLastProjectCheckBox.TabIndex = 0
        Me.OpenLastProjectCheckBox.Text = "Open last loaded Project on Startup"
        Me.OpenLastProjectCheckBox.UseVisualStyleBackColor = True
        '
        'MainTabControl
        '
        Me.MainTabControl.Controls.Add(Me.GeneralTabPage)
        Me.MainTabControl.Controls.Add(Me.EditorsTabPage)
        Me.MainTabControl.Controls.Add(Me.EmulatorTabPage)
        Me.MainTabControl.Controls.Add(Me.StartupTabPage)
        Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainTabControl.Location = New System.Drawing.Point(0, 0)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(284, 309)
        Me.MainTabControl.TabIndex = 1
        '
        'GeneralTabPage
        '
        Me.GeneralTabPage.Controls.Add(Me.ShrinkActionsListChecker)
        Me.GeneralTabPage.Controls.Add(Me.HideOldActionsChecker)
        Me.GeneralTabPage.Controls.Add(Me.CloseNewslineCheckBox)
        Me.GeneralTabPage.Controls.Add(Me.RoomsGroupBox)
        Me.GeneralTabPage.Controls.Add(Me.TransparentAnimationsCheckBox)
        Me.GeneralTabPage.Controls.Add(Me.CodeEditorGroupBox)
        Me.GeneralTabPage.Location = New System.Drawing.Point(4, 22)
        Me.GeneralTabPage.Name = "GeneralTabPage"
        Me.GeneralTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.GeneralTabPage.Size = New System.Drawing.Size(276, 283)
        Me.GeneralTabPage.TabIndex = 0
        Me.GeneralTabPage.Text = "General"
        Me.GeneralTabPage.UseVisualStyleBackColor = True
        '
        'HideOldActionsChecker
        '
        Me.HideOldActionsChecker.AutoSize = True
        Me.HideOldActionsChecker.Location = New System.Drawing.Point(16, 210)
        Me.HideOldActionsChecker.Name = "HideOldActionsChecker"
        Me.HideOldActionsChecker.Size = New System.Drawing.Size(108, 17)
        Me.HideOldActionsChecker.TabIndex = 4
        Me.HideOldActionsChecker.Text = "Hide 'Old' Actions"
        Me.HideOldActionsChecker.UseVisualStyleBackColor = True
        '
        'CloseNewslineCheckBox
        '
        Me.CloseNewslineCheckBox.AutoSize = True
        Me.CloseNewslineCheckBox.Location = New System.Drawing.Point(16, 16)
        Me.CloseNewslineCheckBox.Name = "CloseNewslineCheckBox"
        Me.CloseNewslineCheckBox.Size = New System.Drawing.Size(213, 17)
        Me.CloseNewslineCheckBox.TabIndex = 3
        Me.CloseNewslineCheckBox.Text = "Close Newsline when opening a Project"
        Me.CloseNewslineCheckBox.UseVisualStyleBackColor = True
        '
        'RoomsGroupBox
        '
        Me.RoomsGroupBox.Controls.Add(Me.DefaultRoomHeightTB)
        Me.RoomsGroupBox.Controls.Add(Me.DefaultRoomWidthTB)
        Me.RoomsGroupBox.Controls.Add(Me.DefaultRoomHeightLabel)
        Me.RoomsGroupBox.Controls.Add(Me.DefaultRoomWidthLabel)
        Me.RoomsGroupBox.Location = New System.Drawing.Point(8, 137)
        Me.RoomsGroupBox.Name = "RoomsGroupBox"
        Me.RoomsGroupBox.Size = New System.Drawing.Size(260, 67)
        Me.RoomsGroupBox.TabIndex = 2
        Me.RoomsGroupBox.TabStop = False
        Me.RoomsGroupBox.Text = "Rooms"
        '
        'DefaultRoomHeightTB
        '
        Me.DefaultRoomHeightTB.Location = New System.Drawing.Point(156, 37)
        Me.DefaultRoomHeightTB.Name = "DefaultRoomHeightTB"
        Me.DefaultRoomHeightTB.Size = New System.Drawing.Size(52, 21)
        Me.DefaultRoomHeightTB.TabIndex = 5
        '
        'DefaultRoomWidthTB
        '
        Me.DefaultRoomWidthTB.Location = New System.Drawing.Point(156, 14)
        Me.DefaultRoomWidthTB.Name = "DefaultRoomWidthTB"
        Me.DefaultRoomWidthTB.Size = New System.Drawing.Size(52, 21)
        Me.DefaultRoomWidthTB.TabIndex = 3
        '
        'DefaultRoomHeightLabel
        '
        Me.DefaultRoomHeightLabel.AutoSize = True
        Me.DefaultRoomHeightLabel.Location = New System.Drawing.Point(11, 40)
        Me.DefaultRoomHeightLabel.Name = "DefaultRoomHeightLabel"
        Me.DefaultRoomHeightLabel.Size = New System.Drawing.Size(110, 13)
        Me.DefaultRoomHeightLabel.TabIndex = 4
        Me.DefaultRoomHeightLabel.Text = "Default Room Height:"
        '
        'DefaultRoomWidthLabel
        '
        Me.DefaultRoomWidthLabel.AutoSize = True
        Me.DefaultRoomWidthLabel.Location = New System.Drawing.Point(10, 17)
        Me.DefaultRoomWidthLabel.Name = "DefaultRoomWidthLabel"
        Me.DefaultRoomWidthLabel.Size = New System.Drawing.Size(107, 13)
        Me.DefaultRoomWidthLabel.TabIndex = 3
        Me.DefaultRoomWidthLabel.Text = "Default Room Width:"
        '
        'TransparentAnimationsCheckBox
        '
        Me.TransparentAnimationsCheckBox.AutoSize = True
        Me.TransparentAnimationsCheckBox.Location = New System.Drawing.Point(16, 39)
        Me.TransparentAnimationsCheckBox.Name = "TransparentAnimationsCheckBox"
        Me.TransparentAnimationsCheckBox.Size = New System.Drawing.Size(251, 17)
        Me.TransparentAnimationsCheckBox.TabIndex = 2
        Me.TransparentAnimationsCheckBox.Text = "Use Transparency in Sprite Animation Previews"
        Me.TransparentAnimationsCheckBox.UseVisualStyleBackColor = True
        '
        'CodeEditorGroupBox
        '
        Me.CodeEditorGroupBox.Controls.Add(Me.MatchBracesCheckBox)
        Me.CodeEditorGroupBox.Controls.Add(Me.HighlightCurrentLineCheckBox)
        Me.CodeEditorGroupBox.Location = New System.Drawing.Point(8, 64)
        Me.CodeEditorGroupBox.Name = "CodeEditorGroupBox"
        Me.CodeEditorGroupBox.Size = New System.Drawing.Size(260, 67)
        Me.CodeEditorGroupBox.TabIndex = 1
        Me.CodeEditorGroupBox.TabStop = False
        Me.CodeEditorGroupBox.Text = "Code Editor && Viewer"
        '
        'MatchBracesCheckBox
        '
        Me.MatchBracesCheckBox.AutoSize = True
        Me.MatchBracesCheckBox.Location = New System.Drawing.Point(8, 43)
        Me.MatchBracesCheckBox.Name = "MatchBracesCheckBox"
        Me.MatchBracesCheckBox.Size = New System.Drawing.Size(90, 17)
        Me.MatchBracesCheckBox.TabIndex = 1
        Me.MatchBracesCheckBox.Text = "Match Braces"
        Me.MatchBracesCheckBox.UseVisualStyleBackColor = True
        '
        'HighlightCurrentLineCheckBox
        '
        Me.HighlightCurrentLineCheckBox.AutoSize = True
        Me.HighlightCurrentLineCheckBox.Location = New System.Drawing.Point(8, 20)
        Me.HighlightCurrentLineCheckBox.Name = "HighlightCurrentLineCheckBox"
        Me.HighlightCurrentLineCheckBox.Size = New System.Drawing.Size(131, 17)
        Me.HighlightCurrentLineCheckBox.TabIndex = 0
        Me.HighlightCurrentLineCheckBox.Text = "Highlight Working Line"
        Me.HighlightCurrentLineCheckBox.UseVisualStyleBackColor = True
        '
        'EditorsTabPage
        '
        Me.EditorsTabPage.Controls.Add(Me.ScriptEditorGroupBox)
        Me.EditorsTabPage.Controls.Add(Me.SoundEditorGroupBox)
        Me.EditorsTabPage.Controls.Add(Me.ImageEditorGroupBox)
        Me.EditorsTabPage.Location = New System.Drawing.Point(4, 22)
        Me.EditorsTabPage.Name = "EditorsTabPage"
        Me.EditorsTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.EditorsTabPage.Size = New System.Drawing.Size(276, 283)
        Me.EditorsTabPage.TabIndex = 1
        Me.EditorsTabPage.Text = "Editors"
        Me.EditorsTabPage.UseVisualStyleBackColor = True
        '
        'ScriptEditorGroupBox
        '
        Me.ScriptEditorGroupBox.Controls.Add(Me.ScriptEditorBrowseButton)
        Me.ScriptEditorGroupBox.Controls.Add(Me.ScriptEditorTextBox)
        Me.ScriptEditorGroupBox.Controls.Add(Me.UseExternalScriptEditorRadioButton)
        Me.ScriptEditorGroupBox.Controls.Add(Me.UseInternalScriptEditorRadioButton)
        Me.ScriptEditorGroupBox.Location = New System.Drawing.Point(8, 130)
        Me.ScriptEditorGroupBox.Name = "ScriptEditorGroupBox"
        Me.ScriptEditorGroupBox.Size = New System.Drawing.Size(260, 102)
        Me.ScriptEditorGroupBox.TabIndex = 4
        Me.ScriptEditorGroupBox.TabStop = False
        Me.ScriptEditorGroupBox.Text = "Script Editor"
        '
        'ScriptEditorBrowseButton
        '
        Me.ScriptEditorBrowseButton.Location = New System.Drawing.Point(221, 70)
        Me.ScriptEditorBrowseButton.Name = "ScriptEditorBrowseButton"
        Me.ScriptEditorBrowseButton.Size = New System.Drawing.Size(33, 23)
        Me.ScriptEditorBrowseButton.TabIndex = 3
        Me.ScriptEditorBrowseButton.Text = "..."
        Me.ScriptEditorBrowseButton.UseVisualStyleBackColor = True
        '
        'ScriptEditorTextBox
        '
        Me.ScriptEditorTextBox.Location = New System.Drawing.Point(12, 71)
        Me.ScriptEditorTextBox.Name = "ScriptEditorTextBox"
        Me.ScriptEditorTextBox.Size = New System.Drawing.Size(203, 21)
        Me.ScriptEditorTextBox.TabIndex = 2
        '
        'UseExternalScriptEditorRadioButton
        '
        Me.UseExternalScriptEditorRadioButton.AutoSize = True
        Me.UseExternalScriptEditorRadioButton.Location = New System.Drawing.Point(12, 46)
        Me.UseExternalScriptEditorRadioButton.Name = "UseExternalScriptEditorRadioButton"
        Me.UseExternalScriptEditorRadioButton.Size = New System.Drawing.Size(117, 17)
        Me.UseExternalScriptEditorRadioButton.TabIndex = 2
        Me.UseExternalScriptEditorRadioButton.TabStop = True
        Me.UseExternalScriptEditorRadioButton.Text = "Use External Editor"
        Me.UseExternalScriptEditorRadioButton.UseVisualStyleBackColor = True
        '
        'UseInternalScriptEditorRadioButton
        '
        Me.UseInternalScriptEditorRadioButton.AutoSize = True
        Me.UseInternalScriptEditorRadioButton.Location = New System.Drawing.Point(12, 20)
        Me.UseInternalScriptEditorRadioButton.Name = "UseInternalScriptEditorRadioButton"
        Me.UseInternalScriptEditorRadioButton.Size = New System.Drawing.Size(115, 17)
        Me.UseInternalScriptEditorRadioButton.TabIndex = 0
        Me.UseInternalScriptEditorRadioButton.TabStop = True
        Me.UseInternalScriptEditorRadioButton.Text = "Use Internal Editor"
        Me.UseInternalScriptEditorRadioButton.UseVisualStyleBackColor = True
        '
        'SoundEditorGroupBox
        '
        Me.SoundEditorGroupBox.Controls.Add(Me.SoundEditorBrowseButton)
        Me.SoundEditorGroupBox.Controls.Add(Me.SoundEditorTextBox)
        Me.SoundEditorGroupBox.Location = New System.Drawing.Point(8, 68)
        Me.SoundEditorGroupBox.Name = "SoundEditorGroupBox"
        Me.SoundEditorGroupBox.Size = New System.Drawing.Size(260, 56)
        Me.SoundEditorGroupBox.TabIndex = 1
        Me.SoundEditorGroupBox.TabStop = False
        Me.SoundEditorGroupBox.Text = "Sound Editor"
        '
        'SoundEditorBrowseButton
        '
        Me.SoundEditorBrowseButton.Location = New System.Drawing.Point(221, 19)
        Me.SoundEditorBrowseButton.Name = "SoundEditorBrowseButton"
        Me.SoundEditorBrowseButton.Size = New System.Drawing.Size(33, 23)
        Me.SoundEditorBrowseButton.TabIndex = 8
        Me.SoundEditorBrowseButton.Text = "..."
        Me.SoundEditorBrowseButton.UseVisualStyleBackColor = True
        '
        'SoundEditorTextBox
        '
        Me.SoundEditorTextBox.Location = New System.Drawing.Point(12, 20)
        Me.SoundEditorTextBox.Name = "SoundEditorTextBox"
        Me.SoundEditorTextBox.Size = New System.Drawing.Size(203, 21)
        Me.SoundEditorTextBox.TabIndex = 7
        '
        'ImageEditorGroupBox
        '
        Me.ImageEditorGroupBox.Controls.Add(Me.ImageEditorBrowseButton)
        Me.ImageEditorGroupBox.Controls.Add(Me.ImageEditorTextBox)
        Me.ImageEditorGroupBox.Location = New System.Drawing.Point(8, 6)
        Me.ImageEditorGroupBox.Name = "ImageEditorGroupBox"
        Me.ImageEditorGroupBox.Size = New System.Drawing.Size(260, 56)
        Me.ImageEditorGroupBox.TabIndex = 0
        Me.ImageEditorGroupBox.TabStop = False
        Me.ImageEditorGroupBox.Text = "Image Editor"
        '
        'ImageEditorBrowseButton
        '
        Me.ImageEditorBrowseButton.Location = New System.Drawing.Point(221, 19)
        Me.ImageEditorBrowseButton.Name = "ImageEditorBrowseButton"
        Me.ImageEditorBrowseButton.Size = New System.Drawing.Size(33, 21)
        Me.ImageEditorBrowseButton.TabIndex = 3
        Me.ImageEditorBrowseButton.Text = "..."
        Me.ImageEditorBrowseButton.UseVisualStyleBackColor = True
        '
        'ImageEditorTextBox
        '
        Me.ImageEditorTextBox.Location = New System.Drawing.Point(12, 20)
        Me.ImageEditorTextBox.Name = "ImageEditorTextBox"
        Me.ImageEditorTextBox.Size = New System.Drawing.Size(203, 21)
        Me.ImageEditorTextBox.TabIndex = 2
        '
        'EmulatorTabPage
        '
        Me.EmulatorTabPage.Controls.Add(Me.EmulatorInfoLabel)
        Me.EmulatorTabPage.Controls.Add(Me.CustomEmulatorBrowseButton)
        Me.EmulatorTabPage.Controls.Add(Me.CustomEmulatorTextBox)
        Me.EmulatorTabPage.Controls.Add(Me.RunCustomExecutableRadioButton)
        Me.EmulatorTabPage.Controls.Add(Me.UseNOGBARadioButton)
        Me.EmulatorTabPage.Location = New System.Drawing.Point(4, 22)
        Me.EmulatorTabPage.Name = "EmulatorTabPage"
        Me.EmulatorTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.EmulatorTabPage.Size = New System.Drawing.Size(276, 283)
        Me.EmulatorTabPage.TabIndex = 2
        Me.EmulatorTabPage.Text = "Emulator"
        Me.EmulatorTabPage.UseVisualStyleBackColor = True
        '
        'EmulatorInfoLabel
        '
        Me.EmulatorInfoLabel.BackColor = System.Drawing.SystemColors.Control
        Me.EmulatorInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EmulatorInfoLabel.Location = New System.Drawing.Point(18, 16)
        Me.EmulatorInfoLabel.Name = "EmulatorInfoLabel"
        Me.EmulatorInfoLabel.Padding = New System.Windows.Forms.Padding(4)
        Me.EmulatorInfoLabel.Size = New System.Drawing.Size(242, 44)
        Me.EmulatorInfoLabel.TabIndex = 6
        Me.EmulatorInfoLabel.Text = "You can test your game accurately on your computer to save time with an Emulator." & _
            ""
        Me.EmulatorInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CustomEmulatorBrowseButton
        '
        Me.CustomEmulatorBrowseButton.Location = New System.Drawing.Point(227, 120)
        Me.CustomEmulatorBrowseButton.Name = "CustomEmulatorBrowseButton"
        Me.CustomEmulatorBrowseButton.Size = New System.Drawing.Size(33, 23)
        Me.CustomEmulatorBrowseButton.TabIndex = 5
        Me.CustomEmulatorBrowseButton.Text = "..."
        Me.CustomEmulatorBrowseButton.UseVisualStyleBackColor = True
        '
        'CustomEmulatorTextBox
        '
        Me.CustomEmulatorTextBox.Location = New System.Drawing.Point(18, 122)
        Me.CustomEmulatorTextBox.Name = "CustomEmulatorTextBox"
        Me.CustomEmulatorTextBox.Size = New System.Drawing.Size(203, 21)
        Me.CustomEmulatorTextBox.TabIndex = 4
        '
        'RunCustomExecutableRadioButton
        '
        Me.RunCustomExecutableRadioButton.AutoSize = True
        Me.RunCustomExecutableRadioButton.Location = New System.Drawing.Point(18, 99)
        Me.RunCustomExecutableRadioButton.Name = "RunCustomExecutableRadioButton"
        Me.RunCustomExecutableRadioButton.Size = New System.Drawing.Size(139, 17)
        Me.RunCustomExecutableRadioButton.TabIndex = 2
        Me.RunCustomExecutableRadioButton.Text = "Run Custom Executable"
        Me.RunCustomExecutableRadioButton.UseVisualStyleBackColor = True
        '
        'UseNOGBARadioButton
        '
        Me.UseNOGBARadioButton.AutoSize = True
        Me.UseNOGBARadioButton.Checked = True
        Me.UseNOGBARadioButton.Location = New System.Drawing.Point(18, 74)
        Me.UseNOGBARadioButton.Name = "UseNOGBARadioButton"
        Me.UseNOGBARadioButton.Size = New System.Drawing.Size(139, 17)
        Me.UseNOGBARadioButton.TabIndex = 1
        Me.UseNOGBARadioButton.TabStop = True
        Me.UseNOGBARadioButton.Text = "Use NO$GBA (Included)"
        Me.UseNOGBARadioButton.UseVisualStyleBackColor = True
        '
        'StartupTabPage
        '
        Me.StartupTabPage.Controls.Add(Me.ShowNewsCheckBox)
        Me.StartupTabPage.Controls.Add(Me.OpenLastProjectCheckBox)
        Me.StartupTabPage.Location = New System.Drawing.Point(4, 22)
        Me.StartupTabPage.Name = "StartupTabPage"
        Me.StartupTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.StartupTabPage.Size = New System.Drawing.Size(276, 283)
        Me.StartupTabPage.TabIndex = 3
        Me.StartupTabPage.Text = "Startup"
        Me.StartupTabPage.UseVisualStyleBackColor = True
        '
        'ShowNewsCheckBox
        '
        Me.ShowNewsCheckBox.AutoSize = True
        Me.ShowNewsCheckBox.Location = New System.Drawing.Point(16, 39)
        Me.ShowNewsCheckBox.Name = "ShowNewsCheckBox"
        Me.ShowNewsCheckBox.Size = New System.Drawing.Size(182, 17)
        Me.ShowNewsCheckBox.TabIndex = 1
        Me.ShowNewsCheckBox.Text = "Show DSGM Newsline on Startup"
        Me.ShowNewsCheckBox.UseVisualStyleBackColor = True
        '
        'DOkayButton
        '
        Me.DOkayButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DOkayButton.Location = New System.Drawing.Point(184, 311)
        Me.DOkayButton.Name = "DOkayButton"
        Me.DOkayButton.Size = New System.Drawing.Size(96, 28)
        Me.DOkayButton.TabIndex = 2
        Me.DOkayButton.Text = "OK"
        Me.DOkayButton.UseVisualStyleBackColor = True
        '
        'ShrinkActionsListChecker
        '
        Me.ShrinkActionsListChecker.AutoSize = True
        Me.ShrinkActionsListChecker.Location = New System.Drawing.Point(16, 233)
        Me.ShrinkActionsListChecker.Name = "ShrinkActionsListChecker"
        Me.ShrinkActionsListChecker.Size = New System.Drawing.Size(112, 17)
        Me.ShrinkActionsListChecker.TabIndex = 5
        Me.ShrinkActionsListChecker.Text = "Shrink Actions List"
        Me.ShrinkActionsListChecker.UseVisualStyleBackColor = True
        '
        'Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 344)
        Me.Controls.Add(Me.DOkayButton)
        Me.Controls.Add(Me.MainTabControl)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Options"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.MainTabControl.ResumeLayout(False)
        Me.GeneralTabPage.ResumeLayout(False)
        Me.GeneralTabPage.PerformLayout()
        Me.RoomsGroupBox.ResumeLayout(False)
        Me.RoomsGroupBox.PerformLayout()
        Me.CodeEditorGroupBox.ResumeLayout(False)
        Me.CodeEditorGroupBox.PerformLayout()
        Me.EditorsTabPage.ResumeLayout(False)
        Me.ScriptEditorGroupBox.ResumeLayout(False)
        Me.ScriptEditorGroupBox.PerformLayout()
        Me.SoundEditorGroupBox.ResumeLayout(False)
        Me.SoundEditorGroupBox.PerformLayout()
        Me.ImageEditorGroupBox.ResumeLayout(False)
        Me.ImageEditorGroupBox.PerformLayout()
        Me.EmulatorTabPage.ResumeLayout(False)
        Me.EmulatorTabPage.PerformLayout()
        Me.StartupTabPage.ResumeLayout(False)
        Me.StartupTabPage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenLastProjectCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents GeneralTabPage As System.Windows.Forms.TabPage
    Friend WithEvents EditorsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents DOkayButton As System.Windows.Forms.Button
    Friend WithEvents ImageEditorGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents SoundEditorGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ImageEditorBrowseButton As System.Windows.Forms.Button
    Friend WithEvents ImageEditorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SoundEditorBrowseButton As System.Windows.Forms.Button
    Friend WithEvents SoundEditorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ScriptEditorGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ScriptEditorBrowseButton As System.Windows.Forms.Button
    Friend WithEvents ScriptEditorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UseExternalScriptEditorRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents UseInternalScriptEditorRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents HighlightCurrentLineCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CodeEditorGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents MatchBracesCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TransparentAnimationsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents RoomsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents DefaultRoomHeightLabel As System.Windows.Forms.Label
    Friend WithEvents DefaultRoomWidthLabel As System.Windows.Forms.Label
    Friend WithEvents DefaultRoomHeightTB As System.Windows.Forms.TextBox
    Friend WithEvents DefaultRoomWidthTB As System.Windows.Forms.TextBox
    Friend WithEvents EmulatorTabPage As System.Windows.Forms.TabPage
    Friend WithEvents UseNOGBARadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents RunCustomExecutableRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents CustomEmulatorBrowseButton As System.Windows.Forms.Button
    Friend WithEvents CustomEmulatorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmulatorInfoLabel As System.Windows.Forms.Label
    Friend WithEvents StartupTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ShowNewsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CloseNewslineCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents HideOldActionsChecker As System.Windows.Forms.CheckBox
    Friend WithEvents ShrinkActionsListChecker As System.Windows.Forms.CheckBox
End Class
