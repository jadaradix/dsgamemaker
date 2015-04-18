<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetCoOrdinates
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetCoOrdinates))
        Me.XLabel = New System.Windows.Forms.Label
        Me.YLabel = New System.Windows.Forms.Label
        Me.XTextBox = New System.Windows.Forms.TextBox
        Me.YTextBox = New System.Windows.Forms.TextBox
        Me.DAcceptButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'XLabel
        '
        Me.XLabel.AutoSize = True
        Me.XLabel.Location = New System.Drawing.Point(12, 11)
        Me.XLabel.Name = "XLabel"
        Me.XLabel.Size = New System.Drawing.Size(17, 13)
        Me.XLabel.TabIndex = 3
        Me.XLabel.Text = "X:"
        '
        'YLabel
        '
        Me.YLabel.AutoSize = True
        Me.YLabel.Location = New System.Drawing.Point(12, 36)
        Me.YLabel.Name = "YLabel"
        Me.YLabel.Size = New System.Drawing.Size(17, 13)
        Me.YLabel.TabIndex = 4
        Me.YLabel.Text = "Y:"
        '
        'XTextBox
        '
        Me.XTextBox.Location = New System.Drawing.Point(100, 8)
        Me.XTextBox.Name = "XTextBox"
        Me.XTextBox.Size = New System.Drawing.Size(76, 21)
        Me.XTextBox.TabIndex = 0
        '
        'YTextBox
        '
        Me.YTextBox.Location = New System.Drawing.Point(100, 33)
        Me.YTextBox.Name = "YTextBox"
        Me.YTextBox.Size = New System.Drawing.Size(76, 21)
        Me.YTextBox.TabIndex = 1
        '
        'DAcceptButton
        '
        Me.DAcceptButton.Image = Global.DS_Game_Maker.My.Resources.Resources.AcceptIcon
        Me.DAcceptButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DAcceptButton.Location = New System.Drawing.Point(12, 62)
        Me.DAcceptButton.Name = "DAcceptButton"
        Me.DAcceptButton.Size = New System.Drawing.Size(164, 30)
        Me.DAcceptButton.TabIndex = 2
        Me.DAcceptButton.Text = "Accept"
        Me.DAcceptButton.UseVisualStyleBackColor = True
        '
        'SetCoOrdinates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(188, 104)
        Me.Controls.Add(Me.DAcceptButton)
        Me.Controls.Add(Me.YTextBox)
        Me.Controls.Add(Me.XTextBox)
        Me.Controls.Add(Me.YLabel)
        Me.Controls.Add(Me.XLabel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetCoOrdinates"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Set Co-ordinates"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents XLabel As System.Windows.Forms.Label
    Friend WithEvents YLabel As System.Windows.Forms.Label
    Friend WithEvents XTextBox As System.Windows.Forms.TextBox
    Friend WithEvents YTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DAcceptButton As System.Windows.Forms.Button
End Class
