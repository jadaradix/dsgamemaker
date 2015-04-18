<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Statistics
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Statistics))
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip
        Me.DAcceptButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.CopytoClipboardButton = New System.Windows.Forms.ToolStripButton
        Me.ResourcesHeaderLabel = New System.Windows.Forms.Label
        Me.ResoucesLabel = New System.Windows.Forms.Label
        Me.LogicLabel = New System.Windows.Forms.Label
        Me.LogicHeaderLabel = New System.Windows.Forms.Label
        Me.CoolBar = New System.Windows.Forms.ProgressBar
        Me.CalculateUsageButton = New System.Windows.Forms.Button
        Me.UsageLabel = New System.Windows.Forms.Label
        Me.MainToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton, Me.ToolStripSep1, Me.CopytoClipboardButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(287, 25)
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
        'CopytoClipboardButton
        '
        Me.CopytoClipboardButton.Image = Global.DS_Game_Maker.My.Resources.Resources.CopyIcon
        Me.CopytoClipboardButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopytoClipboardButton.Name = "CopytoClipboardButton"
        Me.CopytoClipboardButton.Size = New System.Drawing.Size(113, 22)
        Me.CopytoClipboardButton.Text = "Copy to Clipboard"
        '
        'ResourcesHeaderLabel
        '
        Me.ResourcesHeaderLabel.AutoSize = True
        Me.ResourcesHeaderLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResourcesHeaderLabel.Location = New System.Drawing.Point(9, 30)
        Me.ResourcesHeaderLabel.Name = "ResourcesHeaderLabel"
        Me.ResourcesHeaderLabel.Size = New System.Drawing.Size(69, 13)
        Me.ResourcesHeaderLabel.TabIndex = 1
        Me.ResourcesHeaderLabel.Text = "Resources:"
        '
        'ResoucesLabel
        '
        Me.ResoucesLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ResoucesLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResoucesLabel.Location = New System.Drawing.Point(12, 47)
        Me.ResoucesLabel.Name = "ResoucesLabel"
        Me.ResoucesLabel.Size = New System.Drawing.Size(263, 90)
        Me.ResoucesLabel.TabIndex = 2
        '
        'LogicLabel
        '
        Me.LogicLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LogicLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogicLabel.Location = New System.Drawing.Point(12, 159)
        Me.LogicLabel.Name = "LogicLabel"
        Me.LogicLabel.Size = New System.Drawing.Size(263, 90)
        Me.LogicLabel.TabIndex = 4
        '
        'LogicHeaderLabel
        '
        Me.LogicHeaderLabel.AutoSize = True
        Me.LogicHeaderLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogicHeaderLabel.Location = New System.Drawing.Point(9, 142)
        Me.LogicHeaderLabel.Name = "LogicHeaderLabel"
        Me.LogicHeaderLabel.Size = New System.Drawing.Size(39, 13)
        Me.LogicHeaderLabel.TabIndex = 3
        Me.LogicHeaderLabel.Text = "Logic:"
        '
        'CoolBar
        '
        Me.CoolBar.Location = New System.Drawing.Point(92, 274)
        Me.CoolBar.Name = "CoolBar"
        Me.CoolBar.Size = New System.Drawing.Size(183, 22)
        Me.CoolBar.TabIndex = 5
        '
        'CalculateUsageButton
        '
        Me.CalculateUsageButton.Location = New System.Drawing.Point(12, 274)
        Me.CalculateUsageButton.Name = "CalculateUsageButton"
        Me.CalculateUsageButton.Size = New System.Drawing.Size(74, 22)
        Me.CalculateUsageButton.TabIndex = 6
        Me.CalculateUsageButton.Text = "Calculate"
        Me.CalculateUsageButton.UseVisualStyleBackColor = True
        '
        'UsageLabel
        '
        Me.UsageLabel.AutoSize = True
        Me.UsageLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsageLabel.Location = New System.Drawing.Point(9, 256)
        Me.UsageLabel.Name = "UsageLabel"
        Me.UsageLabel.Size = New System.Drawing.Size(190, 13)
        Me.UsageLabel.TabIndex = 7
        Me.UsageLabel.Text = "Project Coolness (approximate):"
        '
        'Statistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(287, 311)
        Me.Controls.Add(Me.UsageLabel)
        Me.Controls.Add(Me.CalculateUsageButton)
        Me.Controls.Add(Me.CoolBar)
        Me.Controls.Add(Me.LogicLabel)
        Me.Controls.Add(Me.LogicHeaderLabel)
        Me.Controls.Add(Me.ResoucesLabel)
        Me.Controls.Add(Me.ResourcesHeaderLabel)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Statistics"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Project Statistics"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopytoClipboardButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ResourcesHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents ResoucesLabel As System.Windows.Forms.Label
    Friend WithEvents LogicLabel As System.Windows.Forms.Label
    Friend WithEvents LogicHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents CoolBar As System.Windows.Forms.ProgressBar
    Friend WithEvents CalculateUsageButton As System.Windows.Forms.Button
    Friend WithEvents UsageLabel As System.Windows.Forms.Label
End Class
