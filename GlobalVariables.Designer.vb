<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GlobalVariables
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GlobalVariables))
        Me.TypeLabel = New System.Windows.Forms.Label
        Me.ValueTextBox = New System.Windows.Forms.TextBox
        Me.AddButton = New System.Windows.Forms.Button
        Me.SidePanel = New System.Windows.Forms.Panel
        Me.VariablesList = New System.Windows.Forms.ListBox
        Me.RemoveButton = New System.Windows.Forms.Button
        Me.NamePanel = New System.Windows.Forms.Panel
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.TypeList = New System.Windows.Forms.ListBox
        Me.TypeHeader = New System.Windows.Forms.Panel
        Me.TypeDescriptionLabel = New System.Windows.Forms.Label
        Me.TypeTitleLabel = New System.Windows.Forms.Label
        Me.ValueHeader = New System.Windows.Forms.Panel
        Me.ValueLabel = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.SidePanel.SuspendLayout()
        Me.NamePanel.SuspendLayout()
        Me.TypeHeader.SuspendLayout()
        Me.ValueHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TypeLabel
        '
        Me.TypeLabel.AutoSize = True
        Me.TypeLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TypeLabel.ForeColor = System.Drawing.Color.White
        Me.TypeLabel.Location = New System.Drawing.Point(3, 3)
        Me.TypeLabel.Name = "TypeLabel"
        Me.TypeLabel.Size = New System.Drawing.Size(49, 14)
        Me.TypeLabel.TabIndex = 4
        Me.TypeLabel.Text = "T y p e :"
        '
        'ValueTextBox
        '
        Me.ValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ValueTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ValueTextBox.Location = New System.Drawing.Point(5, 7)
        Me.ValueTextBox.Name = "ValueTextBox"
        Me.ValueTextBox.Size = New System.Drawing.Size(43, 15)
        Me.ValueTextBox.TabIndex = 9
        '
        'AddButton
        '
        Me.AddButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AddButton.Location = New System.Drawing.Point(3, 332)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.Size = New System.Drawing.Size(184, 30)
        Me.AddButton.TabIndex = 11
        Me.AddButton.Text = "Add Global Variable"
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'SidePanel
        '
        Me.SidePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SidePanel.Controls.Add(Me.VariablesList)
        Me.SidePanel.Controls.Add(Me.RemoveButton)
        Me.SidePanel.Controls.Add(Me.AddButton)
        Me.SidePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.SidePanel.Location = New System.Drawing.Point(0, 0)
        Me.SidePanel.Name = "SidePanel"
        Me.SidePanel.Size = New System.Drawing.Size(190, 398)
        Me.SidePanel.TabIndex = 12
        '
        'VariablesList
        '
        Me.VariablesList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VariablesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.VariablesList.FormattingEnabled = True
        Me.VariablesList.Location = New System.Drawing.Point(0, 0)
        Me.VariablesList.Name = "VariablesList"
        Me.VariablesList.Size = New System.Drawing.Size(190, 329)
        Me.VariablesList.TabIndex = 13
        '
        'RemoveButton
        '
        Me.RemoveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RemoveButton.Location = New System.Drawing.Point(3, 364)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(184, 30)
        Me.RemoveButton.TabIndex = 12
        Me.RemoveButton.Text = "Remove"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'NamePanel
        '
        Me.NamePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NamePanel.Controls.Add(Me.NameTextBox)
        Me.NamePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.NamePanel.Location = New System.Drawing.Point(190, 0)
        Me.NamePanel.Name = "NamePanel"
        Me.NamePanel.Size = New System.Drawing.Size(220, 33)
        Me.NamePanel.TabIndex = 14
        '
        'NameTextBox
        '
        Me.NameTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NameTextBox.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameTextBox.ForeColor = System.Drawing.Color.White
        Me.NameTextBox.Location = New System.Drawing.Point(7, 7)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(160, 19)
        Me.NameTextBox.TabIndex = 15
        '
        'TypeList
        '
        Me.TypeList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.TypeList.FormattingEnabled = True
        Me.TypeList.Location = New System.Drawing.Point(195, 64)
        Me.TypeList.Name = "TypeList"
        Me.TypeList.Size = New System.Drawing.Size(105, 147)
        Me.TypeList.TabIndex = 15
        '
        'TypeHeader
        '
        Me.TypeHeader.BackColor = System.Drawing.Color.Silver
        Me.TypeHeader.Controls.Add(Me.TypeLabel)
        Me.TypeHeader.Location = New System.Drawing.Point(194, 37)
        Me.TypeHeader.Name = "TypeHeader"
        Me.TypeHeader.Size = New System.Drawing.Size(212, 22)
        Me.TypeHeader.TabIndex = 16
        '
        'TypeDescriptionLabel
        '
        Me.TypeDescriptionLabel.Location = New System.Drawing.Point(303, 85)
        Me.TypeDescriptionLabel.Name = "TypeDescriptionLabel"
        Me.TypeDescriptionLabel.Size = New System.Drawing.Size(99, 126)
        Me.TypeDescriptionLabel.TabIndex = 17
        Me.TypeDescriptionLabel.Text = "To see a description ..."
        '
        'TypeTitleLabel
        '
        Me.TypeTitleLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TypeTitleLabel.Location = New System.Drawing.Point(303, 68)
        Me.TypeTitleLabel.Name = "TypeTitleLabel"
        Me.TypeTitleLabel.Size = New System.Drawing.Size(99, 18)
        Me.TypeTitleLabel.TabIndex = 18
        Me.TypeTitleLabel.Text = "Select a Type"
        '
        'ValueHeader
        '
        Me.ValueHeader.BackColor = System.Drawing.Color.Silver
        Me.ValueHeader.Controls.Add(Me.ValueLabel)
        Me.ValueHeader.Location = New System.Drawing.Point(194, 224)
        Me.ValueHeader.Name = "ValueHeader"
        Me.ValueHeader.Size = New System.Drawing.Size(212, 22)
        Me.ValueHeader.TabIndex = 17
        '
        'ValueLabel
        '
        Me.ValueLabel.AutoSize = True
        Me.ValueLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ValueLabel.ForeColor = System.Drawing.Color.White
        Me.ValueLabel.Location = New System.Drawing.Point(3, 3)
        Me.ValueLabel.Name = "ValueLabel"
        Me.ValueLabel.Size = New System.Drawing.Size(56, 14)
        Me.ValueLabel.TabIndex = 4
        Me.ValueLabel.Text = "V a l u e :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ValueTextBox)
        Me.Panel1.Location = New System.Drawing.Point(349, 220)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(53, 31)
        Me.Panel1.TabIndex = 19
        '
        'GlobalVariables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 398)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ValueHeader)
        Me.Controls.Add(Me.TypeTitleLabel)
        Me.Controls.Add(Me.TypeDescriptionLabel)
        Me.Controls.Add(Me.TypeHeader)
        Me.Controls.Add(Me.TypeList)
        Me.Controls.Add(Me.NamePanel)
        Me.Controls.Add(Me.SidePanel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GlobalVariables"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Global Variables"
        Me.SidePanel.ResumeLayout(False)
        Me.NamePanel.ResumeLayout(False)
        Me.NamePanel.PerformLayout()
        Me.TypeHeader.ResumeLayout(False)
        Me.TypeHeader.PerformLayout()
        Me.ValueHeader.ResumeLayout(False)
        Me.ValueHeader.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TypeLabel As System.Windows.Forms.Label
    Friend WithEvents ValueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AddButton As System.Windows.Forms.Button
    Friend WithEvents SidePanel As System.Windows.Forms.Panel
    Friend WithEvents RemoveButton As System.Windows.Forms.Button
    Friend WithEvents VariablesList As System.Windows.Forms.ListBox
    Friend WithEvents NamePanel As System.Windows.Forms.Panel
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TypeList As System.Windows.Forms.ListBox
    Friend WithEvents TypeHeader As System.Windows.Forms.Panel
    Friend WithEvents TypeDescriptionLabel As System.Windows.Forms.Label
    Friend WithEvents TypeTitleLabel As System.Windows.Forms.Label
    Friend WithEvents ValueHeader As System.Windows.Forms.Panel
    Friend WithEvents ValueLabel As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
