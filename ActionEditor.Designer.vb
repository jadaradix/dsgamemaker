<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActionEditor
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActionEditor))
        Me.ActionsTreeView = New System.Windows.Forms.TreeView()
        Me.MainImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.CloseButton = New System.Windows.Forms.ToolStripButton()
        Me.MainToolStripSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddActionButton = New System.Windows.Forms.ToolStripButton()
        Me.DeleteActionButton = New System.Windows.Forms.ToolStripButton()
        Me.FormattedDisplayLabel = New System.Windows.Forms.Label()
        Me.ListDisplayTextBox = New System.Windows.Forms.TextBox()
        Me.TypeDropper = New System.Windows.Forms.ComboBox()
        Me.MainTextBox = New ScintillaNet.Scintilla()
        Me.ActionPropertiesPanel = New System.Windows.Forms.Panel()
        Me.ConditionalDisplayChecker = New System.Windows.Forms.CheckBox()
        Me.DontRequestApplicationChecker = New System.Windows.Forms.CheckBox()
        Me.ImageDropper = New System.Windows.Forms.ComboBox()
        Me.IndentationGroupBox = New System.Windows.Forms.GroupBox()
        Me.InvertRadioButton = New System.Windows.Forms.RadioButton()
        Me.IndentRadioButton = New System.Windows.Forms.RadioButton()
        Me.GenericRadioButton = New System.Windows.Forms.RadioButton()
        Me.SubToolStrip = New System.Windows.Forms.ToolStrip()
        Me.SaveButton = New System.Windows.Forms.ToolStripButton()
        Me.SubToolStripSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddArgumentButton = New System.Windows.Forms.ToolStripButton()
        Me.EditArgumentButton = New System.Windows.Forms.ToolStripButton()
        Me.DeleteArgumentButton = New System.Windows.Forms.ToolStripButton()
        Me.InsertArgumentButton = New System.Windows.Forms.ToolStripButton()
        Me.ArgumentsLabel = New System.Windows.Forms.Label()
        Me.ArgumentsListView = New System.Windows.Forms.ListView()
        Me.NameColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TypeColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MainToolStrip.SuspendLayout()
        CType(Me.MainTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ActionPropertiesPanel.SuspendLayout()
        Me.IndentationGroupBox.SuspendLayout()
        Me.SubToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ActionsTreeView
        '
        Me.ActionsTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ActionsTreeView.Dock = System.Windows.Forms.DockStyle.Left
        Me.ActionsTreeView.Indent = 16
        Me.ActionsTreeView.ItemHeight = 19
        Me.ActionsTreeView.Location = New System.Drawing.Point(0, 25)
        Me.ActionsTreeView.Name = "ActionsTreeView"
        Me.ActionsTreeView.Size = New System.Drawing.Size(174, 457)
        Me.ActionsTreeView.TabIndex = 0
        '
        'MainImageList
        '
        Me.MainImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.MainImageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.MainImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(6, 40)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(112, 13)
        Me.NameLabel.TabIndex = 3
        Me.NameLabel.Text = "Name, Type && Image:"
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(6, 56)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(170, 21)
        Me.NameTextBox.TabIndex = 4
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseButton, Me.MainToolStripSep1, Me.AddActionButton, Me.DeleteActionButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(734, 25)
        Me.MainToolStrip.TabIndex = 5
        Me.MainToolStrip.Text = "ToolStrip1"
        '
        'CloseButton
        '
        Me.CloseButton.Image = Global.DS_Game_Maker.My.Resources.Resources.AcceptIcon
        Me.CloseButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(53, 22)
        Me.CloseButton.Text = "Close"
        '
        'MainToolStripSep1
        '
        Me.MainToolStripSep1.Name = "MainToolStripSep1"
        Me.MainToolStripSep1.Size = New System.Drawing.Size(6, 25)
        '
        'AddActionButton
        '
        Me.AddActionButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PlusIcon
        Me.AddActionButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddActionButton.Name = "AddActionButton"
        Me.AddActionButton.Size = New System.Drawing.Size(79, 22)
        Me.AddActionButton.Text = "Add Action"
        '
        'DeleteActionButton
        '
        Me.DeleteActionButton.Image = Global.DS_Game_Maker.My.Resources.Resources.DeleteIcon
        Me.DeleteActionButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteActionButton.Name = "DeleteActionButton"
        Me.DeleteActionButton.Size = New System.Drawing.Size(58, 22)
        Me.DeleteActionButton.Text = "Delete"
        Me.DeleteActionButton.ToolTipText = "Delete Action"
        '
        'FormattedDisplayLabel
        '
        Me.FormattedDisplayLabel.AutoSize = True
        Me.FormattedDisplayLabel.Location = New System.Drawing.Point(6, 114)
        Me.FormattedDisplayLabel.Name = "FormattedDisplayLabel"
        Me.FormattedDisplayLabel.Size = New System.Drawing.Size(64, 13)
        Me.FormattedDisplayLabel.TabIndex = 9
        Me.FormattedDisplayLabel.Text = "List Display:"
        '
        'ListDisplayTextBox
        '
        Me.ListDisplayTextBox.Location = New System.Drawing.Point(6, 130)
        Me.ListDisplayTextBox.Name = "ListDisplayTextBox"
        Me.ListDisplayTextBox.Size = New System.Drawing.Size(170, 21)
        Me.ListDisplayTextBox.TabIndex = 8
        '
        'TypeDropper
        '
        Me.TypeDropper.FormattingEnabled = True
        Me.TypeDropper.Location = New System.Drawing.Point(6, 81)
        Me.TypeDropper.Name = "TypeDropper"
        Me.TypeDropper.Size = New System.Drawing.Size(58, 21)
        Me.TypeDropper.TabIndex = 7
        '
        'MainTextBox
        '
        Me.MainTextBox.ConfigurationManager.Language = "cpp"
        Me.MainTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTextBox.IsBraceMatching = True
        Me.MainTextBox.Location = New System.Drawing.Point(174, 25)
        Me.MainTextBox.Margins.Margin0.Width = 20
        Me.MainTextBox.Name = "MainTextBox"
        Me.MainTextBox.Scrolling.HorizontalWidth = 1000
        Me.MainTextBox.Size = New System.Drawing.Size(379, 457)
        Me.MainTextBox.Styles.BraceBad.FontName = "Verdana"
        Me.MainTextBox.Styles.BraceLight.FontName = "Verdana"
        Me.MainTextBox.Styles.ControlChar.FontName = "Verdana"
        Me.MainTextBox.Styles.Default.FontName = "Verdana"
        Me.MainTextBox.Styles.IndentGuide.FontName = "Verdana"
        Me.MainTextBox.Styles.LastPredefined.FontName = "Verdana"
        Me.MainTextBox.Styles.LineNumber.FontName = "Verdana"
        Me.MainTextBox.Styles.Max.FontName = "Verdana"
        Me.MainTextBox.TabIndex = 7
        '
        'ActionPropertiesPanel
        '
        Me.ActionPropertiesPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ActionPropertiesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ActionPropertiesPanel.Controls.Add(Me.ConditionalDisplayChecker)
        Me.ActionPropertiesPanel.Controls.Add(Me.DontRequestApplicationChecker)
        Me.ActionPropertiesPanel.Controls.Add(Me.ImageDropper)
        Me.ActionPropertiesPanel.Controls.Add(Me.IndentationGroupBox)
        Me.ActionPropertiesPanel.Controls.Add(Me.SubToolStrip)
        Me.ActionPropertiesPanel.Controls.Add(Me.ArgumentsLabel)
        Me.ActionPropertiesPanel.Controls.Add(Me.ListDisplayTextBox)
        Me.ActionPropertiesPanel.Controls.Add(Me.FormattedDisplayLabel)
        Me.ActionPropertiesPanel.Controls.Add(Me.ArgumentsListView)
        Me.ActionPropertiesPanel.Controls.Add(Me.TypeDropper)
        Me.ActionPropertiesPanel.Controls.Add(Me.NameTextBox)
        Me.ActionPropertiesPanel.Controls.Add(Me.NameLabel)
        Me.ActionPropertiesPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.ActionPropertiesPanel.Location = New System.Drawing.Point(553, 25)
        Me.ActionPropertiesPanel.Name = "ActionPropertiesPanel"
        Me.ActionPropertiesPanel.Size = New System.Drawing.Size(181, 457)
        Me.ActionPropertiesPanel.TabIndex = 8
        '
        'ConditionalDisplayChecker
        '
        Me.ConditionalDisplayChecker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConditionalDisplayChecker.AutoSize = True
        Me.ConditionalDisplayChecker.Location = New System.Drawing.Point(10, 331)
        Me.ConditionalDisplayChecker.Name = "ConditionalDisplayChecker"
        Me.ConditionalDisplayChecker.Size = New System.Drawing.Size(116, 17)
        Me.ConditionalDisplayChecker.TabIndex = 16
        Me.ConditionalDisplayChecker.Text = "Conditional Display"
        Me.ConditionalDisplayChecker.UseVisualStyleBackColor = True
        '
        'DontRequestApplicationChecker
        '
        Me.DontRequestApplicationChecker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DontRequestApplicationChecker.AutoSize = True
        Me.DontRequestApplicationChecker.Location = New System.Drawing.Point(10, 348)
        Me.DontRequestApplicationChecker.Name = "DontRequestApplicationChecker"
        Me.DontRequestApplicationChecker.Size = New System.Drawing.Size(149, 17)
        Me.DontRequestApplicationChecker.TabIndex = 15
        Me.DontRequestApplicationChecker.Text = "Don't Request Application"
        Me.DontRequestApplicationChecker.UseVisualStyleBackColor = True
        '
        'ImageDropper
        '
        Me.ImageDropper.FormattingEnabled = True
        Me.ImageDropper.Location = New System.Drawing.Point(65, 81)
        Me.ImageDropper.Name = "ImageDropper"
        Me.ImageDropper.Size = New System.Drawing.Size(111, 21)
        Me.ImageDropper.TabIndex = 14
        '
        'IndentationGroupBox
        '
        Me.IndentationGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IndentationGroupBox.Controls.Add(Me.InvertRadioButton)
        Me.IndentationGroupBox.Controls.Add(Me.IndentRadioButton)
        Me.IndentationGroupBox.Controls.Add(Me.GenericRadioButton)
        Me.IndentationGroupBox.Location = New System.Drawing.Point(6, 368)
        Me.IndentationGroupBox.Name = "IndentationGroupBox"
        Me.IndentationGroupBox.Size = New System.Drawing.Size(170, 83)
        Me.IndentationGroupBox.TabIndex = 9
        Me.IndentationGroupBox.TabStop = False
        Me.IndentationGroupBox.Text = "Indentation"
        '
        'InvertRadioButton
        '
        Me.InvertRadioButton.AutoSize = True
        Me.InvertRadioButton.Location = New System.Drawing.Point(11, 60)
        Me.InvertRadioButton.Name = "InvertRadioButton"
        Me.InvertRadioButton.Size = New System.Drawing.Size(52, 17)
        Me.InvertRadioButton.TabIndex = 16
        Me.InvertRadioButton.TabStop = True
        Me.InvertRadioButton.Text = "Invert"
        Me.InvertRadioButton.UseVisualStyleBackColor = True
        '
        'IndentRadioButton
        '
        Me.IndentRadioButton.AutoSize = True
        Me.IndentRadioButton.Location = New System.Drawing.Point(11, 40)
        Me.IndentRadioButton.Name = "IndentRadioButton"
        Me.IndentRadioButton.Size = New System.Drawing.Size(55, 17)
        Me.IndentRadioButton.TabIndex = 15
        Me.IndentRadioButton.TabStop = True
        Me.IndentRadioButton.Text = "Indent"
        Me.IndentRadioButton.UseVisualStyleBackColor = True
        '
        'GenericRadioButton
        '
        Me.GenericRadioButton.AutoSize = True
        Me.GenericRadioButton.Location = New System.Drawing.Point(11, 20)
        Me.GenericRadioButton.Name = "GenericRadioButton"
        Me.GenericRadioButton.Size = New System.Drawing.Size(62, 17)
        Me.GenericRadioButton.TabIndex = 14
        Me.GenericRadioButton.TabStop = True
        Me.GenericRadioButton.Text = "Generic"
        Me.GenericRadioButton.UseVisualStyleBackColor = True
        '
        'SubToolStrip
        '
        Me.SubToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveButton, Me.SubToolStripSep1, Me.AddArgumentButton, Me.EditArgumentButton, Me.DeleteArgumentButton, Me.InsertArgumentButton})
        Me.SubToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.SubToolStrip.Name = "SubToolStrip"
        Me.SubToolStrip.Size = New System.Drawing.Size(179, 25)
        Me.SubToolStrip.TabIndex = 13
        Me.SubToolStrip.Text = "ToolStrip1"
        '
        'SaveButton
        '
        Me.SaveButton.Image = Global.DS_Game_Maker.My.Resources.Resources.SaveIcon
        Me.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(51, 22)
        Me.SaveButton.Text = "Save"
        '
        'SubToolStripSep1
        '
        Me.SubToolStripSep1.Name = "SubToolStripSep1"
        Me.SubToolStripSep1.Size = New System.Drawing.Size(6, 25)
        '
        'AddArgumentButton
        '
        Me.AddArgumentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AddArgumentButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PlusIcon
        Me.AddArgumentButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddArgumentButton.Name = "AddArgumentButton"
        Me.AddArgumentButton.Size = New System.Drawing.Size(23, 22)
        Me.AddArgumentButton.Text = "Add Argument"
        '
        'EditArgumentButton
        '
        Me.EditArgumentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EditArgumentButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PencilIcon
        Me.EditArgumentButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditArgumentButton.Name = "EditArgumentButton"
        Me.EditArgumentButton.Size = New System.Drawing.Size(23, 22)
        Me.EditArgumentButton.Text = "Edit Argument"
        '
        'DeleteArgumentButton
        '
        Me.DeleteArgumentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DeleteArgumentButton.Image = Global.DS_Game_Maker.My.Resources.Resources.DeleteIcon
        Me.DeleteArgumentButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteArgumentButton.Name = "DeleteArgumentButton"
        Me.DeleteArgumentButton.Size = New System.Drawing.Size(23, 22)
        Me.DeleteArgumentButton.Text = "Delete Argument"
        '
        'InsertArgumentButton
        '
        Me.InsertArgumentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.InsertArgumentButton.Image = Global.DS_Game_Maker.My.Resources.Resources.InsertIcon
        Me.InsertArgumentButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InsertArgumentButton.Name = "InsertArgumentButton"
        Me.InsertArgumentButton.Size = New System.Drawing.Size(23, 22)
        Me.InsertArgumentButton.Text = "Insert Argument into Code"
        '
        'ArgumentsLabel
        '
        Me.ArgumentsLabel.AutoSize = True
        Me.ArgumentsLabel.Location = New System.Drawing.Point(6, 158)
        Me.ArgumentsLabel.Name = "ArgumentsLabel"
        Me.ArgumentsLabel.Size = New System.Drawing.Size(63, 13)
        Me.ArgumentsLabel.TabIndex = 12
        Me.ArgumentsLabel.Text = "Arguments:"
        '
        'ArgumentsListView
        '
        Me.ArgumentsListView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ArgumentsListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NameColumn, Me.TypeColumn})
        Me.ArgumentsListView.Location = New System.Drawing.Point(6, 174)
        Me.ArgumentsListView.MultiSelect = False
        Me.ArgumentsListView.Name = "ArgumentsListView"
        Me.ArgumentsListView.Size = New System.Drawing.Size(170, 155)
        Me.ArgumentsListView.TabIndex = 11
        Me.ArgumentsListView.UseCompatibleStateImageBehavior = False
        Me.ArgumentsListView.View = System.Windows.Forms.View.Details
        '
        'NameColumn
        '
        Me.NameColumn.Text = "Name"
        Me.NameColumn.Width = 83
        '
        'TypeColumn
        '
        Me.TypeColumn.Text = "Type"
        Me.TypeColumn.Width = 82
        '
        'ActionEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 482)
        Me.Controls.Add(Me.MainTextBox)
        Me.Controls.Add(Me.ActionsTreeView)
        Me.Controls.Add(Me.ActionPropertiesPanel)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ActionEditor"
        Me.Text = "Action Editor"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        CType(Me.MainTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ActionPropertiesPanel.ResumeLayout(False)
        Me.ActionPropertiesPanel.PerformLayout()
        Me.IndentationGroupBox.ResumeLayout(False)
        Me.IndentationGroupBox.PerformLayout()
        Me.SubToolStrip.ResumeLayout(False)
        Me.SubToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ActionsTreeView As System.Windows.Forms.TreeView
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents AddActionButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeleteActionButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TypeDropper As System.Windows.Forms.ComboBox
    Friend WithEvents MainTextBox As ScintillaNet.Scintilla
    Friend WithEvents MainImageList As System.Windows.Forms.ImageList
    Friend WithEvents FormattedDisplayLabel As System.Windows.Forms.Label
    Friend WithEvents ListDisplayTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ActionPropertiesPanel As System.Windows.Forms.Panel
    Friend WithEvents ArgumentsListView As System.Windows.Forms.ListView
    Friend WithEvents ArgumentsLabel As System.Windows.Forms.Label
    Friend WithEvents NameColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents TypeColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents MainToolStripSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CloseButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SubToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents SaveButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SubToolStripSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AddArgumentButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditArgumentButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeleteArgumentButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents InsertArgumentButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents InvertRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents IndentRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents GenericRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents IndentationGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ImageDropper As System.Windows.Forms.ComboBox
    Friend WithEvents DontRequestApplicationChecker As System.Windows.Forms.CheckBox
    Friend WithEvents ConditionalDisplayChecker As System.Windows.Forms.CheckBox
End Class
