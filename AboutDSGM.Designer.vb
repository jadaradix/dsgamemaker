<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutDSGM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutDSGM))
        Me.DSGMTopPanel = New System.Windows.Forms.Panel()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.AdditionalCreditsLabel = New System.Windows.Forms.Label()
        Me.WebAddressLabel = New System.Windows.Forms.Label()
        Me.MainInfoLabel = New System.Windows.Forms.Label()
        Me.WrittenByLabel = New System.Windows.Forms.Label()
        Me.VersionLabel = New System.Windows.Forms.Label()
        Me.DOkayButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MainPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'DSGMTopPanel
        '
        Me.DSGMTopPanel.BackgroundImage = Global.DS_Game_Maker.My.Resources.Resources.DSGMTopBanner
        Me.DSGMTopPanel.Location = New System.Drawing.Point(0, 0)
        Me.DSGMTopPanel.Name = "DSGMTopPanel"
        Me.DSGMTopPanel.Size = New System.Drawing.Size(338, 130)
        Me.DSGMTopPanel.TabIndex = 0
        '
        'MainPanel
        '
        Me.MainPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MainPanel.Controls.Add(Me.Label1)
        Me.MainPanel.Controls.Add(Me.AdditionalCreditsLabel)
        Me.MainPanel.Controls.Add(Me.WebAddressLabel)
        Me.MainPanel.Controls.Add(Me.MainInfoLabel)
        Me.MainPanel.Controls.Add(Me.WrittenByLabel)
        Me.MainPanel.Location = New System.Drawing.Point(0, 130)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(338, 235)
        Me.MainPanel.TabIndex = 1
        '
        'AdditionalCreditsLabel
        '
        Me.AdditionalCreditsLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdditionalCreditsLabel.ForeColor = System.Drawing.Color.Silver
        Me.AdditionalCreditsLabel.Location = New System.Drawing.Point(8, 60)
        Me.AdditionalCreditsLabel.Name = "AdditionalCreditsLabel"
        Me.AdditionalCreditsLabel.Size = New System.Drawing.Size(314, 67)
        Me.AdditionalCreditsLabel.TabIndex = 3
        Me.AdditionalCreditsLabel.Text = "Additional components and assistance contributed by Dave J Murphy, Michael Noland" & _
            ", Jason Rogers, Gregory Potdevin, Chris Rickard, Nick Thissen, Robert Dixon, Dav" & _
            "e Tabba, Cilein Kearns and Baron Khan."
        '
        'WebAddressLabel
        '
        Me.WebAddressLabel.AutoSize = True
        Me.WebAddressLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.WebAddressLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WebAddressLabel.ForeColor = System.Drawing.Color.White
        Me.WebAddressLabel.Location = New System.Drawing.Point(8, 207)
        Me.WebAddressLabel.Name = "WebAddressLabel"
        Me.WebAddressLabel.Size = New System.Drawing.Size(157, 14)
        Me.WebAddressLabel.TabIndex = 2
        Me.WebAddressLabel.Text = "www.dsgamemaker.com"
        '
        'MainInfoLabel
        '
        Me.MainInfoLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainInfoLabel.ForeColor = System.Drawing.Color.White
        Me.MainInfoLabel.Location = New System.Drawing.Point(8, 127)
        Me.MainInfoLabel.Name = "MainInfoLabel"
        Me.MainInfoLabel.Size = New System.Drawing.Size(314, 80)
        Me.MainInfoLabel.TabIndex = 1
        Me.MainInfoLabel.Text = "Copyright James Garner, Invisionsoft 2008-2011" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "For DS Game Maker updates, rela" & _
            "ted products (such as DS Homebrew Kits), more information, discussion and games," & _
            " visit our website:"
        '
        'WrittenByLabel
        '
        Me.WrittenByLabel.AutoSize = True
        Me.WrittenByLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WrittenByLabel.ForeColor = System.Drawing.Color.White
        Me.WrittenByLabel.Location = New System.Drawing.Point(8, 12)
        Me.WrittenByLabel.Name = "WrittenByLabel"
        Me.WrittenByLabel.Size = New System.Drawing.Size(158, 14)
        Me.WrittenByLabel.TabIndex = 0
        Me.WrittenByLabel.Text = "Written by James Garner"
        '
        'VersionLabel
        '
        Me.VersionLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLabel.ForeColor = System.Drawing.Color.Gray
        Me.VersionLabel.Location = New System.Drawing.Point(6, 375)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(200, 18)
        Me.VersionLabel.TabIndex = 3
        Me.VersionLabel.Text = "..."
        '
        'DOkayButton
        '
        Me.DOkayButton.Location = New System.Drawing.Point(234, 369)
        Me.DOkayButton.Name = "DOkayButton"
        Me.DOkayButton.Size = New System.Drawing.Size(100, 28)
        Me.DOkayButton.TabIndex = 2
        Me.DOkayButton.Text = "OK"
        Me.DOkayButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(277, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Updates (version 5.2+) written by Chris Ertl"
        '
        'AboutDSGM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 402)
        Me.Controls.Add(Me.VersionLabel)
        Me.Controls.Add(Me.DOkayButton)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.DSGMTopPanel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutDSGM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About DS Game Maker"
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DSGMTopPanel As System.Windows.Forms.Panel
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents DOkayButton As System.Windows.Forms.Button
    Friend WithEvents WrittenByLabel As System.Windows.Forms.Label
    Friend WithEvents MainInfoLabel As System.Windows.Forms.Label
    Friend WithEvents WebAddressLabel As System.Windows.Forms.Label
    Friend WithEvents VersionLabel As System.Windows.Forms.Label
    Friend WithEvents AdditionalCreditsLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
