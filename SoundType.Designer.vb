<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SoundType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SoundType))
        Me.SoundEffectRadioButton = New System.Windows.Forms.RadioButton
        Me.DOkayButton = New System.Windows.Forms.Button
        Me.BackgroundSoundRadioButton = New System.Windows.Forms.RadioButton
        Me.InfoLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'SoundEffectRadioButton
        '
        Me.SoundEffectRadioButton.AutoSize = True
        Me.SoundEffectRadioButton.Location = New System.Drawing.Point(12, 12)
        Me.SoundEffectRadioButton.Name = "SoundEffectRadioButton"
        Me.SoundEffectRadioButton.Size = New System.Drawing.Size(87, 17)
        Me.SoundEffectRadioButton.TabIndex = 0
        Me.SoundEffectRadioButton.Text = "Sound Effect"
        Me.SoundEffectRadioButton.UseVisualStyleBackColor = True
        '
        'DOkayButton
        '
        Me.DOkayButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DOkayButton.Location = New System.Drawing.Point(161, 132)
        Me.DOkayButton.Name = "DOkayButton"
        Me.DOkayButton.Size = New System.Drawing.Size(106, 28)
        Me.DOkayButton.TabIndex = 1
        Me.DOkayButton.Text = "Okay"
        Me.DOkayButton.UseVisualStyleBackColor = True
        '
        'BackgroundSoundRadioButton
        '
        Me.BackgroundSoundRadioButton.AutoSize = True
        Me.BackgroundSoundRadioButton.Location = New System.Drawing.Point(12, 35)
        Me.BackgroundSoundRadioButton.Name = "BackgroundSoundRadioButton"
        Me.BackgroundSoundRadioButton.Size = New System.Drawing.Size(114, 17)
        Me.BackgroundSoundRadioButton.TabIndex = 2
        Me.BackgroundSoundRadioButton.Text = "Background Sound"
        Me.BackgroundSoundRadioButton.UseVisualStyleBackColor = True
        '
        'InfoLabel
        '
        Me.InfoLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.InfoLabel.Location = New System.Drawing.Point(12, 67)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Padding = New System.Windows.Forms.Padding(4)
        Me.InfoLabel.Size = New System.Drawing.Size(255, 62)
        Me.InfoLabel.TabIndex = 3
        Me.InfoLabel.Text = "Label1"
        '
        'SoundType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(279, 172)
        Me.Controls.Add(Me.InfoLabel)
        Me.Controls.Add(Me.BackgroundSoundRadioButton)
        Me.Controls.Add(Me.DOkayButton)
        Me.Controls.Add(Me.SoundEffectRadioButton)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(295, 210)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(295, 210)
        Me.Name = "SoundType"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Sound Type"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SoundEffectRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents DOkayButton As System.Windows.Forms.Button
    Friend WithEvents BackgroundSoundRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents InfoLabel As System.Windows.Forms.Label
End Class
