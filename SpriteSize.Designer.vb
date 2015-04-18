<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpriteSize
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SpriteSize))
        Me.TablePanel = New System.Windows.Forms.Panel
        Me.MainInfoLabel = New System.Windows.Forms.Label
        Me.DOkayButton = New System.Windows.Forms.Button
        Me.OpenEditorButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TablePanel
        '
        Me.TablePanel.BackgroundImage = Global.DS_Game_Maker.My.Resources.Resources.SpriteSizesTable
        Me.TablePanel.Location = New System.Drawing.Point(46, 94)
        Me.TablePanel.Name = "TablePanel"
        Me.TablePanel.Size = New System.Drawing.Size(151, 70)
        Me.TablePanel.TabIndex = 0
        '
        'MainInfoLabel
        '
        Me.MainInfoLabel.Location = New System.Drawing.Point(12, 9)
        Me.MainInfoLabel.Name = "MainInfoLabel"
        Me.MainInfoLabel.Size = New System.Drawing.Size(218, 82)
        Me.MainInfoLabel.TabIndex = 1
        Me.MainInfoLabel.Text = "This Frame was not correctly sized for the DS. It must be one of the below sizes." & _
            "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click 'Open Editor' to open up your image editor so that you can correct the" & _
            " problem."
        '
        'DOkayButton
        '
        Me.DOkayButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DOkayButton.Location = New System.Drawing.Point(124, 185)
        Me.DOkayButton.Name = "DOkayButton"
        Me.DOkayButton.Size = New System.Drawing.Size(105, 28)
        Me.DOkayButton.TabIndex = 2
        Me.DOkayButton.Text = "OK"
        Me.DOkayButton.UseVisualStyleBackColor = True
        '
        'OpenEditorButton
        '
        Me.OpenEditorButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OpenEditorButton.Location = New System.Drawing.Point(15, 185)
        Me.OpenEditorButton.Name = "OpenEditorButton"
        Me.OpenEditorButton.Size = New System.Drawing.Size(105, 28)
        Me.OpenEditorButton.TabIndex = 3
        Me.OpenEditorButton.Text = "Open Editor"
        Me.OpenEditorButton.UseVisualStyleBackColor = True
        '
        'SpriteSize
        '
        Me.AcceptButton = Me.DOkayButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(242, 225)
        Me.Controls.Add(Me.OpenEditorButton)
        Me.Controls.Add(Me.DOkayButton)
        Me.Controls.Add(Me.MainInfoLabel)
        Me.Controls.Add(Me.TablePanel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SpriteSize"
        Me.Text = "Invalid Frame Size"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TablePanel As System.Windows.Forms.Panel
    Friend WithEvents MainInfoLabel As System.Windows.Forms.Label
    Friend WithEvents DOkayButton As System.Windows.Forms.Button
    Friend WithEvents OpenEditorButton As System.Windows.Forms.Button
End Class
