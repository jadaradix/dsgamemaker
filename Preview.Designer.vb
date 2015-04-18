<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Preview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Preview))
        Me.PreviewPanel = New System.Windows.Forms.Panel
        Me.MainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'PreviewPanel
        '
        Me.PreviewPanel.BackColor = System.Drawing.Color.White
        Me.PreviewPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PreviewPanel.Location = New System.Drawing.Point(47, 36)
        Me.PreviewPanel.Name = "PreviewPanel"
        Me.PreviewPanel.Size = New System.Drawing.Size(64, 64)
        Me.PreviewPanel.TabIndex = 0
        '
        'MainTimer
        '
        '
        'Preview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(158, 136)
        Me.Controls.Add(Me.PreviewPanel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Preview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sprite Preview"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PreviewPanel As System.Windows.Forms.Panel
    Friend WithEvents MainTimer As System.Windows.Forms.Timer
End Class
