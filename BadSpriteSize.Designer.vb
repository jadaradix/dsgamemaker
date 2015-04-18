<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BadSpriteSize
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BadSpriteSize))
        Me.ExplanationLabel = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.DAcceptButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ExplanationLabel
        '
        Me.ExplanationLabel.Location = New System.Drawing.Point(13, 9)
        Me.ExplanationLabel.Name = "ExplanationLabel"
        Me.ExplanationLabel.Size = New System.Drawing.Size(196, 57)
        Me.ExplanationLabel.TabIndex = 1
        Me.ExplanationLabel.Text = "The sprite you have tried to load is not correctly sized to be used on the DS. Yo" & _
            "u will need to resize it to one of the sizes below using a paint program."
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.DS_Game_Maker.My.Resources.Resources.SpriteSizesTable1
        Me.Panel1.Location = New System.Drawing.Point(13, 80)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(196, 94)
        Me.Panel1.TabIndex = 2
        '
        'DAcceptButton
        '
        Me.DAcceptButton.Image = Global.DS_Game_Maker.My.Resources.Resources.AcceptIcon
        Me.DAcceptButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DAcceptButton.Location = New System.Drawing.Point(134, 180)
        Me.DAcceptButton.Name = "DAcceptButton"
        Me.DAcceptButton.Size = New System.Drawing.Size(76, 28)
        Me.DAcceptButton.TabIndex = 3
        Me.DAcceptButton.Text = "      Accept"
        Me.DAcceptButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DAcceptButton.UseVisualStyleBackColor = True
        '
        'BadSpriteSize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(222, 220)
        Me.Controls.Add(Me.DAcceptButton)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ExplanationLabel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BadSpriteSize"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Invalid Sprite Size"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExplanationLabel As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DAcceptButton As System.Windows.Forms.Button
End Class
