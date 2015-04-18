<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DEvent
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DEvent))
        Me.DCancelButton = New System.Windows.Forms.Button
        Me.StepEventButton = New System.Windows.Forms.Button
        Me.CollisionEventButton = New System.Windows.Forms.Button
        Me.TouchEventButton = New System.Windows.Forms.Button
        Me.ButtonReleaseEventButton = New System.Windows.Forms.Button
        Me.ButtonHeldEventButton = New System.Windows.Forms.Button
        Me.ButtonPressEventButton = New System.Windows.Forms.Button
        Me.CreateEventButton = New System.Windows.Forms.Button
        Me.Dropper = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SuspendLayout()
        '
        'DCancelButton
        '
        Me.DCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.DCancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DCancelButton.Location = New System.Drawing.Point(12, 150)
        Me.DCancelButton.Name = "DCancelButton"
        Me.DCancelButton.Size = New System.Drawing.Size(256, 28)
        Me.DCancelButton.TabIndex = 2
        Me.DCancelButton.Text = "Cancel"
        Me.DCancelButton.UseVisualStyleBackColor = True
        '
        'StepEventButton
        '
        Me.StepEventButton.Image = Global.DS_Game_Maker.My.Resources.Resources.ClockIcon
        Me.StepEventButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.StepEventButton.Location = New System.Drawing.Point(12, 114)
        Me.StepEventButton.Name = "StepEventButton"
        Me.StepEventButton.Size = New System.Drawing.Size(125, 28)
        Me.StepEventButton.TabIndex = 7
        Me.StepEventButton.Text = "      Step"
        Me.StepEventButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.StepEventButton.UseVisualStyleBackColor = True
        '
        'CollisionEventButton
        '
        Me.CollisionEventButton.Image = Global.DS_Game_Maker.My.Resources.Resources.Collision
        Me.CollisionEventButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CollisionEventButton.Location = New System.Drawing.Point(143, 80)
        Me.CollisionEventButton.Name = "CollisionEventButton"
        Me.CollisionEventButton.Size = New System.Drawing.Size(125, 28)
        Me.CollisionEventButton.TabIndex = 6
        Me.CollisionEventButton.Text = "      Collision"
        Me.CollisionEventButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CollisionEventButton.UseVisualStyleBackColor = True
        '
        'TouchEventButton
        '
        Me.TouchEventButton.Image = Global.DS_Game_Maker.My.Resources.Resources.StylusIcon
        Me.TouchEventButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TouchEventButton.Location = New System.Drawing.Point(12, 80)
        Me.TouchEventButton.Name = "TouchEventButton"
        Me.TouchEventButton.Size = New System.Drawing.Size(125, 28)
        Me.TouchEventButton.TabIndex = 5
        Me.TouchEventButton.Text = "      Touch"
        Me.TouchEventButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TouchEventButton.UseVisualStyleBackColor = True
        '
        'ButtonReleaseEventButton
        '
        Me.ButtonReleaseEventButton.Image = Global.DS_Game_Maker.My.Resources.Resources.KeyDownIcon1
        Me.ButtonReleaseEventButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonReleaseEventButton.Location = New System.Drawing.Point(143, 46)
        Me.ButtonReleaseEventButton.Name = "ButtonReleaseEventButton"
        Me.ButtonReleaseEventButton.Size = New System.Drawing.Size(125, 28)
        Me.ButtonReleaseEventButton.TabIndex = 4
        Me.ButtonReleaseEventButton.Text = "      Button Released"
        Me.ButtonReleaseEventButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonReleaseEventButton.UseVisualStyleBackColor = True
        '
        'ButtonHeldEventButton
        '
        Me.ButtonHeldEventButton.Image = Global.DS_Game_Maker.My.Resources.Resources.KeyDownIcon
        Me.ButtonHeldEventButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonHeldEventButton.Location = New System.Drawing.Point(12, 46)
        Me.ButtonHeldEventButton.Name = "ButtonHeldEventButton"
        Me.ButtonHeldEventButton.Size = New System.Drawing.Size(125, 28)
        Me.ButtonHeldEventButton.TabIndex = 3
        Me.ButtonHeldEventButton.Text = "      Button Held"
        Me.ButtonHeldEventButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonHeldEventButton.UseVisualStyleBackColor = True
        '
        'ButtonPressEventButton
        '
        Me.ButtonPressEventButton.Image = Global.DS_Game_Maker.My.Resources.Resources.KeyIcon
        Me.ButtonPressEventButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonPressEventButton.Location = New System.Drawing.Point(143, 12)
        Me.ButtonPressEventButton.Name = "ButtonPressEventButton"
        Me.ButtonPressEventButton.Size = New System.Drawing.Size(125, 28)
        Me.ButtonPressEventButton.TabIndex = 1
        Me.ButtonPressEventButton.Text = "      Button Press"
        Me.ButtonPressEventButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonPressEventButton.UseVisualStyleBackColor = True
        '
        'CreateEventButton
        '
        Me.CreateEventButton.Image = Global.DS_Game_Maker.My.Resources.Resources.CreateEventIcon
        Me.CreateEventButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CreateEventButton.Location = New System.Drawing.Point(12, 12)
        Me.CreateEventButton.Name = "CreateEventButton"
        Me.CreateEventButton.Size = New System.Drawing.Size(125, 28)
        Me.CreateEventButton.TabIndex = 0
        Me.CreateEventButton.Text = "      Create"
        Me.CreateEventButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CreateEventButton.UseVisualStyleBackColor = True
        '
        'Dropper
        '
        Me.Dropper.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dropper.Name = "EventDropper"
        Me.Dropper.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Dropper.Size = New System.Drawing.Size(61, 4)
        '
        'DEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.DCancelButton
        Me.ClientSize = New System.Drawing.Size(280, 190)
        Me.Controls.Add(Me.StepEventButton)
        Me.Controls.Add(Me.CollisionEventButton)
        Me.Controls.Add(Me.TouchEventButton)
        Me.Controls.Add(Me.ButtonReleaseEventButton)
        Me.Controls.Add(Me.ButtonHeldEventButton)
        Me.Controls.Add(Me.DCancelButton)
        Me.Controls.Add(Me.ButtonPressEventButton)
        Me.Controls.Add(Me.CreateEventButton)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DEvent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CreateEventButton As System.Windows.Forms.Button
    Friend WithEvents ButtonPressEventButton As System.Windows.Forms.Button
    Friend WithEvents DCancelButton As System.Windows.Forms.Button
    Friend WithEvents ButtonHeldEventButton As System.Windows.Forms.Button
    Friend WithEvents ButtonReleaseEventButton As System.Windows.Forms.Button
    Friend WithEvents TouchEventButton As System.Windows.Forms.Button
    Friend WithEvents CollisionEventButton As System.Windows.Forms.Button
    Friend WithEvents StepEventButton As System.Windows.Forms.Button
    Friend WithEvents Dropper As System.Windows.Forms.ContextMenuStrip
End Class
