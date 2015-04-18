<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputBoxForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InputBoxForm))
        Me.DescriptionLabel = New System.Windows.Forms.Label
        Me.MainTextBox = New System.Windows.Forms.TextBox
        Me.DOkayButton = New System.Windows.Forms.Button
        Me.DCancelButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.AutoSize = True
        Me.DescriptionLabel.Location = New System.Drawing.Point(12, 9)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(85, 13)
        Me.DescriptionLabel.TabIndex = 0
        Me.DescriptionLabel.Text = "DescriptionLabel"
        '
        'MainTextBox
        '
        Me.MainTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainTextBox.Location = New System.Drawing.Point(12, 81)
        Me.MainTextBox.Name = "MainTextBox"
        Me.MainTextBox.Size = New System.Drawing.Size(320, 21)
        Me.MainTextBox.TabIndex = 1
        '
        'DOkayButton
        '
        Me.DOkayButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.DOkayButton.Location = New System.Drawing.Point(248, 12)
        Me.DOkayButton.Name = "DOkayButton"
        Me.DOkayButton.Size = New System.Drawing.Size(84, 26)
        Me.DOkayButton.TabIndex = 2
        Me.DOkayButton.Text = "OK"
        Me.DOkayButton.UseVisualStyleBackColor = True
        '
        'DCancelButton
        '
        Me.DCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.DCancelButton.Location = New System.Drawing.Point(248, 40)
        Me.DCancelButton.Name = "DCancelButton"
        Me.DCancelButton.Size = New System.Drawing.Size(84, 26)
        Me.DCancelButton.TabIndex = 3
        Me.DCancelButton.Text = "Cancel"
        Me.DCancelButton.UseVisualStyleBackColor = True
        '
        'InputBoxForm
        '
        Me.AcceptButton = Me.DOkayButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.DCancelButton
        Me.ClientSize = New System.Drawing.Size(344, 114)
        Me.Controls.Add(Me.DCancelButton)
        Me.Controls.Add(Me.DOkayButton)
        Me.Controls.Add(Me.MainTextBox)
        Me.Controls.Add(Me.DescriptionLabel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InputBoxForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DS Game Maker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DescriptionLabel As System.Windows.Forms.Label
    Friend WithEvents MainTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DOkayButton As System.Windows.Forms.Button
    Friend WithEvents DCancelButton As System.Windows.Forms.Button
End Class
