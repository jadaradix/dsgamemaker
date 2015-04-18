<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Script
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Script))
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.DAcceptButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.UndoButton = New System.Windows.Forms.ToolStripButton()
        Me.RedoButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolSep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.LoadInButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveOutButton = New System.Windows.Forms.ToolStripButton()
        Me.MainStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.StatsLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SpacesLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.FunctionLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MainTextBox = New ScintillaNet.Scintilla()
        Me.SidePanel = New System.Windows.Forms.Panel()
        Me.ParseDBASChecker = New System.Windows.Forms.CheckBox()
        Me.ArgumentsList = New System.Windows.Forms.ListBox()
        Me.EditArgumentButton = New System.Windows.Forms.Button()
        Me.AddArgumentButton = New System.Windows.Forms.Button()
        Me.DeleteArgumentButton = New System.Windows.Forms.Button()
        Me.InsertIntoCodeButton = New System.Windows.Forms.Button()
        Me.ArgumentsLabel = New System.Windows.Forms.Label()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.MainToolStrip.SuspendLayout()
        Me.MainStatusStrip.SuspendLayout()
        CType(Me.MainTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SidePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton, Me.ToolSep1, Me.UndoButton, Me.RedoButton, Me.ToolSep3, Me.LoadInButton, Me.SaveOutButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(544, 25)
        Me.MainToolStrip.TabIndex = 0
        Me.MainToolStrip.Text = "ToolStrip1"
        '
        'DAcceptButton
        '
        Me.DAcceptButton.Image = Global.DS_Game_Maker.My.Resources.Resources.AcceptIcon
        Me.DAcceptButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DAcceptButton.Name = "DAcceptButton"
        Me.DAcceptButton.Size = New System.Drawing.Size(60, 22)
        Me.DAcceptButton.Text = "Accept"
        '
        'ToolSep1
        '
        Me.ToolSep1.Name = "ToolSep1"
        Me.ToolSep1.Size = New System.Drawing.Size(6, 25)
        '
        'UndoButton
        '
        Me.UndoButton.Image = Global.DS_Game_Maker.My.Resources.Resources.UndoIcon
        Me.UndoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UndoButton.Name = "UndoButton"
        Me.UndoButton.Size = New System.Drawing.Size(55, 22)
        Me.UndoButton.Text = " Undo"
        '
        'RedoButton
        '
        Me.RedoButton.Image = Global.DS_Game_Maker.My.Resources.Resources.RedoIcon
        Me.RedoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RedoButton.Name = "RedoButton"
        Me.RedoButton.Size = New System.Drawing.Size(55, 22)
        Me.RedoButton.Text = "Redo "
        '
        'ToolSep3
        '
        Me.ToolSep3.Name = "ToolSep3"
        Me.ToolSep3.Size = New System.Drawing.Size(6, 25)
        '
        'LoadInButton
        '
        Me.LoadInButton.Image = Global.DS_Game_Maker.My.Resources.Resources.OpenIcon
        Me.LoadInButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadInButton.Name = "LoadInButton"
        Me.LoadInButton.Size = New System.Drawing.Size(75, 22)
        Me.LoadInButton.Text = "Load In..."
        '
        'SaveOutButton
        '
        Me.SaveOutButton.Image = Global.DS_Game_Maker.My.Resources.Resources.SaveIcon
        Me.SaveOutButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveOutButton.Name = "SaveOutButton"
        Me.SaveOutButton.Size = New System.Drawing.Size(84, 22)
        Me.SaveOutButton.Text = "Save Out..."
        '
        'MainStatusStrip
        '
        Me.MainStatusStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatsLabel, Me.SpacesLabel, Me.FunctionLabel})
        Me.MainStatusStrip.Location = New System.Drawing.Point(0, 477)
        Me.MainStatusStrip.Name = "MainStatusStrip"
        Me.MainStatusStrip.Size = New System.Drawing.Size(544, 26)
        Me.MainStatusStrip.TabIndex = 1
        Me.MainStatusStrip.Text = "StatusStrip1"
        '
        'StatsLabel
        '
        Me.StatsLabel.Name = "StatsLabel"
        Me.StatsLabel.Padding = New System.Windows.Forms.Padding(4)
        Me.StatsLabel.Size = New System.Drawing.Size(19, 21)
        Me.StatsLabel.Text = "-"
        '
        'SpacesLabel
        '
        Me.SpacesLabel.Name = "SpacesLabel"
        Me.SpacesLabel.Padding = New System.Windows.Forms.Padding(4)
        Me.SpacesLabel.Size = New System.Drawing.Size(21, 21)
        Me.SpacesLabel.Text = "  "
        '
        'FunctionLabel
        '
        Me.FunctionLabel.AutoSize = False
        Me.FunctionLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FunctionLabel.Name = "FunctionLabel"
        Me.FunctionLabel.Padding = New System.Windows.Forms.Padding(4)
        Me.FunctionLabel.Size = New System.Drawing.Size(300, 21)
        Me.FunctionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MainTextBox
        '
        Me.MainTextBox.ConfigurationManager.Language = "vbscript"
        Me.MainTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTextBox.IsBraceMatching = True
        Me.MainTextBox.Location = New System.Drawing.Point(196, 25)
        Me.MainTextBox.Margins.Margin0.Width = 20
        Me.MainTextBox.Name = "MainTextBox"
        Me.MainTextBox.Scrolling.HorizontalWidth = 1000
        Me.MainTextBox.Size = New System.Drawing.Size(348, 452)
        Me.MainTextBox.Styles.BraceBad.FontName = "Verdana"
        Me.MainTextBox.Styles.BraceLight.FontName = "Verdana"
        Me.MainTextBox.Styles.ControlChar.FontName = "Verdana"
        Me.MainTextBox.Styles.Default.FontName = "Verdana"
        Me.MainTextBox.Styles.IndentGuide.FontName = "Verdana"
        Me.MainTextBox.Styles.LastPredefined.FontName = "Verdana"
        Me.MainTextBox.Styles.LineNumber.FontName = "Verdana"
        Me.MainTextBox.Styles.Max.FontName = "Verdana"
        Me.MainTextBox.TabIndex = 4
        '
        'SidePanel
        '
        Me.SidePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.SidePanel.Controls.Add(Me.ParseDBASChecker)
        Me.SidePanel.Controls.Add(Me.ArgumentsList)
        Me.SidePanel.Controls.Add(Me.EditArgumentButton)
        Me.SidePanel.Controls.Add(Me.AddArgumentButton)
        Me.SidePanel.Controls.Add(Me.DeleteArgumentButton)
        Me.SidePanel.Controls.Add(Me.InsertIntoCodeButton)
        Me.SidePanel.Controls.Add(Me.ArgumentsLabel)
        Me.SidePanel.Controls.Add(Me.NameLabel)
        Me.SidePanel.Controls.Add(Me.NameTextBox)
        Me.SidePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.SidePanel.Location = New System.Drawing.Point(0, 25)
        Me.SidePanel.Name = "SidePanel"
        Me.SidePanel.Size = New System.Drawing.Size(196, 452)
        Me.SidePanel.TabIndex = 5
        '
        'ParseDBASChecker
        '
        Me.ParseDBASChecker.AutoSize = True
        Me.ParseDBASChecker.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ParseDBASChecker.Location = New System.Drawing.Point(96, 259)
        Me.ParseDBASChecker.Name = "ParseDBASChecker"
        Me.ParseDBASChecker.Size = New System.Drawing.Size(87, 17)
        Me.ParseDBASChecker.TabIndex = 6
        Me.ParseDBASChecker.Text = "Parse DBAS?"
        Me.ParseDBASChecker.UseVisualStyleBackColor = True
        '
        'ArgumentsList
        '
        Me.ArgumentsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ArgumentsList.FormattingEnabled = True
        Me.ArgumentsList.ItemHeight = 16
        Me.ArgumentsList.Location = New System.Drawing.Point(13, 78)
        Me.ArgumentsList.Name = "ArgumentsList"
        Me.ArgumentsList.Size = New System.Drawing.Size(170, 148)
        Me.ArgumentsList.TabIndex = 6
        '
        'EditArgumentButton
        '
        Me.EditArgumentButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PencilIcon
        Me.EditArgumentButton.Location = New System.Drawing.Point(44, 227)
        Me.EditArgumentButton.Name = "EditArgumentButton"
        Me.EditArgumentButton.Size = New System.Drawing.Size(30, 26)
        Me.EditArgumentButton.TabIndex = 14
        Me.EditArgumentButton.UseVisualStyleBackColor = True
        '
        'AddArgumentButton
        '
        Me.AddArgumentButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PlusIcon
        Me.AddArgumentButton.Location = New System.Drawing.Point(13, 227)
        Me.AddArgumentButton.Name = "AddArgumentButton"
        Me.AddArgumentButton.Size = New System.Drawing.Size(30, 26)
        Me.AddArgumentButton.TabIndex = 13
        Me.AddArgumentButton.UseVisualStyleBackColor = True
        '
        'DeleteArgumentButton
        '
        Me.DeleteArgumentButton.Image = Global.DS_Game_Maker.My.Resources.Resources.DeleteIcon
        Me.DeleteArgumentButton.Location = New System.Drawing.Point(75, 227)
        Me.DeleteArgumentButton.Name = "DeleteArgumentButton"
        Me.DeleteArgumentButton.Size = New System.Drawing.Size(30, 26)
        Me.DeleteArgumentButton.TabIndex = 6
        Me.DeleteArgumentButton.UseVisualStyleBackColor = True
        '
        'InsertIntoCodeButton
        '
        Me.InsertIntoCodeButton.Image = Global.DS_Game_Maker.My.Resources.Resources.ArrowFadeRightIcon
        Me.InsertIntoCodeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.InsertIntoCodeButton.Location = New System.Drawing.Point(108, 227)
        Me.InsertIntoCodeButton.Name = "InsertIntoCodeButton"
        Me.InsertIntoCodeButton.Size = New System.Drawing.Size(76, 26)
        Me.InsertIntoCodeButton.TabIndex = 8
        Me.InsertIntoCodeButton.Text = "    Insert"
        Me.InsertIntoCodeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.InsertIntoCodeButton.UseVisualStyleBackColor = True
        '
        'ArgumentsLabel
        '
        Me.ArgumentsLabel.AutoSize = True
        Me.ArgumentsLabel.Location = New System.Drawing.Point(10, 62)
        Me.ArgumentsLabel.Name = "ArgumentsLabel"
        Me.ArgumentsLabel.Size = New System.Drawing.Size(63, 13)
        Me.ArgumentsLabel.TabIndex = 4
        Me.ArgumentsLabel.Text = "Arguments:"
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(10, 13)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(38, 13)
        Me.NameLabel.TabIndex = 2
        Me.NameLabel.Text = "Name:"
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(13, 29)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(170, 21)
        Me.NameTextBox.TabIndex = 1
        '
        'Script
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 503)
        Me.Controls.Add(Me.MainTextBox)
        Me.Controls.Add(Me.SidePanel)
        Me.Controls.Add(Me.MainStatusStrip)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(560, 350)
        Me.Name = "Script"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.MainStatusStrip.ResumeLayout(False)
        Me.MainStatusStrip.PerformLayout()
        CType(Me.MainTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SidePanel.ResumeLayout(False)
        Me.SidePanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents MainStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents StatsLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LoadInButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveOutButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents MainTextBox As ScintillaNet.Scintilla
    Friend WithEvents SidePanel As System.Windows.Forms.Panel
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents ToolSep3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ArgumentsLabel As System.Windows.Forms.Label
    Friend WithEvents InsertIntoCodeButton As System.Windows.Forms.Button
    Friend WithEvents EditArgumentButton As System.Windows.Forms.Button
    Friend WithEvents AddArgumentButton As System.Windows.Forms.Button
    Friend WithEvents DeleteArgumentButton As System.Windows.Forms.Button
    Friend WithEvents FunctionLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SpacesLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ArgumentsList As System.Windows.Forms.ListBox
    Friend WithEvents ParseDBASChecker As System.Windows.Forms.CheckBox
    Friend WithEvents UndoButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents RedoButton As System.Windows.Forms.ToolStripButton
End Class
