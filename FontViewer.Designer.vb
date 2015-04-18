<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FontViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FontViewer))
        Me.NamePanel = New System.Windows.Forms.Panel
        Me.RebuildCacheButton = New System.Windows.Forms.Button
        Me.PreviousButton = New System.Windows.Forms.Button
        Me.NextButton = New System.Windows.Forms.Button
        Me.NameLabel = New System.Windows.Forms.Label
        Me.MainImagePanel = New System.Windows.Forms.Panel
        Me.MainStatusStrip = New System.Windows.Forms.StatusStrip
        Me.MainInfoLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.NamePanel.SuspendLayout()
        Me.MainStatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'NamePanel
        '
        Me.NamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NamePanel.Controls.Add(Me.RebuildCacheButton)
        Me.NamePanel.Controls.Add(Me.PreviousButton)
        Me.NamePanel.Controls.Add(Me.NextButton)
        Me.NamePanel.Controls.Add(Me.NameLabel)
        Me.NamePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.NamePanel.Location = New System.Drawing.Point(0, 0)
        Me.NamePanel.Name = "NamePanel"
        Me.NamePanel.Size = New System.Drawing.Size(280, 28)
        Me.NamePanel.TabIndex = 0
        '
        'RebuildCacheButton
        '
        Me.RebuildCacheButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RebuildCacheButton.Image = Global.DS_Game_Maker.My.Resources.Resources.OpenLastIcon
        Me.RebuildCacheButton.Location = New System.Drawing.Point(205, 1)
        Me.RebuildCacheButton.Name = "RebuildCacheButton"
        Me.RebuildCacheButton.Size = New System.Drawing.Size(24, 24)
        Me.RebuildCacheButton.TabIndex = 3
        Me.RebuildCacheButton.UseVisualStyleBackColor = True
        '
        'PreviousButton
        '
        Me.PreviousButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PreviousButton.Image = Global.DS_Game_Maker.My.Resources.Resources.ArrowUp
        Me.PreviousButton.Location = New System.Drawing.Point(229, 1)
        Me.PreviousButton.Name = "PreviousButton"
        Me.PreviousButton.Size = New System.Drawing.Size(24, 24)
        Me.PreviousButton.TabIndex = 2
        Me.PreviousButton.UseVisualStyleBackColor = True
        '
        'NextButton
        '
        Me.NextButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NextButton.Image = Global.DS_Game_Maker.My.Resources.Resources.ArrowDown
        Me.NextButton.Location = New System.Drawing.Point(253, 1)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(24, 24)
        Me.NextButton.TabIndex = 1
        Me.NextButton.UseVisualStyleBackColor = True
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameLabel.Location = New System.Drawing.Point(3, 5)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(20, 18)
        Me.NameLabel.TabIndex = 1
        Me.NameLabel.Text = "..."
        '
        'MainImagePanel
        '
        Me.MainImagePanel.BackColor = System.Drawing.Color.White
        Me.MainImagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.MainImagePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainImagePanel.Location = New System.Drawing.Point(0, 28)
        Me.MainImagePanel.Name = "MainImagePanel"
        Me.MainImagePanel.Size = New System.Drawing.Size(280, 104)
        Me.MainImagePanel.TabIndex = 1
        '
        'MainStatusStrip
        '
        Me.MainStatusStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainInfoLabel})
        Me.MainStatusStrip.Location = New System.Drawing.Point(0, 132)
        Me.MainStatusStrip.Name = "MainStatusStrip"
        Me.MainStatusStrip.Size = New System.Drawing.Size(280, 22)
        Me.MainStatusStrip.SizingGrip = False
        Me.MainStatusStrip.TabIndex = 2
        Me.MainStatusStrip.Text = "StatusStrip1"
        '
        'MainInfoLabel
        '
        Me.MainInfoLabel.Name = "MainInfoLabel"
        Me.MainInfoLabel.Size = New System.Drawing.Size(19, 17)
        Me.MainInfoLabel.Text = "..."
        '
        'FontViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 154)
        Me.Controls.Add(Me.MainImagePanel)
        Me.Controls.Add(Me.NamePanel)
        Me.Controls.Add(Me.MainStatusStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(296, 192)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(296, 192)
        Me.Name = "FontViewer"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Font Viewer"
        Me.NamePanel.ResumeLayout(False)
        Me.NamePanel.PerformLayout()
        Me.MainStatusStrip.ResumeLayout(False)
        Me.MainStatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NamePanel As System.Windows.Forms.Panel
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents PreviousButton As System.Windows.Forms.Button
    Friend WithEvents MainImagePanel As System.Windows.Forms.Panel
    Friend WithEvents RebuildCacheButton As System.Windows.Forms.Button
    Friend WithEvents MainStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MainInfoLabel As System.Windows.Forms.ToolStripStatusLabel
End Class
