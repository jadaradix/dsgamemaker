<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Background
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Background))
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip
        Me.DAcceptButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.EditButton = New System.Windows.Forms.ToolStripButton
        Me.LoadfromFileButton = New System.Windows.Forms.ToolStripButton
        Me.SubPanel = New System.Windows.Forms.Panel
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.NameLabel = New System.Windows.Forms.Label
        Me.PreviewPanel = New System.Windows.Forms.Panel
        Me.MainToolStrip.SuspendLayout()
        Me.SubPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton, Me.ToolStripSep1, Me.EditButton, Me.LoadfromFileButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(256, 25)
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
        'ToolStripSep1
        '
        Me.ToolStripSep1.Name = "ToolStripSep1"
        Me.ToolStripSep1.Size = New System.Drawing.Size(6, 25)
        '
        'EditButton
        '
        Me.EditButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PencilIcon
        Me.EditButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditButton.Name = "EditButton"
        Me.EditButton.Size = New System.Drawing.Size(45, 22)
        Me.EditButton.Text = "Edit"
        Me.EditButton.ToolTipText = "Edit..."
        '
        'LoadfromFileButton
        '
        Me.LoadfromFileButton.Image = Global.DS_Game_Maker.My.Resources.Resources.FolderIcon
        Me.LoadfromFileButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadfromFileButton.Name = "LoadfromFileButton"
        Me.LoadfromFileButton.Size = New System.Drawing.Size(94, 22)
        Me.LoadfromFileButton.Text = "Load from File"
        Me.LoadfromFileButton.ToolTipText = "Load from File..."
        '
        'SubPanel
        '
        Me.SubPanel.BackColor = System.Drawing.Color.Silver
        Me.SubPanel.Controls.Add(Me.NameTextBox)
        Me.SubPanel.Controls.Add(Me.NameLabel)
        Me.SubPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SubPanel.Location = New System.Drawing.Point(0, 217)
        Me.SubPanel.Name = "SubPanel"
        Me.SubPanel.Size = New System.Drawing.Size(256, 28)
        Me.SubPanel.TabIndex = 1
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(49, 3)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(124, 21)
        Me.NameTextBox.TabIndex = 2
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(5, 7)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(38, 13)
        Me.NameLabel.TabIndex = 2
        Me.NameLabel.Text = "Name:"
        '
        'PreviewPanel
        '
        Me.PreviewPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewPanel.Location = New System.Drawing.Point(0, 25)
        Me.PreviewPanel.Name = "PreviewPanel"
        Me.PreviewPanel.Size = New System.Drawing.Size(256, 192)
        Me.PreviewPanel.TabIndex = 2
        '
        'Background
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(256, 245)
        Me.Controls.Add(Me.PreviewPanel)
        Me.Controls.Add(Me.SubPanel)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(272, 283)
        Me.Name = "Background"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.SubPanel.ResumeLayout(False)
        Me.SubPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LoadfromFileButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SubPanel As System.Windows.Forms.Panel
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PreviewPanel As System.Windows.Forms.Panel
End Class
