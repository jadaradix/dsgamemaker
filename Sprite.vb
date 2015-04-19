Imports System.IO
Public Class Sprite

    Public SpriteName As String
    Dim TheLine As String
    Dim TimesChanged As Int16 = 0
    Public DataChanged As Boolean = False

    Private Sub Sprite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainToolStrip.Renderer = New clsToolstripRenderer
        Me.Text = SpriteName
        NameTextBox.Text = SpriteName
        TheLine = GetXDSLine("SPRITE " + SpriteName + ",")
        Dim ImageCount As Int16 = 0
        MainImageList.Images.Clear()
        For Each X As String In Directory.GetFiles(SessionPath + "Sprites")
            Dim Y As String = X
            X = X.Substring(X.LastIndexOf("\") + 1)
            X = X.Substring(0, X.LastIndexOf("."))
            X = X.Substring(X.IndexOf("_") + 1)
            If X = SpriteName Then
                If ImageCount = 0 Then
                    'First image! Grab the size....
                    MainImageList.ImageSize = PathToImage(Y).Size
                End If
                ImageCount += 1
            End If
        Next
        For X As Int16 = 0 To ImageCount - 1
            Dim ThePath As String = SessionPath + "Sprites\" + X.ToString + "_" + SpriteName + ".png"
            Dim Key As String = "Frame_" + X.ToString
            MainImageList.Images.Add(Key, PathToImage(ThePath))
            MainListView.Items.Add("Frame " + X.ToString, X)
        Next
    End Sub

    Private Sub PreviewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviewButton.Click
        If FPSTextBox.Text.Length = 0 Then
            MsgWarn("Please enter a Speed.") : Exit Sub
        End If
        Dim CanProceed As Boolean = False
        If FPSTextBox.Text.Length = 2 Then
            Dim Okay1 As Boolean = False
            Dim Okay2 As Boolean = False
            For Each X In Numbers
                If FPSTextBox.Text.Substring(0, 1) = X Then Okay1 = True
                If FPSTextBox.Text.Substring(1) = X Then Okay2 = True
            Next
            If Okay1 And Okay2 Then CanProceed = True
        ElseIf FPSTextBox.Text.Length = 1 Then
            For Each X As String In Numbers
                If FPSTextBox.Text = X Then CanProceed = True : Exit For
            Next
        End If
        If Convert.ToByte(FPSTextBox.Text) > 60 Then CanProceed = False
        If Not CanProceed Then
            MsgError("You must enter a valid value for FPS between 1 and 60.")
            Exit Sub
        End If
        Preview.ImageSize = MainImageList.ImageSize
        Preview.Speed = Convert.ToByte(FPSTextBox.Text)
        Preview.TheImage = GenerateDSSprite(SpriteName)
        Preview.ShowDialog()
    End Sub

    Function IsSpriteSizeOkay(ByVal TheSize As Size) As Boolean
        Dim TW As Int16 = TheSize.Width
        Dim TH As Int16 = TheSize.Height
        Dim Alright As Boolean = False
        If (Not TW = 64) And (Not TW = 32) And (Not TW = 16) And (Not TW = 8) Then Return False
        If (Not TH = 64) And (Not TH = 32) And (Not TH = 16) And (Not TW = 8) Then Return False
        If TW = 64 And TH = 8 Then Return False
        If TW = 64 And TH = 16 Then Return False
        If TW = 8 And TH = 64 Then Return False
        If TW = 16 And TH = 64 Then Return False
        Return True
    End Function

    Private Sub LoadFrameButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadFrameButton.Click
        If MainListView.SelectedIndices.Count = 0 Then
            MsgWarn("You must select a Frame into which to copy an existing image file.")
            Exit Sub
        End If
        Dim Result As String = OpenFile(String.Empty, ImageFilter)
        If Result.Length = 0 Then Exit Sub
        Dim NIS As Size = PathToImage(Result).Size
        If Not IsSpriteSizeOkay(NIS) Then
            BadSpriteSize.ShowDialog()
            Exit Sub
        End If
        Dim CW As Int16 = MainImageList.ImageSize.Width
        Dim CH As Int16 = MainImageList.ImageSize.Height
        If NIS.Width = CW And NIS.Height = CH Then
            MainImageList.Images.Item(MainListView.SelectedIndices(0)) = GetMagentaedBMP(Result)
            DataChanged = True
            Exit Sub
        End If
        If NIS.Width > CW Or NIS.Height > CH Then
            MainImageList.ImageSize = NIS
            MainImageList.Images.Item(MainListView.SelectedIndices(0)) = GetMagentaedBMP(Result)
            DataChanged = True
            Exit Sub
        End If
        If NIS.Width < CW Or NIS.Height < CH Then
            Dim NewImage As New Bitmap(NIS.Width, NIS.Height)
            Dim NewImageGFX As Graphics = Graphics.FromImage(NewImage)
            NewImageGFX.Clear(Color.Magenta)
            NewImageGFX.DrawImage(GetMagentaedBMP(Result), New Point(0, 0))
            NewImageGFX.Dispose()
            MainImageList.Images.Item(MainListView.SelectedIndices(0)) = NewImage
        End If
        DataChanged = True
    End Sub

    Private Sub AddBlankFrameButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBlankFrameButton.Click
        Dim TheKey As String = "Frame_" + MainImageList.Images.Count.ToString
        Dim Newun As New Bitmap(MainImageList.ImageSize.Width, MainImageList.ImageSize.Height)
        Dim NewunGFX As Graphics = Graphics.FromImage(Newun)
        NewunGFX.Clear(Color.Magenta)
        MainImageList.Images.Add(TheKey, Newun)
        NewunGFX.Dispose()
        Newun.Dispose()
        MainListView.Items.Add(TheKey.Replace("_", " "), MainImageList.Images.Count - 1)
        DataChanged = True
    End Sub

    Private Sub AddFrameFromFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddFrameFromFileButton.Click
        Dim Response As String = OpenFile(String.Empty, ImageFilter)
        If Response.Length = 0 Then Exit Sub
        Dim TheKey As String = "Frame_" + MainImageList.Images.Count.ToString
        Dim NIS As Size = PathToImage(Response).Size
        Dim CW As Int16 = MainImageList.ImageSize.Width
        Dim CH As Int16 = MainImageList.ImageSize.Height
        If NIS.Width = CW And NIS.Height = CH Then
            MainImageList.Images.Add(TheKey, GetMagentaedBMP(Response))
            MainListView.Items.Add(TheKey.Replace("_", " "), MainImageList.Images.Count - 1)
            DataChanged = True
            Exit Sub
        End If
        If NIS.Width > CW Or NIS.Height > CH Then
            MainImageList.ImageSize = NIS
            MainImageList.Images.Add(TheKey, GetMagentaedBMP(Response))
            MainListView.Items.Add(TheKey.Replace("_", " "), MainImageList.Images.Count - 1)
            DataChanged = True
            Exit Sub
        End If
        If NIS.Width < CW Or NIS.Height < CH Then
            Dim NewImage As New Bitmap(NIS.Width, NIS.Height)
            Dim NewImageGFX As Graphics = Graphics.FromImage(NewImage)
            NewImageGFX.Clear(Color.Magenta)
            NewImageGFX.DrawImage(GetMagentaedBMP(Response), New Point(0, 0))
            NewImageGFX.Dispose()
            MainImageList.Images.Add(TheKey, NewImage)
            MainListView.Items.Add(TheKey.Replace("_", " "), MainImageList.Images.Count - 1)
        End If
        DataChanged = True
    End Sub

    Private Sub EditFrameButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditFrameButton.Click
        If MainListView.SelectedIndices.Count = 0 Then Exit Sub
        If MainListView.SelectedIndices.Count > 1 Then
            MsgWarn("You may only edit one Frame at once.") : Exit Sub
        End If
        Dim ID As Int16 = MainListView.SelectedIndices(0)
        Dim CopyPath As String = SessionPath + "Sprite_Edit.png"
        MainImageList.Images(ID).Save(SessionPath + "Sprite_Edit.png")
        If EditImage(CopyPath, SpriteName, False) Then
            MainImageList.Images.Item(ID) = PathToImage(CopyPath)
            IO.File.Delete(CopyPath)
            DataChanged = True
        End If
    End Sub

    Private Sub DeleteFrameButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteFrameButton.Click
        If MainListView.SelectedIndices.Count = 0 Then Exit Sub
        If MainListView.Items.Count = 1 Then MsgWarn("A Sprite must have at least one Frame.") : Exit Sub
        If MainListView.Items.Count = MainListView.SelectedIndices.Count Then MsgWarn("You cannot delete all of the Frames at once: at least one frame must remain.") : Exit Sub
        Dim ID As Int16 = MainListView.SelectedIndices(0)
        'For Each ID As Byte In MainListView.SelectedIndices
        '    IO.File.Delete(SessionPath + "Sprites\" + ID.ToString + "_" + SpriteName + ".png")
        'Next
        'Directory.CreateDirectory(SessionPath + "Sprites\" + SpriteName)
        'For Each X As String In Directory.GetFiles(SessionPath + "Sprites")
        '    Dim Backup As String = X
        '    X = X.Substring(X.LastIndexOf("\") + 1)
        '    X = X.Substring(0, X.LastIndexOf("."))
        '    Dim ID As Byte = Convert.ToByte(X.Substring(0, X.IndexOf("_")))
        '    X = X.Substring(X.IndexOf("_") + 1)
        '    If X = SpriteName Then
        '        File.Move(Backup, SessionPath + "Sprites\" + SpriteName + "\" + ID.ToString + ".png")
        '    End If
        'Next
        'Dim DOn As Byte = 0
        'For Each X As String In Directory.GetFiles(SessionPath + "Sprites\" + SpriteName)
        '    IO.File.Move(X, SessionPath + "Sprites\" + DOn.ToString + "_" + SpriteName + ".png")
        '    DOn += 1
        'Next
        'Directory.Delete(SessionPath + "Sprites\" + SpriteName)
        'SyncImages()
        MainImageList.Images.RemoveAt(ID)
        MainListView.Items.RemoveAt(ID)
        For i As Int16 = 0 To MainListView.Items.Count - 1
            MainListView.Items(i).ImageIndex = i
        Next
        DataChanged = True
    End Sub

    Private Sub ExportDSSpriteStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportDSSpriteStripButton.Click
        Dim ToSave As Image = GenerateDSSprite(SpriteName)
        Dim Response As String = SaveFile(String.Empty, ImageFilter, SpriteName + "_DS")
        If Response.Length = 0 Then Exit Sub
        ToSave.Save(Response)
        ToSave.Dispose()
    End Sub

    Private Sub PasteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteButton.Click
        Try
            Dim TheKey As String = "Frame_" + MainImageList.Images.Count.ToString
            MainImageList.Images.Add(TheKey, Clipboard.GetImage())
            MainListView.Items.Add(TheKey.Replace("_", " "), MainImageList.Images.Count - 1)
            DataChanged = True
        Catch ex As Exception
            MsgWarn("There is no image on the clipboard." + vbcrlf + vbcrlf + "(" + ex.Message + ")")
        End Try
    End Sub

    Private Sub CopyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyButton.Click
        If MainListView.SelectedIndices.Count = 0 Then MsgWarn("You must select a Frame to Copy.") : Exit Sub
        If MainListView.SelectedIndices.Count > 1 Then MsgWarn("You may only copy on Frame at a time.") : Exit Sub
        Clipboard.SetImage(MainImageList.Images(MainListView.SelectedIndices(0)))
    End Sub

    Private Sub CutButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutButton.Click
        If MainListView.SelectedIndices.Count = 0 Then MsgWarn("You must select a Frame to Copy.") : Exit Sub
        If MainListView.SelectedIndices.Count > 1 Then MsgWarn("You may only copy on Frame at a time.") : Exit Sub
        Clipboard.SetImage(MainImageList.Images(MainListView.SelectedIndices(0)))
        DeleteFrameButton_Click(New Object, New System.EventArgs)
    End Sub

    Private Sub TransformButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransformButton.Click
        If MainListView.SelectedIndices.Count = 0 Then
            For X As Int16 = 0 To MainListView.Items.Count - 1
                MainListView.SelectedIndices.Add(X)
            Next
            'MsgWarn("You must select a Frame to Transform.") : Exit Sub
        End If
        TransformSprite.Text = "Transform " + MainListView.SelectedIndices.Count.ToString + " Frame"
        TransformSprite.Text += If(MainListView.SelectedIndices.Count > 1, "s", String.Empty)
        'TransformSprite.MainTabControl.TabPages(0).Text += If(MainListView.SelectedIndices.Count > 1, "s", String.Empty)
        TransformSprite.ImagePaths.Clear()
        For Each X As Byte In MainListView.SelectedIndices
            TransformSprite.ImagePaths.Add(SessionPath + "Sprites\" + X.ToString + "_" + SpriteName + ".png")
        Next
        TransformSprite.ShowDialog()
        DataChanged = True
    End Sub

    Private Sub FromSheetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FromSheetButton.Click
        Dim MSResponse As Byte = MessageBox.Show("Importing from a Sheet will remove all existing frames." + vbcrlf + vbcrlf + "Would you like to Continue?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Not MSResponse = MsgBoxResult.Yes Then Exit Sub
        Dim Response As String = OpenFile(String.Empty, ImageFilter)
        If Response.Length = 0 Then Exit Sub
        Dim ThePath As String = SessionPath + "Sprites\" + SpriteName + "_Import"
        Directory.CreateDirectory(ThePath)
        ImportSprite.FileName = Response
        ImportSprite.ToDirectory = ThePath
        ImportSprite.ShowDialog()
        If ImportSprite.ImportedCount = 0 Then Exit Sub
        'For Each X As String In Directory.GetFiles(SessionPath + "Sprites")
        '    Dim Backup As String = X
        '    X = X.Substring(X.LastIndexOf("\") + 1)
        '    X = X.Substring(0, X.LastIndexOf("."))
        '    X = X.Substring(X.IndexOf("_") + 1)
        '    If X = SpriteName Then File.Delete(Backup)
        'Next
        Dim ImageCount As Int16 = 0
        MainImageList.Images.Clear()
        MainListView.Items.Clear()
        For Each X As String In Directory.GetFiles(ThePath)
            If ImageCount = 0 Then MainImageList.ImageSize = PathToImage(X).Size
            ImageCount += 1
        Next
        TimesChanged = 0
        For X As Int16 = 0 To ImageCount - 1
            Dim TheKey As String = "Frame_" + MainImageList.Images.Count.ToString
            MainImageList.Images.Add(TheKey, PathToImage(ThePath + "\" + X.ToString + ".png"))
            MainListView.Items.Add(TheKey.Replace("_", " "), MainImageList.Images.Count - 1)
            File.Delete(ThePath + "\" + X.ToString + ".png")
            'File.Move(ThePath + "\" + X.ToString + ".png", SessionPath + "Sprites\" + X.ToString + "_" + SpriteName + ".png")
        Next
        Directory.Delete(ThePath)
        DataChanged = True
    End Sub

    'Private Sub Droppers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If TimesChanged < 2 Then TimesChanged += 1 : Exit Sub
    '    Dim NewWidth As Byte = Convert.ToByte(WidthDropper.Text)
    '    Dim NewHeight As Byte = Convert.ToByte(HeightDropper.Text)
    '    If NewWidth < CurrentSize.Width Or NewHeight < CurrentSize.Height Then
    '        Dim Message As String = "You are about to reduce the size of the Sprite. This will permamently remove image data." + vbcrlf + vbcrlf + "Would you like to continue?"
    '        Dim Response As Byte = MessageBox.Show(Message, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
    '        If Not Response = MsgBoxResult.Yes Then Exit Sub
    '    End If
    '    Dim ImageCount As Int16 = 0
    '    Dim ThePath As String = SessionPath + "Sprites\"
    '    For Each X As String In Directory.GetFiles(ThePath)
    '        X = X.Substring(X.LastIndexOf("\") + 1)
    '        X = X.Substring(0, X.LastIndexOf("."))
    '        X = X.Substring(X.IndexOf("_") + 1)
    '        If X = SpriteName Then ImageCount += 1
    '    Next
    '    For X As Int16 = 0 To ImageCount - 1
    '        Dim Canvas As New Bitmap(NewWidth, NewHeight)
    '        Dim CanvasGFX As Graphics = Graphics.FromImage(Canvas)
    '        CanvasGFX.Clear(Color.Magenta)
    '        CanvasGFX.DrawImage(PathToImage(ThePath + X.ToString + "_" + SpriteName + ".png"), New Point(0, 0))
    '        CanvasGFX.Dispose()
    '        Canvas.Save(ThePath + X.ToString + "_" + SpriteName + ".png")
    '    Next
    '    CurrentSize.Width = Convert.ToInt16(WidthDropper.Text)
    '    CurrentSize.Height = Convert.ToInt16(HeightDropper.Text)
    '    SyncImages()
    '    DataChanged = True
    'End Sub

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        Dim NewName As String = NameTextBox.Text
        If NewName = "None" Then MsgWarn("'None' is not a valid name.") : Exit Sub
        If Not SpriteName = NewName Then
            If GUIResNameChecker(NewName) Then Exit Sub
            If File.Exists(CompilePath + "gfx\" + SpriteName + ".png") Then
                SilentMoveFile(CompilePath + "gfx\" + SpriteName + ".png", CompilePath + "gfx\" + NewName + ".png")
            End If
            If File.Exists(CompilePath + "gfx\bin\" + SpriteName + "_Sprite.bin") Then
                SilentMoveFile(CompilePath + "gfx\bin\" + SpriteName + "_Sprite.bin", CompilePath + "gfx\bin\" + NewName + "_Sprite.bin")
            End If
            Dim BackupDate As Date = File.GetLastWriteTime(CompilePath + "gfx\dsgm_gfx.h")
            Dim FinalString As String = String.Empty
            Dim ToAdd As String = String.Empty
            For Each X As String In StringToLines(PathToString(CompilePath + "gfx\dsgm_gfx.h"))
                ToAdd = X
                If X.Contains(" char " + SpriteName + "_Sprite[") Then
                    ToAdd = X.Replace(" char " + SpriteName + "_Sprite[", " char " + NewName + "_Sprite[")
                End If
                FinalString += ToAdd + vbcrlf
            Next
            File.WriteAllText(CompilePath + "gfx\dsgm_gfx.h", FinalString)
            File.SetLastWriteTime(CompilePath + "gfx\dsgm_gfx.h", BackupDate)
        End If
        If File.Exists(CompilePath + "build\" + SpriteName + "_Sprite.h") Then
            File.Delete(CompilePath + "build\" + SpriteName + "_Sprite.h")
        End If
        If File.Exists(CompilePath + "build\" + SpriteName + "_Sprite.o") Then
            File.Delete(CompilePath + "build\" + SpriteName + "_Sprite.o")
        End If
        Dim OldLine As String = GetXDSLine("SPRITE " + SpriteName + ",")
        Dim NewLine As String = "SPRITE " + NewName + "," + MainImageList.ImageSize.Width.ToString + "," + MainImageList.ImageSize.Height.ToString
        XDSChangeLine(OldLine, NewLine)
        Dim AffectedObjects As New List(Of String)
        For Each X As String In GetXDSFilter("OBJECT ")
            If iGet(X, 1, ",") = SpriteName Then AffectedObjects.Add(iGet(X.Substring(7), 0, ","))
        Next
        For Each X As String In GetXDSFilter("OBJECT ")
            If Not iGet(X, 1, ",") = SpriteName Then Continue For
            Dim ObjectName As String = iGet(X.Substring(7), 0, ",")
            Dim ObjectFrame As String = iGet(X.Substring(7), 2, ",")
            XDSChangeLine(X, "OBJECT " + ObjectName + "," + NewName + "," + ObjectFrame)
        Next
        For Each X As String In Directory.GetFiles(SessionPath + "Sprites")
            Dim Backup As String = X
            X = X.Substring(X.LastIndexOf("\") + 1)
            X = X.Substring(0, X.LastIndexOf("."))
            X = X.Substring(X.IndexOf("_") + 1)
            If X = SpriteName Then IO.File.Delete(Backup)
        Next
        For X As Int16 = 0 To MainImageList.Images.Count - 1
            MainImageList.Images(X).Save(SessionPath + "Sprites\" + X.ToString + "_" + NewName + ".png")
        Next
        For Each X As Form In MainForm.MdiChildren
            If X.Name = "DObject" Then
                Dim DForm As DObject = DirectCast(X, DObject)
                'MsgError(DForm.SpriteDropper.Text)
                DForm.ChangeSprite(SpriteName, NewName)
            ElseIf X.Name = "Room" Then
                Dim DForm As Room = DirectCast(X, Room)
                Dim TopAffected As Byte = 0
                Dim BottomAffected As Byte = 0
                For DOn As Byte = 0 To DForm.Objects.Count - 1
                    If AffectedObjects.Contains(DForm.Objects(DOn).ObjectName) Then
                        If DForm.Objects(DOn).Screen Then TopAffected += 1 Else BottomAffected += 1
                        DForm.Objects(DOn).CacheImage = ObjectGetImage(DForm.Objects(DOn).ObjectName)
                    End If
                Next
                If TopAffected > 0 Then DForm.RefreshRoom(True)
                If BottomAffected > 0 Then DForm.RefreshRoom(False)
            End If
        Next
        UpdateArrayActionsName("Sprite", SpriteName, NewName, False)
        CurrentXDS = UpdateActionsName(CurrentXDS, "Sprite", SpriteName, NewName, False)
        For Each X As TreeNode In MainForm.ResourcesTreeView.Nodes(ResourceIDs.Sprite).Nodes
            If X.Text = SpriteName Then X.Text = NewName
        Next
        RedoSprites = DataChanged
        Me.Close()
    End Sub

    Function GetMagentaedBMP(ByVal Path As String) As Bitmap
        Dim TMP As Bitmap = PathToImage(Path)
        For x As Byte = 0 To TMP.Width - 1
            For y As Byte = 0 To TMP.Height - 1
                If TMP.GetPixel(x, y).A = 0 Then
                    TMP.SetPixel(x, y, Color.Magenta)
                End If
            Next
        Next
        Dim Drawer As New Bitmap(TMP.Width, TMP.Height)
        Dim DrawerGFX As Graphics = Graphics.FromImage(Drawer)
        DrawerGFX.Clear(Color.Black)
        DrawerGFX.DrawImage(TMP, 0, 0)
        DrawerGFX.Dispose()
        Return Drawer
    End Function

    Private Sub FromFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FromFileButton.Click
        MainImageList.Images.Clear()
        MainListView.Items.Clear()
        Dim Result As String = OpenFile(String.Empty, ImageFilter)
        If Result.Length = 0 Then Exit Sub
        Dim TMP As Bitmap = PathToImage(Result)
        If Not IsSpriteSizeOkay(TMP.Size) Then
            BadSpriteSize.ShowDialog()
            Exit Sub
        End If
        MainImageList.ImageSize = TMP.Size
        TMP.Dispose()
        MainImageList.Images.Add("Frame_0", GetMagentaedBMP(Result))
        MainListView.Items.Add("Frame 0", 0)
    End Sub
End Class