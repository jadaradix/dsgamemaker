<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditCode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditCode))
        Me.MainTextBox = New ScintillaNet.Scintilla
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip
        Me.DAcceptButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.UndoButton = New System.Windows.Forms.ToolStripButton
        Me.RedoButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.LoadInButton = New System.Windows.Forms.ToolStripButton
        Me.SaveOutButton = New System.Windows.Forms.ToolStripButton
        Me.MainStatusStrip = New System.Windows.Forms.StatusStrip
        Me.InfoLabel = New System.Windows.Forms.ToolStripStatusLabel
        CType(Me.MainTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainToolStrip.SuspendLayout()
        Me.MainStatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTextBox
        '
        Me.MainTextBox.ConfigurationManager.Language = "vbscript"
        Me.MainTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTextBox.IsBraceMatching = True
        Me.MainTextBox.Location = New System.Drawing.Point(0, 25)
        Me.MainTextBox.Margins.Left = 0
        Me.MainTextBox.Margins.Margin0.Width = 32
        Me.MainTextBox.Margins.Right = 0
        Me.MainTextBox.Name = "MainTextBox"
        Me.MainTextBox.Scrolling.HorizontalWidth = -1
        Me.MainTextBox.Size = New System.Drawing.Size(464, 275)
        Me.MainTextBox.Styles.BraceBad.FontName = "Verdana"
        Me.MainTextBox.Styles.BraceLight.FontName = "Verdana"
        Me.MainTextBox.Styles.CallTip.FontName = "Tahoma"
        Me.MainTextBox.Styles.CallTip.Size = 8.25!
        Me.MainTextBox.Styles.ControlChar.FontName = "Verdana"
        Me.MainTextBox.Styles.Default.FontName = "Verdana"
        Me.MainTextBox.Styles.IndentGuide.FontName = "Verdana"
        Me.MainTextBox.Styles.LastPredefined.FontName = "Verdana"
        Me.MainTextBox.Styles.LineNumber.FontName = "Verdana"
        Me.MainTextBox.Styles.Max.FontName = "Verdana"
        Me.MainTextBox.TabIndex = 6
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton, Me.ToolStripSep1, Me.UndoButton, Me.RedoButton, Me.ToolStripSeparator1, Me.LoadInButton, Me.SaveOutButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(464, 25)
        Me.MainToolStrip.TabIndex = 7
        '
        'DAcceptButton
        '
        Me.DAcceptButton.Image = Global.DS_Game_Maker.My.Resources.Resources.AcceptIcon
        Me.DAcceptButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DAcceptButton.Name = "DAcceptButton"
        Me.DAcceptButton.Size = New System.Drawing.Size(60, 22)
        Me.DAcceptButton.Text = "Accept"
        '
        'ToolStripSep1
        '
        Me.ToolStripSep1.Name = "ToolStripSep1"
        Me.ToolStripSep1.Size = New System.Drawing.Size(6, 25)
        '
        'UndoButton
        '
        Me.UndoButton.Image = Global.DS_Game_Maker.My.Resources.Resources.UndoIcon
        Me.UndoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UndoButton.Name = "UndoButton"
        Me.UndoButton.Size = New System.Drawing.Size(55, 22)
        Me.UndoButton.Text = " Undo"
        Me.UndoButton.ToolTipText = "Undo"
        '
        'RedoButton
        '
        Me.RedoButton.Image = Global.DS_Game_Maker.My.Resources.Resources.RedoIcon
        Me.RedoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RedoButton.Name = "RedoButton"
        Me.RedoButton.Size = New System.Drawing.Size(55, 22)
        Me.RedoButton.Text = "Redo "
        Me.RedoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.RedoButton.ToolTipText = "Redo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'LoadInButton
        '
        Me.LoadInButton.Image = Global.DS_Game_Maker.My.Resources.Resources.OpenIcon
        Me.LoadInButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadInButton.Name = "LoadInButton"
        Me.LoadInButton.Size = New System.Drawing.Size(75, 22)
        Me.LoadInButton.Text = "Load In..."
        '
        'SaveOutButton
        '
        Me.SaveOutButton.Image = Global.DS_Game_Maker.My.Resources.Resources.SaveIcon
        Me.SaveOutButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveOutButton.Name = "SaveOutButton"
        Me.SaveOutButton.Size = New System.Drawing.Size(84, 22)
        Me.SaveOutButton.Text = "Save Out..."
        '
        'MainStatusStrip
        '
        Me.MainStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoLabel})
        Me.MainStatusStrip.Location = New System.Drawing.Point(0, 300)
        Me.MainStatusStrip.Name = "MainStatusStrip"
        Me.MainStatusStrip.Size = New System.Drawing.Size(464, 22)
        Me.MainStatusStrip.TabIndex = 8
        Me.MainStatusStrip.Text = "StatusStrip1"
        '
        'InfoLabel
        '
        Me.InfoLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(0, 17)
        '
        'EditCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 322)
        Me.Controls.Add(Me.MainTextBox)
        Me.Controls.Add(Me.MainStatusStrip)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EditCode"
        Me.Text = "Code Editor"
        CType(Me.MainTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.MainStatusStrip.ResumeLayout(False)
        Me.MainStatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainTextBox As ScintillaNet.Scintilla
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents MainStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UndoButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents RedoButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents InfoLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LoadInButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveOutButton As System.Windows.Forms.ToolStripButton
End Class
