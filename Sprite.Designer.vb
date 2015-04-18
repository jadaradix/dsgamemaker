<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sprite
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sprite))
        Me.PreviewAnimationGroupBox = New System.Windows.Forms.GroupBox
        Me.FPSTextBox = New System.Windows.Forms.TextBox
        Me.FPSLabel = New System.Windows.Forms.Label
        Me.PreviewButton = New System.Windows.Forms.Button
        Me.NameLabel = New System.Windows.Forms.Label
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.SidePanel = New System.Windows.Forms.Panel
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip
        Me.DAcceptButton = New System.Windows.Forms.ToolStripButton
        Me.ToolSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.LoadFromTLabel = New System.Windows.Forms.ToolStripLabel
        Me.FromFileButton = New System.Windows.Forms.ToolStripButton
        Me.FromSheetButton = New System.Windows.Forms.ToolStripButton
        Me.ToolSep2 = New System.Windows.Forms.ToolStripSeparator
        Me.FramesTLabel = New System.Windows.Forms.ToolStripLabel
        Me.AddBlankFrameButton = New System.Windows.Forms.ToolStripButton
        Me.DeleteFrameButton = New System.Windows.Forms.ToolStripButton
        Me.EditFrameButton = New System.Windows.Forms.ToolStripButton
        Me.ToolSep3 = New System.Windows.Forms.ToolStripSeparator
        Me.LoadFrameButton = New System.Windows.Forms.ToolStripButton
        Me.AddFrameFromFileButton = New System.Windows.Forms.ToolStripButton
        Me.ExportDSSpriteStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolSep4 = New System.Windows.Forms.ToolStripSeparator
        Me.CutButton = New System.Windows.Forms.ToolStripButton
        Me.CopyButton = New System.Windows.Forms.ToolStripButton
        Me.PasteButton = New System.Windows.Forms.ToolStripButton
        Me.ToolSep5 = New System.Windows.Forms.ToolStripSeparator
        Me.TransformButton = New System.Windows.Forms.ToolStripButton
        Me.MainImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.MainListView = New System.Windows.Forms.ListView
        Me.PreviewAnimationGroupBox.SuspendLayout()
        Me.SidePanel.SuspendLayout()
        Me.MainToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'PreviewAnimationGroupBox
        '
        Me.PreviewAnimationGroupBox.Controls.Add(Me.FPSTextBox)
        Me.PreviewAnimationGroupBox.Controls.Add(Me.FPSLabel)
        Me.PreviewAnimationGroupBox.Controls.Add(Me.PreviewButton)
        Me.PreviewAnimationGroupBox.Location = New System.Drawing.Point(12, 52)
        Me.PreviewAnimationGroupBox.Name = "PreviewAnimationGroupBox"
        Me.PreviewAnimationGroupBox.Size = New System.Drawing.Size(153, 69)
        Me.PreviewAnimationGroupBox.TabIndex = 0
        Me.PreviewAnimationGroupBox.TabStop = False
        Me.PreviewAnimationGroupBox.Text = "Preview Animation"
        '
        'FPSTextBox
        '
        Me.FPSTextBox.Location = New System.Drawing.Point(9, 37)
        Me.FPSTextBox.MaxLength = 2
        Me.FPSTextBox.Name = "FPSTextBox"
        Me.FPSTextBox.Size = New System.Drawing.Size(40, 21)
        Me.FPSTextBox.TabIndex = 7
        Me.FPSTextBox.Text = "5"
        '
        'FPSLabel
        '
        Me.FPSLabel.AutoSize = True
        Me.FPSLabel.Location = New System.Drawing.Point(6, 18)
        Me.FPSLabel.Name = "FPSLabel"
        Me.FPSLabel.Size = New System.Drawing.Size(103, 13)
        Me.FPSLabel.TabIndex = 7
        Me.FPSLabel.Text = "Frames Per Second:"
        '
        'PreviewButton
        '
        Me.PreviewButton.Location = New System.Drawing.Point(55, 36)
        Me.PreviewButton.Name = "PreviewButton"
        Me.PreviewButton.Size = New System.Drawing.Size(92, 22)
        Me.PreviewButton.TabIndex = 7
        Me.PreviewButton.Text = "Preview"
        Me.PreviewButton.UseVisualStyleBackColor = True
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(12, 9)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(38, 13)
        Me.NameLabel.TabIndex = 1
        Me.NameLabel.Text = "Name:"
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(12, 25)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(153, 21)
        Me.NameTextBox.TabIndex = 2
        '
        'SidePanel
        '
        Me.SidePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.SidePanel.Controls.Add(Me.NameLabel)
        Me.SidePanel.Controls.Add(Me.NameTextBox)
        Me.SidePanel.Controls.Add(Me.PreviewAnimationGroupBox)
        Me.SidePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.SidePanel.Location = New System.Drawing.Point(0, 25)
        Me.SidePanel.Name = "SidePanel"
        Me.SidePanel.Size = New System.Drawing.Size(177, 288)
        Me.SidePanel.TabIndex = 4
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton, Me.ToolSep1, Me.LoadFromTLabel, Me.FromFileButton, Me.FromSheetButton, Me.ToolSep2, Me.FramesTLabel, Me.AddBlankFrameButton, Me.EditFrameButton, Me.DeleteFrameButton, Me.ToolSep3, Me.LoadFrameButton, Me.AddFrameFromFileButton, Me.ExportDSSpriteStripButton, Me.ToolSep4, Me.CutButton, Me.CopyButton, Me.PasteButton, Me.ToolSep5, Me.TransformButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(612, 25)
        Me.MainToolStrip.TabIndex = 6
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
        'LoadFromTLabel
        '
        Me.LoadFromTLabel.Name = "LoadFromTLabel"
        Me.LoadFromTLabel.Size = New System.Drawing.Size(59, 22)
        Me.LoadFromTLabel.Text = "Load from:"
        '
        'FromFileButton
        '
        Me.FromFileButton.Image = Global.DS_Game_Maker.My.Resources.Resources.OpenIcon
        Me.FromFileButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FromFileButton.Name = "FromFileButton"
        Me.FromFileButton.Size = New System.Drawing.Size(43, 22)
        Me.FromFileButton.Text = "File"
        Me.FromFileButton.ToolTipText = "Import from File..."
        '
        'FromSheetButton
        '
        Me.FromSheetButton.Image = Global.DS_Game_Maker.My.Resources.Resources.InsertIcon
        Me.FromSheetButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FromSheetButton.Name = "FromSheetButton"
        Me.FromSheetButton.Size = New System.Drawing.Size(55, 22)
        Me.FromSheetButton.Text = "Sheet"
        Me.FromSheetButton.ToolTipText = "Import from Sheet..."
        '
        'ToolSep2
        '
        Me.ToolSep2.Name = "ToolSep2"
        Me.ToolSep2.Size = New System.Drawing.Size(6, 25)
        '
        'FramesTLabel
        '
        Me.FramesTLabel.Name = "FramesTLabel"
        Me.FramesTLabel.Size = New System.Drawing.Size(46, 22)
        Me.FramesTLabel.Text = "Frames:"
        '
        'AddBlankFrameButton
        '
        Me.AddBlankFrameButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AddBlankFrameButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PlusIcon
        Me.AddBlankFrameButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddBlankFrameButton.Name = "AddBlankFrameButton"
        Me.AddBlankFrameButton.Size = New System.Drawing.Size(23, 22)
        Me.AddBlankFrameButton.Text = "Add"
        Me.AddBlankFrameButton.ToolTipText = "Add Frame"
        '
        'DeleteFrameButton
        '
        Me.DeleteFrameButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DeleteFrameButton.Image = Global.DS_Game_Maker.My.Resources.Resources.DeleteIcon
        Me.DeleteFrameButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteFrameButton.Name = "DeleteFrameButton"
        Me.DeleteFrameButton.Size = New System.Drawing.Size(23, 22)
        Me.DeleteFrameButton.Text = "Delete"
        Me.DeleteFrameButton.ToolTipText = "Delete Frame"
        '
        'EditFrameButton
        '
        Me.EditFrameButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PencilIcon
        Me.EditFrameButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditFrameButton.Name = "EditFrameButton"
        Me.EditFrameButton.Size = New System.Drawing.Size(45, 22)
        Me.EditFrameButton.Text = "Edit"
        Me.EditFrameButton.ToolTipText = "Edit Frame..."
        '
        'ToolSep3
        '
        Me.ToolSep3.Name = "ToolSep3"
        Me.ToolSep3.Size = New System.Drawing.Size(6, 25)
        '
        'LoadFrameButton
        '
        Me.LoadFrameButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LoadFrameButton.Image = Global.DS_Game_Maker.My.Resources.Resources.OpenIcon
        Me.LoadFrameButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadFrameButton.Name = "LoadFrameButton"
        Me.LoadFrameButton.Size = New System.Drawing.Size(23, 22)
        Me.LoadFrameButton.Text = "Load Frame from File"
        Me.LoadFrameButton.ToolTipText = "Load Frame from File..."
        '
        'AddFrameFromFileButton
        '
        Me.AddFrameFromFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AddFrameFromFileButton.Image = Global.DS_Game_Maker.My.Resources.Resources.AddFolderIcon
        Me.AddFrameFromFileButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddFrameFromFileButton.Name = "AddFrameFromFileButton"
        Me.AddFrameFromFileButton.Size = New System.Drawing.Size(23, 22)
        Me.AddFrameFromFileButton.Text = "Add Frame From File"
        Me.AddFrameFromFileButton.ToolTipText = "Add Frame From File..."
        '
        'ExportDSSpriteStripButton
        '
        Me.ExportDSSpriteStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExportDSSpriteStripButton.Image = Global.DS_Game_Maker.My.Resources.Resources.ExportSpriteStripButton
        Me.ExportDSSpriteStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExportDSSpriteStripButton.Name = "ExportDSSpriteStripButton"
        Me.ExportDSSpriteStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ExportDSSpriteStripButton.Text = "Export as DS Compatible Strip"
        Me.ExportDSSpriteStripButton.ToolTipText = "Export as DS Compatible Strip..."
        '
        'ToolSep4
        '
        Me.ToolSep4.Name = "ToolSep4"
        Me.ToolSep4.Size = New System.Drawing.Size(6, 25)
        '
        'CutButton
        '
        Me.CutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutButton.Image = Global.DS_Game_Maker.My.Resources.Resources.CutIcon
        Me.CutButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutButton.Name = "CutButton"
        Me.CutButton.Size = New System.Drawing.Size(23, 22)
        Me.CutButton.Text = "Cut Frame"
        '
        'CopyButton
        '
        Me.CopyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyButton.Image = Global.DS_Game_Maker.My.Resources.Resources.CopyIcon
        Me.CopyButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyButton.Name = "CopyButton"
        Me.CopyButton.Size = New System.Drawing.Size(23, 22)
        Me.CopyButton.Text = "Copy Frame"
        '
        'PasteButton
        '
        Me.PasteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PasteIcon
        Me.PasteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteButton.Name = "PasteButton"
        Me.PasteButton.Size = New System.Drawing.Size(23, 22)
        Me.PasteButton.Text = "Paste Frame"
        '
        'ToolSep5
        '
        Me.ToolSep5.Name = "ToolSep5"
        Me.ToolSep5.Size = New System.Drawing.Size(6, 25)
        '
        'TransformButton
        '
        Me.TransformButton.Enabled = False
        Me.TransformButton.Image = Global.DS_Game_Maker.My.Resources.Resources.TransformIcon
        Me.TransformButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TransformButton.Name = "TransformButton"
        Me.TransformButton.Size = New System.Drawing.Size(76, 22)
        Me.TransformButton.Text = "Transform"
        Me.TransformButton.ToolTipText = "Transform Frame(s)..."
        '
        'MainImageList
        '
        Me.MainImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.MainImageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.MainImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'MainListView
        '
        Me.MainListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainListView.LargeImageList = Me.MainImageList
        Me.MainListView.Location = New System.Drawing.Point(177, 25)
        Me.MainListView.Name = "MainListView"
        Me.MainListView.Size = New System.Drawing.Size(435, 288)
        Me.MainListView.TabIndex = 3
        Me.MainListView.UseCompatibleStateImageBehavior = False
        '
        'Sprite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(612, 313)
        Me.Controls.Add(Me.MainListView)
        Me.Controls.Add(Me.SidePanel)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(620, 340)
        Me.Name = "Sprite"
        Me.PreviewAnimationGroupBox.ResumeLayout(False)
        Me.PreviewAnimationGroupBox.PerformLayout()
        Me.SidePanel.ResumeLayout(False)
        Me.SidePanel.PerformLayout()
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PreviewAnimationGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SidePanel As System.Windows.Forms.Panel
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents AddBlankFrameButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeleteFrameButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditFrameButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FPSLabel As System.Windows.Forms.Label
    Friend WithEvents PreviewButton As System.Windows.Forms.Button
    Friend WithEvents FPSTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MainImageList As System.Windows.Forms.ImageList
    Friend WithEvents LoadFrameButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSep3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MainListView As System.Windows.Forms.ListView
    Friend WithEvents FromSheetButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AddFrameFromFileButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ExportDSSpriteStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSep4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PasteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSep5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TransformButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FromFileButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FramesTLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LoadFromTLabel As System.Windows.Forms.ToolStripLabel
End Class
