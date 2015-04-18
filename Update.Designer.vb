<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DUpdate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DUpdate))
        Me.MainTopPanel = New System.Windows.Forms.Panel
        Me.InfoLabel = New System.Windows.Forms.Label
        Me.TitleLabel = New System.Windows.Forms.Label
        Me.InstallButton = New System.Windows.Forms.Button
        Me.NeverMindButton = New System.Windows.Forms.Button
        Me.MainWebBrowser = New System.Windows.Forms.WebBrowser
        Me.UpdateIconPanel = New System.Windows.Forms.Panel
        Me.MainTopPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTopPanel
        '
        Me.MainTopPanel.BackColor = System.Drawing.Color.White
        Me.MainTopPanel.Controls.Add(Me.InfoLabel)
        Me.MainTopPanel.Controls.Add(Me.TitleLabel)
        Me.MainTopPanel.Controls.Add(Me.UpdateIconPanel)
        Me.MainTopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainTopPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainTopPanel.Name = "MainTopPanel"
        Me.MainTopPanel.Size = New System.Drawing.Size(362, 108)
        Me.MainTopPanel.TabIndex = 0
        '
        'InfoLabel
        '
        Me.InfoLabel.AutoSize = True
        Me.InfoLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoLabel.ForeColor = System.Drawing.Color.Gray
        Me.InfoLabel.Location = New System.Drawing.Point(110, 44)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(192, 14)
        Me.InfoLabel.TabIndex = 3
        Me.InfoLabel.Text = "Available for immediate installation"
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(108, 20)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(31, 24)
        Me.TitleLabel.TabIndex = 2
        Me.TitleLabel.Text = "..."
        '
        'InstallButton
        '
        Me.InstallButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstallButton.Location = New System.Drawing.Point(272, 366)
        Me.InstallButton.Name = "InstallButton"
        Me.InstallButton.Size = New System.Drawing.Size(84, 28)
        Me.InstallButton.TabIndex = 1
        Me.InstallButton.Text = "Install"
        Me.InstallButton.UseVisualStyleBackColor = True
        '
        'NeverMindButton
        '
        Me.NeverMindButton.Location = New System.Drawing.Point(186, 366)
        Me.NeverMindButton.Name = "NeverMindButton"
        Me.NeverMindButton.Size = New System.Drawing.Size(84, 28)
        Me.NeverMindButton.TabIndex = 2
        Me.NeverMindButton.Text = "Never Mind"
        Me.NeverMindButton.UseVisualStyleBackColor = True
        '
        'MainWebBrowser
        '
        Me.MainWebBrowser.Location = New System.Drawing.Point(6, 114)
        Me.MainWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.MainWebBrowser.Name = "MainWebBrowser"
        Me.MainWebBrowser.Size = New System.Drawing.Size(350, 246)
        Me.MainWebBrowser.TabIndex = 3
        '
        'UpdateIconPanel
        '
        Me.UpdateIconPanel.BackgroundImage = Global.DS_Game_Maker.My.Resources.Resources.UpdateBigIcon
        Me.UpdateIconPanel.Location = New System.Drawing.Point(6, 6)
        Me.UpdateIconPanel.Name = "UpdateIconPanel"
        Me.UpdateIconPanel.Size = New System.Drawing.Size(96, 96)
        Me.UpdateIconPanel.TabIndex = 1
        '
        'DUpdate
        '
        Me.AcceptButton = Me.InstallButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 399)
        Me.Controls.Add(Me.MainWebBrowser)
        Me.Controls.Add(Me.NeverMindButton)
        Me.Controls.Add(Me.InstallButton)
        Me.Controls.Add(Me.MainTopPanel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Update"
        Me.MainTopPanel.ResumeLayout(False)
        Me.MainTopPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainTopPanel As System.Windows.Forms.Panel
    Friend WithEvents UpdateIconPanel As System.Windows.Forms.Panel
    Friend WithEvents TitleLabel As System.Windows.Forms.Label
    Friend WithEvents InfoLabel As System.Windows.Forms.Label
    Friend WithEvents InstallButton As System.Windows.Forms.Button
    Friend WithEvents NeverMindButton As System.Windows.Forms.Button
    Friend WithEvents MainWebBrowser As System.Windows.Forms.WebBrowser
End Class
