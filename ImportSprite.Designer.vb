<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportSprite
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportSprite))
        Me.ImportSettingsPanel = New System.Windows.Forms.Panel
        Me.ImagesPerColumnDropper = New System.Windows.Forms.NumericUpDown
        Me.ImagesPerColumnLabel = New System.Windows.Forms.Label
        Me.DAcceptButton = New System.Windows.Forms.Button
        Me.ImagesPerRowDropper = New System.Windows.Forms.NumericUpDown
        Me.FrameHeightDropper = New System.Windows.Forms.ComboBox
        Me.FrameHeightLabel = New System.Windows.Forms.Label
        Me.FrameWidthDropper = New System.Windows.Forms.ComboBox
        Me.FrameWidthLabel = New System.Windows.Forms.Label
        Me.ImagesPerRowLabel = New System.Windows.Forms.Label
        Me.PreviewPanel = New System.Windows.Forms.Panel
        Me.ImportSettingsPanel.SuspendLayout()
        CType(Me.ImagesPerColumnDropper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImagesPerRowDropper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImportSettingsPanel
        '
        Me.ImportSettingsPanel.Controls.Add(Me.ImagesPerColumnDropper)
        Me.ImportSettingsPanel.Controls.Add(Me.ImagesPerColumnLabel)
        Me.ImportSettingsPanel.Controls.Add(Me.DAcceptButton)
        Me.ImportSettingsPanel.Controls.Add(Me.ImagesPerRowDropper)
        Me.ImportSettingsPanel.Controls.Add(Me.FrameHeightDropper)
        Me.ImportSettingsPanel.Controls.Add(Me.FrameHeightLabel)
        Me.ImportSettingsPanel.Controls.Add(Me.FrameWidthDropper)
        Me.ImportSettingsPanel.Controls.Add(Me.FrameWidthLabel)
        Me.ImportSettingsPanel.Controls.Add(Me.ImagesPerRowLabel)
        Me.ImportSettingsPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.ImportSettingsPanel.Location = New System.Drawing.Point(0, 0)
        Me.ImportSettingsPanel.Name = "ImportSettingsPanel"
        Me.ImportSettingsPanel.Size = New System.Drawing.Size(177, 442)
        Me.ImportSettingsPanel.TabIndex = 0
        '
        'ImagesPerColumnDropper
        '
        Me.ImagesPerColumnDropper.Location = New System.Drawing.Point(117, 93)
        Me.ImagesPerColumnDropper.Name = "ImagesPerColumnDropper"
        Me.ImagesPerColumnDropper.Size = New System.Drawing.Size(47, 21)
        Me.ImagesPerColumnDropper.TabIndex = 6
        Me.ImagesPerColumnDropper.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'ImagesPerColumnLabel
        '
        Me.ImagesPerColumnLabel.AutoSize = True
        Me.ImagesPerColumnLabel.Location = New System.Drawing.Point(8, 95)
        Me.ImagesPerColumnLabel.Name = "ImagesPerColumnLabel"
        Me.ImagesPerColumnLabel.Size = New System.Drawing.Size(103, 13)
        Me.ImagesPerColumnLabel.TabIndex = 7
        Me.ImagesPerColumnLabel.Text = "Images Per Column:"
        '
        'DAcceptButton
        '
        Me.DAcceptButton.Image = Global.DS_Game_Maker.My.Resources.Resources.AcceptIcon
        Me.DAcceptButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DAcceptButton.Location = New System.Drawing.Point(12, 120)
        Me.DAcceptButton.Name = "DAcceptButton"
        Me.DAcceptButton.Size = New System.Drawing.Size(152, 26)
        Me.DAcceptButton.TabIndex = 5
        Me.DAcceptButton.Text = "Accept"
        Me.DAcceptButton.UseVisualStyleBackColor = True
        '
        'ImagesPerRowDropper
        '
        Me.ImagesPerRowDropper.Location = New System.Drawing.Point(117, 66)
        Me.ImagesPerRowDropper.Name = "ImagesPerRowDropper"
        Me.ImagesPerRowDropper.Size = New System.Drawing.Size(47, 21)
        Me.ImagesPerRowDropper.TabIndex = 1
        Me.ImagesPerRowDropper.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'FrameHeightDropper
        '
        Me.FrameHeightDropper.FormattingEnabled = True
        Me.FrameHeightDropper.Items.AddRange(New Object() {"16", "32", "64"})
        Me.FrameHeightDropper.Location = New System.Drawing.Point(117, 39)
        Me.FrameHeightDropper.Name = "FrameHeightDropper"
        Me.FrameHeightDropper.Size = New System.Drawing.Size(47, 21)
        Me.FrameHeightDropper.TabIndex = 4
        Me.FrameHeightDropper.Text = "32"
        '
        'FrameHeightLabel
        '
        Me.FrameHeightLabel.AutoSize = True
        Me.FrameHeightLabel.Location = New System.Drawing.Point(36, 42)
        Me.FrameHeightLabel.Name = "FrameHeightLabel"
        Me.FrameHeightLabel.Size = New System.Drawing.Size(75, 13)
        Me.FrameHeightLabel.TabIndex = 3
        Me.FrameHeightLabel.Text = "Frame Height:"
        '
        'FrameWidthDropper
        '
        Me.FrameWidthDropper.FormattingEnabled = True
        Me.FrameWidthDropper.Items.AddRange(New Object() {"16", "32", "64"})
        Me.FrameWidthDropper.Location = New System.Drawing.Point(117, 12)
        Me.FrameWidthDropper.Name = "FrameWidthDropper"
        Me.FrameWidthDropper.Size = New System.Drawing.Size(47, 21)
        Me.FrameWidthDropper.TabIndex = 1
        Me.FrameWidthDropper.Text = "32"
        '
        'FrameWidthLabel
        '
        Me.FrameWidthLabel.AutoSize = True
        Me.FrameWidthLabel.Location = New System.Drawing.Point(39, 15)
        Me.FrameWidthLabel.Name = "FrameWidthLabel"
        Me.FrameWidthLabel.Size = New System.Drawing.Size(72, 13)
        Me.FrameWidthLabel.TabIndex = 1
        Me.FrameWidthLabel.Text = "Frame Width:"
        '
        'ImagesPerRowLabel
        '
        Me.ImagesPerRowLabel.AutoSize = True
        Me.ImagesPerRowLabel.Location = New System.Drawing.Point(22, 68)
        Me.ImagesPerRowLabel.Name = "ImagesPerRowLabel"
        Me.ImagesPerRowLabel.Size = New System.Drawing.Size(89, 13)
        Me.ImagesPerRowLabel.TabIndex = 2
        Me.ImagesPerRowLabel.Text = "Images Per Row:"
        '
        'PreviewPanel
        '
        Me.PreviewPanel.BackColor = System.Drawing.Color.White
        Me.PreviewPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewPanel.Location = New System.Drawing.Point(177, 0)
        Me.PreviewPanel.Name = "PreviewPanel"
        Me.PreviewPanel.Size = New System.Drawing.Size(447, 442)
        Me.PreviewPanel.TabIndex = 1
        '
        'ImportSprite
        '
        Me.AcceptButton = Me.DAcceptButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(624, 442)
        Me.Controls.Add(Me.PreviewPanel)
        Me.Controls.Add(Me.ImportSettingsPanel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ImportSprite"
        Me.Text = "Import Sprite"
        Me.ImportSettingsPanel.ResumeLayout(False)
        Me.ImportSettingsPanel.PerformLayout()
        CType(Me.ImagesPerColumnDropper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImagesPerRowDropper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImportSettingsPanel As System.Windows.Forms.Panel
    Friend WithEvents ImagesPerRowDropper As System.Windows.Forms.NumericUpDown
    Friend WithEvents ImagesPerRowLabel As System.Windows.Forms.Label
    Friend WithEvents FrameWidthDropper As System.Windows.Forms.ComboBox
    Friend WithEvents FrameWidthLabel As System.Windows.Forms.Label
    Friend WithEvents FrameHeightDropper As System.Windows.Forms.ComboBox
    Friend WithEvents FrameHeightLabel As System.Windows.Forms.Label
    Friend WithEvents DAcceptButton As System.Windows.Forms.Button
    Friend WithEvents PreviewPanel As System.Windows.Forms.Panel
    Friend WithEvents ImagesPerColumnDropper As System.Windows.Forms.NumericUpDown
    Friend WithEvents ImagesPerColumnLabel As System.Windows.Forms.Label
End Class
