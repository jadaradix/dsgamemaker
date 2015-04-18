<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Room
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Room))
        Me.NameLabel = New System.Windows.Forms.Label
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.TopHeightLabel = New System.Windows.Forms.Label
        Me.TopWidthLabel = New System.Windows.Forms.Label
        Me.ObjectsTabControl = New System.Windows.Forms.TabControl
        Me.GeneralTab = New System.Windows.Forms.TabPage
        Me.BottomScreenGroupBox = New System.Windows.Forms.GroupBox
        Me.BottomScreenBGDropper = New System.Windows.Forms.ComboBox
        Me.BottomHeightDropper = New System.Windows.Forms.NumericUpDown
        Me.BottomWidthDropper = New System.Windows.Forms.NumericUpDown
        Me.BottomScreenScrollChecker = New System.Windows.Forms.CheckBox
        Me.BottomWidthLabel = New System.Windows.Forms.Label
        Me.BottomHeightLabel = New System.Windows.Forms.Label
        Me.TopScreenGroupBox = New System.Windows.Forms.GroupBox
        Me.TopHeightDropper = New System.Windows.Forms.NumericUpDown
        Me.TopWidthDropper = New System.Windows.Forms.NumericUpDown
        Me.TopScreenBGDropper = New System.Windows.Forms.ComboBox
        Me.TopScreenScrollChecker = New System.Windows.Forms.CheckBox
        Me.DesignTab = New System.Windows.Forms.TabPage
        Me.CursorPositionSnapLabel = New System.Windows.Forms.Label
        Me.CursorPositionLabel = New System.Windows.Forms.Label
        Me.UseRightClickMenuChecker = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ObjectInfoLabel = New System.Windows.Forms.Label
        Me.ObjectDropper = New System.Windows.Forms.ComboBox
        Me.PlotWithLeftClickLabel = New System.Windows.Forms.Label
        Me.SnappingGroupBox = New System.Windows.Forms.GroupBox
        Me.GridColorButton = New System.Windows.Forms.Button
        Me.SnapYTextBox = New System.Windows.Forms.TextBox
        Me.SnapYLabel = New System.Windows.Forms.Label
        Me.SnapXTextBox = New System.Windows.Forms.TextBox
        Me.SnapToGridChecker = New System.Windows.Forms.CheckBox
        Me.SnapXLabel = New System.Windows.Forms.Label
        Me.ShowGridChecker = New System.Windows.Forms.CheckBox
        Me.TopScreen = New System.Windows.Forms.Panel
        Me.BottomScreen = New System.Windows.Forms.Panel
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip
        Me.DAcceptButton = New System.Windows.Forms.ToolStripButton
        Me.ObjectRightClickMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteObjectButton = New System.Windows.Forms.ToolStripMenuItem
        Me.SetCoOrdinatesButton = New System.Windows.Forms.ToolStripMenuItem
        Me.RightClickSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.OpenObjectButton = New System.Windows.Forms.ToolStripMenuItem
        Me.ObjectsTabControl.SuspendLayout()
        Me.GeneralTab.SuspendLayout()
        Me.BottomScreenGroupBox.SuspendLayout()
        CType(Me.BottomHeightDropper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomWidthDropper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopScreenGroupBox.SuspendLayout()
        CType(Me.TopHeightDropper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopWidthDropper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DesignTab.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SnappingGroupBox.SuspendLayout()
        Me.MainToolStrip.SuspendLayout()
        Me.ObjectRightClickMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(6, 8)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(38, 13)
        Me.NameLabel.TabIndex = 3
        Me.NameLabel.Text = "Name:"
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(7, 24)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(153, 21)
        Me.NameTextBox.TabIndex = 0
        '
        'TopHeightLabel
        '
        Me.TopHeightLabel.AutoSize = True
        Me.TopHeightLabel.Location = New System.Drawing.Point(29, 43)
        Me.TopHeightLabel.Name = "TopHeightLabel"
        Me.TopHeightLabel.Size = New System.Drawing.Size(42, 13)
        Me.TopHeightLabel.TabIndex = 4
        Me.TopHeightLabel.Text = "Height:"
        '
        'TopWidthLabel
        '
        Me.TopWidthLabel.AutoSize = True
        Me.TopWidthLabel.BackColor = System.Drawing.Color.Transparent
        Me.TopWidthLabel.Location = New System.Drawing.Point(29, 20)
        Me.TopWidthLabel.Name = "TopWidthLabel"
        Me.TopWidthLabel.Size = New System.Drawing.Size(39, 13)
        Me.TopWidthLabel.TabIndex = 3
        Me.TopWidthLabel.Text = "Width:"
        '
        'ObjectsTabControl
        '
        Me.ObjectsTabControl.Controls.Add(Me.GeneralTab)
        Me.ObjectsTabControl.Controls.Add(Me.DesignTab)
        Me.ObjectsTabControl.Dock = System.Windows.Forms.DockStyle.Left
        Me.ObjectsTabControl.Location = New System.Drawing.Point(0, 25)
        Me.ObjectsTabControl.Name = "ObjectsTabControl"
        Me.ObjectsTabControl.SelectedIndex = 0
        Me.ObjectsTabControl.Size = New System.Drawing.Size(177, 389)
        Me.ObjectsTabControl.TabIndex = 1
        '
        'GeneralTab
        '
        Me.GeneralTab.Controls.Add(Me.BottomScreenGroupBox)
        Me.GeneralTab.Controls.Add(Me.TopScreenGroupBox)
        Me.GeneralTab.Controls.Add(Me.NameTextBox)
        Me.GeneralTab.Controls.Add(Me.NameLabel)
        Me.GeneralTab.Location = New System.Drawing.Point(4, 22)
        Me.GeneralTab.Name = "GeneralTab"
        Me.GeneralTab.Padding = New System.Windows.Forms.Padding(3)
        Me.GeneralTab.Size = New System.Drawing.Size(169, 363)
        Me.GeneralTab.TabIndex = 0
        Me.GeneralTab.Text = "General"
        Me.GeneralTab.UseVisualStyleBackColor = True
        '
        'BottomScreenGroupBox
        '
        Me.BottomScreenGroupBox.Controls.Add(Me.BottomScreenBGDropper)
        Me.BottomScreenGroupBox.Controls.Add(Me.BottomHeightDropper)
        Me.BottomScreenGroupBox.Controls.Add(Me.BottomWidthDropper)
        Me.BottomScreenGroupBox.Controls.Add(Me.BottomScreenScrollChecker)
        Me.BottomScreenGroupBox.Controls.Add(Me.BottomWidthLabel)
        Me.BottomScreenGroupBox.Controls.Add(Me.BottomHeightLabel)
        Me.BottomScreenGroupBox.Location = New System.Drawing.Point(7, 176)
        Me.BottomScreenGroupBox.Name = "BottomScreenGroupBox"
        Me.BottomScreenGroupBox.Size = New System.Drawing.Size(153, 119)
        Me.BottomScreenGroupBox.TabIndex = 2
        Me.BottomScreenGroupBox.TabStop = False
        Me.BottomScreenGroupBox.Text = "Bottom Screen"
        '
        'BottomScreenBGDropper
        '
        Me.BottomScreenBGDropper.FormattingEnabled = True
        Me.BottomScreenBGDropper.Location = New System.Drawing.Point(9, 68)
        Me.BottomScreenBGDropper.Name = "BottomScreenBGDropper"
        Me.BottomScreenBGDropper.Size = New System.Drawing.Size(135, 21)
        Me.BottomScreenBGDropper.TabIndex = 7
        '
        'BottomHeightDropper
        '
        Me.BottomHeightDropper.Location = New System.Drawing.Point(104, 41)
        Me.BottomHeightDropper.Maximum = New Decimal(New Integer() {4096, 0, 0, 0})
        Me.BottomHeightDropper.Minimum = New Decimal(New Integer() {192, 0, 0, 0})
        Me.BottomHeightDropper.Name = "BottomHeightDropper"
        Me.BottomHeightDropper.Size = New System.Drawing.Size(40, 21)
        Me.BottomHeightDropper.TabIndex = 1
        Me.BottomHeightDropper.Value = New Decimal(New Integer() {192, 0, 0, 0})
        '
        'BottomWidthDropper
        '
        Me.BottomWidthDropper.Location = New System.Drawing.Point(104, 18)
        Me.BottomWidthDropper.Maximum = New Decimal(New Integer() {4096, 0, 0, 0})
        Me.BottomWidthDropper.Minimum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.BottomWidthDropper.Name = "BottomWidthDropper"
        Me.BottomWidthDropper.Size = New System.Drawing.Size(40, 21)
        Me.BottomWidthDropper.TabIndex = 0
        Me.BottomWidthDropper.Value = New Decimal(New Integer() {256, 0, 0, 0})
        '
        'BottomScreenScrollChecker
        '
        Me.BottomScreenScrollChecker.AutoSize = True
        Me.BottomScreenScrollChecker.Location = New System.Drawing.Point(9, 95)
        Me.BottomScreenScrollChecker.Name = "BottomScreenScrollChecker"
        Me.BottomScreenScrollChecker.Size = New System.Drawing.Size(130, 17)
        Me.BottomScreenScrollChecker.TabIndex = 2
        Me.BottomScreenScrollChecker.Text = "Scroll BG with Camera"
        Me.BottomScreenScrollChecker.UseVisualStyleBackColor = True
        '
        'BottomWidthLabel
        '
        Me.BottomWidthLabel.AutoSize = True
        Me.BottomWidthLabel.BackColor = System.Drawing.Color.Transparent
        Me.BottomWidthLabel.Location = New System.Drawing.Point(29, 20)
        Me.BottomWidthLabel.Name = "BottomWidthLabel"
        Me.BottomWidthLabel.Size = New System.Drawing.Size(39, 13)
        Me.BottomWidthLabel.TabIndex = 3
        Me.BottomWidthLabel.Text = "Width:"
        '
        'BottomHeightLabel
        '
        Me.BottomHeightLabel.AutoSize = True
        Me.BottomHeightLabel.Location = New System.Drawing.Point(29, 43)
        Me.BottomHeightLabel.Name = "BottomHeightLabel"
        Me.BottomHeightLabel.Size = New System.Drawing.Size(42, 13)
        Me.BottomHeightLabel.TabIndex = 4
        Me.BottomHeightLabel.Text = "Height:"
        '
        'TopScreenGroupBox
        '
        Me.TopScreenGroupBox.Controls.Add(Me.TopHeightDropper)
        Me.TopScreenGroupBox.Controls.Add(Me.TopWidthDropper)
        Me.TopScreenGroupBox.Controls.Add(Me.TopScreenBGDropper)
        Me.TopScreenGroupBox.Controls.Add(Me.TopScreenScrollChecker)
        Me.TopScreenGroupBox.Controls.Add(Me.TopWidthLabel)
        Me.TopScreenGroupBox.Controls.Add(Me.TopHeightLabel)
        Me.TopScreenGroupBox.Location = New System.Drawing.Point(7, 51)
        Me.TopScreenGroupBox.Name = "TopScreenGroupBox"
        Me.TopScreenGroupBox.Size = New System.Drawing.Size(153, 119)
        Me.TopScreenGroupBox.TabIndex = 1
        Me.TopScreenGroupBox.TabStop = False
        Me.TopScreenGroupBox.Text = "Top Screen"
        '
        'TopHeightDropper
        '
        Me.TopHeightDropper.Location = New System.Drawing.Point(104, 41)
        Me.TopHeightDropper.Maximum = New Decimal(New Integer() {4096, 0, 0, 0})
        Me.TopHeightDropper.Minimum = New Decimal(New Integer() {192, 0, 0, 0})
        Me.TopHeightDropper.Name = "TopHeightDropper"
        Me.TopHeightDropper.Size = New System.Drawing.Size(40, 21)
        Me.TopHeightDropper.TabIndex = 2
        Me.TopHeightDropper.Value = New Decimal(New Integer() {192, 0, 0, 0})
        '
        'TopWidthDropper
        '
        Me.TopWidthDropper.Location = New System.Drawing.Point(104, 18)
        Me.TopWidthDropper.Maximum = New Decimal(New Integer() {4096, 0, 0, 0})
        Me.TopWidthDropper.Minimum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.TopWidthDropper.Name = "TopWidthDropper"
        Me.TopWidthDropper.Size = New System.Drawing.Size(40, 21)
        Me.TopWidthDropper.TabIndex = 1
        Me.TopWidthDropper.Value = New Decimal(New Integer() {256, 0, 0, 0})
        '
        'TopScreenBGDropper
        '
        Me.TopScreenBGDropper.FormattingEnabled = True
        Me.TopScreenBGDropper.Location = New System.Drawing.Point(9, 68)
        Me.TopScreenBGDropper.Name = "TopScreenBGDropper"
        Me.TopScreenBGDropper.Size = New System.Drawing.Size(135, 21)
        Me.TopScreenBGDropper.TabIndex = 4
        '
        'TopScreenScrollChecker
        '
        Me.TopScreenScrollChecker.AutoSize = True
        Me.TopScreenScrollChecker.Location = New System.Drawing.Point(9, 95)
        Me.TopScreenScrollChecker.Name = "TopScreenScrollChecker"
        Me.TopScreenScrollChecker.Size = New System.Drawing.Size(130, 17)
        Me.TopScreenScrollChecker.TabIndex = 0
        Me.TopScreenScrollChecker.Text = "Scroll BG with Camera"
        Me.TopScreenScrollChecker.UseVisualStyleBackColor = True
        '
        'DesignTab
        '
        Me.DesignTab.Controls.Add(Me.CursorPositionSnapLabel)
        Me.DesignTab.Controls.Add(Me.CursorPositionLabel)
        Me.DesignTab.Controls.Add(Me.UseRightClickMenuChecker)
        Me.DesignTab.Controls.Add(Me.GroupBox1)
        Me.DesignTab.Controls.Add(Me.ObjectDropper)
        Me.DesignTab.Controls.Add(Me.PlotWithLeftClickLabel)
        Me.DesignTab.Controls.Add(Me.SnappingGroupBox)
        Me.DesignTab.Location = New System.Drawing.Point(4, 22)
        Me.DesignTab.Name = "DesignTab"
        Me.DesignTab.Padding = New System.Windows.Forms.Padding(3)
        Me.DesignTab.Size = New System.Drawing.Size(169, 363)
        Me.DesignTab.TabIndex = 3
        Me.DesignTab.Text = "Design"
        Me.DesignTab.UseVisualStyleBackColor = True
        '
        'CursorPositionSnapLabel
        '
        Me.CursorPositionSnapLabel.AutoSize = True
        Me.CursorPositionSnapLabel.BackColor = System.Drawing.Color.Transparent
        Me.CursorPositionSnapLabel.Location = New System.Drawing.Point(8, 321)
        Me.CursorPositionSnapLabel.Name = "CursorPositionSnapLabel"
        Me.CursorPositionSnapLabel.Size = New System.Drawing.Size(117, 13)
        Me.CursorPositionSnapLabel.TabIndex = 6
        Me.CursorPositionSnapLabel.Text = "Cursor Position (snap):"
        '
        'CursorPositionLabel
        '
        Me.CursorPositionLabel.AutoSize = True
        Me.CursorPositionLabel.BackColor = System.Drawing.Color.Transparent
        Me.CursorPositionLabel.Location = New System.Drawing.Point(42, 308)
        Me.CursorPositionLabel.Name = "CursorPositionLabel"
        Me.CursorPositionLabel.Size = New System.Drawing.Size(83, 13)
        Me.CursorPositionLabel.TabIndex = 5
        Me.CursorPositionLabel.Text = "Cursor Position:"
        '
        'UseRightClickMenuChecker
        '
        Me.UseRightClickMenuChecker.AutoSize = True
        Me.UseRightClickMenuChecker.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.UseRightClickMenuChecker.Location = New System.Drawing.Point(37, 341)
        Me.UseRightClickMenuChecker.Name = "UseRightClickMenuChecker"
        Me.UseRightClickMenuChecker.Size = New System.Drawing.Size(126, 17)
        Me.UseRightClickMenuChecker.TabIndex = 0
        Me.UseRightClickMenuChecker.Text = "Use Right-Click Menu"
        Me.UseRightClickMenuChecker.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ObjectInfoLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 214)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(155, 91)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Object(s) under Mouse"
        '
        'ObjectInfoLabel
        '
        Me.ObjectInfoLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ObjectInfoLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ObjectInfoLabel.Location = New System.Drawing.Point(7, 17)
        Me.ObjectInfoLabel.Name = "ObjectInfoLabel"
        Me.ObjectInfoLabel.Size = New System.Drawing.Size(142, 64)
        Me.ObjectInfoLabel.TabIndex = 0
        Me.ObjectInfoLabel.Text = "..."
        '
        'ObjectDropper
        '
        Me.ObjectDropper.FormattingEnabled = True
        Me.ObjectDropper.Location = New System.Drawing.Point(8, 28)
        Me.ObjectDropper.Name = "ObjectDropper"
        Me.ObjectDropper.Size = New System.Drawing.Size(155, 21)
        Me.ObjectDropper.TabIndex = 2
        '
        'PlotWithLeftClickLabel
        '
        Me.PlotWithLeftClickLabel.AutoSize = True
        Me.PlotWithLeftClickLabel.Location = New System.Drawing.Point(8, 12)
        Me.PlotWithLeftClickLabel.Name = "PlotWithLeftClickLabel"
        Me.PlotWithLeftClickLabel.Size = New System.Drawing.Size(77, 13)
        Me.PlotWithLeftClickLabel.TabIndex = 1
        Me.PlotWithLeftClickLabel.Text = "Object to Plot:"
        '
        'SnappingGroupBox
        '
        Me.SnappingGroupBox.Controls.Add(Me.GridColorButton)
        Me.SnappingGroupBox.Controls.Add(Me.SnapYTextBox)
        Me.SnappingGroupBox.Controls.Add(Me.SnapYLabel)
        Me.SnappingGroupBox.Controls.Add(Me.SnapXTextBox)
        Me.SnappingGroupBox.Controls.Add(Me.SnapToGridChecker)
        Me.SnappingGroupBox.Controls.Add(Me.SnapXLabel)
        Me.SnappingGroupBox.Controls.Add(Me.ShowGridChecker)
        Me.SnappingGroupBox.Location = New System.Drawing.Point(8, 64)
        Me.SnappingGroupBox.Name = "SnappingGroupBox"
        Me.SnappingGroupBox.Size = New System.Drawing.Size(155, 145)
        Me.SnappingGroupBox.TabIndex = 0
        Me.SnappingGroupBox.TabStop = False
        Me.SnappingGroupBox.Text = "Snap Settings"
        '
        'GridColorButton
        '
        Me.GridColorButton.Image = Global.DS_Game_Maker.My.Resources.Resources.color
        Me.GridColorButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.GridColorButton.Location = New System.Drawing.Point(50, 109)
        Me.GridColorButton.Name = "GridColorButton"
        Me.GridColorButton.Size = New System.Drawing.Size(99, 28)
        Me.GridColorButton.TabIndex = 0
        Me.GridColorButton.Text = "      Set Grid Color"
        Me.GridColorButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.GridColorButton.UseVisualStyleBackColor = True
        '
        'SnapYTextBox
        '
        Me.SnapYTextBox.Location = New System.Drawing.Point(97, 82)
        Me.SnapYTextBox.Name = "SnapYTextBox"
        Me.SnapYTextBox.Size = New System.Drawing.Size(52, 21)
        Me.SnapYTextBox.TabIndex = 3
        '
        'SnapYLabel
        '
        Me.SnapYLabel.AutoSize = True
        Me.SnapYLabel.Location = New System.Drawing.Point(46, 85)
        Me.SnapYLabel.Name = "SnapYLabel"
        Me.SnapYLabel.Size = New System.Drawing.Size(44, 13)
        Me.SnapYLabel.TabIndex = 2
        Me.SnapYLabel.Text = "Snap Y:"
        '
        'SnapXTextBox
        '
        Me.SnapXTextBox.Location = New System.Drawing.Point(97, 57)
        Me.SnapXTextBox.Name = "SnapXTextBox"
        Me.SnapXTextBox.Size = New System.Drawing.Size(52, 21)
        Me.SnapXTextBox.TabIndex = 0
        '
        'SnapToGridChecker
        '
        Me.SnapToGridChecker.AutoSize = True
        Me.SnapToGridChecker.Location = New System.Drawing.Point(10, 20)
        Me.SnapToGridChecker.Name = "SnapToGridChecker"
        Me.SnapToGridChecker.Size = New System.Drawing.Size(125, 17)
        Me.SnapToGridChecker.TabIndex = 0
        Me.SnapToGridChecker.Text = "Snap Objects to Grid"
        Me.SnapToGridChecker.UseVisualStyleBackColor = True
        '
        'SnapXLabel
        '
        Me.SnapXLabel.AutoSize = True
        Me.SnapXLabel.Location = New System.Drawing.Point(46, 60)
        Me.SnapXLabel.Name = "SnapXLabel"
        Me.SnapXLabel.Size = New System.Drawing.Size(44, 13)
        Me.SnapXLabel.TabIndex = 0
        Me.SnapXLabel.Text = "Snap X:"
        '
        'ShowGridChecker
        '
        Me.ShowGridChecker.AutoSize = True
        Me.ShowGridChecker.Location = New System.Drawing.Point(10, 40)
        Me.ShowGridChecker.Name = "ShowGridChecker"
        Me.ShowGridChecker.Size = New System.Drawing.Size(74, 17)
        Me.ShowGridChecker.TabIndex = 1
        Me.ShowGridChecker.Text = "Show Grid"
        Me.ShowGridChecker.UseVisualStyleBackColor = True
        '
        'TopScreen
        '
        Me.TopScreen.BackColor = System.Drawing.Color.Black
        Me.TopScreen.Location = New System.Drawing.Point(178, 25)
        Me.TopScreen.Name = "TopScreen"
        Me.TopScreen.Size = New System.Drawing.Size(588, 192)
        Me.TopScreen.TabIndex = 1
        '
        'BottomScreen
        '
        Me.BottomScreen.BackColor = System.Drawing.Color.Black
        Me.BottomScreen.Location = New System.Drawing.Point(178, 221)
        Me.BottomScreen.Name = "BottomScreen"
        Me.BottomScreen.Size = New System.Drawing.Size(588, 192)
        Me.BottomScreen.TabIndex = 2
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(434, 25)
        Me.MainToolStrip.TabIndex = 0
        '
        'DAcceptButton
        '
        Me.DAcceptButton.Image = Global.DS_Game_Maker.My.Resources.Resources.AcceptIcon
        Me.DAcceptButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DAcceptButton.Name = "DAcceptButton"
        Me.DAcceptButton.Size = New System.Drawing.Size(60, 22)
        Me.DAcceptButton.Text = "Accept"
        '
        'ObjectRightClickMenu
        '
        Me.ObjectRightClickMenu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ObjectRightClickMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteObjectButton, Me.OpenObjectButton, Me.RightClickSep1, Me.SetCoOrdinatesButton})
        Me.ObjectRightClickMenu.Name = "ObjectRightClickMenu"
        Me.ObjectRightClickMenu.Size = New System.Drawing.Size(166, 98)
        '
        'DeleteObjectButton
        '
        Me.DeleteObjectButton.Image = Global.DS_Game_Maker.My.Resources.Resources.DeleteIcon
        Me.DeleteObjectButton.Name = "DeleteObjectButton"
        Me.DeleteObjectButton.Size = New System.Drawing.Size(165, 22)
        Me.DeleteObjectButton.Text = "Delete"
        '
        'SetCoOrdinatesButton
        '
        Me.SetCoOrdinatesButton.Name = "SetCoOrdinatesButton"
        Me.SetCoOrdinatesButton.Size = New System.Drawing.Size(165, 22)
        Me.SetCoOrdinatesButton.Text = "Move to Position..."
        '
        'RightClickSep1
        '
        Me.RightClickSep1.Name = "RightClickSep1"
        Me.RightClickSep1.Size = New System.Drawing.Size(162, 6)
        '
        'OpenObjectButton
        '
        Me.OpenObjectButton.Image = Global.DS_Game_Maker.My.Resources.Resources.OpenObjectIcon
        Me.OpenObjectButton.Name = "OpenObjectButton"
        Me.OpenObjectButton.Size = New System.Drawing.Size(165, 22)
        Me.OpenObjectButton.Text = "Open Object"
        '
        'Room
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(434, 414)
        Me.Controls.Add(Me.ObjectsTabControl)
        Me.Controls.Add(Me.BottomScreen)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Controls.Add(Me.TopScreen)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(450, 451)
        Me.Name = "Room"
        Me.ObjectsTabControl.ResumeLayout(False)
        Me.GeneralTab.ResumeLayout(False)
        Me.GeneralTab.PerformLayout()
        Me.BottomScreenGroupBox.ResumeLayout(False)
        Me.BottomScreenGroupBox.PerformLayout()
        CType(Me.BottomHeightDropper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomWidthDropper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopScreenGroupBox.ResumeLayout(False)
        Me.TopScreenGroupBox.PerformLayout()
        CType(Me.TopHeightDropper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopWidthDropper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DesignTab.ResumeLayout(False)
        Me.DesignTab.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.SnappingGroupBox.ResumeLayout(False)
        Me.SnappingGroupBox.PerformLayout()
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.ObjectRightClickMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TopHeightLabel As System.Windows.Forms.Label
    Friend WithEvents TopWidthLabel As System.Windows.Forms.Label
    Friend WithEvents ObjectsTabControl As System.Windows.Forms.TabControl
    Friend WithEvents GeneralTab As System.Windows.Forms.TabPage
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TopScreenGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents BottomScreenGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents BottomWidthLabel As System.Windows.Forms.Label
    Friend WithEvents BottomHeightLabel As System.Windows.Forms.Label
    Friend WithEvents TopScreenScrollChecker As System.Windows.Forms.CheckBox
    Friend WithEvents BottomScreenScrollChecker As System.Windows.Forms.CheckBox
    Friend WithEvents ObjectDropper As System.Windows.Forms.ComboBox
    Friend WithEvents PlotWithLeftClickLabel As System.Windows.Forms.Label
    Friend WithEvents BottomHeightDropper As System.Windows.Forms.NumericUpDown
    Friend WithEvents BottomWidthDropper As System.Windows.Forms.NumericUpDown
    Friend WithEvents TopHeightDropper As System.Windows.Forms.NumericUpDown
    Friend WithEvents TopWidthDropper As System.Windows.Forms.NumericUpDown
    Friend WithEvents BottomScreenBGDropper As System.Windows.Forms.ComboBox
    Friend WithEvents TopScreenBGDropper As System.Windows.Forms.ComboBox
    Private WithEvents TopScreen As System.Windows.Forms.Panel
    Private WithEvents BottomScreen As System.Windows.Forms.Panel
    Friend WithEvents DesignTab As System.Windows.Forms.TabPage
    Friend WithEvents ShowGridChecker As System.Windows.Forms.CheckBox
    Friend WithEvents SnapToGridChecker As System.Windows.Forms.CheckBox
    Friend WithEvents SnapXLabel As System.Windows.Forms.Label
    Friend WithEvents SnappingGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents SnapYTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SnapYLabel As System.Windows.Forms.Label
    Friend WithEvents SnapXTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GridColorButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ObjectInfoLabel As System.Windows.Forms.Label
    Friend WithEvents UseRightClickMenuChecker As System.Windows.Forms.CheckBox
    Friend WithEvents ObjectRightClickMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteObjectButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RightClickSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenObjectButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetCoOrdinatesButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CursorPositionSnapLabel As System.Windows.Forms.Label
    Friend WithEvents CursorPositionLabel As System.Windows.Forms.Label
End Class
