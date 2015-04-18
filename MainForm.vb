Imports System
Imports System.IO
Imports Microsoft.Win32

Public Class MainForm

    Dim NeedsDKP As Boolean = False
    Dim CacheHasTinternet As Boolean = True

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Initialize Apply Finders
        With ApplyFinders
            .Add("[X]")
            .Add("[Y]")
            .Add("[VX]")
            .Add("[VY]")
            .Add("[OriginalX]")
            .Add("[OriginalY]")
            .Add("[Screen]")
            .Add("[Width]")
            .Add("[Height]")
        End With
        'Initialize Variable Types
        With VariableTypes
            .Add("Integer")
            .Add("Boolean")
            .Add("Float")
            .Add("Signed Byte")
            .Add("Unsigned Byte")
            .Add("String")
        End With
        'Path Works
        AppPath = Application.StartupPath
        If AppPath.EndsWith("\bin\Debug") Then AppPath = My.Computer.FileSystem.SpecialDirectories.ProgramFiles + "\" + Application.ProductName
        AppPath += "\"
        DevPath = AppPath + "Dev\"
        CDrive = AppPath.Substring(0, 3)
        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is MdiClient Then ctl.BackgroundImage = My.Resources.MDIBG
        Next ctl
        Dim System32Path As String = Environment.GetFolderPath(Environment.SpecialFolder.System)
        'CacheHasTinternet = HasInternetConnection("http://invisionsoft.co.uk")
        If Not File.Exists(System32Path + "\SciLexer.dll") Then
            File.Copy(DevPath + "SciLexer.dll", System32Path + "\SciLexer.dll")
        End If
        If Not File.Exists(System32Path + "\ScintillaNet.dll") Then
            File.Copy(DevPath + "ScintillaNet.dll", System32Path + "\ScintillaNet.dll")
        End If
        'Also into Windows... nasty, rare suggested fix
        Dim WindowsPath As String = System32Path.Substring(0, System32Path.LastIndexOf("\"))
        If Not File.Exists(WindowsPath + "\SciLexer.dll") Then
            File.Copy(DevPath + "SciLexer.dll", WindowsPath + "\SciLexer.dll")
        End If
        If Not File.Exists(WindowsPath + "\ScintillaNet.dll") Then
            File.Copy(DevPath + "ScintillaNet.dll", WindowsPath + "\ScintillaNet.dll")
        End If
        If Not File.Exists(DevPath + "devkitProUpdater-1.5.0.exe") Then
            If CacheHasTinternet Then
                Dim ReqURL As String = WC.DownloadString("http://dsgamemaker.com/DSGM5RegClient/murphy.php")
                WC.DownloadFile(ReqURL, DevPath + "devkitProUpdater-1.5.0.exe")
            End If
        End If
        Try
            SetFileType(".dsgm", "DSGMFile")
            SetFileDescription("DSGMFile", Application.ProductName + " Project")
            AddAction("DSGMFile", "open", "Open")
            SetExtensionCommandLine("open", "DSGMFile", """" + AppPath + Application.ProductName + ".exe"" ""%1""")
            SetDefaultIcon("DSGMFile", """" + AppPath + "Icon.ico""")
        Catch WhatsBad As Exception
            MsgWarn("You should run " + Application.ProductName + " as an Administrator." + vbCrLf + vbCrLf + "(" + WhatsBad.Message + ")")
        End Try
        Dim VitalFiles As New Collection
        With VitalFiles
            .Add(AppPath + "Resources\NoSprite.png")
            .Add(AppPath + "ActionIcons\Empty.png")
            .Add(AppPath + "DefaultResources\Sprite.png")
            .Add(AppPath + "DefaultResources\Background.png")
            .Add(AppPath + "DefaultResources\Sound.wav")
        End With
        Dim VitalBuggered As Byte = 0
        For Each X As String In VitalFiles
            If Not File.Exists(X) Then VitalBuggered += 1
        Next
        If VitalBuggered = 1 Then MsgError("A vital file is missing. You must reinstall " + Application.ProductName + ".") : Exit Sub
        If VitalBuggered > 1 Then MsgError("Some vital files are missing. You must reinstall " + Application.ProductName + ".") : Exit Sub
        RebuildFontCache()
        'Toolstrip Renderers
        MainToolStrip.Renderer = New clsToolstripRenderer
        DMainMenuStrip.Renderer = New clsMenuRenderer
        ResRightClickMenu.Renderer = New clsMenuRenderer
        'Resources Setup
        ResourceTypes(0) = "Sprites"
        MainImageList.Images.Add("SpriteIcon", My.Resources.SpriteIcon)
        ResourceTypes(1) = "Objects"
        MainImageList.Images.Add("ObjectIcon", My.Resources.ObjectIcon)
        ResourceTypes(2) = "Backgrounds"
        MainImageList.Images.Add("BackgroundIcon", My.Resources.BackgroundIcon)
        ResourceTypes(3) = "Sounds"
        MainImageList.Images.Add("SoundIcon", My.Resources.SoundIcon)
        ResourceTypes(4) = "Rooms"
        MainImageList.Images.Add("RoomIcon", My.Resources.RoomIcon)
        ResourceTypes(5) = "Paths"
        MainImageList.Images.Add("PathIcon", My.Resources.PathIcon)
        ResourceTypes(6) = "Scripts"
        MainImageList.Images.Add("ScriptIcon", My.Resources.ScriptIcon)
        'Imagelist Setup
        MainImageList.Images.Add("FolderIcon", My.Resources.FolderIcon)
        'Resources Setup
        For Resource As Byte = 0 To ResourceTypes.Length - 1
            ResourcesTreeView.Nodes.Add(String.Empty, ResourceTypes(Resource), 7, 7)
        Next
        'Settings
        OptionPath = AppPath + "Settings.dat"
        If Not File.Exists(OptionPath) Then
            IO.File.Copy(AppPath + "SettingsRestore.dat", OptionPath)
        End If
        PatchOption("USE_EXTERNAL_SCRIPT_EDITOR", "0")
        PatchOption("RIGHT_CLICK", "1")
        PatchOption("HIDE_OLD_ACTIONS", "1")
        PatchOption("SHRINK_ACTIONS_LIST", "0")
        LoadOptions()
        'Fonts Setup
        For Each FontFile As String In Directory.GetFiles(AppPath + "Fonts")
            Dim FontName As String = FontFile.Substring(FontFile.LastIndexOf("\") + 1)
            FontName = FontName.Substring(0, FontName.IndexOf("."))
            FontNames.Add(FontName)
        Next
        Text = TitleDataWorks()
    End Sub

    Private Sub MainForm_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim BlankNew As Boolean = True
        If UpdateVersion > IDVersion Then
            DUpdate.ShowDialog()
        End If
        If Not Directory.Exists(CDrive + "devkitPro") Then
            MsgInfo("Thank you for installing " + Application.ProductName + "." + vbcrlf + vbcrlf + "'devkitPro Updater' will now launch so that you may install devkitARM (to compile your games).")
            RundevkitProUpdater()
        End If
        Dim SkipAuto As Boolean = False
        Dim Args As New List(Of String)
        For Each X As String In My.Application.CommandLineArgs
            If X = "/skipauto" Then SkipAuto = True : Continue For
            Args.Add(X)
        Next
        If Args.Count > 1 Then
            MsgWarn("You can only open one Project with " + Application.ProductName + " at once.")
        ElseIf Args.Count = 1 Then
            If File.Exists(Args(0)) Then OpenProject(Args(0))
            BlankNew = False
        Else
            If Not SkipAuto Then
                If Convert.ToByte(GetOption("OPEN_LAST_PROJECT_STARTUP")) = 1 Then
                    LoadLastProject(True)
                    BlankNew = False
                End If
            End If
        End If
        If BlankNew Then

            Dim NewName As String = "NewProject"

            BeingUsed = True
            Dim SessionName As String = String.Empty
            For Looper As Byte = 0 To 10
                SessionName = NewName + MakeSessionName()
                If Not IO.Directory.Exists(AppPath + "ProjectTemp\" + SessionName) Then Exit For
            Next
            FormSession(SessionName)
            FormSessionFS()
            IsNewProject = True
            ProjectPath = AppPath + "NewProjects\" + SessionName + ".dsgm"
            Text = TitleDataWorks()

            Dim DW As UInt16 = Convert.ToUInt16(GetOption("DEFAULT_ROOM_WIDTH"))
            Dim DH As UInt16 = Convert.ToUInt16(GetOption("DEFAULT_ROOM_HEIGHT"))
            If DW < 256 Then DW = 256
            If DW > 4096 Then DW = 4096
            If DW < 192 Then DW = 192
            If DH > 4096 Then DH = 4096
            CurrentXDS += "BOOTROOM Room_1" + vbCrLf
            CurrentXDS += "SCORE 0" + vbCrLf
            CurrentXDS += "LIVES 3" + vbCrLf
            CurrentXDS += "HEALTH 100" + vbCrLf
            CurrentXDS += "PROJECTNAME " + NewName + vbCrLf
            CurrentXDS += "TEXT2 " + vbCrLf
            CurrentXDS += "TEXT3 " + vbCrLf
            CurrentXDS += "FAT_CALL 0" + vbCrLf
            CurrentXDS += "NITROFS_CALL 1" + vbCrLf
            CurrentXDS += "MIDPOINT_COLLISIONS 0" + vbCrLf
            CurrentXDS += "INCLUDE_WIFI_LIB 0" + vbCrLf

            RedoAllGraphics = True
            RedoSprites = True
            BGsToRedo.Clear()
            ToggleShowWindow()
            AddObject("Object_1")
            AddRoom("Room_1")
            ToggleShowWindow()
            InternalSave()

        End If
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If BeingUsed Then
            Dim WillExit As Boolean = False
            Dim TheText As String = "Your new project"
            If Not IsNewProject Then
                TheText = "'" + CacheProjectName + "'"
            End If
            Dim Result As Integer = MessageBox.Show(TheText + " may have unsaved changes." + vbcrlf + vbcrlf + "Do you want to save just in case?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            If Result = MsgBoxResult.Yes Then : SaveButton_Click(New Object, New System.EventArgs) : WillExit = True
            ElseIf Result = MsgBoxResult.No Then : e.Cancel = False : WillExit = True
            ElseIf Result = MsgBoxResult.Cancel Then : e.Cancel = True
            End If
            Try
                If WillExit Then
                    Directory.Delete(SessionPath, True)
                    Directory.Delete(CompilePath, True)
                    If IsNewProject Then IO.File.Delete(AppPath + "NewProjects\" + Session + ".dsgm")
                End If
            Catch : End Try
        End If
    End Sub

    Private Sub NewProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewProjectButton.Click, NewProjectButtonTool.Click
        Shell(AppPath + ProductName + ".exe /skipauto")
    End Sub

    Public Sub InternalSave()
        CleanInternalXDS()
        SaveButton.Enabled = False
        SaveButtonTool.Enabled = False
        IO.File.WriteAllText(SessionPath + "XDS.xds", CurrentXDS)
        Dim MyBAT As String = "zip.exe a save.zip Sprites Backgrounds Sounds Scripts IncludeFiles NitroFSFiles XDS.xds" + vbcrlf + "exit"
        RunBatchString(MyBAT, SessionPath, True)
        'File.Delete(ProjectPath)
        File.Copy(SessionPath + "save.zip", ProjectPath, True)
        File.Delete(SessionPath + "save.bat")
        File.Delete(SessionPath + "save.zip")
        SaveButton.Enabled = True
        SaveButtonTool.Enabled = True
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click, SaveButtonTool.Click
        'If it's a new project, call Save As instead.
        If IsNewProject Then
            SaveAsButton_Click(New Object, New System.EventArgs)
            Exit Sub
        End If
        InternalSave()
        IsNewProject = False
    End Sub

    Private Sub AddSpriteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddSpriteButton.Click, AddSpriteButtonTool.Click
        Dim NewName As String = MakeResourceName("Sprite", "SPRITE")
        AddSprite(NewName)
    End Sub

    Private Sub AddObjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddObjectButton.Click, AddObjectButtonTool.Click
        Dim NewName As String = MakeResourceName("Object", "OBJECT")
        AddObject(NewName)
    End Sub

    Private Sub AddBackgroundButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBackgroundButton.Click, AddBackgroundButtonTool.Click
        Dim NewName As String = MakeResourceName("Background", "BACKGROUND")
        AddBackground(NewName)
    End Sub

    Private Sub AddSoundButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddSoundButton.Click, AddSoundButtonTool.Click
        Dim NewName As String = MakeResourceName("Sound", "SOUND")
        AddSound(NewName)
    End Sub

    Private Sub AddRoomButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddRoomButton.Click, AddRoomButtonTool.Click
        Dim NewName As String = MakeResourceName("Room", "ROOM")
        AddRoom(NewName)
    End Sub

    Private Sub AddScriptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddScriptButton.click, AddScriptButtonTool.Click
        Dim NewName As String = MakeResourceName("Script", "SCRIPT")
        AddScript(NewName, True)
    End Sub

    Public Function OpenWarn() As Boolean
        Dim TheText As String = "'" + CacheProjectName + "'"
        If IsNewProject Then TheText = "your new Project"
        Dim Answer As Byte = MessageBox.Show("Are you sure you want to open another Project?" + vbcrlf + vbcrlf + "You will lose any changes you have made to " + TheText + ".", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Answer = MsgBoxResult.Yes Then Return True Else Return False
    End Function

    Private Sub OpenProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenProjectButton.Click, OpenProjectButtonTool.Click
        If BeingUsed Then : If Not OpenWarn() Then : Exit Sub : End If : End If
        Dim Result As String = OpenFile(String.Empty, Application.ProductName + " Projects|*.dsgm")
        If Result.Length = 0 Then Exit Sub
        OpenProject(Result)
    End Sub

    Sub LoadLastProject(ByVal Automatic As Boolean)
        'IsNewProject = False
        Dim LastPath As String = GetOption("LAST_PROJECT")
        If Automatic Then
            If File.Exists(LastPath) Then
                OpenProject(LastPath)
            End If
            Exit Sub
        End If
        If BeingUsed Then
            If LastPath = ProjectPath Then
                'Same Project - Reload job
                Dim Result As Byte = MessageBox.Show("Do you want to reload the current Project?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If Result = MsgBoxResult.Yes Then
                    CleanFresh()
                    OpenProject(ProjectPath)
                    Exit Sub
                End If

            Else
                'Loading a different project
                If Not OpenWarn() Then Exit Sub
                'Yes load a new file
                If File.Exists(LastPath) Then
                    OpenProject(LastPath)
                    Exit Sub
                Else
                    OpenProjectButton_Click(New Object, New System.EventArgs)
                End If
            End If
        Else
            'Fresh session
            If File.Exists(LastPath) Then
                OpenProject(LastPath)
            Else
                OpenProjectButton_Click(New Object, New System.EventArgs)
            End If
        End If
    End Sub

    Private Sub OpenLastProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenLastProjectButton.Click, OpenLastProjectButtonTool.Click
        LoadLastProject(False)
    End Sub

    Private Sub SaveAsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsButton.Click, SaveAsButtonTool.Click
        Dim Directory As String = ProjectPath
        Directory = Directory.Substring(0, Directory.IndexOf("\"))
        Dim Result As String = String.Empty
        If IsNewProject Then
            Result = SaveFile(Directory, Application.ProductName + " Projects|*.dsgm", "New Project.dsgm")
        Else
            Result = SaveFile(Directory, Application.ProductName + " Projects|*.dsgm", CacheProjectName + ".dsgm")
        End If
        If Result.Length = 0 Then Exit Sub
        CleanInternalXDS()
        SaveButton.Enabled = False
        SaveButtonTool.Enabled = False
        IO.File.WriteAllText(SessionPath + "XDS.xds", CurrentXDS)
        Dim MyBAT As String = "zip.exe a save.zip Sprites Backgrounds Sounds Scripts IncludeFiles NitroFSFiles XDS.xds" + vbcrlf + "exit"
        RunBatchString(MyBAT, SessionPath, True)
        'File.Delete(ProjectPath)
        ProjectPath = Result
        File.Copy(SessionPath + "save.zip", ProjectPath, True)
        File.Delete(SessionPath + "save.bat")
        File.Delete(SessionPath + "save.zip")
        SaveButton.Enabled = True
        SaveButtonTool.Enabled = True
        IsNewProject = False
        Me.Text = TitleDataWorks()
    End Sub

    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        MainForm_FormClosing(New Object, New FormClosingEventArgs(CloseReason.ApplicationExitCall, False))
    End Sub

    Private Sub OptionsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsButton.Click, OptionsButtonTool.Click
        Options.ShowDialog()
    End Sub

    Private Sub ResourcesTreeView_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles ResourcesTreeView.NodeMouseDoubleClick
        If Not e.Node.Parent Is Nothing Then
            OpenResource(e.Node.Text, e.Node.Parent.Index, False)
        End If
    End Sub

    Private Sub GameSettingsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GameSettingsButton.Click, GameSettingsButtonTool.Click
        GameSettings.ShowDialog()
    End Sub

    Private Sub TestGameButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestGameButton.Click, TestGameButtonTool.Click
        If Not CompileWrapper() Then Exit Sub
        With Compile
            .HasDoneIt = False
            .ShowDialog()
            If .Success Then
                NOGBAShizzle()
            Else
                CompileFail()
            End If
        End With
    End Sub

    Private Sub CompileGameButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompileGameButton.Click, CompileGameButtonTool.Click
        If Not CompileWrapper() Then Exit Sub
        Compile.HasDoneIt = False
        Compile.ShowDialog()
        If Compile.Success Then
            With Compiled
                .Text = CacheProjectName
                .MainLabel.Text = CacheProjectName
                .SubLabel.Text = "Compiled by " + Environment.UserName + " at " + GetTime()
                .ShowDialog()
            End With
        Else
            CompileFail()
        End If
    End Sub

    Private Sub ActionEditorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionEditorButton.Click
        For Each X As Form In MdiChildren
            If X.Text = "Action Editor" Then X.Focus() : Exit Sub
        Next
        'Dim ActionForm As New ActionEditor
        ShowInternalForm(ActionEditor)
    End Sub

    Private Sub VariableManagerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlobalVariablesButton.Click, GlobalVariablesButtonTool.Click
        GlobalVariables.ShowDialog()
    End Sub

    Sub ActuallyCleanUp()
        For Each X As String In Directory.GetDirectories(CDrive)
            If X = CompilePath.Substring(0, CompilePath.Length - 1) Then Continue For
            Try
                If X.StartsWith(CDrive + "DSGMTemp") Then Directory.Delete(X, True)
            Catch : End Try
        Next
        For Each X As String In Directory.GetDirectories(AppPath + "ProjectTemp")
            If X = SessionPath.Substring(0, SessionPath.Length - 1) Then Continue For
            Try
                Directory.Delete(X, True)
            Catch : End Try
        Next
        'For Each X As String In Directory.GetFiles(AppPath + "NewProjects")
        '    If X.EndsWith(CacheProjectName + ".dsgm") Then Continue For
        '    File.Delete(X)
        'Next
    End Sub

    Private Sub CleanUpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CleanUpButton.Click
        'If ProjectPath.Length > 0 Then MsgError("You have a project loaded, so temporary data may not be cleared.") : Exit Sub
        MsgWarn("This will clean up all unused data created by the sessions system." + vbcrlf + vbcrlf + "Ensure you do not have other instances of the application open.")
        ActuallyCleanUp()
        MsgInfo("The process completed successfully.")
    End Sub

    Private Sub ProjectStatisticsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Statistics.ShowDialog()
    End Sub

    Private Sub OpenCompileTempButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenCompileTempButton.Click
        System.Diagnostics.Process.Start("explorer", CompilePath)
    End Sub

    Private Sub OpenProjectTempButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenProjectTempButton.Click
        System.Diagnostics.Process.Start("explorer", SessionPath)
    End Sub

    Private Sub WebsiteButton_Click() Handles WebsiteButton.Click
        URL(Domain)
    End Sub

    Private Sub ForumButton_Click() Handles ForumButton.Click
        URL(Domain + "dsgmforum")
    End Sub

    Private Sub EditInternalXDSButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditInternalXDSButton.Click
        If MdiChildren.Count > 0 Then MsgWarn("You must close all open windows to continue.") : Exit Sub
        Dim Thing As New EditCode
        With Thing
            .CodeMode = CodeMode.XDS
            .ImportExport = False
            .ReturnableCode = CurrentXDS
            .StartPosition = FormStartPosition.CenterParent
            .Text = "Edit Internal XDS"
            .ShowDialog()
            CurrentXDS = .MainTextBox.Text
        End With
    End Sub

    Private Sub FontViewerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontViewerButton.Click
        For Each X As Form In MdiChildren
            If X.Text = "Font Viewer" Then X.Focus() : Exit Sub
        Next
        'Dim ActionForm As New ActionEditor
        ShowInternalForm(FontViewer)
        'FontEditor.ShowDialog()
    End Sub

    Private Sub GlobalArraysButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlobalArraysButton.Click, GlobalArraysButtonTool.Click
        GlobalArrays.ShowDialog()
    End Sub

    Private Sub AboutDSGMButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutDSGMButton.Click
        AboutDSGM.ShowDialog()
    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        DeleteResource(ActiveMdiChild.Text, ActiveMdiChild.Name)
    End Sub

    Private Sub TutorialsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnlineTutorialsButton.Click
        URL(Domain + "dsgmforum/viewforum.php?f=6")
    End Sub

    Private Sub GlobalStructuresButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlobalStructuresButton.Click, GlobalStructuresButtonTool.Click
        GlobalStructures.ShowDialog()
    End Sub

    Private Sub ReinstallToolchainAndPAlibButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReinstallToolchainAndPAlibButton.Click
        RundevkitProUpdater()
    End Sub

    Private Sub EditMenu_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMenu.DropDownOpening
        GoToLastFoundButton.Enabled = False
        If LastResourceFound.Length > 0 Then GoToLastFoundButton.Enabled = True
        Dim OuiOui As Boolean = Not (ActiveMdiChild Is Nothing)
        DeleteButton.Enabled = OuiOui
        DuplicateButton.Enabled = OuiOui
    End Sub

    Private Sub CompileChangeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GraphicsChangeButton.Click, SoundChangeButton.Click
        Select Case DirectCast(sender, ToolStripMenuItem).Name
            Case "GraphicsChangeButton"
                RedoAllGraphics = True
                RedoSprites = True
                BGsToRedo.Clear()
            Case "SoundChangeButton"
                BuildSoundsRedoFromFile()
        End Select
    End Sub

    Private Sub RunNOGBAButton_Click() Handles RunNOGBAButton.Click
        Diagnostics.Process.Start(FormNOGBAPath() + "\NO$GBA.exe")
    End Sub

    Private Sub ResRightClickMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ResRightClickMenu.Opening
        Dim ToWorkFrom As TreeNode
        Try
            ToWorkFrom = ResourcesTreeView.SelectedNode.Parent
            DeleteResourceRightClickButton.Enabled = True
            OpenResourceRightClickButton.Enabled = True
            DuplicateResourceRightClickButton.Enabled = True
            If ToWorkFrom.Text = String.Empty Then Exit Try
        Catch ex As Exception
            ToWorkFrom = ResourcesTreeView.SelectedNode
            DeleteResourceRightClickButton.Enabled = False
            OpenResourceRightClickButton.Enabled = False
            DuplicateResourceRightClickButton.Enabled = False
        End Try
        With AddResourceRightClickButton
            .Image = My.Resources.PlusIcon
            Select Case ToWorkFrom.Text.Substring(0, ToWorkFrom.Text.Length - 1)
                Case "Sprite" : .Image = AddSpriteButton.Image
                Case "Background" : .Image = AddBackgroundButton.Image
                Case "Script" : .Image = AddScriptButton.Image
                Case "Room" : .Image = AddRoomButton.Image
                Case "Object" : .Image = AddObjectButton.Image
                Case "Sound" : .Image = AddSoundButton.Image
            End Select
            .Text = "Add " + ToWorkFrom.Text.Substring(0, ToWorkFrom.Text.Length - 1)
        End With
    End Sub

    Private Sub ResourcesTreeView_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles ResourcesTreeView.NodeMouseClick
        ResourcesTreeView.SelectedNode = e.Node
    End Sub

    Private Sub DeleteResourceRightClickButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteResourceRightClickButton.Click
        Dim Type As String = ResourcesTreeView.SelectedNode.Parent.Text.Substring(0, ResourcesTreeView.SelectedNode.Parent.Text.Length - 1)
        If Type = "Object" Then Type = "DObject"
        Type = Type.Replace(" ", String.Empty)
        DeleteResource(ResourcesTreeView.SelectedNode.Text, Type)
    End Sub

    Private Sub OpenResourceRightClickButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenResourceRightClickButton.Click
        OpenResource(ResourcesTreeView.SelectedNode.Text, ResourcesTreeView.SelectedNode.Parent.Index, False)
    End Sub

    Private Sub AddResourceRightClickButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddResourceRightClickButton.Click
        Dim TheText As String = AddResourceRightClickButton.Text.Substring(4)
        Select Case TheText
            Case "Sprite" : AddSpriteButton_Click(New Object, New System.EventArgs)
            Case "Background" : AddBackgroundButton_Click(New Object, New System.EventArgs)
            Case "Object" : AddObjectButton_Click(New Object, New System.EventArgs)
            Case "Sound" : AddSoundButton_Click(New Object, New System.EventArgs)
            Case "Room" : AddRoomButton_Click(New Object, New System.EventArgs)
            Case "Script" : AddScriptButton_Click(New Object, New System.EventArgs)
        End Select
    End Sub

    Private Sub DuplicateResourceRightClickButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DuplicateResourceRightClickButton.Click
        Dim TheName As String = ResourcesTreeView.SelectedNode.Text
        CopyResource(TheName, GenerateDuplicateResourceName(TheName), ResourcesTreeView.SelectedNode.Parent.Index)
    End Sub

    Private Sub FindResourceButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindResourceButton.Click
        Dim Result As String = GetInput("Which resource are you looking for?", LastResourceFound, ValidateLevel.None)
        FindResource(Result)
    End Sub

    Private Sub GoToLastFoundButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoToLastFoundButton.Click
        FindResource(LastResourceFound)
    End Sub

    Private Sub FindInScriptsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindInScriptsButton.Click
        Dim Result As String = GetInput("Search term:", LastScriptTermFound, ValidateLevel.None)
        Dim Shower As New FoundInScripts
        With Shower
            .Term = Result
            .Text = "Searching Scripts for '" + Result + "'"
        End With
        ShowInternalForm(Shower)
    End Sub

    Private Sub DuplicateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DuplicateButton.Click
        If ActiveMdiChild Is Nothing Then Exit Sub
        Dim TheName As String = ActiveMdiChild.Text
        Dim ResT As Byte = 0
        Select Case ActiveMdiChild.Name
            Case "Sprite"
                ResT = ResourceIDs.Sprite
            Case "DObject"
                ResT = ResourceIDs.DObject
            Case "Background"
                ResT = ResourceIDs.Background
            Case "Sound"
                ResT = ResourceIDs.Sound
            Case "Room"
                ResT = ResourceIDs.Room
            Case "Script"
                ResT = ResourceIDs.Script
        End Select
        CopyResource(TheName, GenerateDuplicateResourceName(TheName), ResT)
    End Sub

    Private Sub WriteOriginalMakefileButton_Click(sender As System.Object, e As System.EventArgs) Handles WriteOriginalMakefileButton.Click
        ReplaceMakefile("Original_Makefile")
    End Sub

    Private Sub Write512MakefileButton_Click(sender As System.Object, e As System.EventArgs) Handles Write512MakefileButton.Click
        ReplaceMakefile("512_Makefile")
    End Sub

    Private Sub WriteCurrentMakefileButton_Click(sender As System.Object, e As System.EventArgs) Handles WriteCurrentMakefileButton.Click
        ReplaceMakefile("Current_Makefile")
    End Sub

End Class
