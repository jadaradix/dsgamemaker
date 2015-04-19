<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pro))
        Me.CloseButton = New System.Windows.Forms.Button
        Me.EnterSerialButton = New System.Windows.Forms.Button
        Me.BuyProButton = New System.Windows.Forms.Button
        Me.MainInfoLabel = New System.Windows.Forms.Label
        Me.MainSalesLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseButton.Location = New System.Drawing.Point(170, 350)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(162, 28)
        Me.CloseButton.TabIndex = 0
        Me.CloseButton.Text = "Continue using Free"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'EnterSerialButton
        '
        Me.EnterSerialButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EnterSerialButton.Location = New System.Drawing.Point(6, 350)
        Me.EnterSerialButton.Name = "EnterSerialButton"
        Me.EnterSerialButton.Size = New System.Drawing.Size(162, 28)
        Me.EnterSerialButton.TabIndex = 1
        Me.EnterSerialButton.Text = "Enter Serial..."
        Me.EnterSerialButton.UseVisualStyleBackColor = True
        '
        'BuyProButton
        '
        Me.BuyProButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BuyProButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuyProButton.Location = New System.Drawing.Point(6, 317)
        Me.BuyProButton.Name = "BuyProButton"
        Me.BuyProButton.Size = New System.Drawing.Size(326, 32)
        Me.BuyProButton.TabIndex = 2
        Me.BuyProButton.Text = "Buy Pro ($14.99 for Lifetime license)"
        Me.BuyProButton.UseVisualStyleBackColor = True
        '
        'MainInfoLabel
        '
        Me.MainInfoLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainInfoLabel.ForeColor = System.Drawing.Color.White
        Me.MainInfoLabel.Location = New System.Drawing.Point(6, 166)
        Me.MainInfoLabel.Name = "MainInfoLabel"
        Me.MainInfoLabel.Size = New System.Drawing.Size(326, 31)
        Me.MainInfoLabel.TabIndex = 3
        Me.MainInfoLabel.Text = "..."
        Me.MainInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MainSalesLabel
        '
        Me.MainSalesLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainSalesLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainSalesLabel.Location = New System.Drawing.Point(6, 200)
        Me.MainSalesLabel.Name = "MainSalesLabel"
        Me.MainSalesLabel.Size = New System.Drawing.Size(326, 110)
        Me.MainSalesLabel.TabIndex = 4
        Me.MainSalesLabel.Text = resources.GetString("MainSalesLabel.Text")
        Me.MainSalesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = Global.DS_Game_Maker.My.Resources.Resources.ProBanner
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(338, 387)
        Me.Controls.Add(Me.MainSalesLabel)
        Me.Controls.Add(Me.MainInfoLabel)
        Me.Controls.Add(Me.BuyProButton)
        Me.Controls.Add(Me.EnterSerialButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Pro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Upgrade to Pro"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents EnterSerialButton As System.Windows.Forms.Button
    Friend WithEvents BuyProButton As System.Windows.Forms.Button
    Friend WithEvents MainInfoLabel As System.Windows.Forms.Label
    Friend WithEvents MainSalesLabel As System.Windows.Forms.Label
End Class
