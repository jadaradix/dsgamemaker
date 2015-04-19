<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HelpViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HelpViewer))
        Me.SideTabControl = New System.Windows.Forms.TabControl
        Me.ContentsTab = New System.Windows.Forms.TabPage
        Me.MainTreeView = New System.Windows.Forms.TreeView
        Me.MainImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.IndexTab = New System.Windows.Forms.TabPage
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.SearchBoxPanel = New System.Windows.Forms.Panel
        Me.SearchButton = New System.Windows.Forms.Button
        Me.SearchBox = New System.Windows.Forms.Panel
        Me.SearchBoxTB = New System.Windows.Forms.TextBox
        Me.DocBrowser = New System.Windows.Forms.WebBrowser
        Me.SideTabControl.SuspendLayout()
        Me.ContentsTab.SuspendLayout()
        Me.IndexTab.SuspendLayout()
        Me.SearchBoxPanel.SuspendLayout()
        Me.SearchBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'SideTabControl
        '
        Me.SideTabControl.Controls.Add(Me.ContentsTab)
        Me.SideTabControl.Controls.Add(Me.IndexTab)
        Me.SideTabControl.Dock = System.Windows.Forms.DockStyle.Left
        Me.SideTabControl.Location = New System.Drawing.Point(0, 0)
        Me.SideTabControl.Margin = New System.Windows.Forms.Padding(0)
        Me.SideTabControl.Name = "SideTabControl"
        Me.SideTabControl.SelectedIndex = 0
        Me.SideTabControl.Size = New System.Drawing.Size(256, 446)
        Me.SideTabControl.TabIndex = 1
        '
        'ContentsTab
        '
        Me.ContentsTab.Controls.Add(Me.MainTreeView)
        Me.ContentsTab.Location = New System.Drawing.Point(4, 22)
        Me.ContentsTab.Name = "ContentsTab"
        Me.ContentsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ContentsTab.Size = New System.Drawing.Size(248, 420)
        Me.ContentsTab.TabIndex = 0
        Me.ContentsTab.Text = "Contents"
        Me.ContentsTab.UseVisualStyleBackColor = True
        '
        'MainTreeView
        '
        Me.MainTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MainTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTreeView.ImageIndex = 0
        Me.MainTreeView.ImageList = Me.MainImageList
        Me.MainTreeView.ItemHeight = 20
        Me.MainTreeView.Location = New System.Drawing.Point(3, 3)
        Me.MainTreeView.Name = "MainTreeView"
        Me.MainTreeView.SelectedImageIndex = 0
        Me.MainTreeView.Size = New System.Drawing.Size(242, 414)
        Me.MainTreeView.TabIndex = 3
        '
        'MainImageList
        '
        Me.MainImageList.ImageStream = CType(resources.GetObject("MainImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.MainImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.MainImageList.Images.SetKeyName(0, "book.png")
        Me.MainImageList.Images.SetKeyName(1, "document.png")
        '
        'IndexTab
        '
        Me.IndexTab.Controls.Add(Me.ListBox1)
        Me.IndexTab.Controls.Add(Me.SearchBoxPanel)
        Me.IndexTab.Location = New System.Drawing.Point(4, 22)
        Me.IndexTab.Margin = New System.Windows.Forms.Padding(0)
        Me.IndexTab.Name = "IndexTab"
        Me.IndexTab.Size = New System.Drawing.Size(232, 420)
        Me.IndexTab.TabIndex = 1
        Me.IndexTab.Text = "Index"
        Me.IndexTab.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(0, 39)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(232, 381)
        Me.ListBox1.TabIndex = 3
        '
        'SearchBoxPanel
        '
        Me.SearchBoxPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.SearchBoxPanel.BackgroundImage = CType(resources.GetObject("SearchBoxPanel.BackgroundImage"), System.Drawing.Image)
        Me.SearchBoxPanel.Controls.Add(Me.SearchButton)
        Me.SearchBoxPanel.Controls.Add(Me.SearchBox)
        Me.SearchBoxPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.SearchBoxPanel.Location = New System.Drawing.Point(0, 0)
        Me.SearchBoxPanel.Name = "SearchBoxPanel"
        Me.SearchBoxPanel.Size = New System.Drawing.Size(232, 39)
        Me.SearchBoxPanel.TabIndex = 5
        '
        'SearchButton
        '
        Me.SearchButton.AccessibleName = "Search"
        Me.SearchButton.Image = Global.DS_Game_Maker.My.Resources.Resources.TestGameIcon
        Me.SearchButton.Location = New System.Drawing.Point(176, 7)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(26, 26)
        Me.SearchButton.TabIndex = 3
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'SearchBox
        '
        Me.SearchBox.BackgroundImage = CType(resources.GetObject("SearchBox.BackgroundImage"), System.Drawing.Image)
        Me.SearchBox.Controls.Add(Me.SearchBoxTB)
        Me.SearchBox.Location = New System.Drawing.Point(8, 8)
        Me.SearchBox.Name = "SearchBox"
        Me.SearchBox.Size = New System.Drawing.Size(166, 23)
        Me.SearchBox.TabIndex = 4
        '
        'SearchBoxTB
        '
        Me.SearchBoxTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SearchBoxTB.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchBoxTB.ForeColor = System.Drawing.Color.Gray
        Me.SearchBoxTB.Location = New System.Drawing.Point(21, 4)
        Me.SearchBoxTB.Name = "SearchBoxTB"
        Me.SearchBoxTB.Size = New System.Drawing.Size(130, 15)
        Me.SearchBoxTB.TabIndex = 3
        Me.SearchBoxTB.Text = "Hello, World"
        '
        'DocBrowser
        '
        Me.DocBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocBrowser.Location = New System.Drawing.Point(256, 0)
        Me.DocBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.DocBrowser.Name = "DocBrowser"
        Me.DocBrowser.Size = New System.Drawing.Size(368, 446)
        Me.DocBrowser.TabIndex = 2
        '
        'HelpViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(624, 446)
        Me.Controls.Add(Me.DocBrowser)
        Me.Controls.Add(Me.SideTabControl)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "HelpViewer"
        Me.Text = "DS Game Maker Help"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SideTabControl.ResumeLayout(False)
        Me.ContentsTab.ResumeLayout(False)
        Me.IndexTab.ResumeLayout(False)
        Me.SearchBoxPanel.ResumeLayout(False)
        Me.SearchBox.ResumeLayout(False)
        Me.SearchBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SideTabControl As System.Windows.Forms.TabControl
    Friend WithEvents ContentsTab As System.Windows.Forms.TabPage
    Friend WithEvents IndexTab As System.Windows.Forms.TabPage
    Friend WithEvents DocBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents MainTreeView As System.Windows.Forms.TreeView
    Friend WithEvents SearchBoxPanel As System.Windows.Forms.Panel
    Friend WithEvents SearchBoxTB As System.Windows.Forms.TextBox
    Friend WithEvents SearchBox As System.Windows.Forms.Panel
    Friend WithEvents SearchButton As System.Windows.Forms.Button
    Friend WithEvents MainImageList As System.Windows.Forms.ImageList
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
End Class
