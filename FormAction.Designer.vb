<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAction
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
        Me.SubPanel = New System.Windows.Forms.Panel()
        Me.DOkayButton = New System.Windows.Forms.Button()
        Me.AppliesToGroupBox = New System.Windows.Forms.GroupBox()
        Me.InstancesTextBox = New System.Windows.Forms.TextBox()
        Me.InstancesOfDropper = New System.Windows.Forms.ComboBox()
        Me.InstancesRadioButton = New System.Windows.Forms.RadioButton()
        Me.InstancesOfRadioButton = New System.Windows.Forms.RadioButton()
        Me.ThisRadioButton = New System.Windows.Forms.RadioButton()
        Me.LabelsPanel = New System.Windows.Forms.Panel()
        Me.ControlsPanel = New System.Windows.Forms.Panel()
        Me.SubPanel.SuspendLayout()
        Me.AppliesToGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'SubPanel
        '
        Me.SubPanel.Controls.Add(Me.DOkayButton)
        Me.SubPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SubPanel.Location = New System.Drawing.Point(0, 272)
        Me.SubPanel.Name = "SubPanel"
        Me.SubPanel.Size = New System.Drawing.Size(259, 40)
        Me.SubPanel.TabIndex = 0
        '
        'DOkayButton
        '
        Me.DOkayButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DOkayButton.Location = New System.Drawing.Point(148, 5)
        Me.DOkayButton.Name = "DOkayButton"
        Me.DOkayButton.Size = New System.Drawing.Size(104, 26)
        Me.DOkayButton.TabIndex = 1
        Me.DOkayButton.Text = "OK"
        Me.DOkayButton.UseVisualStyleBackColor = True
        '
        'AppliesToGroupBox
        '
        Me.AppliesToGroupBox.Controls.Add(Me.InstancesTextBox)
        Me.AppliesToGroupBox.Controls.Add(Me.InstancesOfDropper)
        Me.AppliesToGroupBox.Controls.Add(Me.InstancesRadioButton)
        Me.AppliesToGroupBox.Controls.Add(Me.InstancesOfRadioButton)
        Me.AppliesToGroupBox.Controls.Add(Me.ThisRadioButton)
        Me.AppliesToGroupBox.Location = New System.Drawing.Point(7, 7)
        Me.AppliesToGroupBox.Name = "AppliesToGroupBox"
        Me.AppliesToGroupBox.Size = New System.Drawing.Size(245, 90)
        Me.AppliesToGroupBox.TabIndex = 1
        Me.AppliesToGroupBox.TabStop = False
        Me.AppliesToGroupBox.Text = "Applies To"
        '
        'InstancesTextBox
        '
        Me.InstancesTextBox.Location = New System.Drawing.Point(120, 62)
        Me.InstancesTextBox.Name = "InstancesTextBox"
        Me.InstancesTextBox.Size = New System.Drawing.Size(119, 21)
        Me.InstancesTextBox.TabIndex = 0
        '
        'InstancesOfDropper
        '
        Me.InstancesOfDropper.FormattingEnabled = True
        Me.InstancesOfDropper.Location = New System.Drawing.Point(120, 39)
        Me.InstancesOfDropper.Name = "InstancesOfDropper"
        Me.InstancesOfDropper.Size = New System.Drawing.Size(119, 21)
        Me.InstancesOfDropper.TabIndex = 2
        '
        'InstancesRadioButton
        '
        Me.InstancesRadioButton.AutoSize = True
        Me.InstancesRadioButton.Location = New System.Drawing.Point(11, 63)
        Me.InstancesRadioButton.Name = "InstancesRadioButton"
        Me.InstancesRadioButton.Size = New System.Drawing.Size(76, 17)
        Me.InstancesRadioButton.TabIndex = 4
        Me.InstancesRadioButton.TabStop = True
        Me.InstancesRadioButton.Text = "Instances:"
        Me.InstancesRadioButton.UseVisualStyleBackColor = True
        '
        'InstancesOfRadioButton
        '
        Me.InstancesOfRadioButton.AutoSize = True
        Me.InstancesOfRadioButton.Location = New System.Drawing.Point(11, 40)
        Me.InstancesOfRadioButton.Name = "InstancesOfRadioButton"
        Me.InstancesOfRadioButton.Size = New System.Drawing.Size(89, 17)
        Me.InstancesOfRadioButton.TabIndex = 3
        Me.InstancesOfRadioButton.TabStop = True
        Me.InstancesOfRadioButton.Text = "Instances of:"
        Me.InstancesOfRadioButton.UseVisualStyleBackColor = True
        '
        'ThisRadioButton
        '
        Me.ThisRadioButton.AutoSize = True
        Me.ThisRadioButton.Location = New System.Drawing.Point(11, 18)
        Me.ThisRadioButton.Name = "ThisRadioButton"
        Me.ThisRadioButton.Size = New System.Drawing.Size(44, 17)
        Me.ThisRadioButton.TabIndex = 2
        Me.ThisRadioButton.TabStop = True
        Me.ThisRadioButton.Text = "This"
        Me.ThisRadioButton.UseVisualStyleBackColor = True
        '
        'LabelsPanel
        '
        Me.LabelsPanel.Location = New System.Drawing.Point(7, 108)
        Me.LabelsPanel.Name = "LabelsPanel"
        Me.LabelsPanel.Size = New System.Drawing.Size(112, 158)
        Me.LabelsPanel.TabIndex = 2
        '
        'ControlsPanel
        '
        Me.ControlsPanel.Location = New System.Drawing.Point(122, 108)
        Me.ControlsPanel.Name = "ControlsPanel"
        Me.ControlsPanel.Size = New System.Drawing.Size(128, 158)
        Me.ControlsPanel.TabIndex = 3
        '
        'FormAction
        '
        Me.AcceptButton = Me.DOkayButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 312)
        Me.Controls.Add(Me.ControlsPanel)
        Me.Controls.Add(Me.LabelsPanel)
        Me.Controls.Add(Me.AppliesToGroupBox)
        Me.Controls.Add(Me.SubPanel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.SubPanel.ResumeLayout(False)
        Me.AppliesToGroupBox.ResumeLayout(False)
        Me.AppliesToGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SubPanel As System.Windows.Forms.Panel
    Friend WithEvents DOkayButton As System.Windows.Forms.Button
    Friend WithEvents AppliesToGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents InstancesRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents InstancesOfRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents ThisRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents InstancesOfDropper As System.Windows.Forms.ComboBox
    Friend WithEvents LabelsPanel As System.Windows.Forms.Panel
    Friend WithEvents ControlsPanel As System.Windows.Forms.Panel
    Friend WithEvents InstancesTextBox As System.Windows.Forms.TextBox
End Class
