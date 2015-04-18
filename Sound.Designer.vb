<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sound
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sound))
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip
        Me.DAcceptButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.EditButton = New System.Windows.Forms.ToolStripButton
        Me.LoadButton = New System.Windows.Forms.ToolStripButton
        Me.IconPictureBox = New System.Windows.Forms.PictureBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.InfoLabel = New System.Windows.Forms.Label
        Me.PlayButton = New System.Windows.Forms.Panel
        Me.StopButton = New System.Windows.Forms.Panel
        Me.MainToolStrip.SuspendLayout()
        CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton, Me.ToolStripSeparator, Me.EditButton, Me.LoadButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(235, 25)
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
        'ToolStripSeparator
        '
        Me.ToolStripSeparator.Name = "ToolStripSeparator"
        Me.ToolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'EditButton
        '
        Me.EditButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PencilIcon
        Me.EditButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditButton.Name = "EditButton"
        Me.EditButton.Size = New System.Drawing.Size(45, 22)
        Me.EditButton.Text = "Edit"
        '
        'LoadButton
        '
        Me.LoadButton.Image = Global.DS_Game_Maker.My.Resources.Resources.OpenIcon
        Me.LoadButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadButton.Name = "LoadButton"
        Me.LoadButton.Size = New System.Drawing.Size(94, 22)
        Me.LoadButton.Text = "Load from File"
        '
        'IconPictureBox
        '
        Me.IconPictureBox.Image = Global.DS_Game_Maker.My.Resources.Resources.BigMusicIcon1
        Me.IconPictureBox.Location = New System.Drawing.Point(4, 27)
        Me.IconPictureBox.Name = "IconPictureBox"
        Me.IconPictureBox.Size = New System.Drawing.Size(84, 84)
        Me.IconPictureBox.TabIndex = 1
        Me.IconPictureBox.TabStop = False
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(94, 29)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(136, 21)
        Me.NameTextBox.TabIndex = 3
        '
        'InfoLabel
        '
        Me.InfoLabel.AutoSize = True
        Me.InfoLabel.Location = New System.Drawing.Point(94, 53)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(19, 13)
        Me.InfoLabel.TabIndex = 6
        Me.InfoLabel.Text = "..."
        '
        'PlayButton
        '
        Me.PlayButton.BackgroundImage = Global.DS_Game_Maker.My.Resources.Resources.PlayButtonIcon
        Me.PlayButton.Location = New System.Drawing.Point(161, 79)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(32, 32)
        Me.PlayButton.TabIndex = 6
        '
        'StopButton
        '
        Me.StopButton.BackgroundImage = Global.DS_Game_Maker.My.Resources.Resources.StopButtonIcon
        Me.StopButton.Location = New System.Drawing.Point(197, 79)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(32, 32)
        Me.StopButton.TabIndex = 7
        '
        'Sound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(235, 116)
        Me.Controls.Add(Me.PlayButton)
        Me.Controls.Add(Me.StopButton)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Controls.Add(Me.IconPictureBox)
        Me.Controls.Add(Me.InfoLabel)
        Me.Controls.Add(Me.NameTextBox)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(251, 323)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(251, 50)
        Me.Name = "Sound"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents IconPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EditButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LoadButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents InfoLabel As System.Windows.Forms.Label
    Friend WithEvents PlayButton As System.Windows.Forms.Panel
    Friend WithEvents StopButton As System.Windows.Forms.Panel
End Class
