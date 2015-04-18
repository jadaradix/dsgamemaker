<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DObject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DObject))
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.DAcceptButton = New System.Windows.Forms.ToolStripButton()
        Me.SelectAllButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectManyButton = New System.Windows.Forms.ToolStripButton()
        Me.SelectOneButton = New System.Windows.Forms.ToolStripButton()
        Me.ObjectPropertiesPanel = New System.Windows.Forms.Panel()
        Me.DeleteEventButton = New System.Windows.Forms.Button()
        Me.ChangeEventButton = New System.Windows.Forms.Button()
        Me.AddEventButton = New System.Windows.Forms.Button()
        Me.EventsListBox = New System.Windows.Forms.ListBox()
        Me.EventRightClickMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddEventRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.RightClickSep4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangeEventRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.RightClickSep5 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteEventRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.RightClickSep6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearEventsButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpriteGroupBox = New System.Windows.Forms.GroupBox()
        Me.OpenSpriteButton = New System.Windows.Forms.Button()
        Me.FrameLabel = New System.Windows.Forms.Label()
        Me.FrameRightButton = New System.Windows.Forms.Button()
        Me.FrameLeftButton = New System.Windows.Forms.Button()
        Me.SpriteDropper = New System.Windows.Forms.ComboBox()
        Me.SpritePanel = New System.Windows.Forms.Panel()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.ActionsToAddTabControl = New System.Windows.Forms.TabControl()
        Me.ActionsList = New System.Windows.Forms.ListBox()
        Me.ActionRightClickMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditValuesRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.RightClickSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectOneRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectManyRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.RightClickSep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutActionRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyActionRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteActionBelowRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.RightClickSep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteActionRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearActionsRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActionsPanel = New System.Windows.Forms.Panel()
        Me.ActionInfoPanel = New System.Windows.Forms.Panel()
        Me.ArgumentsListLabel = New System.Windows.Forms.Label()
        Me.ArgumentsHeaderLabel = New System.Windows.Forms.Label()
        Me.ActionNameLabel = New System.Windows.Forms.Label()
        Me.MainToolStrip.SuspendLayout()
        Me.ObjectPropertiesPanel.SuspendLayout()
        Me.EventRightClickMenu.SuspendLayout()
        Me.SpriteGroupBox.SuspendLayout()
        Me.ActionRightClickMenu.SuspendLayout()
        Me.ActionsPanel.SuspendLayout()
        Me.ActionInfoPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton, Me.SelectAllButton, Me.ToolStripSeparator2, Me.SelectManyButton, Me.SelectOneButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(692, 25)
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
        'SelectAllButton
        '
        Me.SelectAllButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SelectAllButton.Image = Global.DS_Game_Maker.My.Resources.Resources.CopyIcon
        Me.SelectAllButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SelectAllButton.Name = "SelectAllButton"
        Me.SelectAllButton.Size = New System.Drawing.Size(70, 22)
        Me.SelectAllButton.Text = "Select All"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'SelectManyButton
        '
        Me.SelectManyButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SelectManyButton.Image = Global.DS_Game_Maker.My.Resources.Resources.ListIcon
        Me.SelectManyButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SelectManyButton.Name = "SelectManyButton"
        Me.SelectManyButton.Size = New System.Drawing.Size(85, 22)
        Me.SelectManyButton.Text = "Select Many"
        '
        'SelectOneButton
        '
        Me.SelectOneButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SelectOneButton.Image = Global.DS_Game_Maker.My.Resources.Resources.ListIcon
        Me.SelectOneButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SelectOneButton.Name = "SelectOneButton"
        Me.SelectOneButton.Size = New System.Drawing.Size(79, 22)
        Me.SelectOneButton.Text = "Select One"
        '
        'ObjectPropertiesPanel
        '
        Me.ObjectPropertiesPanel.Controls.Add(Me.DeleteEventButton)
        Me.ObjectPropertiesPanel.Controls.Add(Me.ChangeEventButton)
        Me.ObjectPropertiesPanel.Controls.Add(Me.AddEventButton)
        Me.ObjectPropertiesPanel.Controls.Add(Me.EventsListBox)
        Me.ObjectPropertiesPanel.Controls.Add(Me.SpriteGroupBox)
        Me.ObjectPropertiesPanel.Controls.Add(Me.NameLabel)
        Me.ObjectPropertiesPanel.Controls.Add(Me.NameTextBox)
        Me.ObjectPropertiesPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.ObjectPropertiesPanel.Location = New System.Drawing.Point(0, 25)
        Me.ObjectPropertiesPanel.Name = "ObjectPropertiesPanel"
        Me.ObjectPropertiesPanel.Size = New System.Drawing.Size(210, 517)
        Me.ObjectPropertiesPanel.TabIndex = 1
        '
        'DeleteEventButton
        '
        Me.DeleteEventButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DeleteEventButton.Location = New System.Drawing.Point(106, 477)
        Me.DeleteEventButton.Name = "DeleteEventButton"
        Me.DeleteEventButton.Size = New System.Drawing.Size(92, 28)
        Me.DeleteEventButton.TabIndex = 6
        Me.DeleteEventButton.Text = "Delete"
        Me.DeleteEventButton.UseVisualStyleBackColor = True
        '
        'ChangeEventButton
        '
        Me.ChangeEventButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChangeEventButton.Location = New System.Drawing.Point(12, 477)
        Me.ChangeEventButton.Name = "ChangeEventButton"
        Me.ChangeEventButton.Size = New System.Drawing.Size(92, 28)
        Me.ChangeEventButton.TabIndex = 5
        Me.ChangeEventButton.Text = "Change"
        Me.ChangeEventButton.UseVisualStyleBackColor = True
        '
        'AddEventButton
        '
        Me.AddEventButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AddEventButton.Location = New System.Drawing.Point(12, 446)
        Me.AddEventButton.Name = "AddEventButton"
        Me.AddEventButton.Size = New System.Drawing.Size(186, 28)
        Me.AddEventButton.TabIndex = 4
        Me.AddEventButton.Text = "Add Event"
        Me.AddEventButton.UseVisualStyleBackColor = True
        '
        'EventsListBox
        '
        Me.EventsListBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EventsListBox.ContextMenuStrip = Me.EventRightClickMenu
        Me.EventsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.EventsListBox.FormattingEnabled = True
        Me.EventsListBox.Location = New System.Drawing.Point(12, 150)
        Me.EventsListBox.Name = "EventsListBox"
        Me.EventsListBox.Size = New System.Drawing.Size(186, 292)
        Me.EventsListBox.TabIndex = 4
        '
        'EventRightClickMenu
        '
        Me.EventRightClickMenu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EventRightClickMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEventRightClickButton, Me.RightClickSep4, Me.ChangeEventRightClickButton, Me.RightClickSep5, Me.DeleteEventRightClickButton, Me.RightClickSep6, Me.ClearEventsButton})
        Me.EventRightClickMenu.Name = "ActionRightClickMenu"
        Me.EventRightClickMenu.Size = New System.Drawing.Size(153, 132)
        '
        'AddEventRightClickButton
        '
        Me.AddEventRightClickButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PlusIcon
        Me.AddEventRightClickButton.Name = "AddEventRightClickButton"
        Me.AddEventRightClickButton.Size = New System.Drawing.Size(152, 22)
        Me.AddEventRightClickButton.Text = "Add Event"
        '
        'RightClickSep4
        '
        Me.RightClickSep4.Name = "RightClickSep4"
        Me.RightClickSep4.Size = New System.Drawing.Size(149, 6)
        '
        'ChangeEventRightClickButton
        '
        Me.ChangeEventRightClickButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PencilIcon
        Me.ChangeEventRightClickButton.Name = "ChangeEventRightClickButton"
        Me.ChangeEventRightClickButton.Size = New System.Drawing.Size(152, 22)
        Me.ChangeEventRightClickButton.Text = "Change"
        '
        'RightClickSep5
        '
        Me.RightClickSep5.Name = "RightClickSep5"
        Me.RightClickSep5.Size = New System.Drawing.Size(149, 6)
        '
        'DeleteEventRightClickButton
        '
        Me.DeleteEventRightClickButton.Image = Global.DS_Game_Maker.My.Resources.Resources.DeleteIcon
        Me.DeleteEventRightClickButton.Name = "DeleteEventRightClickButton"
        Me.DeleteEventRightClickButton.Size = New System.Drawing.Size(152, 22)
        Me.DeleteEventRightClickButton.Text = "Delete"
        '
        'RightClickSep6
        '
        Me.RightClickSep6.Name = "RightClickSep6"
        Me.RightClickSep6.Size = New System.Drawing.Size(149, 6)
        '
        'ClearEventsButton
        '
        Me.ClearEventsButton.Name = "ClearEventsButton"
        Me.ClearEventsButton.Size = New System.Drawing.Size(152, 22)
        Me.ClearEventsButton.Text = "Clear"
        '
        'SpriteGroupBox
        '
        Me.SpriteGroupBox.Controls.Add(Me.OpenSpriteButton)
        Me.SpriteGroupBox.Controls.Add(Me.FrameLabel)
        Me.SpriteGroupBox.Controls.Add(Me.FrameRightButton)
        Me.SpriteGroupBox.Controls.Add(Me.FrameLeftButton)
        Me.SpriteGroupBox.Controls.Add(Me.SpriteDropper)
        Me.SpriteGroupBox.Controls.Add(Me.SpritePanel)
        Me.SpriteGroupBox.Location = New System.Drawing.Point(12, 53)
        Me.SpriteGroupBox.Name = "SpriteGroupBox"
        Me.SpriteGroupBox.Size = New System.Drawing.Size(186, 91)
        Me.SpriteGroupBox.TabIndex = 4
        Me.SpriteGroupBox.TabStop = False
        Me.SpriteGroupBox.Text = "Sprite"
        '
        'OpenSpriteButton
        '
        Me.OpenSpriteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OpenSpriteButton.Location = New System.Drawing.Point(76, 63)
        Me.OpenSpriteButton.Name = "OpenSpriteButton"
        Me.OpenSpriteButton.Size = New System.Drawing.Size(104, 22)
        Me.OpenSpriteButton.TabIndex = 6
        Me.OpenSpriteButton.Text = "Open Sprite"
        Me.OpenSpriteButton.UseVisualStyleBackColor = True
        '
        'FrameLabel
        '
        Me.FrameLabel.AutoSize = True
        Me.FrameLabel.Location = New System.Drawing.Point(91, 45)
        Me.FrameLabel.Name = "FrameLabel"
        Me.FrameLabel.Size = New System.Drawing.Size(41, 13)
        Me.FrameLabel.TabIndex = 4
        Me.FrameLabel.Text = "Frame:"
        '
        'FrameRightButton
        '
        Me.FrameRightButton.Image = Global.DS_Game_Maker.My.Resources.Resources.RightArrowSmall
        Me.FrameRightButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.FrameRightButton.Location = New System.Drawing.Point(158, 42)
        Me.FrameRightButton.Name = "FrameRightButton"
        Me.FrameRightButton.Size = New System.Drawing.Size(22, 20)
        Me.FrameRightButton.TabIndex = 5
        Me.FrameRightButton.UseVisualStyleBackColor = True
        '
        'FrameLeftButton
        '
        Me.FrameLeftButton.Image = Global.DS_Game_Maker.My.Resources.Resources.LeftArrowSmall
        Me.FrameLeftButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FrameLeftButton.Location = New System.Drawing.Point(134, 42)
        Me.FrameLeftButton.Name = "FrameLeftButton"
        Me.FrameLeftButton.Size = New System.Drawing.Size(22, 20)
        Me.FrameLeftButton.TabIndex = 4
        Me.FrameLeftButton.UseVisualStyleBackColor = True
        '
        'SpriteDropper
        '
        Me.SpriteDropper.FormattingEnabled = True
        Me.SpriteDropper.Location = New System.Drawing.Point(76, 20)
        Me.SpriteDropper.Name = "SpriteDropper"
        Me.SpriteDropper.Size = New System.Drawing.Size(104, 21)
        Me.SpriteDropper.TabIndex = 4
        '
        'SpritePanel
        '
        Me.SpritePanel.Location = New System.Drawing.Point(6, 20)
        Me.SpritePanel.Name = "SpritePanel"
        Me.SpritePanel.Size = New System.Drawing.Size(64, 64)
        Me.SpritePanel.TabIndex = 4
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(9, 10)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(38, 13)
        Me.NameLabel.TabIndex = 4
        Me.NameLabel.Text = "Name:"
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(12, 26)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(186, 21)
        Me.NameTextBox.TabIndex = 3
        '
        'ActionsToAddTabControl
        '
        Me.ActionsToAddTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ActionsToAddTabControl.Location = New System.Drawing.Point(0, 0)
        Me.ActionsToAddTabControl.Name = "ActionsToAddTabControl"
        Me.ActionsToAddTabControl.SelectedIndex = 0
        Me.ActionsToAddTabControl.Size = New System.Drawing.Size(312, 160)
        Me.ActionsToAddTabControl.TabIndex = 2
        '
        'ActionsList
        '
        Me.ActionsList.ContextMenuStrip = Me.ActionRightClickMenu
        Me.ActionsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ActionsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.ActionsList.FormattingEnabled = True
        Me.ActionsList.Location = New System.Drawing.Point(210, 25)
        Me.ActionsList.Name = "ActionsList"
        Me.ActionsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ActionsList.Size = New System.Drawing.Size(482, 357)
        Me.ActionsList.TabIndex = 3
        '
        'ActionRightClickMenu
        '
        Me.ActionRightClickMenu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActionRightClickMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditValuesRightClickButton, Me.RightClickSep1, Me.SelectOneRightClickButton, Me.SelectManyRightClickButton, Me.RightClickSep3, Me.CutActionRightClickButton, Me.CopyActionRightClickButton, Me.PasteActionBelowRightClickButton, Me.RightClickSep2, Me.DeleteActionRightClickButton, Me.ClearActionsRightClickButton})
        Me.ActionRightClickMenu.Name = "ActionRightClickMenu"
        Me.ActionRightClickMenu.Size = New System.Drawing.Size(133, 198)
        '
        'EditValuesRightClickButton
        '
        Me.EditValuesRightClickButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PencilIcon
        Me.EditValuesRightClickButton.Name = "EditValuesRightClickButton"
        Me.EditValuesRightClickButton.Size = New System.Drawing.Size(132, 22)
        Me.EditValuesRightClickButton.Text = "Edit Values"
        '
        'RightClickSep1
        '
        Me.RightClickSep1.Name = "RightClickSep1"
        Me.RightClickSep1.Size = New System.Drawing.Size(129, 6)
        '
        'SelectOneRightClickButton
        '
        Me.SelectOneRightClickButton.Image = Global.DS_Game_Maker.My.Resources.Resources.ListIcon
        Me.SelectOneRightClickButton.Name = "SelectOneRightClickButton"
        Me.SelectOneRightClickButton.Size = New System.Drawing.Size(132, 22)
        Me.SelectOneRightClickButton.Text = "Select One"
        '
        'SelectManyRightClickButton
        '
        Me.SelectManyRightClickButton.Image = Global.DS_Game_Maker.My.Resources.Resources.ListIcon
        Me.SelectManyRightClickButton.Name = "SelectManyRightClickButton"
        Me.SelectManyRightClickButton.Size = New System.Drawing.Size(132, 22)
        Me.SelectManyRightClickButton.Text = "Select Many"
        '
        'RightClickSep3
        '
        Me.RightClickSep3.Name = "RightClickSep3"
        Me.RightClickSep3.Size = New System.Drawing.Size(129, 6)
        '
        'CutActionRightClickButton
        '
        Me.CutActionRightClickButton.Name = "CutActionRightClickButton"
        Me.CutActionRightClickButton.Size = New System.Drawing.Size(132, 22)
        Me.CutActionRightClickButton.Text = "Cut"
        '
        'CopyActionRightClickButton
        '
        Me.CopyActionRightClickButton.Image = Global.DS_Game_Maker.My.Resources.Resources.CopyIcon
        Me.CopyActionRightClickButton.Name = "CopyActionRightClickButton"
        Me.CopyActionRightClickButton.Size = New System.Drawing.Size(132, 22)
        Me.CopyActionRightClickButton.Text = "Copy"
        '
        'PasteActionBelowRightClickButton
        '
        Me.PasteActionBelowRightClickButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PasteIcon
        Me.PasteActionBelowRightClickButton.Name = "PasteActionBelowRightClickButton"
        Me.PasteActionBelowRightClickButton.Size = New System.Drawing.Size(132, 22)
        Me.PasteActionBelowRightClickButton.Text = "Paste below"
        '
        'RightClickSep2
        '
        Me.RightClickSep2.Name = "RightClickSep2"
        Me.RightClickSep2.Size = New System.Drawing.Size(129, 6)
        '
        'DeleteActionRightClickButton
        '
        Me.DeleteActionRightClickButton.Image = Global.DS_Game_Maker.My.Resources.Resources.DeleteIcon
        Me.DeleteActionRightClickButton.Name = "DeleteActionRightClickButton"
        Me.DeleteActionRightClickButton.Size = New System.Drawing.Size(132, 22)
        Me.DeleteActionRightClickButton.Text = "Delete"
        '
        'ClearActionsRightClickButton
        '
        Me.ClearActionsRightClickButton.Name = "ClearActionsRightClickButton"
        Me.ClearActionsRightClickButton.Size = New System.Drawing.Size(132, 22)
        Me.ClearActionsRightClickButton.Text = "Clear"
        '
        'ActionsPanel
        '
        Me.ActionsPanel.Controls.Add(Me.ActionsToAddTabControl)
        Me.ActionsPanel.Controls.Add(Me.ActionInfoPanel)
        Me.ActionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ActionsPanel.Location = New System.Drawing.Point(210, 382)
        Me.ActionsPanel.Name = "ActionsPanel"
        Me.ActionsPanel.Size = New System.Drawing.Size(482, 160)
        Me.ActionsPanel.TabIndex = 4
        '
        'ActionInfoPanel
        '
        Me.ActionInfoPanel.Controls.Add(Me.ArgumentsListLabel)
        Me.ActionInfoPanel.Controls.Add(Me.ArgumentsHeaderLabel)
        Me.ActionInfoPanel.Controls.Add(Me.ActionNameLabel)
        Me.ActionInfoPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.ActionInfoPanel.Location = New System.Drawing.Point(312, 0)
        Me.ActionInfoPanel.Name = "ActionInfoPanel"
        Me.ActionInfoPanel.Size = New System.Drawing.Size(170, 160)
        Me.ActionInfoPanel.TabIndex = 5
        '
        'ArgumentsListLabel
        '
        Me.ArgumentsListLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ArgumentsListLabel.Location = New System.Drawing.Point(7, 58)
        Me.ArgumentsListLabel.Name = "ArgumentsListLabel"
        Me.ArgumentsListLabel.Padding = New System.Windows.Forms.Padding(0, 2, 4, 4)
        Me.ArgumentsListLabel.Size = New System.Drawing.Size(156, 94)
        Me.ArgumentsListLabel.TabIndex = 2
        Me.ArgumentsListLabel.Text = ""
        '
        'ArgumentsHeaderLabel
        '
        Me.ArgumentsHeaderLabel.BackColor = System.Drawing.Color.Gray
        Me.ArgumentsHeaderLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ArgumentsHeaderLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArgumentsHeaderLabel.ForeColor = System.Drawing.Color.White
        Me.ArgumentsHeaderLabel.Location = New System.Drawing.Point(4, 36)
        Me.ArgumentsHeaderLabel.Name = "ArgumentsHeaderLabel"
        Me.ArgumentsHeaderLabel.Padding = New System.Windows.Forms.Padding(2)
        Me.ArgumentsHeaderLabel.Size = New System.Drawing.Size(162, 120)
        Me.ArgumentsHeaderLabel.TabIndex = 1
        Me.ArgumentsHeaderLabel.Text = "Arguments:"
        '
        'ActionNameLabel
        '
        Me.ActionNameLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ActionNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ActionNameLabel.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActionNameLabel.ForeColor = System.Drawing.Color.White
        Me.ActionNameLabel.Location = New System.Drawing.Point(4, 5)
        Me.ActionNameLabel.Name = "ActionNameLabel"
        Me.ActionNameLabel.Padding = New System.Windows.Forms.Padding(2, 4, 4, 4)
        Me.ActionNameLabel.Size = New System.Drawing.Size(162, 27)
        Me.ActionNameLabel.TabIndex = 0
        Me.ActionNameLabel.Text = "..."
        '
        'DObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 542)
        Me.Controls.Add(Me.ActionsList)
        Me.Controls.Add(Me.ActionsPanel)
        Me.Controls.Add(Me.ObjectPropertiesPanel)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(708, 580)
        Me.Name = "DObject"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.ObjectPropertiesPanel.ResumeLayout(False)
        Me.ObjectPropertiesPanel.PerformLayout()
        Me.EventRightClickMenu.ResumeLayout(False)
        Me.SpriteGroupBox.ResumeLayout(False)
        Me.SpriteGroupBox.PerformLayout()
        Me.ActionRightClickMenu.ResumeLayout(False)
        Me.ActionsPanel.ResumeLayout(False)
        Me.ActionInfoPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ObjectPropertiesPanel As System.Windows.Forms.Panel
    Friend WithEvents ActionsToAddTabControl As System.Windows.Forms.TabControl
    Friend WithEvents ActionsList As System.Windows.Forms.ListBox
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SpriteGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents SpritePanel As System.Windows.Forms.Panel
    Friend WithEvents SpriteDropper As System.Windows.Forms.ComboBox
    Friend WithEvents FrameLabel As System.Windows.Forms.Label
    Friend WithEvents FrameRightButton As System.Windows.Forms.Button
    Friend WithEvents FrameLeftButton As System.Windows.Forms.Button
    Friend WithEvents ChangeEventButton As System.Windows.Forms.Button
    Friend WithEvents AddEventButton As System.Windows.Forms.Button
    Friend WithEvents EventsListBox As System.Windows.Forms.ListBox
    Friend WithEvents DeleteEventButton As System.Windows.Forms.Button
    Friend WithEvents ActionRightClickMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditValuesRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteActionRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RightClickSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutActionRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyActionRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteActionBelowRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RightClickSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RightClickSep3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearActionsRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenSpriteButton As System.Windows.Forms.Button
    Friend WithEvents EventRightClickMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddEventRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RightClickSep4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteEventRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RightClickSep6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearEventsButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeEventRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RightClickSep5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ActionsPanel As System.Windows.Forms.Panel
    Friend WithEvents ActionInfoPanel As System.Windows.Forms.Panel
    Friend WithEvents ActionNameLabel As System.Windows.Forms.Label
    Friend WithEvents ArgumentsHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents ArgumentsListLabel As System.Windows.Forms.Label
    Friend WithEvents SelectManyButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SelectOneButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SelectOneRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectManyRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
