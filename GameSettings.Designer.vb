<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GameSettings))
        Me.MainTabControl = New System.Windows.Forms.TabControl
        Me.GeneralTabPage = New System.Windows.Forms.TabPage
        Me.MidPointCheckBox = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.NitroFSCallCheckBox = New System.Windows.Forms.CheckBox
        Me.FATCallCheckBox = New System.Windows.Forms.CheckBox
        Me.StartingRoomDropper = New System.Windows.Forms.ComboBox
        Me.StartingRoomLabel = New System.Windows.Forms.Label
        Me.ProjectInfoTabPage = New System.Windows.Forms.TabPage
        Me.ProjectInfoInfoLabel = New System.Windows.Forms.Label
        Me.Text3TextBox = New System.Windows.Forms.TextBox
        Me.Text3Label = New System.Windows.Forms.Label
        Me.Text2TextBox = New System.Windows.Forms.TextBox
        Me.Text2Label = New System.Windows.Forms.Label
        Me.ProjectNameTextBox = New System.Windows.Forms.TextBox
        Me.ProjectNameLabel = New System.Windows.Forms.Label
        Me.ScoringTabPage = New System.Windows.Forms.TabPage
        Me.HealthDropper = New System.Windows.Forms.NumericUpDown
        Me.ScoreDropper = New System.Windows.Forms.NumericUpDown
        Me.LivesDropper = New System.Windows.Forms.NumericUpDown
        Me.HealthLabel = New System.Windows.Forms.Label
        Me.LivesLabel = New System.Windows.Forms.Label
        Me.ScoreLabel = New System.Windows.Forms.Label
        Me.ScoringInfoLabel = New System.Windows.Forms.Label
        Me.DCancelButton = New System.Windows.Forms.Button
        Me.DOkayButton = New System.Windows.Forms.Button
        Me.CodingTabPage = New System.Windows.Forms.TabPage
        Me.IncludeWiFiLibChecker = New System.Windows.Forms.CheckBox
        Me.IncludeFilesList = New System.Windows.Forms.ListBox
        Me.IncludeFilesLabel = New System.Windows.Forms.Label
        Me.NitroFSFilesLabel = New System.Windows.Forms.Label
        Me.NitroFSFilesList = New System.Windows.Forms.ListBox
        Me.AddIncludeFileButton = New System.Windows.Forms.Button
        Me.IncludeFilesControlPanel = New System.Windows.Forms.Panel
        Me.NitroFSFilesControlPanel = New System.Windows.Forms.Panel
        Me.EditIncludeFileButton = New System.Windows.Forms.Button
        Me.DeleteIncludeFileButton = New System.Windows.Forms.Button
        Me.DeleteNitroFSFileButton = New System.Windows.Forms.Button
        Me.EditNitroFSFileButton = New System.Windows.Forms.Button
        Me.AddNitroFSFileButton = New System.Windows.Forms.Button
        Me.MainTabControl.SuspendLayout()
        Me.GeneralTabPage.SuspendLayout()
        Me.ProjectInfoTabPage.SuspendLayout()
        Me.ScoringTabPage.SuspendLayout()
        CType(Me.HealthDropper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScoreDropper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LivesDropper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CodingTabPage.SuspendLayout()
        Me.IncludeFilesControlPanel.SuspendLayout()
        Me.NitroFSFilesControlPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTabControl
        '
        Me.MainTabControl.Controls.Add(Me.GeneralTabPage)
        Me.MainTabControl.Controls.Add(Me.ProjectInfoTabPage)
        Me.MainTabControl.Controls.Add(Me.ScoringTabPage)
        Me.MainTabControl.Controls.Add(Me.CodingTabPage)
        Me.MainTabControl.Location = New System.Drawing.Point(0, 0)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(284, 262)
        Me.MainTabControl.TabIndex = 0
        '
        'GeneralTabPage
        '
        Me.GeneralTabPage.Controls.Add(Me.MidPointCheckBox)
        Me.GeneralTabPage.Controls.Add(Me.Label1)
        Me.GeneralTabPage.Controls.Add(Me.NitroFSCallCheckBox)
        Me.GeneralTabPage.Controls.Add(Me.FATCallCheckBox)
        Me.GeneralTabPage.Controls.Add(Me.StartingRoomDropper)
        Me.GeneralTabPage.Controls.Add(Me.StartingRoomLabel)
        Me.GeneralTabPage.Location = New System.Drawing.Point(4, 22)
        Me.GeneralTabPage.Name = "GeneralTabPage"
        Me.GeneralTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.GeneralTabPage.Size = New System.Drawing.Size(276, 236)
        Me.GeneralTabPage.TabIndex = 0
        Me.GeneralTabPage.Text = "General"
        Me.GeneralTabPage.UseVisualStyleBackColor = True
        '
        'MidPointCheckBox
        '
        Me.MidPointCheckBox.AutoSize = True
        Me.MidPointCheckBox.Location = New System.Drawing.Point(20, 104)
        Me.MidPointCheckBox.Name = "MidPointCheckBox"
        Me.MidPointCheckBox.Size = New System.Drawing.Size(133, 17)
        Me.MidPointCheckBox.TabIndex = 8
        Me.MidPointCheckBox.Text = "Use Midpoint Collisions"
        Me.MidPointCheckBox.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Enables Sound and Filesystem"
        '
        'NitroFSCallCheckBox
        '
        Me.NitroFSCallCheckBox.AutoSize = True
        Me.NitroFSCallCheckBox.Location = New System.Drawing.Point(20, 69)
        Me.NitroFSCallCheckBox.Name = "NitroFSCallCheckBox"
        Me.NitroFSCallCheckBox.Size = New System.Drawing.Size(162, 17)
        Me.NitroFSCallCheckBox.TabIndex = 3
        Me.NitroFSCallCheckBox.Text = "Perform NitroFS Initialization"
        Me.NitroFSCallCheckBox.UseVisualStyleBackColor = True
        '
        'FATCallCheckBox
        '
        Me.FATCallCheckBox.AutoSize = True
        Me.FATCallCheckBox.Location = New System.Drawing.Point(20, 46)
        Me.FATCallCheckBox.Name = "FATCallCheckBox"
        Me.FATCallCheckBox.Size = New System.Drawing.Size(185, 17)
        Me.FATCallCheckBox.TabIndex = 2
        Me.FATCallCheckBox.Text = "Perform Generic FAT Initialization"
        Me.FATCallCheckBox.UseVisualStyleBackColor = True
        '
        'StartingRoomDropper
        '
        Me.StartingRoomDropper.FormattingEnabled = True
        Me.StartingRoomDropper.Location = New System.Drawing.Point(119, 17)
        Me.StartingRoomDropper.Name = "StartingRoomDropper"
        Me.StartingRoomDropper.Size = New System.Drawing.Size(112, 21)
        Me.StartingRoomDropper.TabIndex = 1
        '
        'StartingRoomLabel
        '
        Me.StartingRoomLabel.AutoSize = True
        Me.StartingRoomLabel.Location = New System.Drawing.Point(20, 20)
        Me.StartingRoomLabel.Name = "StartingRoomLabel"
        Me.StartingRoomLabel.Size = New System.Drawing.Size(79, 13)
        Me.StartingRoomLabel.TabIndex = 0
        Me.StartingRoomLabel.Text = "Starting Room:"
        '
        'ProjectInfoTabPage
        '
        Me.ProjectInfoTabPage.Controls.Add(Me.ProjectInfoInfoLabel)
        Me.ProjectInfoTabPage.Controls.Add(Me.Text3TextBox)
        Me.ProjectInfoTabPage.Controls.Add(Me.Text3Label)
        Me.ProjectInfoTabPage.Controls.Add(Me.Text2TextBox)
        Me.ProjectInfoTabPage.Controls.Add(Me.Text2Label)
        Me.ProjectInfoTabPage.Controls.Add(Me.ProjectNameTextBox)
        Me.ProjectInfoTabPage.Controls.Add(Me.ProjectNameLabel)
        Me.ProjectInfoTabPage.Location = New System.Drawing.Point(4, 22)
        Me.ProjectInfoTabPage.Name = "ProjectInfoTabPage"
        Me.ProjectInfoTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.ProjectInfoTabPage.Size = New System.Drawing.Size(276, 236)
        Me.ProjectInfoTabPage.TabIndex = 2
        Me.ProjectInfoTabPage.Text = "Project Info."
        Me.ProjectInfoTabPage.UseVisualStyleBackColor = True
        '
        'ProjectInfoInfoLabel
        '
        Me.ProjectInfoInfoLabel.BackColor = System.Drawing.SystemColors.Control
        Me.ProjectInfoInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ProjectInfoInfoLabel.Location = New System.Drawing.Point(20, 20)
        Me.ProjectInfoInfoLabel.Name = "ProjectInfoInfoLabel"
        Me.ProjectInfoInfoLabel.Padding = New System.Windows.Forms.Padding(8)
        Me.ProjectInfoInfoLabel.Size = New System.Drawing.Size(236, 72)
        Me.ProjectInfoInfoLabel.TabIndex = 12
        Me.ProjectInfoInfoLabel.Text = "A game can have 3 lines of description texts that appear on the DS Homebrew Kit o" & _
            "r other Flashcart. The Project Name is equivelant to the first thereof."
        Me.ProjectInfoInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Text3TextBox
        '
        Me.Text3TextBox.Location = New System.Drawing.Point(119, 156)
        Me.Text3TextBox.MaxLength = 24
        Me.Text3TextBox.Name = "Text3TextBox"
        Me.Text3TextBox.Size = New System.Drawing.Size(112, 21)
        Me.Text3TextBox.TabIndex = 11
        '
        'Text3Label
        '
        Me.Text3Label.AutoSize = True
        Me.Text3Label.Location = New System.Drawing.Point(20, 159)
        Me.Text3Label.Name = "Text3Label"
        Me.Text3Label.Size = New System.Drawing.Size(42, 13)
        Me.Text3Label.TabIndex = 10
        Me.Text3Label.Text = "Text 3:"
        '
        'Text2TextBox
        '
        Me.Text2TextBox.Location = New System.Drawing.Point(119, 129)
        Me.Text2TextBox.MaxLength = 24
        Me.Text2TextBox.Name = "Text2TextBox"
        Me.Text2TextBox.Size = New System.Drawing.Size(112, 21)
        Me.Text2TextBox.TabIndex = 9
        '
        'Text2Label
        '
        Me.Text2Label.AutoSize = True
        Me.Text2Label.Location = New System.Drawing.Point(20, 132)
        Me.Text2Label.Name = "Text2Label"
        Me.Text2Label.Size = New System.Drawing.Size(42, 13)
        Me.Text2Label.TabIndex = 8
        Me.Text2Label.Text = "Text 2:"
        '
        'ProjectNameTextBox
        '
        Me.ProjectNameTextBox.Location = New System.Drawing.Point(119, 102)
        Me.ProjectNameTextBox.MaxLength = 24
        Me.ProjectNameTextBox.Name = "ProjectNameTextBox"
        Me.ProjectNameTextBox.Size = New System.Drawing.Size(112, 21)
        Me.ProjectNameTextBox.TabIndex = 7
        '
        'ProjectNameLabel
        '
        Me.ProjectNameLabel.AutoSize = True
        Me.ProjectNameLabel.Location = New System.Drawing.Point(20, 105)
        Me.ProjectNameLabel.Name = "ProjectNameLabel"
        Me.ProjectNameLabel.Size = New System.Drawing.Size(75, 13)
        Me.ProjectNameLabel.TabIndex = 6
        Me.ProjectNameLabel.Text = "Project Name:"
        '
        'ScoringTabPage
        '
        Me.ScoringTabPage.Controls.Add(Me.HealthDropper)
        Me.ScoringTabPage.Controls.Add(Me.ScoreDropper)
        Me.ScoringTabPage.Controls.Add(Me.LivesDropper)
        Me.ScoringTabPage.Controls.Add(Me.HealthLabel)
        Me.ScoringTabPage.Controls.Add(Me.LivesLabel)
        Me.ScoringTabPage.Controls.Add(Me.ScoreLabel)
        Me.ScoringTabPage.Controls.Add(Me.ScoringInfoLabel)
        Me.ScoringTabPage.Location = New System.Drawing.Point(4, 22)
        Me.ScoringTabPage.Name = "ScoringTabPage"
        Me.ScoringTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.ScoringTabPage.Size = New System.Drawing.Size(276, 236)
        Me.ScoringTabPage.TabIndex = 1
        Me.ScoringTabPage.Text = "Scoring"
        Me.ScoringTabPage.UseVisualStyleBackColor = True
        '
        'HealthDropper
        '
        Me.HealthDropper.Location = New System.Drawing.Point(119, 144)
        Me.HealthDropper.Maximum = New Decimal(New Integer() {8192, 0, 0, 0})
        Me.HealthDropper.Name = "HealthDropper"
        Me.HealthDropper.Size = New System.Drawing.Size(60, 21)
        Me.HealthDropper.TabIndex = 20
        Me.HealthDropper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ScoreDropper
        '
        Me.ScoreDropper.Location = New System.Drawing.Point(119, 90)
        Me.ScoreDropper.Maximum = New Decimal(New Integer() {8192, 0, 0, 0})
        Me.ScoreDropper.Name = "ScoreDropper"
        Me.ScoreDropper.Size = New System.Drawing.Size(60, 21)
        Me.ScoreDropper.TabIndex = 19
        Me.ScoreDropper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LivesDropper
        '
        Me.LivesDropper.Location = New System.Drawing.Point(119, 117)
        Me.LivesDropper.Maximum = New Decimal(New Integer() {8192, 0, 0, 0})
        Me.LivesDropper.Name = "LivesDropper"
        Me.LivesDropper.Size = New System.Drawing.Size(60, 21)
        Me.LivesDropper.TabIndex = 18
        Me.LivesDropper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'HealthLabel
        '
        Me.HealthLabel.AutoSize = True
        Me.HealthLabel.Location = New System.Drawing.Point(20, 146)
        Me.HealthLabel.Name = "HealthLabel"
        Me.HealthLabel.Size = New System.Drawing.Size(42, 13)
        Me.HealthLabel.TabIndex = 16
        Me.HealthLabel.Text = "Health:"
        '
        'LivesLabel
        '
        Me.LivesLabel.AutoSize = True
        Me.LivesLabel.Location = New System.Drawing.Point(20, 119)
        Me.LivesLabel.Name = "LivesLabel"
        Me.LivesLabel.Size = New System.Drawing.Size(35, 13)
        Me.LivesLabel.TabIndex = 14
        Me.LivesLabel.Text = "Lives:"
        '
        'ScoreLabel
        '
        Me.ScoreLabel.AutoSize = True
        Me.ScoreLabel.Location = New System.Drawing.Point(20, 92)
        Me.ScoreLabel.Name = "ScoreLabel"
        Me.ScoreLabel.Size = New System.Drawing.Size(38, 13)
        Me.ScoreLabel.TabIndex = 12
        Me.ScoreLabel.Text = "Score:"
        '
        'ScoringInfoLabel
        '
        Me.ScoringInfoLabel.BackColor = System.Drawing.SystemColors.Control
        Me.ScoringInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ScoringInfoLabel.Location = New System.Drawing.Point(20, 20)
        Me.ScoringInfoLabel.Name = "ScoringInfoLabel"
        Me.ScoringInfoLabel.Padding = New System.Windows.Forms.Padding(8)
        Me.ScoringInfoLabel.Size = New System.Drawing.Size(236, 57)
        Me.ScoringInfoLabel.TabIndex = 0
        Me.ScoringInfoLabel.Text = "Here you may set the default values (values when the Game starts) of the built-in" & _
            " lives, health and score variables."
        Me.ScoringInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DCancelButton
        '
        Me.DCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.DCancelButton.Location = New System.Drawing.Point(201, 267)
        Me.DCancelButton.Name = "DCancelButton"
        Me.DCancelButton.Size = New System.Drawing.Size(75, 28)
        Me.DCancelButton.TabIndex = 1
        Me.DCancelButton.Text = "Cancel"
        Me.DCancelButton.UseVisualStyleBackColor = True
        '
        'DOkayButton
        '
        Me.DOkayButton.Location = New System.Drawing.Point(123, 267)
        Me.DOkayButton.Name = "DOkayButton"
        Me.DOkayButton.Size = New System.Drawing.Size(75, 28)
        Me.DOkayButton.TabIndex = 2
        Me.DOkayButton.Text = "OK"
        Me.DOkayButton.UseVisualStyleBackColor = True
        '
        'CodingTabPage
        '
        Me.CodingTabPage.Controls.Add(Me.NitroFSFilesControlPanel)
        Me.CodingTabPage.Controls.Add(Me.IncludeFilesControlPanel)
        Me.CodingTabPage.Controls.Add(Me.NitroFSFilesLabel)
        Me.CodingTabPage.Controls.Add(Me.NitroFSFilesList)
        Me.CodingTabPage.Controls.Add(Me.IncludeFilesLabel)
        Me.CodingTabPage.Controls.Add(Me.IncludeFilesList)
        Me.CodingTabPage.Controls.Add(Me.IncludeWiFiLibChecker)
        Me.CodingTabPage.Location = New System.Drawing.Point(4, 22)
        Me.CodingTabPage.Name = "CodingTabPage"
        Me.CodingTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.CodingTabPage.Size = New System.Drawing.Size(276, 236)
        Me.CodingTabPage.TabIndex = 3
        Me.CodingTabPage.Text = "Coding"
        Me.CodingTabPage.UseVisualStyleBackColor = True
        '
        'IncludeWiFiLibChecker
        '
        Me.IncludeWiFiLibChecker.AutoSize = True
        Me.IncludeWiFiLibChecker.Location = New System.Drawing.Point(20, 20)
        Me.IncludeWiFiLibChecker.Name = "IncludeWiFiLibChecker"
        Me.IncludeWiFiLibChecker.Size = New System.Drawing.Size(100, 17)
        Me.IncludeWiFiLibChecker.TabIndex = 0
        Me.IncludeWiFiLibChecker.Text = "Include WiFi Lib"
        Me.IncludeWiFiLibChecker.UseVisualStyleBackColor = True
        '
        'IncludeFilesList
        '
        Me.IncludeFilesList.FormattingEnabled = True
        Me.IncludeFilesList.Location = New System.Drawing.Point(20, 62)
        Me.IncludeFilesList.Name = "IncludeFilesList"
        Me.IncludeFilesList.Size = New System.Drawing.Size(113, 108)
        Me.IncludeFilesList.TabIndex = 1
        '
        'IncludeFilesLabel
        '
        Me.IncludeFilesLabel.AutoSize = True
        Me.IncludeFilesLabel.Location = New System.Drawing.Point(17, 46)
        Me.IncludeFilesLabel.Name = "IncludeFilesLabel"
        Me.IncludeFilesLabel.Size = New System.Drawing.Size(70, 13)
        Me.IncludeFilesLabel.TabIndex = 2
        Me.IncludeFilesLabel.Text = "Include Files:"
        '
        'NitroFSFilesLabel
        '
        Me.NitroFSFilesLabel.AutoSize = True
        Me.NitroFSFilesLabel.Location = New System.Drawing.Point(140, 46)
        Me.NitroFSFilesLabel.Name = "NitroFSFilesLabel"
        Me.NitroFSFilesLabel.Size = New System.Drawing.Size(70, 13)
        Me.NitroFSFilesLabel.TabIndex = 4
        Me.NitroFSFilesLabel.Text = "NitroFS Files:"
        '
        'NitroFSFilesList
        '
        Me.NitroFSFilesList.FormattingEnabled = True
        Me.NitroFSFilesList.Location = New System.Drawing.Point(143, 62)
        Me.NitroFSFilesList.Name = "NitroFSFilesList"
        Me.NitroFSFilesList.Size = New System.Drawing.Size(113, 108)
        Me.NitroFSFilesList.TabIndex = 3
        '
        'AddIncludeFileButton
        '
        Me.AddIncludeFileButton.AccessibleName = "Add Include File"
        Me.AddIncludeFileButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PlusIcon
        Me.AddIncludeFileButton.Location = New System.Drawing.Point(2, 2)
        Me.AddIncludeFileButton.Name = "AddIncludeFileButton"
        Me.AddIncludeFileButton.Size = New System.Drawing.Size(30, 26)
        Me.AddIncludeFileButton.TabIndex = 5
        Me.AddIncludeFileButton.UseVisualStyleBackColor = True
        '
        'IncludeFilesControlPanel
        '
        Me.IncludeFilesControlPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.IncludeFilesControlPanel.Controls.Add(Me.DeleteIncludeFileButton)
        Me.IncludeFilesControlPanel.Controls.Add(Me.EditIncludeFileButton)
        Me.IncludeFilesControlPanel.Controls.Add(Me.AddIncludeFileButton)
        Me.IncludeFilesControlPanel.Location = New System.Drawing.Point(20, 173)
        Me.IncludeFilesControlPanel.Name = "IncludeFilesControlPanel"
        Me.IncludeFilesControlPanel.Size = New System.Drawing.Size(113, 30)
        Me.IncludeFilesControlPanel.TabIndex = 6
        '
        'NitroFSFilesControlPanel
        '
        Me.NitroFSFilesControlPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.NitroFSFilesControlPanel.Controls.Add(Me.DeleteNitroFSFileButton)
        Me.NitroFSFilesControlPanel.Controls.Add(Me.EditNitroFSFileButton)
        Me.NitroFSFilesControlPanel.Controls.Add(Me.AddNitroFSFileButton)
        Me.NitroFSFilesControlPanel.Location = New System.Drawing.Point(143, 173)
        Me.NitroFSFilesControlPanel.Name = "NitroFSFilesControlPanel"
        Me.NitroFSFilesControlPanel.Size = New System.Drawing.Size(113, 30)
        Me.NitroFSFilesControlPanel.TabIndex = 7
        '
        'EditIncludeFileButton
        '
        Me.EditIncludeFileButton.AccessibleName = "Edit Include File"
        Me.EditIncludeFileButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PencilIcon
        Me.EditIncludeFileButton.Location = New System.Drawing.Point(32, 2)
        Me.EditIncludeFileButton.Name = "EditIncludeFileButton"
        Me.EditIncludeFileButton.Size = New System.Drawing.Size(30, 26)
        Me.EditIncludeFileButton.TabIndex = 6
        Me.EditIncludeFileButton.UseVisualStyleBackColor = True
        '
        'DeleteIncludeFileButton
        '
        Me.DeleteIncludeFileButton.AccessibleName = "Delete Include File"
        Me.DeleteIncludeFileButton.Image = Global.DS_Game_Maker.My.Resources.Resources.DeleteIcon
        Me.DeleteIncludeFileButton.Location = New System.Drawing.Point(62, 2)
        Me.DeleteIncludeFileButton.Name = "DeleteIncludeFileButton"
        Me.DeleteIncludeFileButton.Size = New System.Drawing.Size(30, 26)
        Me.DeleteIncludeFileButton.TabIndex = 7
        Me.DeleteIncludeFileButton.UseVisualStyleBackColor = True
        '
        'DeleteNitroFSFileButton
        '
        Me.DeleteNitroFSFileButton.AccessibleName = "Delete NitroFS File"
        Me.DeleteNitroFSFileButton.Image = Global.DS_Game_Maker.My.Resources.Resources.DeleteIcon
        Me.DeleteNitroFSFileButton.Location = New System.Drawing.Point(62, 2)
        Me.DeleteNitroFSFileButton.Name = "DeleteNitroFSFileButton"
        Me.DeleteNitroFSFileButton.Size = New System.Drawing.Size(30, 26)
        Me.DeleteNitroFSFileButton.TabIndex = 10
        Me.DeleteNitroFSFileButton.UseVisualStyleBackColor = True
        '
        'EditNitroFSFileButton
        '
        Me.EditNitroFSFileButton.AccessibleName = "Edit NitroFS File"
        Me.EditNitroFSFileButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PencilIcon
        Me.EditNitroFSFileButton.Location = New System.Drawing.Point(32, 2)
        Me.EditNitroFSFileButton.Name = "EditNitroFSFileButton"
        Me.EditNitroFSFileButton.Size = New System.Drawing.Size(30, 26)
        Me.EditNitroFSFileButton.TabIndex = 9
        Me.EditNitroFSFileButton.UseVisualStyleBackColor = True
        '
        'AddNitroFSFileButton
        '
        Me.AddNitroFSFileButton.AccessibleName = "Add NitroFS File"
        Me.AddNitroFSFileButton.Image = Global.DS_Game_Maker.My.Resources.Resources.PlusIcon
        Me.AddNitroFSFileButton.Location = New System.Drawing.Point(2, 2)
        Me.AddNitroFSFileButton.Name = "AddNitroFSFileButton"
        Me.AddNitroFSFileButton.Size = New System.Drawing.Size(30, 26)
        Me.AddNitroFSFileButton.TabIndex = 8
        Me.AddNitroFSFileButton.UseVisualStyleBackColor = True
        '
        'GameSettings
        '
        Me.AcceptButton = Me.DOkayButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.DCancelButton
        Me.ClientSize = New System.Drawing.Size(284, 302)
        Me.Controls.Add(Me.DOkayButton)
        Me.Controls.Add(Me.DCancelButton)
        Me.Controls.Add(Me.MainTabControl)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GameSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Game Settings"
        Me.MainTabControl.ResumeLayout(False)
        Me.GeneralTabPage.ResumeLayout(False)
        Me.GeneralTabPage.PerformLayout()
        Me.ProjectInfoTabPage.ResumeLayout(False)
        Me.ProjectInfoTabPage.PerformLayout()
        Me.ScoringTabPage.ResumeLayout(False)
        Me.ScoringTabPage.PerformLayout()
        CType(Me.HealthDropper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScoreDropper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LivesDropper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CodingTabPage.ResumeLayout(False)
        Me.CodingTabPage.PerformLayout()
        Me.IncludeFilesControlPanel.ResumeLayout(False)
        Me.NitroFSFilesControlPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents GeneralTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ScoringTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ProjectInfoTabPage As System.Windows.Forms.TabPage
    Friend WithEvents Text3TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Text3Label As System.Windows.Forms.Label
    Friend WithEvents Text2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Text2Label As System.Windows.Forms.Label
    Friend WithEvents ProjectNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProjectNameLabel As System.Windows.Forms.Label
    Friend WithEvents DCancelButton As System.Windows.Forms.Button
    Friend WithEvents DOkayButton As System.Windows.Forms.Button
    Friend WithEvents StartingRoomLabel As System.Windows.Forms.Label
    Friend WithEvents StartingRoomDropper As System.Windows.Forms.ComboBox
    Friend WithEvents ScoringInfoLabel As System.Windows.Forms.Label
    Friend WithEvents HealthLabel As System.Windows.Forms.Label
    Friend WithEvents LivesLabel As System.Windows.Forms.Label
    Friend WithEvents ScoreLabel As System.Windows.Forms.Label
    Friend WithEvents HealthDropper As System.Windows.Forms.NumericUpDown
    Friend WithEvents ScoreDropper As System.Windows.Forms.NumericUpDown
    Friend WithEvents LivesDropper As System.Windows.Forms.NumericUpDown
    Friend WithEvents ProjectInfoInfoLabel As System.Windows.Forms.Label
    Friend WithEvents NitroFSCallCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents FATCallCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MidPointCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CodingTabPage As System.Windows.Forms.TabPage
    Friend WithEvents IncludeWiFiLibChecker As System.Windows.Forms.CheckBox
    Friend WithEvents IncludeFilesLabel As System.Windows.Forms.Label
    Friend WithEvents IncludeFilesList As System.Windows.Forms.ListBox
    Friend WithEvents NitroFSFilesLabel As System.Windows.Forms.Label
    Friend WithEvents NitroFSFilesList As System.Windows.Forms.ListBox
    Friend WithEvents AddIncludeFileButton As System.Windows.Forms.Button
    Friend WithEvents NitroFSFilesControlPanel As System.Windows.Forms.Panel
    Friend WithEvents IncludeFilesControlPanel As System.Windows.Forms.Panel
    Friend WithEvents DeleteIncludeFileButton As System.Windows.Forms.Button
    Friend WithEvents EditIncludeFileButton As System.Windows.Forms.Button
    Friend WithEvents DeleteNitroFSFileButton As System.Windows.Forms.Button
    Friend WithEvents EditNitroFSFileButton As System.Windows.Forms.Button
    Friend WithEvents AddNitroFSFileButton As System.Windows.Forms.Button
End Class
