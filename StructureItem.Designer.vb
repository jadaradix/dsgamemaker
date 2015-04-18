<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StructureItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StructureItem))
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip
        Me.DAcceptButton = New System.Windows.Forms.ToolStripButton
        Me.TypeDropper = New System.Windows.Forms.ComboBox
        Me.TypeLabel = New System.Windows.Forms.Label
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.NameLabel = New System.Windows.Forms.Label
        Me.ValueTextBox = New System.Windows.Forms.TextBox
        Me.ValueLabel = New System.Windows.Forms.Label
        Me.ToolStripContainer = New System.Windows.Forms.Panel
        Me.MainToolStrip.SuspendLayout()
        Me.ToolStripContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(153, 25)
        Me.MainToolStrip.TabIndex = 0
        Me.MainToolStrip.Text = "ToolStrip1"
        '
        'DAcceptButton
        '
        Me.DAcceptButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.DAcceptButton.Image = Global.DS_Game_Maker.My.Resources.Resources.AcceptIcon
        Me.DAcceptButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DAcceptButton.Name = "DAcceptButton"
        Me.DAcceptButton.Size = New System.Drawing.Size(60, 22)
        Me.DAcceptButton.Text = "Accept"
        '
        'TypeDropper
        '
        Me.TypeDropper.FormattingEnabled = True
        Me.TypeDropper.Location = New System.Drawing.Point(11, 89)
        Me.TypeDropper.Name = "TypeDropper"
        Me.TypeDropper.Size = New System.Drawing.Size(129, 21)
        Me.TypeDropper.TabIndex = 8
        '
        'TypeLabel
        '
        Me.TypeLabel.AutoSize = True
        Me.TypeLabel.ForeColor = System.Drawing.Color.White
        Me.TypeLabel.Location = New System.Drawing.Point(9, 73)
        Me.TypeLabel.Name = "TypeLabel"
        Me.TypeLabel.Size = New System.Drawing.Size(35, 13)
        Me.TypeLabel.TabIndex = 7
        Me.TypeLabel.Text = "Type:"
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(11, 49)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(129, 21)
        Me.NameTextBox.TabIndex = 6
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.ForeColor = System.Drawing.Color.White
        Me.NameLabel.Location = New System.Drawing.Point(9, 33)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(38, 13)
        Me.NameLabel.TabIndex = 5
        Me.NameLabel.Text = "Name:"
        '
        'ValueTextBox
        '
        Me.ValueTextBox.Location = New System.Drawing.Point(12, 129)
        Me.ValueTextBox.Name = "ValueTextBox"
        Me.ValueTextBox.Size = New System.Drawing.Size(129, 21)
        Me.ValueTextBox.TabIndex = 10
        '
        'ValueLabel
        '
        Me.ValueLabel.AutoSize = True
        Me.ValueLabel.ForeColor = System.Drawing.Color.White
        Me.ValueLabel.Location = New System.Drawing.Point(9, 113)
        Me.ValueLabel.Name = "ValueLabel"
        Me.ValueLabel.Size = New System.Drawing.Size(37, 13)
        Me.ValueLabel.TabIndex = 9
        Me.ValueLabel.Text = "Value:"
        '
        'ToolStripContainer
        '
        Me.ToolStripContainer.BackColor = System.Drawing.Color.Silver
        Me.ToolStripContainer.Controls.Add(Me.MainToolStrip)
        Me.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripContainer.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer.Name = "ToolStripContainer"
        Me.ToolStripContainer.Size = New System.Drawing.Size(153, 25)
        Me.ToolStripContainer.TabIndex = 11
        '
        'StructureItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(153, 162)
        Me.Controls.Add(Me.ToolStripContainer)
        Me.Controls.Add(Me.ValueTextBox)
        Me.Controls.Add(Me.ValueLabel)
        Me.Controls.Add(Me.TypeDropper)
        Me.Controls.Add(Me.TypeLabel)
        Me.Controls.Add(Me.NameTextBox)
        Me.Controls.Add(Me.NameLabel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StructureItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Member"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.ToolStripContainer.ResumeLayout(False)
        Me.ToolStripContainer.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TypeDropper As System.Windows.Forms.ComboBox
    Friend WithEvents TypeLabel As System.Windows.Forms.Label
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents ValueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ValueLabel As System.Windows.Forms.Label
    Friend WithEvents ToolStripContainer As System.Windows.Forms.Panel
End Class
