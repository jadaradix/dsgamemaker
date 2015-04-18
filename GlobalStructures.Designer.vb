<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GlobalStructures
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GlobalStructures))
        Me.MembersLabel = New System.Windows.Forms.Label
        Me.TypeHeader = New System.Windows.Forms.Panel
        Me.MembersList = New System.Windows.Forms.ListBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.AddButton = New System.Windows.Forms.Button
        Me.NamePanel = New System.Windows.Forms.Panel
        Me.StructuresList = New System.Windows.Forms.ListBox
        Me.RemoveButton = New System.Windows.Forms.Button
        Me.SidePanel = New System.Windows.Forms.Panel
        Me.NameLabel = New System.Windows.Forms.Label
        Me.TypeLabel = New System.Windows.Forms.Label
        Me.ValueLabel = New System.Windows.Forms.Label
        Me.AddMemberButton = New System.Windows.Forms.Button
        Me.EditMemberButton = New System.Windows.Forms.Button
        Me.DeleteMemberButton = New System.Windows.Forms.Button
        Me.TypeHeader.SuspendLayout()
        Me.NamePanel.SuspendLayout()
        Me.SidePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MembersLabel
        '
        Me.MembersLabel.AutoSize = True
        Me.MembersLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MembersLabel.ForeColor = System.Drawing.Color.White
        Me.MembersLabel.Location = New System.Drawing.Point(3, 3)
        Me.MembersLabel.Name = "MembersLabel"
        Me.MembersLabel.Size = New System.Drawing.Size(85, 14)
        Me.MembersLabel.TabIndex = 4
        Me.MembersLabel.Text = "M e m b e r s :"
        '
        'TypeHeader
        '
        Me.TypeHeader.BackColor = System.Drawing.Color.Silver
        Me.TypeHeader.Controls.Add(Me.MembersLabel)
        Me.TypeHeader.Location = New System.Drawing.Point(194, 37)
        Me.TypeHeader.Name = "TypeHeader"
        Me.TypeHeader.Size = New System.Drawing.Size(212, 22)
        Me.TypeHeader.TabIndex = 23
        '
        'MembersList
        '
        Me.MembersList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.MembersList.FormattingEnabled = True
        Me.MembersList.Location = New System.Drawing.Point(194, 82)
        Me.MembersList.Name = "MembersList"
        Me.MembersList.Size = New System.Drawing.Size(212, 108)
        Me.MembersList.TabIndex = 22
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
        'AddButton
        '
        Me.AddButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AddButton.Location = New System.Drawing.Point(3, 332)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.Size = New System.Drawing.Size(184, 30)
        Me.AddButton.TabIndex = 11
        Me.AddButton.Text = "Add Global Structure"
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'NamePanel
        '
        Me.NamePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NamePanel.Controls.Add(Me.NameTextBox)
        Me.NamePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.NamePanel.Location = New System.Drawing.Point(190, 0)
        Me.NamePanel.Name = "NamePanel"
        Me.NamePanel.Size = New System.Drawing.Size(220, 33)
        Me.NamePanel.TabIndex = 21
        '
        'StructuresList
        '
        Me.StructuresList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StructuresList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.StructuresList.FormattingEnabled = True
        Me.StructuresList.Location = New System.Drawing.Point(0, 0)
        Me.StructuresList.Name = "StructuresList"
        Me.StructuresList.Size = New System.Drawing.Size(190, 329)
        Me.StructuresList.TabIndex = 13
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
        'SidePanel
        '
        Me.SidePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SidePanel.Controls.Add(Me.StructuresList)
        Me.SidePanel.Controls.Add(Me.RemoveButton)
        Me.SidePanel.Controls.Add(Me.AddButton)
        Me.SidePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.SidePanel.Location = New System.Drawing.Point(0, 0)
        Me.SidePanel.Name = "SidePanel"
        Me.SidePanel.Size = New System.Drawing.Size(190, 398)
        Me.SidePanel.TabIndex = 20
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NameLabel.Location = New System.Drawing.Point(191, 66)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(34, 13)
        Me.NameLabel.TabIndex = 24
        Me.NameLabel.Text = "Name"
        '
        'TypeLabel
        '
        Me.TypeLabel.AutoSize = True
        Me.TypeLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TypeLabel.Location = New System.Drawing.Point(264, 66)
        Me.TypeLabel.Name = "TypeLabel"
        Me.TypeLabel.Size = New System.Drawing.Size(31, 13)
        Me.TypeLabel.TabIndex = 25
        Me.TypeLabel.Text = "Type"
        '
        'ValueLabel
        '
        Me.ValueLabel.AutoSize = True
        Me.ValueLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ValueLabel.Location = New System.Drawing.Point(335, 66)
        Me.ValueLabel.Name = "ValueLabel"
        Me.ValueLabel.Size = New System.Drawing.Size(33, 13)
        Me.ValueLabel.TabIndex = 26
        Me.ValueLabel.Text = "Value"
        '
        'AddMemberButton
        '
        Me.AddMemberButton.Location = New System.Drawing.Point(194, 191)
        Me.AddMemberButton.Name = "AddMemberButton"
        Me.AddMemberButton.Size = New System.Drawing.Size(60, 24)
        Me.AddMemberButton.TabIndex = 27
        Me.AddMemberButton.Text = "Add"
        Me.AddMemberButton.UseVisualStyleBackColor = True
        '
        'EditMemberButton
        '
        Me.EditMemberButton.Location = New System.Drawing.Point(254, 191)
        Me.EditMemberButton.Name = "EditMemberButton"
        Me.EditMemberButton.Size = New System.Drawing.Size(60, 24)
        Me.EditMemberButton.TabIndex = 28
        Me.EditMemberButton.Text = "Edit"
        Me.EditMemberButton.UseVisualStyleBackColor = True
        '
        'DeleteMemberButton
        '
        Me.DeleteMemberButton.Location = New System.Drawing.Point(314, 191)
        Me.DeleteMemberButton.Name = "DeleteMemberButton"
        Me.DeleteMemberButton.Size = New System.Drawing.Size(60, 24)
        Me.DeleteMemberButton.TabIndex = 29
        Me.DeleteMemberButton.Text = "Delete"
        Me.DeleteMemberButton.UseVisualStyleBackColor = True
        '
        'GlobalStructures
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 398)
        Me.Controls.Add(Me.DeleteMemberButton)
        Me.Controls.Add(Me.EditMemberButton)
        Me.Controls.Add(Me.AddMemberButton)
        Me.Controls.Add(Me.ValueLabel)
        Me.Controls.Add(Me.TypeLabel)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.TypeHeader)
        Me.Controls.Add(Me.MembersList)
        Me.Controls.Add(Me.NamePanel)
        Me.Controls.Add(Me.SidePanel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GlobalStructures"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Global Structures"
        Me.TypeHeader.ResumeLayout(False)
        Me.TypeHeader.PerformLayout()
        Me.NamePanel.ResumeLayout(False)
        Me.NamePanel.PerformLayout()
        Me.SidePanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MembersLabel As System.Windows.Forms.Label
    Friend WithEvents TypeHeader As System.Windows.Forms.Panel
    Friend WithEvents MembersList As System.Windows.Forms.ListBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AddButton As System.Windows.Forms.Button
    Friend WithEvents NamePanel As System.Windows.Forms.Panel
    Friend WithEvents StructuresList As System.Windows.Forms.ListBox
    Friend WithEvents RemoveButton As System.Windows.Forms.Button
    Friend WithEvents SidePanel As System.Windows.Forms.Panel
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents TypeLabel As System.Windows.Forms.Label
    Friend WithEvents ValueLabel As System.Windows.Forms.Label
    Friend WithEvents AddMemberButton As System.Windows.Forms.Button
    Friend WithEvents EditMemberButton As System.Windows.Forms.Button
    Friend WithEvents DeleteMemberButton As System.Windows.Forms.Button
End Class
