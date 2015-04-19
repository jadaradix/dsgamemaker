<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnterSerial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnterSerial))
        Me.OKButton = New System.Windows.Forms.Button
        Me.EmailLabel = New System.Windows.Forms.Label
        Me.SerialcodeLabel = New System.Windows.Forms.Label
        Me.EmailTextBox = New System.Windows.Forms.TextBox
        Me.SerialCodeTextBox = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(164, 66)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(117, 28)
        Me.OKButton.TabIndex = 1
        Me.OKButton.Text = "Verify"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'EmailLabel
        '
        Me.EmailLabel.AutoSize = True
        Me.EmailLabel.Location = New System.Drawing.Point(40, 15)
        Me.EmailLabel.Name = "EmailLabel"
        Me.EmailLabel.Size = New System.Drawing.Size(35, 13)
        Me.EmailLabel.TabIndex = 3
        Me.EmailLabel.Text = "Email:"
        '
        'SerialcodeLabel
        '
        Me.SerialcodeLabel.AutoSize = True
        Me.SerialcodeLabel.Location = New System.Drawing.Point(12, 42)
        Me.SerialcodeLabel.Name = "SerialcodeLabel"
        Me.SerialcodeLabel.Size = New System.Drawing.Size(63, 13)
        Me.SerialcodeLabel.TabIndex = 4
        Me.SerialcodeLabel.Text = "Serial code:"
        '
        'EmailTextBox
        '
        Me.EmailTextBox.Location = New System.Drawing.Point(90, 12)
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(191, 21)
        Me.EmailTextBox.TabIndex = 5
        '
        'SerialCodeTextBox
        '
        Me.SerialCodeTextBox.Location = New System.Drawing.Point(90, 39)
        Me.SerialCodeTextBox.Name = "SerialCodeTextBox"
        Me.SerialCodeTextBox.Size = New System.Drawing.Size(191, 21)
        Me.SerialCodeTextBox.TabIndex = 6
        '
        'EnterSerial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(293, 106)
        Me.Controls.Add(Me.SerialCodeTextBox)
        Me.Controls.Add(Me.EmailTextBox)
        Me.Controls.Add(Me.SerialcodeLabel)
        Me.Controls.Add(Me.EmailLabel)
        Me.Controls.Add(Me.OKButton)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EnterSerial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Enter Serial Code"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents EmailLabel As System.Windows.Forms.Label
    Friend WithEvents SerialcodeLabel As System.Windows.Forms.Label
    Friend WithEvents EmailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SerialCodeTextBox As System.Windows.Forms.TextBox
End Class
