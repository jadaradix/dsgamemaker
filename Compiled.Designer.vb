<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Compiled
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Compiled))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.SubLabel = New System.Windows.Forms.Label
        Me.MainLabel = New System.Windows.Forms.Label
        Me.CloseButton = New System.Windows.Forms.Button
        Me.SavetoKitButton = New System.Windows.Forms.Button
        Me.OpenCompileFolderButton = New System.Windows.Forms.Button
        Me.SaveNDSFileButton = New System.Windows.Forms.Button
        Me.PlayButton = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.SubLabel)
        Me.Panel1.Controls.Add(Me.MainLabel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 54)
        Me.Panel1.TabIndex = 0
        '
        'SubLabel
        '
        Me.SubLabel.AutoSize = True
        Me.SubLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubLabel.ForeColor = System.Drawing.Color.Silver
        Me.SubLabel.Location = New System.Drawing.Point(8, 27)
        Me.SubLabel.Name = "SubLabel"
        Me.SubLabel.Size = New System.Drawing.Size(16, 15)
        Me.SubLabel.TabIndex = 2
        Me.SubLabel.Text = "..."
        '
        'MainLabel
        '
        Me.MainLabel.AutoSize = True
        Me.MainLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainLabel.ForeColor = System.Drawing.Color.White
        Me.MainLabel.Location = New System.Drawing.Point(6, 9)
        Me.MainLabel.Name = "MainLabel"
        Me.MainLabel.Size = New System.Drawing.Size(21, 19)
        Me.MainLabel.TabIndex = 1
        Me.MainLabel.Text = "..."
        '
        'CloseButton
        '
        Me.CloseButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseButton.Location = New System.Drawing.Point(179, 268)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(98, 28)
        Me.CloseButton.TabIndex = 1
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'SavetoKitButton
        '
        Me.SavetoKitButton.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SavetoKitButton.Image = Global.DS_Game_Maker.My.Resources.Resources.BigHBIcon
        Me.SavetoKitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SavetoKitButton.Location = New System.Drawing.Point(8, 114)
        Me.SavetoKitButton.Name = "SavetoKitButton"
        Me.SavetoKitButton.Size = New System.Drawing.Size(269, 48)
        Me.SavetoKitButton.TabIndex = 5
        Me.SavetoKitButton.Text = "           Save to Homebrew Kit"
        Me.SavetoKitButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SavetoKitButton.UseVisualStyleBackColor = True
        '
        'OpenCompileFolderButton
        '
        Me.OpenCompileFolderButton.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenCompileFolderButton.Image = Global.DS_Game_Maker.My.Resources.Resources.BigFolderIcon
        Me.OpenCompileFolderButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OpenCompileFolderButton.Location = New System.Drawing.Point(8, 214)
        Me.OpenCompileFolderButton.Name = "OpenCompileFolderButton"
        Me.OpenCompileFolderButton.Size = New System.Drawing.Size(269, 48)
        Me.OpenCompileFolderButton.TabIndex = 4
        Me.OpenCompileFolderButton.Text = "           Open Compile Folder"
        Me.OpenCompileFolderButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OpenCompileFolderButton.UseVisualStyleBackColor = True
        '
        'SaveNDSFileButton
        '
        Me.SaveNDSFileButton.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveNDSFileButton.Image = Global.DS_Game_Maker.My.Resources.Resources.BigSaveIcon
        Me.SaveNDSFileButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveNDSFileButton.Location = New System.Drawing.Point(8, 164)
        Me.SaveNDSFileButton.Name = "SaveNDSFileButton"
        Me.SaveNDSFileButton.Size = New System.Drawing.Size(269, 48)
        Me.SaveNDSFileButton.TabIndex = 3
        Me.SaveNDSFileButton.Text = "           Save NDS File"
        Me.SaveNDSFileButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveNDSFileButton.UseVisualStyleBackColor = True
        '
        'PlayButton
        '
        Me.PlayButton.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayButton.Image = Global.DS_Game_Maker.My.Resources.Resources.BigPlayButton
        Me.PlayButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PlayButton.Location = New System.Drawing.Point(8, 64)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(269, 48)
        Me.PlayButton.TabIndex = 2
        Me.PlayButton.Text = "           Play Game"
        Me.PlayButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PlayButton.UseVisualStyleBackColor = True
        '
        'Compiled
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(284, 304)
        Me.Controls.Add(Me.SavetoKitButton)
        Me.Controls.Add(Me.OpenCompileFolderButton)
        Me.Controls.Add(Me.SaveNDSFileButton)
        Me.Controls.Add(Me.PlayButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Compiled"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MainLabel As System.Windows.Forms.Label
    Friend WithEvents SubLabel As System.Windows.Forms.Label
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents PlayButton As System.Windows.Forms.Button
    Friend WithEvents SaveNDSFileButton As System.Windows.Forms.Button
    Friend WithEvents OpenCompileFolderButton As System.Windows.Forms.Button
    Friend WithEvents SavetoKitButton As System.Windows.Forms.Button
End Class
