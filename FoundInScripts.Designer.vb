<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FoundInScripts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FoundInScripts))
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip
        Me.CloseButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.RefreshButton = New System.Windows.Forms.ToolStripButton
        Me.MainListBox = New System.Windows.Forms.ListBox
        Me.MainToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseButton, Me.ToolStripSep1, Me.RefreshButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(544, 25)
        Me.MainToolStrip.TabIndex = 0
        '
        'CloseButton
        '
        Me.CloseButton.Image = Global.DS_Game_Maker.My.Resources.Resources.AcceptIcon
        Me.CloseButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(53, 22)
        Me.CloseButton.Text = "Close"
        '
        'ToolStripSep1
        '
        Me.ToolStripSep1.Name = "ToolStripSep1"
        Me.ToolStripSep1.Size = New System.Drawing.Size(6, 25)
        '
        'RefreshButton
        '
        Me.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.RefreshButton.Image = CType(resources.GetObject("RefreshButton.Image"), System.Drawing.Image)
        Me.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(49, 22)
        Me.RefreshButton.Text = "Refresh"
        '
        'MainListBox
        '
        Me.MainListBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MainListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.MainListBox.FormattingEnabled = True
        Me.MainListBox.Location = New System.Drawing.Point(0, 25)
        Me.MainListBox.Name = "MainListBox"
        Me.MainListBox.Size = New System.Drawing.Size(544, 357)
        Me.MainListBox.TabIndex = 1
        '
        'FoundInScripts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 382)
        Me.Controls.Add(Me.MainListBox)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FoundInScripts"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents CloseButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents MainListBox As System.Windows.Forms.ListBox
End Class
