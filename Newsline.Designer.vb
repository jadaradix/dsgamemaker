<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Newsline
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Newsline))
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LoadanExampleButton = New System.Windows.Forms.Button()
        Me.VisitForumButton = New System.Windows.Forms.Button()
        Me.MainWebBrowser = New System.Windows.Forms.WebBrowser()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseButton.Location = New System.Drawing.Point(320, 4)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(100, 27)
        Me.CloseButton.TabIndex = 0
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LoadanExampleButton)
        Me.Panel1.Controls.Add(Me.VisitForumButton)
        Me.Panel1.Controls.Add(Me.CloseButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 387)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(424, 35)
        Me.Panel1.TabIndex = 1
        '
        'LoadanExampleButton
        '
        Me.LoadanExampleButton.Location = New System.Drawing.Point(106, 4)
        Me.LoadanExampleButton.Name = "LoadanExampleButton"
        Me.LoadanExampleButton.Size = New System.Drawing.Size(100, 27)
        Me.LoadanExampleButton.TabIndex = 3
        Me.LoadanExampleButton.Text = "Load an Example"
        Me.LoadanExampleButton.UseVisualStyleBackColor = True
        '
        'VisitForumButton
        '
        Me.VisitForumButton.Location = New System.Drawing.Point(4, 4)
        Me.VisitForumButton.Name = "VisitForumButton"
        Me.VisitForumButton.Size = New System.Drawing.Size(100, 27)
        Me.VisitForumButton.TabIndex = 2
        Me.VisitForumButton.Text = "Visit Forum"
        Me.VisitForumButton.UseVisualStyleBackColor = True
        '
        'MainWebBrowser
        '
        Me.MainWebBrowser.AllowWebBrowserDrop = False
        Me.MainWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainWebBrowser.Location = New System.Drawing.Point(0, 0)
        Me.MainWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.MainWebBrowser.Name = "MainWebBrowser"
        Me.MainWebBrowser.ScriptErrorsSuppressed = True
        Me.MainWebBrowser.Size = New System.Drawing.Size(424, 387)
        Me.MainWebBrowser.TabIndex = 2
        Me.MainWebBrowser.Url = New System.Uri("http://dsgamemaker.com/newsline", System.UriKind.Absolute)
        '
        'Newsline
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 422)
        Me.Controls.Add(Me.MainWebBrowser)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(22, 22)
        Me.MinimumSize = New System.Drawing.Size(340, 360)
        Me.Name = "Newsline"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = ""
        Me.Text = "DS Game Maker Newsline"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents VisitForumButton As System.Windows.Forms.Button
    Friend WithEvents MainWebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents LoadanExampleButton As System.Windows.Forms.Button
End Class
