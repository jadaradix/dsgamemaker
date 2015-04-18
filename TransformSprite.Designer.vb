<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransformSprite
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransformSprite))
        Me.MainTabControl = New System.Windows.Forms.TabControl
        Me.FlipAndRotateTabPage = New System.Windows.Forms.TabPage
        Me.HorizontalRadioButton = New System.Windows.Forms.RadioButton
        Me.VerticalRadioButton = New System.Windows.Forms.RadioButton
        Me.ReplaceColorTab = New System.Windows.Forms.TabPage
        Me.WithThisLabel = New System.Windows.Forms.Label
        Me.ReplaceColorButton = New System.Windows.Forms.Button
        Me.ReplaceColorLabel = New System.Windows.Forms.Label
        Me.OriginalColorButton = New System.Windows.Forms.Button
        Me.SubPanel = New System.Windows.Forms.Panel
        Me.DOkayButton = New System.Windows.Forms.Button
        Me.FlipGroupBox = New System.Windows.Forms.GroupBox
        Me.NoneRadioButton = New System.Windows.Forms.RadioButton
        Me.BothRadioButton = New System.Windows.Forms.RadioButton
        Me.RotationLabel = New System.Windows.Forms.Label
        Me.RotationDropper = New System.Windows.Forms.ComboBox
        Me.DegreesLabel = New System.Windows.Forms.Label
        Me.MainTabControl.SuspendLayout()
        Me.FlipAndRotateTabPage.SuspendLayout()
        Me.ReplaceColorTab.SuspendLayout()
        Me.SubPanel.SuspendLayout()
        Me.FlipGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTabControl
        '
        Me.MainTabControl.Controls.Add(Me.FlipAndRotateTabPage)
        Me.MainTabControl.Controls.Add(Me.ReplaceColorTab)
        Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTabControl.Location = New System.Drawing.Point(0, 0)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(284, 220)
        Me.MainTabControl.TabIndex = 0
        '
        'FlipAndRotateTabPage
        '
        Me.FlipAndRotateTabPage.Controls.Add(Me.DegreesLabel)
        Me.FlipAndRotateTabPage.Controls.Add(Me.RotationDropper)
        Me.FlipAndRotateTabPage.Controls.Add(Me.RotationLabel)
        Me.FlipAndRotateTabPage.Controls.Add(Me.FlipGroupBox)
        Me.FlipAndRotateTabPage.Location = New System.Drawing.Point(4, 22)
        Me.FlipAndRotateTabPage.Name = "FlipAndRotateTabPage"
        Me.FlipAndRotateTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.FlipAndRotateTabPage.Size = New System.Drawing.Size(276, 194)
        Me.FlipAndRotateTabPage.TabIndex = 0
        Me.FlipAndRotateTabPage.Text = "Flip && Rotate"
        Me.FlipAndRotateTabPage.UseVisualStyleBackColor = True
        '
        'HorizontalRadioButton
        '
        Me.HorizontalRadioButton.AutoSize = True
        Me.HorizontalRadioButton.Location = New System.Drawing.Point(12, 43)
        Me.HorizontalRadioButton.Name = "HorizontalRadioButton"
        Me.HorizontalRadioButton.Size = New System.Drawing.Size(73, 17)
        Me.HorizontalRadioButton.TabIndex = 1
        Me.HorizontalRadioButton.Text = "Horizontal"
        Me.HorizontalRadioButton.UseVisualStyleBackColor = True
        '
        'VerticalRadioButton
        '
        Me.VerticalRadioButton.AutoSize = True
        Me.VerticalRadioButton.Location = New System.Drawing.Point(12, 66)
        Me.VerticalRadioButton.Name = "VerticalRadioButton"
        Me.VerticalRadioButton.Size = New System.Drawing.Size(60, 17)
        Me.VerticalRadioButton.TabIndex = 0
        Me.VerticalRadioButton.Text = "Vertical"
        Me.VerticalRadioButton.UseVisualStyleBackColor = True
        '
        'ReplaceColorTab
        '
        Me.ReplaceColorTab.Controls.Add(Me.WithThisLabel)
        Me.ReplaceColorTab.Controls.Add(Me.ReplaceColorButton)
        Me.ReplaceColorTab.Controls.Add(Me.ReplaceColorLabel)
        Me.ReplaceColorTab.Controls.Add(Me.OriginalColorButton)
        Me.ReplaceColorTab.Location = New System.Drawing.Point(4, 22)
        Me.ReplaceColorTab.Name = "ReplaceColorTab"
        Me.ReplaceColorTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ReplaceColorTab.Size = New System.Drawing.Size(276, 194)
        Me.ReplaceColorTab.TabIndex = 2
        Me.ReplaceColorTab.Text = "Replace Color"
        Me.ReplaceColorTab.UseVisualStyleBackColor = True
        '
        'WithThisLabel
        '
        Me.WithThisLabel.AutoSize = True
        Me.WithThisLabel.Location = New System.Drawing.Point(69, 87)
        Me.WithThisLabel.Name = "WithThisLabel"
        Me.WithThisLabel.Size = New System.Drawing.Size(51, 13)
        Me.WithThisLabel.TabIndex = 3
        Me.WithThisLabel.Text = "With This"
        '
        'ReplaceColorButton
        '
        Me.ReplaceColorButton.BackColor = System.Drawing.Color.White
        Me.ReplaceColorButton.Location = New System.Drawing.Point(11, 78)
        Me.ReplaceColorButton.Name = "ReplaceColorButton"
        Me.ReplaceColorButton.Size = New System.Drawing.Size(52, 52)
        Me.ReplaceColorButton.TabIndex = 2
        Me.ReplaceColorButton.UseVisualStyleBackColor = False
        '
        'ReplaceColorLabel
        '
        Me.ReplaceColorLabel.AutoSize = True
        Me.ReplaceColorLabel.Location = New System.Drawing.Point(69, 29)
        Me.ReplaceColorLabel.Name = "ReplaceColorLabel"
        Me.ReplaceColorLabel.Size = New System.Drawing.Size(93, 13)
        Me.ReplaceColorLabel.TabIndex = 1
        Me.ReplaceColorLabel.Text = "Replace this Color"
        '
        'OriginalColorButton
        '
        Me.OriginalColorButton.BackColor = System.Drawing.Color.Black
        Me.OriginalColorButton.Location = New System.Drawing.Point(11, 20)
        Me.OriginalColorButton.Name = "OriginalColorButton"
        Me.OriginalColorButton.Size = New System.Drawing.Size(52, 52)
        Me.OriginalColorButton.TabIndex = 0
        Me.OriginalColorButton.UseVisualStyleBackColor = False
        '
        'SubPanel
        '
        Me.SubPanel.Controls.Add(Me.DOkayButton)
        Me.SubPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SubPanel.Location = New System.Drawing.Point(0, 220)
        Me.SubPanel.Name = "SubPanel"
        Me.SubPanel.Size = New System.Drawing.Size(284, 42)
        Me.SubPanel.TabIndex = 1
        '
        'DOkayButton
        '
        Me.DOkayButton.Location = New System.Drawing.Point(190, 6)
        Me.DOkayButton.Name = "DOkayButton"
        Me.DOkayButton.Size = New System.Drawing.Size(84, 26)
        Me.DOkayButton.TabIndex = 0
        Me.DOkayButton.Text = "Okay"
        Me.DOkayButton.UseVisualStyleBackColor = True
        '
        'FlipGroupBox
        '
        Me.FlipGroupBox.Controls.Add(Me.BothRadioButton)
        Me.FlipGroupBox.Controls.Add(Me.NoneRadioButton)
        Me.FlipGroupBox.Controls.Add(Me.HorizontalRadioButton)
        Me.FlipGroupBox.Controls.Add(Me.VerticalRadioButton)
        Me.FlipGroupBox.Location = New System.Drawing.Point(8, 6)
        Me.FlipGroupBox.Name = "FlipGroupBox"
        Me.FlipGroupBox.Size = New System.Drawing.Size(262, 123)
        Me.FlipGroupBox.TabIndex = 2
        Me.FlipGroupBox.TabStop = False
        Me.FlipGroupBox.Text = "Flip"
        '
        'NoneRadioButton
        '
        Me.NoneRadioButton.AutoSize = True
        Me.NoneRadioButton.Checked = True
        Me.NoneRadioButton.Location = New System.Drawing.Point(12, 20)
        Me.NoneRadioButton.Name = "NoneRadioButton"
        Me.NoneRadioButton.Size = New System.Drawing.Size(50, 17)
        Me.NoneRadioButton.TabIndex = 2
        Me.NoneRadioButton.Text = "None"
        Me.NoneRadioButton.UseVisualStyleBackColor = True
        '
        'BothRadioButton
        '
        Me.BothRadioButton.AutoSize = True
        Me.BothRadioButton.Location = New System.Drawing.Point(12, 89)
        Me.BothRadioButton.Name = "BothRadioButton"
        Me.BothRadioButton.Size = New System.Drawing.Size(146, 17)
        Me.BothRadioButton.TabIndex = 3
        Me.BothRadioButton.Text = "Both Horizontal && Vertical"
        Me.BothRadioButton.UseVisualStyleBackColor = True
        '
        'RotationLabel
        '
        Me.RotationLabel.AutoSize = True
        Me.RotationLabel.Location = New System.Drawing.Point(91, 141)
        Me.RotationLabel.Name = "RotationLabel"
        Me.RotationLabel.Size = New System.Drawing.Size(59, 13)
        Me.RotationLabel.TabIndex = 3
        Me.RotationLabel.Text = "Rotate By:"
        '
        'RotationDropper
        '
        Me.RotationDropper.FormattingEnabled = True
        Me.RotationDropper.Items.AddRange(New Object() {"0", "90", "180", "270"})
        Me.RotationDropper.Location = New System.Drawing.Point(172, 138)
        Me.RotationDropper.Name = "RotationDropper"
        Me.RotationDropper.Size = New System.Drawing.Size(44, 21)
        Me.RotationDropper.TabIndex = 4
        Me.RotationDropper.Text = "0"
        '
        'DegreesLabel
        '
        Me.DegreesLabel.AutoSize = True
        Me.DegreesLabel.Location = New System.Drawing.Point(222, 141)
        Me.DegreesLabel.Name = "DegreesLabel"
        Me.DegreesLabel.Size = New System.Drawing.Size(46, 13)
        Me.DegreesLabel.TabIndex = 5
        Me.DegreesLabel.Text = "degrees"
        '
        'TransformSprite
        '
        Me.AcceptButton = Me.DOkayButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.MainTabControl)
        Me.Controls.Add(Me.SubPanel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TransformSprite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.MainTabControl.ResumeLayout(False)
        Me.FlipAndRotateTabPage.ResumeLayout(False)
        Me.FlipAndRotateTabPage.PerformLayout()
        Me.ReplaceColorTab.ResumeLayout(False)
        Me.ReplaceColorTab.PerformLayout()
        Me.SubPanel.ResumeLayout(False)
        Me.FlipGroupBox.ResumeLayout(False)
        Me.FlipGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents FlipAndRotateTabPage As System.Windows.Forms.TabPage
    Friend WithEvents SubPanel As System.Windows.Forms.Panel
    Friend WithEvents DOkayButton As System.Windows.Forms.Button
    Friend WithEvents HorizontalRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents VerticalRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents ReplaceColorTab As System.Windows.Forms.TabPage
    Friend WithEvents WithThisLabel As System.Windows.Forms.Label
    Friend WithEvents ReplaceColorButton As System.Windows.Forms.Button
    Friend WithEvents ReplaceColorLabel As System.Windows.Forms.Label
    Friend WithEvents OriginalColorButton As System.Windows.Forms.Button
    Friend WithEvents FlipGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents BothRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents NoneRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents RotationDropper As System.Windows.Forms.ComboBox
    Friend WithEvents RotationLabel As System.Windows.Forms.Label
    Friend WithEvents DegreesLabel As System.Windows.Forms.Label
End Class
