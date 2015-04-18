Imports System.IO

Module ResourcesLib

    Dim ShowWindowMode As Boolean = True

    Sub ToggleShowWindow()
        ShowWindowMode = Not ShowWindowMode
    End Sub

    '''''''''''''''''
    '''' SPRITES ''''
    '''''''''''''''''

    Sub AddSprite(ByVal DName As String)
        File.Copy(AppPath + "DefaultResources\Sprite.png", SessionPath + "Sprites\0_" + DName + ".png")
        XDSAddLine("SPRITE " + DName + ",32,32")
        For Each X As Form In MainForm.MdiChildren
            If Not IsObject(X.Text) Then Continue For
            DirectCast(X, DObject).AddSprite(DName)
        Next
        AddResourceNode(ResourceIDs.Sprite, DName, "SpriteNode", ShowWindowMode)
        RedoSprites = True
    End Sub

    '''''''''''''''''
    '''' OBJECTS ''''
    '''''''''''''''''

    Public Function IsObject(ByVal DName As String) As Boolean
        Return GetXDSFilter("OBJECT " + DName + ",").Length > 0
    End Function

    Sub AddObject(ByVal DName As String)
        Dim ObjectCount As UInt16 = GetXDSFilter("OBJECT ").Length
        XDSAddLine("OBJECT " + DName + ",None,0")
        For Each X As Form In MainForm.MdiChildren
            If Not X.Name = "Room" Then Continue For
            DirectCast(X, Room).AddObjectToDropper(DName)
        Next
        AddResourceNode(ResourceIDs.DObject, DName, "ObjectNode", ShowWindowMode)
    End Sub

    '''''''''''''''''''''
    '''' BACKGROUNDS ''''
    '''''''''''''''''''''

    Sub AddBackground(ByVal DName As String)
        File.Copy(AppPath + "DefaultResources\Background.png", SessionPath + "Backgrounds\" + DName + ".png")
        XDSAddLine("BACKGROUND " + DName)
        AddResourceNode(ResourceIDs.Background, DName, "BackgroundNode", ShowWindowMode)
        For Each X As Form In MainForm.MdiChildren
            If Not IsRoom(X.Text) Then Continue For
            For Each Y As Control In X.Controls
                If Not Y.Name = "ObjectsTabControl" Then Continue For
                For Each Z As Control In DirectCast(Y, TabControl).TabPages(0).Controls
                    If Z.Name = "TopScreenGroupBox" Or Z.Name = "BottomScreenGroupBox" Then
                        For Each I As Control In Z.Controls
                            If I.Name.EndsWith("BGDropper") Then
                                DirectCast(I, ComboBox).Items.Add(DName)
                            End If
                        Next
                    End If
                Next
            Next
        Next
        BGsToRedo.Add(DName)
    End Sub

    Public Function IsBackground(ByVal DName As String) As Boolean
        Return DoesXDSLineExist("BACKGROUND " + DName)
    End Function

    ''''''''''''''''
    '''' SOUNDS ''''
    ''''''''''''''''

    Sub AddSound(ByVal DName As String)
        SoundType.ShowDialog()
        Dim SB As Boolean = SoundType.IsSoundEffect
        Dim Extension As String = If(SB, "wav", "mp3")
        File.Copy(AppPath + "DefaultResources\Sound." + Extension, SessionPath + "Sounds\" + DName + "." + Extension)
        XDSAddLine("SOUND " + DName + "," + If(SB, 0, 1).ToString)
        AddResourceNode(ResourceIDs.Sound, DName, "SoundNode", ShowWindowMode)
        SoundsToRedo.Add(DName)
    End Sub

    '''''''''''''''
    '''' ROOMS ''''
    '''''''''''''''

    Sub AddRoom(ByVal DName As String)
        Dim RoomCount As Byte = GetXDSFilter("ROOM ").Length
        Dim DW As Int16 = Convert.ToInt16(GetOption("DEFAULT_ROOM_WIDTH"))
        Dim DH As Int16 = Convert.ToInt16(GetOption("DEFAULT_ROOM_HEIGHT"))
        If DW < 256 Then DW = 256
        If DW > 4096 Then DW = 4096
        If DW < 192 Then DW = 192
        If DH > 4096 Then DH = 4096
        XDSAddLine("ROOM " + DName + "," + DW.ToString + "," + DH.ToString + ",1,," + DW.ToString + "," + DH.ToString + ",1,")
        AddResourceNode(ResourceIDs.Room, DName, "RoomNode", ShowWindowMode)
    End Sub

    Public Function IsRoom(ByVal ThingyName As String) As Boolean
        Return GetXDSFilter("ROOM " + ThingyName + ",").Length > 0
    End Function

    '''''''''''''''''
    '''' SCRIPTS ''''
    '''''''''''''''''

    Sub AddScript(ByVal DName As String, ByVal IsDBAS As Boolean)
        File.CreateText(SessionPath + "Scripts\" + DName + ".dbas").Dispose()
        XDSAddLine("SCRIPT " + DName + "," + If(IsDBAS, 1, 0).ToString)
        AddResourceNode(ResourceIDs.Script, DName, "ScriptNode", ShowWindowMode)
    End Sub

End Module
