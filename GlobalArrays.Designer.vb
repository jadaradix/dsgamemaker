<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GlobalArrays
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GlobalArrays))
        Me.ArraysList = New System.Windows.Forms.TreeView
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.NameLabel = New System.Windows.Forms.Label
        Me.SaveButton = New System.Windows.Forms.Button
        Me.DeleteButton = New System.Windows.Forms.ToolStripButton
        Me.TypeLabel = New System.Windows.Forms.Label
        Me.AddButton = New System.Windows.Forms.ToolStripButton
        Me.CloseButton = New System.Windows.Forms.ToolStripButton
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip
        Me.ToolStripSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.TypeDropper = New System.Windows.Forms.ComboBox
        Me.MainGroupBox = New System.Windows.Forms.GroupBox
        Me.DeleteValueButton = New System.Windows.Forms.Button
        Me.EditValueButton = New System.Windows.Forms.Button
        Me.ValuesListBox = New System.Windows.Forms.ListBox
        Me.ValuesLabel = New System.Windows.Forms.Label
        Me.AddValueButton = New System.Windows.Forms.Button
        Me.MainToolStrip.SuspendLayout()
        Me.MainGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ArraysList
        '
        Me.ArraysList.Dock = System.Windows.Forms.DockStyle.Left
        Me.ArraysList.Indent = 16
        Me.ArraysList.ItemHeight = 19
        Me.ArraysList.Location = New System.Drawing.Point(0, 25)
        Me.ArraysList.Name = "ArraysList"
        Me.ArraysList.Size = New System.Drawing.Size(180, 373)
        Me.ArraysList.TabIndex = 11
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(69, 24)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(120, 21)
        Me.NameTextBox.TabIndex = 3
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(22, 27)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(38, 13)
        Me.NameLabel.TabIndex = 2
        Me.NameLabel.Text = "Name:"
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(192, 264)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(206, 28)
        Me.SaveButton.TabIndex = 13
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'DeleteButton
        '
        Me.DeleteButton.Image = Global.DS_Game_Maker.My.Resources.Resources.DeleteIcon
        Me.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(58, 22)
        Me.DeleteButton.Text = "Delete"
        '
        'TypeLabel
        '
        Me.TypeLabel.AutoSize = True
        Me.TypeLabel.Location = New System.Drawing.Point(25, 54)
        Me.TypeLabel.Name = "TypeLabel"
        Me.TypeLabel.Size = New System.Drawing.Size(35, 13)
        Me.TypeLabel.TabIndex = 4
        Me.TypeLabel.Text = "Type:"
        '
        'AddButton
        '
        Me.AddButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PlusIcon
        Me.AddButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddButton.Name = "AddButton"
        Me.AddButton.Size = New System.Drawing.Size(46, 22)
        Me.AddButton.Text = "Add"
        '
        'CloseButton
        '
        Me.CloseButton.Image = Global.DS_Game_Maker.My.Resources.Resources.AcceptIcon
        Me.CloseButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(53, 22)
        Me.CloseButton.Text = "Close"
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseButton, Me.ToolStripSep1, Me.AddButton, Me.DeleteButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(410, 25)
        Me.MainToolStrip.TabIndex = 12
        Me.MainToolStrip.Text = "ToolStrip1"
        '
        'ToolStripSep1
        '
        Me.ToolStripSep1.Name = "ToolStripSep1"
        Me.ToolStripSep1.Size = New System.Drawing.Size(6, 25)
        '
        'TypeDropper
        '
        Me.TypeDropper.FormattingEnabled = True
        Me.TypeDropper.Items.AddRange(New Object() {"Number", "TrueFalse"})
        Me.TypeDropper.Location = New System.Drawing.Point(69, 51)
        Me.TypeDropper.Name = "TypeDropper"
        Me.TypeDropper.Size = New System.Drawing.Size(120, 21)
        Me.TypeDropper.TabIndex = 5
        '
        'MainGroupBox
        '
        Me.MainGroupBox.Controls.Add(Me.DeleteValueButton)
        Me.MainGroupBox.Controls.Add(Me.EditValueButton)
        Me.MainGroupBox.Controls.Add(Me.ValuesListBox)
        Me.MainGroupBox.Controls.Add(Me.ValuesLabel)
        Me.MainGroupBox.Controls.Add(Me.AddValueButton)
        Me.MainGroupBox.Controls.Add(Me.NameTextBox)
        Me.MainGroupBox.Controls.Add(Me.NameLabel)
        Me.MainGroupBox.Controls.Add(Me.TypeLabel)
        Me.MainGroupBox.Controls.Add(Me.TypeDropper)
        Me.MainGroupBox.Location = New System.Drawing.Point(192, 35)
        Me.MainGroupBox.Name = "MainGroupBox"
        Me.MainGroupBox.Size = New System.Drawing.Size(206, 223)
        Me.MainGroupBox.TabIndex = 14
        Me.MainGroupBox.TabStop = False
        Me.MainGroupBox.Text = "<No Array Selected>"
        '
        'DeleteValueButton
        '
        Me.DeleteValueButton.Location = New System.Drawing.Point(6, 190)
        Me.DeleteValueButton.Name = "DeleteValueButton"
        Me.DeleteValueButton.Size = New System.Drawing.Size(60, 22)
        Me.DeleteValueButton.TabIndex = 17
        Me.DeleteValueButton.Text = "Delete"
        Me.DeleteValueButton.UseVisualStyleBackColor = True
        '
        'EditValueButton
        '
        Me.EditValueButton.Location = New System.Drawing.Point(6, 168)
        Me.EditValueButton.Name = "EditValueButton"
        Me.EditValueButton.Size = New System.Drawing.Size(60, 22)
        Me.EditValueButton.TabIndex = 16
        Me.EditValueButton.Text = "Edit"
        Me.EditValueButton.UseVisualStyleBackColor = True
        '
        'ValuesListBox
        '
        Me.ValuesListBox.FormattingEnabled = True
        Me.ValuesListBox.Location = New System.Drawing.Point(69, 78)
        Me.ValuesListBox.Name = "ValuesListBox"
        Me.ValuesListBox.Size = New System.Drawing.Size(120, 134)
        Me.ValuesListBox.TabIndex = 15
        '
        'ValuesLabel
        '
        Me.ValuesLabel.AutoSize = True
        Me.ValuesLabel.Location = New System.Drawing.Point(18, 81)
        Me.ValuesLabel.Name = "ValuesLabel"
        Me.ValuesLabel.Size = New System.Drawing.Size(42, 13)
        Me.ValuesLabel.TabIndex = 6
        Me.ValuesLabel.Text = "Values:"
        '
        'AddValueButton
        '
        Me.AddValueButton.Location = New System.Drawing.Point(6, 146)
        Me.AddValueButton.Name = "AddValueButton"
        Me.AddValueButton.Size = New System.Drawing.Size(60, 22)
        Me.AddValueButton.TabIndex = 15
        Me.AddValueButton.Text = "Add"
        Me.AddValueButton.UseVisualStyleBackColor = True
        '
        'GlobalArrays
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 398)
        Me.Controls.Add(Me.ArraysList)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Controls.Add(Me.MainGroupBox)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GlobalArrays"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Global Arrays"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.MainGroupBox.ResumeLayout(False)
        Me.MainGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ArraysList As System.Windows.Forms.TreeView
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents SaveButton As System.Windows.Forms.Button
    Friend WithEvents DeleteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TypeLabel As System.Windows.Forms.Label
    Friend WithEvents AddButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CloseButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TypeDropper As System.Windows.Forms.ComboBox
    Friend WithEvents MainGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ValuesListBox As System.Windows.Forms.ListBox
    Friend WithEvents ValuesLabel As System.Windows.Forms.Label
    Friend WithEvents DeleteValueButton As System.Windows.Forms.Button
    Friend WithEvents EditValueButton As System.Windows.Forms.Button
    Friend WithEvents AddValueButton As System.Windows.Forms.Button
End Class
