Imports System.IO
Imports System.Drawing.Imaging
Imports System.Net

Module DSGMlib

    Public ResourceTypes(6) As String

    Public IsPro As Boolean = True
    Public IDVersion As Int16 = 512
    Public Domain As String = "http://dsgamemaker.com/"
    Public OrderURL As String = "http://order." + Domain.Substring(7)
    Public UpdateVersion As Int16 = 0

    Public ActionBG As New Bitmap(32, 32)
    Public ActionConditionalBG As New Bitmap(32, 32)
    Public WC As New WebClient

    Public AppPath As String = String.Empty
    Public ProjectPath As String = String.Empty

    Public CDrive As String = String.Empty
    Public CacheProjectName As String = String.Empty
    Public BeingUsed As Boolean = False
    Public CurrentXDS As String = String.Empty

    Public FontNames As New List(Of String)

    Public BannedChars() As String = New String() {" ", ",", ".", ";", "/", "\", "!", """", "(", ")", "£", "$", "%", "^", "&", "*", "{", "}", _
                                            "[", "]", "@", "#", "'", "~", "<", ">", "?", "+", "=", "-", "|", "¬", "`"}

    Public Numbers() As String = New String() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}
    Public ImageFilter As String = "Graphics|*.png; *.gif; *.bmp|PNG Images|*.png|GIF Images|*.gif|Bitmap Images|*.bmp"

    Public LoadDefaultFolder As String = My.Computer.FileSystem.SpecialDirectories.Desktop
    Public SaveDefaultFolder As String = My.Computer.FileSystem.SpecialDirectories.Desktop

    Public RedoAllGraphics As Boolean = False
    Public RedoSprites As Boolean = False
    Public BGsToRedo As New List(Of String)
    Public FontsUsedLastTime As New List(Of String)
    Public SoundsToRedo As New List(Of String)

    Public IsNewProject As Boolean = False

    Public ProActions() As String = {"Enable Rotation", "Set Angle", "Disable Rotation"}
    'Public ProActions() As String = {}

    Public LastResourceFound As String = String.Empty
    Public LastScriptTermFound As String = String.Empty

    Sub FindResource(ByVal ResourceName As String)
        LastResourceFound = ResourceName
        If GetXDSFilter("SPRITE " + ResourceName + ",").Length > 0 Then
            OpenResource(ResourceName, ResourceIDs.Sprite, False)
            Exit Sub
        ElseIf DoesXDSLineExist("BACKGROUND " + ResourceName) Then
            OpenResource(ResourceName, ResourceIDs.Background, False)
            Exit Sub
        ElseIf GetXDSFilter("SCRIPT " + ResourceName + ",").Length > 0 Then
            OpenResource(ResourceName, ResourceIDs.Script, False)
            Exit Sub
        ElseIf DoesXDSLineExist("PATH " + ResourceName) Then
            OpenResource(ResourceName, ResourceIDs.Path, False)
            Exit Sub
        ElseIf GetXDSFilter("ROOM " + ResourceName + ",").Length > 0 Then
            OpenResource(ResourceName, ResourceIDs.Room, False)
            Exit Sub
        ElseIf GetXDSFilter("OBJECT " + ResourceName + ",").Length > 0 Then
            OpenResource(ResourceName, ResourceIDs.DObject, False)
            Exit Sub
        ElseIf GetXDSFilter("SOUND " + ResourceName + ",").Length > 0 Then
            OpenResource(ResourceName, ResourceIDs.Sound, False)
            Exit Sub
        End If
        MsgInfo("There is no Resource named '" + ResourceName + "'.")
    End Sub

    Public Function IsObject(ByVal ThingyName As String) As Boolean
        If GetXDSFilter("OBJECT " + ThingyName + ",").Length > 0 Then Return True Else Return False
    End Function

    Public Function IsBG(ByVal ThingyName As String) As Boolean
        Return DoesXDSLineExist("BACKGROUND " + ThingyName)
    End Function

    Public Function IsRoom(ByVal ThingyName As String) As Boolean
        If GetXDSFilter("ROOM " + ThingyName + ",").Length > 0 Then Return True Else Return False
    End Function

    Public Function ResurrectResourceName(ByVal ResourceName As String) As String
        Dim Returnable As String = ResourceName
        For Each BannedChar As String In BannedChars
            Returnable = Returnable.Replace(BannedChar, String.Empty)
        Next
        Return Returnable
    End Function

    Function GenerateDSSprite(ByVal TheSpriteName As String) As Bitmap
        Dim Folder As String = SessionPath + "Sprites\"
        Dim ImageCount As Byte = 0
        Dim Images As New List(Of String)
        For Each X As String In Directory.GetFiles(Folder)
            X = X.Substring(X.LastIndexOf("\") + 1)
            X = X.Substring(0, X.IndexOf(".png"))
            X = X.Substring(X.IndexOf("_") + 1)
            If X = TheSpriteName Then ImageCount += 1
        Next
        For X = 0 To ImageCount - 1
            Images.Add(Folder + X.ToString + "_" + TheSpriteName + ".png")
        Next
        Dim TheSize As Size = PathToImage(Images(0)).Size
        Dim Returnable As New Bitmap(TheSize.Width, TheSize.Height * Images.Count)
        Dim TempGFX As Graphics = Graphics.FromImage(Returnable)
        Dim DOn As Int16 = 0
        For Each X As String In Images
            TempGFX.DrawImage(PathToImage(X), New Point(0, DOn * TheSize.Height))
            DOn += 1
        Next
        TempGFX.Dispose()
        Return Returnable
    End Function

    Public Function HasInternetConnection(ByVal URL As String) As Boolean
        Dim uri As New System.Uri(URL)
        Dim request As WebRequest = WebRequest.Create(uri)
        Dim response As WebResponse
        Try
            response = request.GetResponse()
            response.Close()
            request = Nothing
            response.Close()
            request = Nothing
            Return True
        Catch : Return False
        End Try
    End Function

    Function ReallyPro() As Boolean
        Dim Email As String = GetSetting("PRO_EMAIL")
        Dim Serial As String = GetSetting("PRO_SERIAL")
        Dim UserPro As Boolean = If(Convert.ToByte(GetSetting("PRO")) = 1, True, False)
        If Not UserPro = My.Settings.ProActivated Then UserPro = My.Settings.ProActivated
        If Not UserPro Then Return False
        If Not Email = My.Settings.ProEmail Then Email = My.Settings.ProEmail
        If Not Serial = My.Settings.ProSerial Then Serial = My.Settings.ProSerial
        If UserPro Then
            'Okay, using Pro... let's check those details baby
            If HasInternetConnection(Domain) Then
                Dim Request As String = Domain + "DSGM5RegClient/key.php?data1=" + Email + "&data2=" + Serial
                Dim Response As String = WC.DownloadString(Request)
                If Response = "0" Then Return False
                WC.Dispose()
                Return True
            Else
                If Not Email.Contains("@") Then Return False
                If Not Serial.StartsWith("DSGM") Then Return False
                Return True
            End If
        End If
    End Function

    Public Function SQLSanitize(ByVal InputData As String, ByVal AlsoSpaces As Boolean) As String
        InputData = InputData.Replace("(", String.Empty)
        InputData = InputData.Replace("'", String.Empty)
        InputData = InputData.Replace("""", String.Empty)
        If AlsoSpaces Then InputData = InputData.Replace(" ", String.Empty)
        Return InputData
    End Function

    Function MakeSpaces(ByVal HowMany As Byte)
        Dim Returnable As String = String.Empty
        If HowMany = 0 Then Return Returnable
        For X As Byte = 0 To HowMany - 1
            Returnable += " "
        Next
        Return Returnable
    End Function

    Public Fonts As New List(Of String)

    Sub RebuildFontCache()
        Fonts.Clear()
        For Each X As String In Directory.GetFiles(AppPath + "Fonts")
            If Not X.EndsWith(".png") Then Continue For
            Dim FontName As String = X.Substring(X.LastIndexOf("\") + 1)
            FontName = FontName.Substring(0, FontName.Length - 4)
            Fonts.Add(FontName)
        Next
    End Sub

    Sub OpenResource(ByVal ResourceName As String, ByVal ResourceType As Byte, ByVal SpriteDataChanged As Boolean)
        For Each TheForm As Form In MainForm.MdiChildren
            If TheForm.Text = ResourceName Then TheForm.Focus() : Exit Sub
        Next
        Select Case ResourceType
            Case ResourceIDs.Sprite
                Dim SpriteForm As New Sprite
                SpriteForm.SpriteName = ResourceName
                SpriteForm.DataChanged = SpriteDataChanged
                ShowInternalForm(SpriteForm)
            Case ResourceIDs.DObject
                Dim ObjectForm As New DObject
                ObjectForm.ObjectName = ResourceName
                ShowInternalForm(ObjectForm)
            Case ResourceIDs.Background
                Dim BGForm As New Background
                BGForm.BackgroundName = ResourceName
                ShowInternalForm(BGForm)
            Case ResourceIDs.Sound
                Dim SoundForm As New Sound
                SoundForm.SoundName = ResourceName
                ShowInternalForm(SoundForm)
            Case ResourceIDs.Room
                Dim RoomForm As New Room
                RoomForm.RoomName = ResourceName
                ShowInternalForm(RoomForm)
            Case ResourceIDs.Script
                Dim ScriptForm As New Script
                ScriptForm.ScriptName = ResourceName
                ShowInternalForm(ScriptForm)
        End Select
    End Sub

    Public Function CompileWrapper()
        If Not Directory.Exists(CDrive + "devkitPro\devkitARM") Then
            MsgError("The development toolchain was not found." + vbcrlf + vbcrlf + "Please restart " + Application.ProductName + ". You will receive a prompt to install it.")
            Return False
        End If
        Return True
    End Function

    Public Sub CompileFail()
        MsgError("Your game was not successfully compiled and could therefore not be run." + vbcrlf + vbcrlf + "Look for logic errors in your game and try again.")
    End Sub

    Function SillyFixMe(ByVal Input As String)
        If Input.Length > 5 And Input.Substring(0, Input.Length - 5).StartsWith("this") Then
            Input = Input.Substring(0, Input.Length - 1)
        Else
            If Char.IsNumber(Input(Input.Length - 1)) = False And Char.IsLetter(Input(Input.Length - 1)) = False Then
                Input = Input.Substring(0, Input.Length - 1)
            End If
        End If

        Return Input
    End Function

    Public Function GetTime()
        Dim Returnable As String = Now.Hour.ToString + ":"
        If Now.Minute = 0 Then Returnable += "00"
        If Now.Minute > 0 And Now.Minute < 10 Then Returnable += "0" + Now.Minute.ToString
        If Now.Minute >= 10 Then Returnable += Now.Minute.ToString
        Return Returnable
    End Function

    Public Function CompileGame() As Boolean
        Compile.CustomPerformStep("Cleaning Temporary Data")
        File.Delete(CompilePath + "DSGMTemp" + Session + ".nds")
        For Each TheProcess As Process In Process.GetProcesses
            If TheProcess.ProcessName.ToLower = "pagfx" Or TheProcess.ProcessName.ToLower = "make" Then
                TheProcess.Kill()
            End If
        Next
        Dim FontsUsedThisTime As New List(Of String)
        FontsUsedThisTime.Add("Default")
        For Each X As String In GetXDSFilter("ACT ")
            If Not X.Contains(",Change Font,") Then Continue For
            X = X.Substring(X.IndexOf(";") + 1)
            X = X.Substring(0, X.LastIndexOf(","))
            If Not FontsUsedThisTime.Contains(X) Then FontsUsedThisTime.Add(X)
        Next
        If Not Directory.Exists(CompilePath + "gfx\bin") Then
            Directory.CreateDirectory(CompilePath + "gfx\bin")
        End If
        If Not IsPro Then
            If Not File.Exists(CompilePath + "gfx\bin\DSGMPro.c") Then
                File.Copy(AppPath + "CompiledBINs\DSGMPro.c", CompilePath + "gfx\bin\DSGMPro.c", True)
                File.Copy(AppPath + "CompiledBINs\DSGMPro_Tiles.bin", CompilePath + "gfx\bin\DSGMPro_Tiles.bin", True)
                File.Copy(AppPath + "CompiledBINs\DSGMPro_Map.bin", CompilePath + "gfx\bin\DSGMPro_Map.bin", True)
                File.Copy(AppPath + "CompiledBINs\DSGMPro_Pal.bin", CompilePath + "gfx\bin\DSGMPro_Pal.bin", True)
            End If
        End If
        'Remove fonts not used this time
        For Each X As String In FontsUsedLastTime
            If Not FontsUsedThisTime.Contains(X) Then
                File.Delete(CompilePath + "gfx\bin\" + X + ".c")
                File.Delete(CompilePath + "gfx\bin\" + X + "_Map.bin")
                File.Delete(CompilePath + "gfx\bin\" + X + "_Tiles.bin")
                File.Delete(CompilePath + "gfx\bin\" + X + "_Pal.bin")
            End If
        Next
        Dim FontH As String = String.Empty
        FontH += "#pragma once" + vbcrlf
        FontH += "#include <PA_BgStruct.h>" + vbcrlf
        'FontH += "#ifdef __cplusplus" + vbcrlf
        'FontH += "  extern ""C"" {" + vbcrlf
        'FontH += "#endif" + vbcrlf
        'MsgError("fonts used last time")
        'For Each Y As String In FontsUsedLastTime
        '    MsgError(Y)
        'Next
        For Each X As String In FontsUsedThisTime
            'If there's a font in this time's that's not in last times...
            If Not FontsUsedLastTime.Contains(X) Then
                File.Copy(AppPath + "CompiledBINs\" + X + ".c", CompilePath + "gfx\bin\" + X + ".c", True)
                File.Copy(AppPath + "CompiledBINs\" + X + "_Map.bin", CompilePath + "gfx\bin\" + X + "_Map.bin", True)
                File.Copy(AppPath + "CompiledBINs\" + X + "_Tiles.bin", CompilePath + "gfx\bin\" + X + "_Tiles.bin", True)
                File.Copy(AppPath + "CompiledBINs\" + X + "_Pal.bin", CompilePath + "gfx\bin\" + X + "_Pal.bin", True)
            End If
            FontH += "extern const PA_BgStruct " + X + ";" + vbcrlf
        Next
        If Not IsPro Then FontH += "extern const PA_BgStruct DSGMPro;" + vbcrlf
        'FontH += "#ifdef __cplusplus" + vbcrlf
        'FontH += "  }" + vbcrlf
        'FontH += "#endif"
        File.WriteAllText(CompilePath + "gfx\custom_gfx.h", FontH)
        Dim MyFiles As FileInfo()
        If RedoAllGraphics Then
            MyFiles = New IO.DirectoryInfo(CompilePath + "gfx").GetFiles()
            For Each dra As FileInfo In MyFiles
                If dra.Name.ToLower = "pagfx.exe" Or dra.Name.ToLower = "custom_gfx.h" Then Continue For
                IO.File.Delete(dra.FullName)
            Next
        End If
        MyFiles = New IO.DirectoryInfo(CompilePath + "data").GetFiles()
        For Each TheFile As IO.FileInfo In MyFiles
            If TheFile.Name.EndsWith(".raw") Then Continue For
            System.IO.File.Delete(TheFile.FullName)
        Next
        MyFiles = New IO.DirectoryInfo(CompilePath + "nitrofiles").GetFiles()
        For Each TheFile As IO.FileInfo In MyFiles
            If TheFile.FullName.EndsWith(".mp3") Then
                Dim IsMyMP3 As Boolean = False
                Dim RName As String = TheFile.FullName
                RName = RName.Substring(RName.LastIndexOf("\") + 1)
                RName = RName.Substring(0, RName.LastIndexOf("."))
                If IsAlreadyResource(RName).Length > 0 Then IsMyMP3 = True
                If Not IsMyMP3 Then System.IO.File.Delete(TheFile.FullName)
            Else
                System.IO.File.Delete(TheFile.FullName)
            End If
        Next
        MyFiles = New IO.DirectoryInfo(CompilePath + "include").GetFiles()
        For Each TheFile As IO.FileInfo In MyFiles
            'File.Delete(TheFile.FullName)
            If Not TheFile.Name = "ActionWorks.h" Then File.Delete(TheFile.FullName)
        Next
        If GetXDSLine("SAVE ").EndsWith("1") Then
            Dim ff(32768) As Byte
            For i As Int16 = 0 To 32767
                ff(i) = 0
            Next
            IO.File.WriteAllBytes(CompilePath + "nitrofiles\SaveData.dat", ff)
        End If

        If GetXDSLine("PROJECTLOGO ").Length < 12 Then
            If File.Exists(CompilePath + "logo.bmp") Then
                File.Delete(CompilePath + "logo.bmp")
            End If
            File.Copy(AppPath + "logo.bmp", CompilePath + "logo.bmp")
        Else
            If File.Exists(CompilePath + "logo.bmp") Then
                File.Delete(CompilePath + "logo.bmp")
            End If
            File.Copy(GetXDSLine("PROJECTLOGO ").Substring(12), CompilePath + "logo.bmp")
        End If

        Dim BootRoom As String = GetXDSLine("BOOTROOM ").Substring(9)
        Dim FinalString As String = String.Empty
        FinalString += "#include <PA9.h>" + vbCrLf
        FinalString += "#include <dirent.h>" + vbCrLf
        FinalString += "#include <filesystem.h>" + vbCrLf
        FinalString += "#include <unistd.h>" + vbCrLf

        'FinalString += "#include ""NitroGraphics.h""" + vbCrLf

        File.WriteAllBytes(CompilePath + "include\NitroGraphics.h", My.Resources.NitroGraphics)
        If GetXDSLine("INCLUDE_WIFI_LIB ").Substring(17) = "1" Then
            FinalString += "#include ""ky_geturl.h""" + vbCrLf
            If Not File.Exists(CompilePath + "source\ky_geturl.h") Then
                File.WriteAllBytes(CompilePath + "source\ky_geturl.h", My.Resources.WifiLibH)
            End If
            If Not File.Exists(CompilePath + "source\ky_geturl.c") Then
                File.WriteAllBytes(CompilePath + "source\ky_geturl.c", My.Resources.WifiLibC)
            End If
        Else
            If File.Exists(CompilePath + "source\ky_geturl.h") Then
                File.Delete(CompilePath + "source\ky_geturl.h")
            End If
            If File.Exists(CompilePath + "source\ky_geturl.c") Then
                File.Delete(CompilePath + "source\ky_geturl.c")
            End If
        End If
        FinalString += "#include ""dsgm_gfx.h""" + vbCrLf
        FinalString += "#include ""GameWorks.h""" + vbCrLf
        Compile.CustomPerformStep("Converting Sounds")
        Dim RAWString As String = String.Empty
        Dim MP3String As String = String.Empty
        Dim DoRAW As Boolean = False
        Dim DoMP3 As Boolean = False
        For Each X As String In SoundsToRedo
            If iGet(GetXDSLine("SOUND " + X + ","), 1, ",") = "1" Then
                MP3String += "mp3enc -b 64 """ + X + "_enc.mp3"" """ + X + """.mp3" + vbCrLf
                IO.File.Copy(SessionPath + "Sounds\" + X + ".mp3", CompilePath + "nitrofiles\" + X + "_enc.mp3")
                DoMP3 = True
            Else
                RAWString += "sox """ + X + """.wav -r 11025 -c 1 -e signed -b 8 """ + X + """.raw" + vbCrLf
                File.Copy(SessionPath + "Sounds\" + X + ".wav", CompilePath + "data\" + X + ".wav")
                DoRAW = True
            End If
        Next
        If DoRAW Then
            File.Copy(AppPath + "sox.exe", CompilePath + "data\sox.exe")
            File.Copy(AppPath + "libgomp-1.dll", CompilePath + "data\libgomp-1.dll")
            File.Copy(AppPath + "pthreadgc2.dll", CompilePath + "data\pthreadgc2.dll")
            File.Copy(AppPath + "zlib1.dll", CompilePath + "data\zlib1.dll")
            RunBatchString(RAWString, CompilePath + "data", False)
            File.Delete(CompilePath + "data\sox.exe")
            File.Delete(CompilePath + "data\libgomp-1.dll")
            File.Delete(CompilePath + "data\pthreadgc2.dll")
            File.Delete(CompilePath + "data\zlib1.dll")
            For Each X As String In SoundsToRedo
                If iGet(GetXDSLine("SOUND " + X + ","), 1, ",") = "1" Then Continue For
                File.Delete(CompilePath + "data\" + X + ".wav")
            Next
        End If
        If DoMP3 Then
            File.Copy(AppPath + "mp3enc.exe", CompilePath + "nitrofiles\mp3enc.exe")
            RunBatchString(MP3String, CompilePath + "nitrofiles", False)
            For Each X As String In SoundsToRedo
                If iGet(GetXDSLine("SOUND " + X + ","), 1, ",") = "0" Then Continue For
                File.Delete(CompilePath + "nitrofiles\" + X + "_enc.mp3")
            Next
            File.Delete(CompilePath + "nitrofiles\mp3enc.exe")
        End If
        FinalString += vbCrLf
        For Each X As String In GetXDSFilter("NITROFS ")
            Dim FileName As String = X.Substring(8)
            IO.File.Copy(SessionPath + "NitroFSFiles\" + FileName, CompilePath + "nitrofiles\" + FileName, True)
        Next
        'FinalString += "s16 score = " + GetXDSLine("SCORE ").ToString.Substring(6) + ";" + vbcrlf
        'FinalString += "s16 health = " + GetXDSLine("HEALTH ").ToString.Substring(7) + ";" + vbcrlf
        'FinalString += "s16 lives = " + GetXDSLine("LIVES ").ToString.Substring(6) + ";" + vbcrlf
        'If GetXDSFilter("GLOBAL ").Length > 0 Then
        '    FinalString += vbcrlf
        'End If
        'If GetXDSFilter("GLOBAL ").Length > 0 Then
        '    FinalString += vbcrlf
        'End If
        'FinalString += "bool DSGM_CreateObject(u8 ObjectID, u8 InstanceID, bool Screen, s16 X, s16 Y);" + vbcrlf
        'FinalString += "bool DSGM_SetObjectSprite(u8 InstanceID, u8 SpriteID, bool DeleteOld);" + vbcrlf
        'FinalString += "bool DSGM_SwitchRoomByIndex(u8 RoomIndex);" + vbcrlf
        'FinalString += vbcrlf + "int main (int argc, char ** argv) {" + vbcrlf
        FinalString += vbCrLf + "int main (void) {" + vbCrLf
        FinalString += "  RoomCount = " + GetXDSFilter("ROOM ").Length.ToString + ";" + vbCrLf
        FinalString += "  score = " + GetXDSLine("SCORE ").Substring(6) + ";" + vbCrLf
        FinalString += "  lives = " + GetXDSLine("LIVES ").Substring(6) + ";" + vbCrLf
        FinalString += "  health = " + GetXDSLine("HEALTH ").Substring(7) + ";" + vbCrLf
        For Each XDSLine As String In GetXDSFilter("GLOBAL ")
            XDSLine = XDSLine.Substring(7)
            Dim VariableType As String = iGet(XDSLine, 1, ",")
            If Not VariableType = "String" Then Continue For
            Dim VariableName As String = iGet(XDSLine, 0, ",")
            Dim VariableValue As String = iGet(XDSLine, 2, ",")
            FinalString += "  strcpy(" + VariableName + ", """ + VariableValue + """);" + vbCrLf
        Next
        FinalString += "  CurrentRoom = Room_Get_Index(""" + GetXDSLine("BOOTROOM ").Substring(9) + """);" + vbCrLf
        FinalString += "  swiWaitForVBlank();" + vbCrLf
        FinalString += "  PA_InitFifo();" + vbCrLf
        FinalString += "  PA_Init();" + vbCrLf
        'FinalString += "  PA_Init2D();" + vbcrlf
        FinalString += "  DSGM_Init_PAlib();" + vbCrLf
        FinalString += "  Reset_Alarms();" + vbCrLf
        If GetXDSLine("NITROFS_CALL ").Substring(13) = "1" Then
            FinalString += "  nitroFSInit(NULL);" + vbCrLf
            FinalString += "  chdir(""nitro:/"");" + vbCrLf
        End If
        If GetXDSLine("FAT_CALL ").Substring(9) = "1" Then
            FinalString += "  fatInitDefault();" + vbCrLf
        End If
        If XDSCountLines("SOUND ") > 0 Then
            FinalString += "  DSGM_Init_Sound();" + vbCrLf
        End If
        If IsPro Then
            FinalString += "  " + BootRoom + "();" + vbCrLf
        Else
            FinalString += "  PA_LoadBackground(1, 2, &DSGMPro);" + vbCrLf
            FinalString += "  PA_LoadBackground(0, 2, &DSGMPro);" + vbCrLf
            FinalString += "  PA_EasyBgScrollXY(0, 2, 256, 0);" + vbCrLf
            FinalString += "  bool ProDir = false;" + vbCrLf
            FinalString += "  s8 ProFadeAmount = 0;" + vbCrLf
            FinalString += "  u8 ProFrameOn = 0;" + vbCrLf
            FinalString += "  while (true) {" + vbCrLf
            FinalString += "    if (ProFrameOn % 4 == 0) {" + vbCrLf
            FinalString += "      if (ProFadeAmount <= -15) {" + vbCrLf
            FinalString += "        ProDir = true;" + vbCrLf
            FinalString += "      }" + vbCrLf
            FinalString += "      if (ProFadeAmount >= 0) {" + vbCrLf
            FinalString += "        ProDir = false;" + vbCrLf
            FinalString += "      }" + vbCrLf
            FinalString += "      if (ProDir) ProFadeAmount += 1;" + vbCrLf
            FinalString += "      if (!ProDir) ProFadeAmount -= 1;" + vbCrLf
            FinalString += "      PA_SetBrightness(0, ProFadeAmount);" + vbCrLf
            FinalString += "    }" + vbCrLf
            FinalString += "    if (Stylus.Newpress || Pad.Newpress.Anykey) {" + vbCrLf
            FinalString += "      PA_SetBrightness(0, 0);" + vbCrLf
            FinalString += "      " + BootRoom + "();" + vbCrLf
            FinalString += "    }" + vbCrLf
            FinalString += "    ProFrameOn += 1;" + vbCrLf
            FinalString += "    if (ProFrameOn == 200) ProFrameOn = 0;" + vbCrLf
            FinalString += "    PA_WaitForVBL();" + vbCrLf
            FinalString += "  }" + vbCrLf
        End If
        FinalString += "  return 0;" + vbCrLf
        FinalString += "}" + vbCrLf
        Dim PAini As String = "#TranspColor Magenta"
        PAini += vbCrLf + "#Backgrounds : " + vbCrLf
        Dim DOn As Int16 = 0
        If RedoAllGraphics Then
            For Each XDSLine As String In GetXDSFilter("BACKGROUND ")
                XDSLine = XDSLine.Substring(11)
                Dim BackgroundName As String = iGet(XDSLine, 0, ",")
                Dim BGImage As Image = PathToImage(SessionPath + "Backgrounds\" + BackgroundName + ".png")
                PAini += BackgroundName + ".png "
                If BGImage.Width > 256 And BGImage.Height > 256 Then
                    PAini += "LargeMap" : Else : PAini += "EasyBG"
                End If
                File.Copy(SessionPath + "Backgrounds\" + BackgroundName + ".png", CompilePath + "gfx\" + BackgroundName + ".png")
                PAini += vbCrLf
            Next
        Else
            For Each X As String In BGsToRedo
                'Dim IsBG As Boolean = DoesXDSLineExist("BACKGROUND " + X)
                'If Not IsBG Then Continue For
                Dim BGImage As Image = PathToImage(SessionPath + "Backgrounds\" + X + ".png")
                PAini += X + ".png "
                If BGImage.Width > 256 And BGImage.Height > 256 Then
                    PAini += "LargeMap" : Else : PAini += "EasyBG"
                End If
                PAini += vbCrLf
                File.Copy(SessionPath + "Backgrounds\" + X + ".png", CompilePath + "gfx\" + X + ".png", True)
                BGImage.Dispose()
                DOn += 1
            Next
        End If
        'FinalString += "u8 ObjectGetPallet(char *ObjectName) {" + vbcrlf
        'For Each X As String In GetXDSFilter("OBJECT ")
        '    X = X.Substring(7)
        '    Dim ObjectName As String = iget(X, 0, ",")
        '    Dim SpriteName As String = iget(GetXDSLine("OBJECT " + ObjectName + ","), 1, ",")
        '    Dim PalletNumber As Byte = 0
        '    For Each PalletString As String In PalletNumbers
        '        If PalletString.StartsWith(SpriteName + ",") Then
        '            PalletNumber = Convert.ToByte(PalletString.Substring(PalletString.IndexOf(",") + 1))
        '        End If
        '    Next
        '    FinalString += " if (strcmp(ObjectName, """ + ObjectName + """) == 0) return " + PalletNumber.ToString + ";" + vbcrlf
        'Next
        'FinalString += " return 0;" + vbcrlf
        'FinalString += "}" + vbcrlf
        'Dim EventsHeaderString As String = String.Empty
        'For Each XDSLine As String In GetXDSFilter("EVENT ")
        '    DOn = 0
        '    XDSLine = XDSLine.Substring(6)
        '    Dim ObjectName As String = iget(XDSLine, 0, ",")
        '    Dim MainClass As String = iget(XDSLine, 1, ",")
        '    Dim StringMainClass As String = MainClassTypeToString(MainClass).Replace(" ", String.Empty)
        '    Dim SubClass As String = iget(XDSLine, 2, ",")
        '    Dim StringSubClass As String = SubClass.Replace(" ", String.Empty)
        '    If StringSubClass = "NoData" Then StringSubClass = String.Empty
        '    EventsHeaderString += "void " + ObjectName + StringMainClass + StringSubClass + "_Event(u8 DAppliesTo);" + vbcrlf
        'Next
        PAini += vbCrLf + "#Sprites : " + vbCrLf
        Dim PalletNumbers As New Collection
        Dim PalletNames As New Collection
        Dim PalletNumbers_Nitro As New Collection
        Dim PalletNames_Nitro As New Collection
        Dim AllColors As Int16 = 0
        Dim PalletOn As Byte = 0
        Dim AllColors_Nitro As Int16 = 0
        Dim PalletOn_Nitro As Byte = 0
        Dim FirstRun As Boolean = True
        For Each XDSLine As String In GetXDSFilter("SPRITE ")
            XDSLine = XDSLine.Substring(7)
            Dim SpriteName As String = iGet(XDSLine, 0, ",")
            Dim TheImage As Bitmap = GenerateDSSprite(SpriteName)
            Dim SpriteNameExtension As String = SpriteName + ".png"
            Dim CurrentColors As Int16 = ImageCountColors(TheImage)
            If iGet(GetXDSLine("SPRITE " + XDSLine), 3, ",") = "Nitro" Then
                If AllColors_Nitro + CurrentColors >= 256 Then
                    AllColors_Nitro = 0
                    PalletOn_Nitro += 1
                Else
                    AllColors_Nitro += CurrentColors
                End If
                PalletNumbers_Nitro.Add(SpriteName + "," + PalletOn_Nitro.ToString)
            Else
                If AllColors + CurrentColors >= 256 Then
                    AllColors = 0
                    PalletOn += 1
                Else
                    AllColors += CurrentColors
                End If
                PalletNumbers.Add(SpriteName + "," + PalletOn.ToString)
            End If
            If RedoSprites Then
                TheImage.Save(CompilePath + "gfx\" + SpriteNameExtension)
                If iGet(GetXDSLine("SPRITE " + XDSLine), 3, ",") = "Nitro" Then
                    PAini += SpriteNameExtension + " 256Colors " + "NitroPal" + PalletOn_Nitro.ToString + vbCrLf
                Else
                    PAini += SpriteNameExtension + " 256Colors " + "DSGMPal" + PalletOn.ToString + vbCrLf
                End If
            End If
            If iGet(GetXDSLine("SPRITE " + XDSLine), 3, ",") = "Nitro" Then
                If FirstRun Then PalletNames_Nitro.Add(SpriteName + "," + PalletOn_Nitro.ToString) : FirstRun = False : Continue For
                If AllColors = 0 Then PalletNames_Nitro.Add(SpriteName + "," + PalletOn_Nitro.ToString)
            Else
                If FirstRun Then PalletNames.Add(SpriteName + "," + PalletOn.ToString) : FirstRun = False : Continue For
                If AllColors = 0 Then PalletNames.Add(SpriteName + "," + PalletOn.ToString)
            End If
        Next
        File.WriteAllText(CompilePath + "gfx\PAGfx.ini", PAini)
        Dim EventsString As String = String.Empty
        For Each XDSLine As String In GetXDSFilter("EVENT ")
            DOn = 0
            XDSLine = XDSLine.Substring(6)
            Dim ObjectName As String = iGet(XDSLine, 0, ",")
            Dim MainClass As String = iGet(XDSLine, 1, ",")
            Dim StringMainClass As String = MainClassTypeToString(MainClass).Replace(" ", String.Empty)
            Dim SubClass As String = iGet(XDSLine, 2, ",")
            Dim StringSubClass As String = SubClass.Replace(" ", String.Empty)
            If StringSubClass = "NoData" Then StringSubClass = String.Empty
            If StringSubClass = "<Unknown>" Then Continue For
            EventsString += "void " + ObjectName + StringMainClass + StringSubClass + "_Event(u8 DAppliesTo) {" + vbCrLf
            Dim CurrentIndent As Byte = 1
            Dim IndentOrDedent As Byte = 0
            Dim Added As Byte = 0
            For Each Y As String In GetXDSFilter("ACT " + ObjectName + "," + MainClass + "," + SubClass + ",")
                Y = SillyFixMe(Y)
                Y = Y.Substring(("ACT " + ObjectName + "," + MainClass + "," + SubClass + ",").Length)
                Dim ActionName As String = iGet(Y, 0, ",")
                If Not File.Exists(AppPath + "Actions\" + ActionName + ".action") Then Continue For
                IndentOrDedent = 0
                Added = 0
                Dim NeedsAppliesToVar As Boolean = False
                If Not ActionName = "Execute Code" Then
                    For Each X As String In File.ReadAllLines(AppPath + "Actions\" + ActionName + ".action")
                        If X = "INDENT" Then IndentOrDedent = 1
                        If X = "DEDENT" Then IndentOrDedent = 2
                        If X.Contains("AppliesTo") Then NeedsAppliesToVar = True
                    Next
                End If
                Dim Arguments As String = iGet(Y, 1, ",")
                Dim AppliesToString As String = iGet(Y, 2, ",")
                If AppliesToString = "<Unknown>" Or Arguments.Contains("<Unknown>") Then Continue For
                Dim ArgumentCount As Byte = HowManyChar(Arguments, ";") + 1
                Dim InputtedArgumentValues As New List(Of String)
                For X As Byte = 0 To ArgumentCount - 1
                    InputtedArgumentValues.Add(iGet(Arguments, X, ";").ToString.Replace("<com>", ","))
                Next
                'For Each X As String In File.ReadAllLines(AppPath + "Actions\" + ActionName + ".action")
                '    If X = "NOAPPLIES" Then ActionSaysIgnoreApplies = True : Exit For
                'Next
                If Not ActionName = "Execute Code" Then
                    For Each X As String In ApplyFinders
                        If Arguments.Contains(X) Then NeedsAppliesToVar = True
                    Next
                End If
                'If Not IgnoreApplies Then NeedsAppliesToVar = True
                Dim TempLine As String = String.Empty
                ' If ApplicationUsed Then
                Dim ToReplace As String = "AppliesTo"
                If ActionName = "Execute Code" Then ToReplace = "DAppliesTo"
                For X As Byte = 0 To InputtedArgumentValues.Count - 1
                    For Each D As String In ApplyFinders
                        Dim NoBrackets As String = D
                        NoBrackets = NoBrackets.Substring(1)
                        NoBrackets = NoBrackets.Substring(0, NoBrackets.Length - 1)
                        InputtedArgumentValues.Item(X) = InputtedArgumentValues(X).Replace(D, "Instances[" + ToReplace + "]." + NoBrackets)
                    Next
                    'InputtedArgumentValues.Item(X) = InputtedArgumentValues(X).Replace("[Me]", "DAppliesTo")
                Next
                '  End If
                If NeedsAppliesToVar Then
                    If AppliesToString = "this" Then
                        EventsString += MakeSpaces(CurrentIndent * 2) + "u16 AppliesTo" + DOn.ToString + " = DAppliesTo;" + vbCrLf
                        Added = 0
                    ElseIf IsObject(AppliesToString) Then
                        EventsString += MakeSpaces(CurrentIndent * 2) + "u16 AppliesTo" + DOn.ToString + " = 0;" + vbCrLf
                        EventsString += MakeSpaces(CurrentIndent * 2) + "for (AppliesTo" + DOn.ToString + " = 0; AppliesTo" + DOn.ToString + " < 256; AppliesTo" + DOn.ToString + "++) {" + vbCrLf
                        EventsString += MakeSpaces(CurrentIndent * 2) + "  if (Instances[AppliesTo" + DOn.ToString + "].InUse && Instances[AppliesTo" + DOn.ToString + "].EName == " + AppliesToString + ") {" + vbCrLf
                        CurrentIndent += 2
                        Added = 2
                    Else
                        TempLine = "u8 ArrayAppliesTo" + DOn.ToString + "[] = {"
                        Dim LoopTo As Byte = 0
                        For I As Byte = 0 To HowManyChar(AppliesToString, " ")
                            TempLine += iGet(AppliesToString, I, " ") + ", "
                            LoopTo += 1
                        Next
                        TempLine = TempLine.Substring(0, TempLine.Length - 2)
                        TempLine += "};"
                        EventsString += MakeSpaces(CurrentIndent * 2) + TempLine + vbCrLf
                        EventsString += MakeSpaces(CurrentIndent * 2) + "u16 AppliesTo" + DOn.ToString + " = 0;" + vbCrLf
                        TempLine = MakeSpaces(CurrentIndent * 2) + "for (AppliesTo" + DOn.ToString + " = 0; AppliesTo" + DOn.ToString + " < " + LoopTo.ToString + "; AppliesTo" + DOn.ToString + "++) {"
                        EventsString += TempLine + vbCrLf
                        CurrentIndent += 1
                        Added = 1
                    End If
                End If
                'For Each X As String In File.ReadAllLines(AppPath + "Actions\" + ActionName + ".action")
                '    If X = "INDENT" Then
                '        CurrentIndent += 1
                '    End If
                '    If X = "DEDENT" Then
                '        If CurrentIndent > 0 Then CurrentIndent -= 1
                '    End If
                'Next
                If IndentOrDedent = 1 Then CurrentIndent += 1
                If IndentOrDedent = 2 Then
                    If CurrentIndent > 0 Then CurrentIndent -= 1
                End If
                If ActionName = "Execute Code" Then
                    Dim DBASCode As String = Arguments
                    'Dim BRCount As Int16 = HowManyChar(OriginalCode, "<br|>")
                    'For i As Int16 = 0 To BRCount

                    'Next
                    DBASCode = DBASCode.Replace("<br|>", vbCrLf).Replace("<com>", ",").Replace("<sem>", ";")
                    Dim CCode As String = ScriptParseFromContent("Temp", DBASCode, String.Empty, String.Empty, False, True, False)
                    For Each X As String In StringToLines(CCode)
                        EventsString += MakeSpaces(CurrentIndent * 2) + X + vbCrLf
                    Next
                Else
                    For Each X As String In File.ReadAllLines(AppPath + "Actions\" + ActionName + ".action")
                        If X.Length = 0 Then Continue For
                        If X.StartsWith("ARG ") Then Continue For
                        If X.StartsWith("DISPLAY ") Then Continue For
                        If X.StartsWith("TYPE ") Then Continue For
                        If X.StartsWith("ICON ") Then Continue For
                        If X.StartsWith("CONDITION ") Then Continue For
                        If X = "INDENT" Then Continue For
                        If X = "DEDENT" Then Continue For
                        If X = "NOAPPLIES" Then Continue For
                        For i As Byte = 0 To 200
                            If X(0).ToString = " " Then X = X.Substring(1) Else Exit For
                        Next
                        For FOn = 0 To ArgumentCount - 1
                            X = X.Replace("!" + (FOn + 1).ToString + "!", InputtedArgumentValues(FOn))
                        Next
                        If NeedsAppliesToVar Then
                            If IsObject(AppliesToString) Or AppliesToString = "this" Then
                                X = X.Replace("AppliesTo", "DX" + DOn.ToString)
                            Else
                                X = X.Replace("AppliesTo", "ArrayDX" + DOn.ToString + "[DX" + DOn.ToString + "]")
                            End If
                            X = X.Replace("DX", "AppliesTo")
                        End If
                        X = X.Replace("[Me]", "DAppliesTo")
                        X = MakeSpaces(CurrentIndent * 2) + X
                        EventsString += X + vbCrLf
                    Next
                End If
                If IndentOrDedent = 0 Then
                    CurrentIndent -= Added
                    If Added = 1 Then
                        EventsString += MakeSpaces(CurrentIndent * 2) + "}" + vbCrLf
                    ElseIf Added = 2 Then
                        EventsString += MakeSpaces(CurrentIndent * 2) + "  }" + vbCrLf
                        EventsString += MakeSpaces(CurrentIndent * 2) + "}" + vbCrLf
                    End If
                End If
                DOn += 1
            Next
            For i = CurrentIndent - 1 To 0 Step -1
                EventsString += MakeSpaces(i * 2) + "}" + vbCrLf
            Next
        Next
        'File.WriteAllText(CompilePath + "source\Events.c", EventsString)
        DOn = 0
        'Twas here, Marvolo!
        For Each X As String In GetXDSFilter("ROOM ")
            X = X.Substring(5)
            Dim RoomName As String = iGet(X, 0, ",")
            Dim TopWidth As Int16 = Convert.ToInt16(iGet(X, 1, ","))
            Dim TopHeight As Int16 = Convert.ToInt16(iGet(X, 2, ","))
            Dim TopScroll As Boolean = If(iGet(X, 3, ",") = "1", True, False)
            Dim TopBG As String = iGet(X, 4, ",")
            Dim BottomWidth As Int16 = Convert.ToInt16(iGet(X, 5, ","))
            Dim BottomHeight As Int16 = Convert.ToInt16(iGet(X, 6, ","))
            Dim BottomScroll As Boolean = If(iGet(X, 7, ",") = "1", True, False)
            Dim BottomBG As String = iGet(X, 8, ",")
            FinalString += "bool " + RoomName + "(void) {" + vbCrLf
            FinalString += "  PA_ResetSpriteSys();" + vbCrLf
            FinalString += "  PA_ResetBgSys();" + vbCrLf
            If iGet(GetXDSLine("BACKGROUND " + TopBG), 1, ",") = "Nitro" Then
                If TopBG.Length > 0 Then FinalString += "  FAT_LoadBackground(1, 2, """ + TopBG + """);" + vbCrLf
                If BottomBG.Length > 0 Then FinalString += "  FAT_LoadBackground(0, 2, """ + BottomBG + """);" + vbCrLf
            Else
                If TopBG.Length > 0 Then FinalString += "  PA_LoadBackground(1, 2, &" + TopBG + ");" + vbCrLf
                If BottomBG.Length > 0 Then FinalString += "  PA_LoadBackground(0, 2, &" + BottomBG + ");" + vbCrLf
            End If
            Dim MyPalletLines As New Collection
            Dim MyNewLine As String = String.Empty
            For Each p As String In PalletNames
                Dim PalletNo As Byte = Convert.ToByte(p.Substring(p.IndexOf(",") + 1))
                If File.ReadAllText(CompilePath + "gfx\PAGfx.ini").Contains("DSGMPal" + PalletNo.ToString) Then
                    MyNewLine = "  PA_LoadSpritePal(1, " + PalletNo.ToString + ", (void*)DSGMPal" + PalletNo.ToString + "_Pal);"
                    MyNewLine += " PA_LoadSpritePal(0, " + PalletNo.ToString + ", (void*)DSGMPal" + PalletNo.ToString + "_Pal);"
                End If
                Dim AlreadyDone As Boolean = False
                For Each MyLine As String In MyPalletLines
                    If MyLine = MyNewLine Then AlreadyDone = True : Exit For
                Next
                If Not AlreadyDone Then MyPalletLines.Add(MyNewLine)
            Next
            For Each MyLine As String In MyPalletLines
                FinalString += MyLine + vbCrLf
            Next
            FinalString += "  DSGM_Setup_Room(" + TopWidth.ToString + ", "
            FinalString += TopHeight.ToString + ", "
            FinalString += BottomWidth.ToString + ", "
            FinalString += BottomHeight.ToString + ", 0, 0, 0, 0);" + vbCrLf
            FinalString += "  PA_LoadText(1, 0, &Default); PA_LoadText(0, 0, &Default);" + vbCrLf
            DOn = 0
            For Each Y As String In GetXDSFilter("OBJECTPLOT ")
                Y = Y.Substring(11)
                If Not iGet(Y, 1, ",") = RoomName Then Continue For
                Dim ObjectName As String = iGet(Y, 0, ",")
                'FinalString += "  // " + ObjectName + vbcrlf
                Dim ObjectLine As String = GetXDSLine("OBJECT " + ObjectName + ",")
                Dim Screen As Boolean = If(iGet(Y, 2, ",") = "1", True, False)
                Dim DX As Int16 = Convert.ToInt16(iGet(Y, 3, ","))
                Dim DY As Int16 = Convert.ToInt16(iGet(Y, 4, ","))
                Dim SpriteName As String = iGet(ObjectLine, 1, ",")
                Dim SpriteLine As String = GetXDSLine("SPRITE " + SpriteName + ",")
                'Dim DefaultFrame As Int16 = Convert.ToInt16(iget(ObjectLine, 2, ","))
                FinalString += "  Create_Object(" + ObjectName + ", " + DOn.ToString + ", " + If(Screen, "true", "false") + ", " + DX.ToString + ", " + DY.ToString + ");" + vbCrLf
                'Dim SW As Byte = Convert.ToByte(iget(SpriteLine, 1, ","))
                'Dim SH As Byte = Convert.ToByte(iget(SpriteLine, 2, ","))
                'FinalString += "  Instances[" + DOn.ToString + "].ObjectID = ObjectToID(""" + ObjectName + """);" + vbcrlf
                'FinalString += "  Instances[" + DOn.ToString + "].InUse = true; Instances[" + DOn.ToString + "].Screen = " + If(Screen = 1, "true", "false") + ";" + vbcrlf
                'FinalString += "  Instances[" + DOn.ToString + "].X = " + DX.ToString + "; Instances[" + DOn.ToString + "].Y = " + DY.ToString + ";" + vbcrlf
                'FinalString += "  Instances[" + DOn.ToString + "].Width = " + SW.ToString + "; Instances[" + DOn.ToString + "].Height = " + SH.ToString + ";" + vbcrlf
                'FinalString += "  Instances[" + DOn.ToString + "].Frame = " + DefaultFrame.ToString + ";" + vbcrlf
                'If DefaultFrame > 0 Then FinalString += "  Instances[" + DOn.ToString + "].FrameChanged = true;" + vbcrlf
                'Dim PalletNumber As Byte = 0
                'For Each PalletString As String In PalletNumbers
                '    If PalletString.StartsWith(SpriteName + ",") Then
                '        PalletNumber = Convert.ToByte(PalletString.Substring(PalletString.IndexOf(",") + 1))
                '    End If
                'Next
                'FinalString += "  PA_CreateSprite(" + Screen.ToString + ", " + DOn.ToString + ", (void*)" + SpriteName + "_Sprite, OBJ_SIZE_" + SW.ToString + "X" + SH.ToString + ", 1, " + PalletNumber.ToString + ", 256, 192);" + vbcrlf
                'If Not DefaultFrame = 0 Then FinalString += "  PA_SetSpriteAnim(" + Screen + ", " + DOn.ToString + ", " + DefaultFrame.ToString + ");" + vbcrlf
                'If DoesXDSLineExist("EVENT " + ObjectName + ",1,NoData") Then FinalString += "  " + ObjectName + "Create_Event(" + DOn.ToString + ");" + vbcrlf
                DOn += 1
            Next
            FinalString += "  DSGM_Complete_Room();" + vbCrLf
            FinalString += "  while(true) {" + vbCrLf
            DOn = 0
            Dim HasSuchEvents As Boolean = False
            For Each Y As String In GetXDSFilter("EVENT ")
                If iGet(Y, 1, ",") = "7" Then HasSuchEvents = True : Exit For
            Next
            If HasSuchEvents Then
                'FinalString += "    // Step Events" + vbcrlf
                FinalString += "    for (DSGMPL = 0; DSGMPL <= 127; DSGMPL++) {" + vbCrLf
                FinalString += "      if (Instances[DSGMPL].InUse) {" + vbCrLf
                For Each Y As String In GetXDSFilter("OBJECT ")
                    Y = Y.Substring(7)
                    Dim ObjectName As String = iGet(Y, 0, ",")
                    If DoesXDSLineExist("EVENT " + ObjectName + ",7,NoData") Then
                        FinalString += "        if (Instances[DSGMPL].EName == " + ObjectName + ") " + ObjectName + "Step_Event(DSGMPL);" + vbCrLf
                    End If
                    DOn += 1
                Next
                FinalString += "      }" + vbCrLf
                FinalString += "    }" + vbCrLf
            End If
            DOn = 0
            HasSuchEvents = False
            For Each Y As String In GetXDSFilter("EVENT ")
                If iGet(Y, 1, ",") = "5" Then HasSuchEvents = True : Exit For
            Next
            If HasSuchEvents Then
                'FinalString += "    // Touch (Stylus) Events" + vbcrlf
                FinalString += "    for (DSGMPL = 0; DSGMPL <= 127; DSGMPL++) {" + vbCrLf
                FinalString += "      if (Instances[DSGMPL].InUse) {" + vbCrLf
                For Each Y As String In GetXDSFilter("OBJECT ")
                    Dim ObjectName As String = iGet(Y.Substring(7), 0, ",")
                    If DoesXDSLineExist("EVENT " + ObjectName + ",5,New Press") Then
                        FinalString += "        if (Instances[DSGMPL].EName == " + ObjectName + " && Stylus.Newpress && PA_SpriteTouched(DSGMPL)) " + ObjectName + "TouchNewPress_Event(DSGMPL);" + vbCrLf
                    End If
                    If DoesXDSLineExist("EVENT " + ObjectName + ",5,Double Press") Then
                        FinalString += "        if (Instances[DSGMPL].EName == " + ObjectName + " && Stylus.DblClick && PA_SpriteTouched(DSGMPL)) " + ObjectName + "TouchDoublePress_Event(DSGMPL);" + vbCrLf
                    End If
                    If DoesXDSLineExist("EVENT " + ObjectName + ",5,Held") Then
                        FinalString += "        if (Instances[DSGMPL].EName == " + ObjectName + " && Stylus.Held && PA_SpriteTouched(DSGMPL)) " + ObjectName + "TouchHeld_Event(DSGMPL);" + vbCrLf
                    End If
                    If DoesXDSLineExist("EVENT " + ObjectName + ",5,Released") Then
                        FinalString += "        if (Instances[DSGMPL].EName == " + ObjectName + " && Stylus.Released && PA_SpriteTouched(DSGMPL)) " + ObjectName + "TouchReleased_Event(DSGMPL);" + vbCrLf
                    End If
                    DOn += 1
                Next
                FinalString += "      }" + vbCrLf
                FinalString += "    }" + vbCrLf
            End If
            DOn = 0
            HasSuchEvents = False
            For Each Y As String In GetXDSFilter("EVENT ")
                If iGet(Y, 1, ",") = "6" Then HasSuchEvents = True : Exit For
            Next
            If HasSuchEvents Then
                'FinalString += "    // Collision Events" + vbcrlf
                FinalString += "    for (DSGMPL = 0; DSGMPL <= 127; DSGMPL++) {" + vbCrLf
                For Each Y As String In GetXDSFilter("OBJECT ")
                    Y = Y.Substring(7)
                    Dim ObjectName As String = iGet(Y, 0, ",")
                    If GetXDSFilter("EVENT " + ObjectName + ",6,").Length > 0 Then
                        FinalString += "      if (Instances[DSGMPL].InUse && Instances[DSGMPL].EName == " + ObjectName + ") {" + vbCrLf
                        For Each Z As String In GetXDSFilter("EVENT " + ObjectName + ",6,")
                            Dim CollidingObject As String = Z.Substring(Z.LastIndexOf(",") + 1)
                            FinalString += "        for (DSGMSL = 0; DSGMSL <= 127; DSGMSL++) {" + vbCrLf
                            FinalString += "          if (Instances[DSGMSL].InUse && Instances[DSGMSL].EName == " + CollidingObject + ") {" + vbCrLf
                            FinalString += "            if (" + If(GetXDSLine("MIDPOINT_COLLISIONS ").Substring(20) = "1", "Sprite_Collision_Mid(", "Sprite_Collision(") + "DSGMPL, DSGMSL)) " + ObjectName + "Collision" + CollidingObject + "_Event(DSGMPL);" + vbCrLf
                            FinalString += "          }" + vbCrLf
                            FinalString += "        }" + vbCrLf
                        Next
                        FinalString += "      }" + vbCrLf
                    End If
                    DOn += 1
                Next
                FinalString += "    }" + vbCrLf
            End If
            DOn = 0
            HasSuchEvents = False
            For Each Y As String In GetXDSFilter("EVENT ")
                If iGet(Y, 1, ",") = "2" Then HasSuchEvents = True
                If iGet(Y, 1, ",") = "3" Then HasSuchEvents = True
                If iGet(Y, 1, ",") = "4" Then HasSuchEvents = True
            Next
            If HasSuchEvents Then
                'FinalString += "    // Button Events" + vbcrlf
                FinalString += "    for (DSGMPL = 0; DSGMPL <= 127; DSGMPL++) {" + vbCrLf
                FinalString += "      if(Instances[DSGMPL].InUse) {" + vbCrLf
                For Each Y As String In GetXDSFilter("OBJECT ")
                    Y = Y.Substring(7)
                    Dim ObjectName As String = iGet(Y, 0, ",")
                    If GetXDSFilter("EVENT " + ObjectName + ",2,").Length > 0 Then
                        FinalString += "        if (Instances[DSGMPL].EName == " + ObjectName + ") {" + vbCrLf
                        For Each Z As String In GetXDSFilter("EVENT " + ObjectName + ",2,")
                            Dim TC As String = Z.Substring(Z.LastIndexOf(",") + 1)
                            FinalString += "          if(Pad.Newpress." + TC + ") " + ObjectName + "ButtonPress" + TC + "_Event(DSGMPL);" + vbCrLf
                        Next
                        FinalString += "        }" + vbCrLf
                    End If
                    If GetXDSFilter("EVENT " + ObjectName + ",3,").Length > 0 Then
                        FinalString += "        if (Instances[DSGMPL].EName == " + ObjectName + ") {" + vbCrLf
                        For Each Z As String In GetXDSFilter("EVENT " + ObjectName + ",3,")
                            Dim TC As String = Z.Substring(Z.LastIndexOf(",") + 1)
                            FinalString += "          if(Pad.Held." + TC + ") " + ObjectName + "ButtonHeld" + TC + "_Event(DSGMPL);" + vbCrLf
                        Next
                        FinalString += "        }" + vbCrLf
                    End If
                    If GetXDSFilter("EVENT " + ObjectName + ",4,").Length > 0 Then
                        FinalString += "        if (Instances[DSGMPL].EName == " + ObjectName + ") {" + vbCrLf
                        For Each Z As String In GetXDSFilter("EVENT " + ObjectName + ",4,")
                            Dim TC As String = Z.Substring(Z.LastIndexOf(",") + 1)
                            FinalString += "          if(Pad.Released." + TC + ") " + ObjectName + "ButtonReleased" + TC + "_Event(DSGMPL);" + vbCrLf
                        Next
                        FinalString += "        }" + vbCrLf
                    End If
                    DOn += 1
                Next
                FinalString += "      }" + vbCrLf
                FinalString += "    }" + vbCrLf
            End If
            FinalString += "    Frames += 1;" + vbCrLf
            FinalString += "    RoomFrames += 1;" + vbCrLf
            FinalString += "    if (Frames % 60 == 0) Seconds += 1;" + vbCrLf
            FinalString += "    if (Frames % 60 == 0) RoomSeconds += 1;" + vbCrLf
            'FinalString += "    for (DSGMPL = 0; DSGMPL <= 127; DSGMPL++) {" + vbcrlf
            'FinalString += "      if (Instances[DSGMPL].InUse && Instances[DSGMPL].FrameChanged) {" + vbcrlf
            'FinalString += "        PA_SetSpriteAnim(Instances[DSGMPL].Screen, DSGMPL, Instances[DSGMPL].Frame);" + vbcrlf
            'FinalString += "        Instances[DSGMPL].FrameChanged = false;" + vbcrlf
            'FinalString += "      }" + vbcrlf
            'FinalString += "    }" + vbcrlf
            'FinalString += "    for (DSGMPL = 0; DSGMPL < 255; DSGMPL++) {" + vbcrlf
            'FinalString += "      if (Instances[DSGMPL].InUse) Instances[DSGMPL].FrameChanged = false;" + vbcrlf
            'FinalString += "    }" + vbcrlf
            'FinalString += "    Frames += 1;" + vbcrlf
            'FinalString += "    RoomFrames += 1;" + vbcrlf
            'FinalString += "    if (Frames % 60 == 0) Seconds += 1;" + vbcrlf
            'FinalString += "    if (Frames % 60 == 0) RoomSeconds += 1;" + vbcrlf
            FinalString += "    DSGM_ObjectsSync();" + vbCrLf
            FinalString += "    DSGM_AlarmsSync();" + vbCrLf
            FinalString += "    PA_WaitForVBL();" + vbCrLf
            If TopScroll Then FinalString += _
            "    PA_EasyBgScrollXY(1, 2, RoomData.TopX, RoomData.TopY);" + vbCrLf
            If BottomScroll Then FinalString += _
            "    PA_EasyBgScrollXY(0, 2, RoomData.BottomX, RoomData.BottomY);" + vbCrLf
            FinalString += "  }" + vbCrLf
            FinalString += "  return true;" + vbCrLf
            FinalString += "}" + vbCrLf
        Next
        DOn = 0
        'Twas here 2, Marvolo!
        'FinalString += "  return true;" + vbcrlf
        'FinalString += "}" + vbcrlf + vbcrlf
        'File.WriteAllText(CompilePath + "gfx\PAGfx.ini", PAini)
        File.WriteAllText(CompilePath + "source\main.c", FinalString)
        Dim DefsString As String = String.Empty
        For Each XDSLine As String In GetXDSFilter("ROOM ")
            DefsString += "bool " + iGet(XDSLine.Substring(5), 0, ",") + "();" + vbCrLf
        Next
        For Each XDSLine As String In GetXDSFilter("SCRIPT ")
            Dim ScriptName As String = XDSLine.Substring(7)
            ScriptName = ScriptName.Substring(0, ScriptName.LastIndexOf(","))
            DefsString += "int " + ScriptName + "("
            Dim ArgumentString As String = String.Empty
            For Each YXDSLine As String In GetXDSFilter("SCRIPTARG " + ScriptName + ",")
                Dim ArgumentName As String = iGet(YXDSLine, 1, ",")
                Dim ArgumentType As String = GenerateCType(iGet(YXDSLine, 2, ","))
                ArgumentString += ArgumentType + " "
                If ArgumentType = "char" Then ArgumentString += "*"
                ArgumentString += ArgumentName + ", "
            Next
            If ArgumentString.Length = 0 Then
                DefsString += "void"
            Else
                ArgumentString = ArgumentString.Substring(0, ArgumentString.Length - 2)
                DefsString += ArgumentString
            End If
            DefsString += ");" + vbCrLf
        Next
        'fsdds()
        File.WriteAllText(CompilePath + "include\Defines.h", DefsString)
        'File.WriteAllBytes(CompilePath + "include\ActionWorks.h", My.Resources.ActionWorks)
        Dim GameString As String = String.Empty
        GameString += "#include ""dsgm_gfx.h""" + vbCrLf
        GameString += "#include ""custom_gfx.h""" + vbCrLf
        GameString += "#include ""Defines.h""" + vbCrLf
        GameString += "#include ""ActionWorks.h""" + vbCrLf + vbCrLf
        For Each X As String In GetXDSFilter("INCLUDE ")
            Dim FileName As String = X.Substring(8)
            GameString += "#include """ + FileName + """" + vbCrLf
            IO.File.Copy(SessionPath + "IncludeFiles\" + FileName, CompilePath + "include\" + FileName)
        Next
        For Each X As String In GetXDSFilter("SOUND ")
            If iGet(X, 1, ",") = "1" Then Continue For
            X = X.Substring(6)
            Dim SoundName As String = iGet(X, 0, ",")
            If File.Exists(CompilePath + "data\" + SoundName + ".raw") Then
                GameString += "#include """ + SoundName + ".h""" + vbCrLf
            Else
                GameString += "// Error converting " + SoundName + " with SOX! Sorry folks, use a proper WAV next time." + vbCrLf
            End If
        Next
        GameString += vbCrLf
        For Each XDSLine As String In GetXDSFilter("STRUCT ")
            Dim StructureName As String = XDSLine.Substring(7)
            GameString += "typedef struct {" + vbCrLf
            For Each Y As String In GetXDSFilter("STRUCTMEMBER " + StructureName + ",")
                Y = Y.Substring(("STRUCTMEMBER " + StructureName).Length + 1)
                Dim ItemName As String = Y.Substring(0, Y.IndexOf(","))
                Dim ItemType As String = Y.Substring(ItemName.Length + 1)
                ItemType = ItemType.Substring(0, ItemType.IndexOf(","))
                ItemType = GenerateCType(ItemType)
                Dim ItemValue As String = Y.Substring(Y.LastIndexOf(",") + 1).Replace("<comma>", ",")
                GameString += "  " + ItemType + " " + If(ItemType = "char", "*", String.Empty) + ItemName + ";" + vbCrLf
            Next
            GameString += "} " + StructureName + ";" + vbCrLf
            'GameString += StructureName + "Struct " + StructureName + ";" + vbcrlf
        Next
        GameString += vbCrLf
        For Each XDSLine As String In GetXDSFilter("GLOBAL ")
            Dim TempString As String = String.Empty
            XDSLine = XDSLine.Substring(7)
            Dim VariableName As String = iGet(XDSLine, 0, ",")
            Dim VariableType As String = iGet(XDSLine, 1, ",")
            Dim CVariableType As String = GenerateCType(VariableType)
            'If RealVariableType = "pie" Then RealVariableType = VariableType
            Dim VariableValue As String = iGet(XDSLine, 2, ",")
            TempString = CVariableType + " " + VariableName
            If CVariableType.ToLower = "char" Then
                TempString += "[128]"
            Else
                If Not DoesXDSLineExist("STRUCT " + VariableType) Then
                    If VariableValue.Length > 0 Then TempString += " = " + VariableValue
                End If
            End If
            GameString += TempString + ";" + vbCrLf
        Next
        GameString += vbCrLf
        For Each XDSLine As String In GetXDSFilter("ARRAY ")
            XDSLine = XDSLine.Substring(6)
            Dim VariableName As String = iGet(XDSLine, 0, ",")
            Dim VariableType As Byte = Convert.ToByte(iGet(XDSLine, 1, ","))
            Dim RealVariableType As String = String.Empty
            If VariableType = 0 Then RealVariableType = "s32"
            If VariableType = 1 Then RealVariableType = "bool"
            Dim ValuesString As String = iGet(XDSLine, 2, ",")
            ValuesString = ValuesString.Replace(";", ", ")
            GameString += RealVariableType + " " + VariableName + "[] = {" + ValuesString + "};" + vbCrLf
        Next
        GameString += vbCrLf
        If GetXDSFilter("OBJECT ").Length > 0 Then
            GameString += "enum ObjectEnums { "
            Dim ELooper As Byte = 1
            For Each P As String In GetXDSFilter("OBJECT ")
                P = P.Substring(7)
                P = P.Substring(0, P.IndexOf(","))
                GameString += P + " = " + ELooper.ToString + ", "
                ELooper += 1
            Next
            GameString += " };" + vbCrLf
        End If
        GameString += "void Set_Sprite(u8 InstanceID, char *SpriteName, bool DeleteOld);" + vbCrLf
        GameString += "void Create_Object(u8 ObjectEnum, u8 InstanceID, bool Screen, s16 X, s16 Y);" + vbCrLf
        GameString += "u8 Sprite_Get_ID(char *SpriteName);" + vbCrLf
        GameString += "u8 Room_Get_Index(char *RoomName);" + vbCrLf
        GameString += "void Goto_Room_Backend(u8 RoomIndex);" + vbCrLf
        GameString += "u8 Count_Instances(u8 ObjectEnum);" + vbCrLf
        GameString += "void Goto_Next_Room(void);" + vbCrLf + vbCrLf
        GameString += EventsString + vbCrLf
        For Each XDSLine As String In GetXDSFilter("SCRIPT ")
            XDSLine = XDSLine.Substring(7)
            Dim C As Boolean = (XDSLine.EndsWith(",0"))
            XDSLine = XDSLine.Substring(0, XDSLine.LastIndexOf(","))
            GameString += vbCrLf + ScriptParse(XDSLine, C) + vbCrLf
        Next
        GameString += vbCrLf
        'GameString += "s16 score = " + GetXDSLine("SCORE ").ToString.Substring(6) + ";" + vbcrlf
        'GameString += "s16 lives = " + GetXDSLine("LIVES ").ToString.Substring(6) + ";" + vbcrlf
        'GameString += "s16 health = " + GetXDSLine("HEALTH ").ToString.Substring(7) + ";" + vbcrlf
        'GameString += "u8 RoomCount = " + GetXDSFilter("ROOM ").Length.ToString + ";" + vbcrlf
        'GameString += "u8 CurrentRoom = 0;" + vbcrlf + vbcrlf
        DOn = 0
        GameString += "void Set_Sprite(u8 InstanceID, char *SpriteName, bool DeleteOld) {" + vbCrLf
        GameString += "  Instances[InstanceID].HasSprite = true;" + vbCrLf
        GameString += "  if (DeleteOld) PA_DeleteSprite(Instances[InstanceID].Screen, InstanceID);" + vbCrLf
        If GetXDSFilter("SPRITE ").Length > 0 Then
            GameString += "  switch(Sprite_Get_ID(SpriteName)) {" + vbCrLf
            For Each X As String In GetXDSFilter("SPRITE ")
                X = X.Substring(7)
                Dim SpriteName As String = iGet(X, 0, ",")
                Dim SW As String = iGet(X, 1, ",")
                Dim SH As String = iGet(X, 2, ",")
                Dim PalletNumber As Byte = 0
                Dim PalletNumber_Nitro As Byte = 0
                If iGet(X, 3, ",") = "Nitro" Then
                    For Each PalletString_Nitro As String In PalletNumbers_Nitro
                        If PalletString_Nitro.StartsWith(SpriteName + ",") Then
                            PalletNumber_Nitro = Convert.ToByte(PalletString_Nitro.Substring(PalletString_Nitro.IndexOf(",") + 1))
                        End If
                    Next
                    PalletNumber = PalletNumbers.Count
                Else
                    For Each PalletString As String In PalletNumbers
                        If PalletString.StartsWith(SpriteName + ",") Then
                            PalletNumber = Convert.ToByte(PalletString.Substring(PalletString.IndexOf(",") + 1))
                        End If
                    Next
                End If
                GameString += "    case " + DOn.ToString + ":" + vbCrLf
                GameString += "      Instances[InstanceID].Width = " + SW + "; Instances[InstanceID].Height = " + SH + ";" + vbCrLf

                If iGet(X, 3, ",") = "Nitro" Then
                    'Fix palette
                    ' Nitro + DSGM
                    GameString += "      FAT_BasicCreateSprite(Instances[InstanceID].Screen, InstanceID, " + (PalletNumber_Nitro + PalletNumber).ToString + ", """ + SpriteName + "_Sprite.bin"", """ + "NitroPal" + PalletNumber_Nitro.ToString + "_Pal.bin"", OBJ_SIZE_" + SW + "X" + SH + ", 256, 192);" + vbCrLf
                Else
                    GameString += "      PA_CreateSprite(Instances[InstanceID].Screen, InstanceID, (void*)" + SpriteName + "_Sprite, " + _
                                         "OBJ_SIZE_" + SW + "X" + SH + ", 1, " + PalletNumber.ToString + ", 256, 192);" + vbCrLf
                End If

                GameString += "      break;" + vbCrLf
                DOn += 1
            Next
            GameString += "  }" + vbCrLf
        End If
        'FinalString += "  return true;" + vbcrlf
        GameString += "}" + vbCrLf + vbCrLf
        DOn = 0
        GameString += "void Create_Object(u8 ObjectEnum, u8 InstanceID, bool Screen, s16 X, s16 Y) {" + vbCrLf
        'GameString += "  strcpy(Instances[InstanceID].Name, ObjectName);" + vbCrLf
        GameString += "  Instances[InstanceID].EName = ObjectEnum;"
        GameString += "  Instances[InstanceID].InUse = true; Instances[InstanceID].Screen = Screen;" + vbCrLf
        GameString += "  Instances[InstanceID].OriginalX = X; Instances[InstanceID].OriginalY = Y;" + vbCrLf
        GameString += "  Instances[InstanceID].X = X; Instances[InstanceID].Y = Y;" + vbCrLf
        GameString += "  Instances[InstanceID].VX = 0; Instances[InstanceID].VY = 0;" + vbCrLf
        If GetXDSFilter("OBJECT ").Length > 0 Then
            For Each X As String In GetXDSFilter("OBJECT ")
                X = X.Substring(7)
                Dim ObjectName As String = iGet(X, 0, ",")
                Dim ObjectFrame As Int16 = Convert.ToInt16(iGet(X, 2, ","))
                Dim SpriteName As String = iGet(GetXDSLine("OBJECT " + ObjectName + ","), 1, ",")
                If DOn = 0 Then
                    GameString += "  if (ObjectEnum == " + ObjectName + ") {" + vbCrLf
                Else
                    GameString += "  } else if (ObjectEnum == " + ObjectName + ") {" + vbCrLf
                End If
                If Not SpriteName = "None" Then
                    Dim SpriteLine As String = GetXDSLine("SPRITE " + SpriteName + ",")
                    Dim SW As Byte = Convert.ToByte(iGet(SpriteLine, 1, ","))
                    Dim SH As Byte = Convert.ToByte(iGet(SpriteLine, 2, ","))
                    GameString += "     Instances[InstanceID].HasSprite = true;" + vbCrLf
                    GameString += "     Set_Sprite(InstanceID, """ + SpriteName + """, false);" + vbCrLf
                    If ObjectFrame > 0 Then GameString += "     Set_Frame(InstanceID, " + ObjectFrame.ToString + ");" + vbCrLf
                Else
                    GameString += "     Instances[InstanceID].HasSprite = false;" + vbCrLf
                    'FinalString += "     PA_CreateSprite(Screen, InstanceID, (void*)" + SpriteName + "_Sprite, OBJ_SIZE_" + SW.ToString + "X" + SH.ToString + ", 1, " + PalletNumber.ToString + ", 256, 192);" + vbcrlf
                End If
                'FinalString += "     #ifdef " + ObjectName + "CreateExists" + vbcrlf
                If DoesXDSLineExist("EVENT " + ObjectName + ",1,NoData") Then
                    GameString += "     " + ObjectName + "Create_Event(InstanceID);" + vbCrLf
                End If
                'FinalString += "       " + ObjectName + "Create_Event(" + DOn.ToString + ");" + vbcrlf
                'FinalString += "     #endif" + vbcrlf
                'GameString += "     break;" + vbcrlf
                DOn += 1
            Next
            GameString += "  }" + vbCrLf + vbCrLf
        End If
        'GameString += "  return true;" + vbcrlf
        GameString += "}" + vbCrLf
        DOn = 0
        GameString += "u8 Sprite_Get_ID(char *SpriteName) {" + vbCrLf
        For Each X As String In GetXDSFilter("SPRITE ")
            X = X.Substring(7)
            Dim SpriteName As String = iGet(X, 0, ",")
            GameString += " if (strcmp(SpriteName, """ + SpriteName + """) == 0) return " + DOn.ToString + ";" + vbCrLf
            DOn += 1
        Next
        GameString += " return 0;" + vbCrLf
        GameString += "}" + vbCrLf + vbCrLf
        DOn = 0
        GameString += "u8 Room_Get_Index(char *RoomName) {" + vbCrLf
        For Each X As String In GetXDSFilter("ROOM ")
            X = X.Substring(5)
            Dim RoomName As String = iGet(X, 0, ",")
            GameString += " if (strcmp(RoomName, """ + RoomName + """) == 0) return " + DOn.ToString + ";" + vbCrLf
            DOn += 1
        Next
        GameString += " return 0;" + vbCrLf
        GameString += "}" + vbCrLf + vbCrLf
        DOn = 0
        GameString += "void Goto_Room_Backend(u8 RoomIndex) {" + vbCrLf
        GameString += "  RoomFrames = 0;" + vbCrLf
        GameString += "  RoomSeconds = 0;" + vbCrLf
        For Each X As String In GetXDSFilter("ROOM ")
            X = X.Substring(5)
            Dim RoomName As String = iGet(X, 0, ",")
            GameString += "  if (RoomIndex == " + DOn.ToString + ") " + RoomName + "();" + vbCrLf
            DOn += 1
        Next
        GameString += "}" + vbCrLf + vbCrLf
        GameString += "void Goto_Next_Room(void) {" + vbCrLf
        GameString += " if (CurrentRoom < RoomCount) {" + vbCrLf
        GameString += "  CurrentRoom += 1;" + vbCrLf
        GameString += "  Goto_Room_Backend(CurrentRoom);" + vbCrLf
        GameString += " }" + vbCrLf
        GameString += "}" + vbCrLf + vbCrLf
        'GameString += "void Goto_Room(char *RoomName) {" + vbcrlf
        'GameString += "  Goto_Room_Backend(Room_Get_Index(RoomName));" + vbcrlf
        'GameString += "}" + vbcrlf
        File.WriteAllText(CompilePath + "include\GameWorks.h", GameString)
        Dim MF As String = _
              "ARM7_SELECTED = ARM7_MP3_DSWIFI" + vbCrLf
        MF += "USE_NITROFS  = YES" + vbCrLf
        MF += "NITRODATA   := nitrofiles" + vbCrLf
        MF += "TEXT1        := " + GetXDSLine("PROJECTNAME ").ToString.Substring(12) + vbCrLf
        MF += "TEXT2        := " + GetXDSLine("TEXT2 ").ToString.Substring(6) + vbCrLf
        MF += "TEXT3        := " + GetXDSLine("TEXT3 ").ToString.Substring(6) + vbCrLf
        MF += "TARGET       := $(shell basename $(CURDIR))" + vbCrLf
        MF += "BUILD        := build" + vbCrLf
        MF += "SOURCES      := source data gfx/bin" + vbCrLf
        MF += "INCLUDES     := include build data gfx" + vbCrLf
        MF += "RELEASEPATH  := " + vbCrLf
        MF += "MAKEFILE_VER := ver2" + vbCrLf
        MF += "include " + CDrive + "devkitPro\PAlib\lib\PA_Makefile" + vbCrLf
        System.IO.File.WriteAllText(CompilePath + "Makefile", MF)
        Compile.CustomPerformStep("Processing Graphics")
        Dim MyProcess As New Process
        Dim MyInfo As New ProcessStartInfo
        If RedoAllGraphics Or BGsToRedo.Count > 0 Or RedoSprites Then
            With MyInfo
                .FileName = CompilePath + "gfx\PAGfx.exe"
                .WorkingDirectory = CompilePath + "gfx"
            End With
            With MyProcess
                .StartInfo = MyInfo
                .Start()
                .WaitForExit()
            End With
        End If
        File.Delete(CompilePath + "gfx\PAGfx.txt")
        File.Delete(CompilePath + "gfx\all_gfx.h")
        'Make a hacky GFX file ...
        Dim DSGMH As String = String.Empty
        DSGMH += "#pragma once" + vbCrLf
        DSGMH += "#include <PA_BgStruct.h>" + vbCrLf + vbCrLf
        DSGMH += "//Sprites:" + vbCrLf
        For Each X As String In GetXDSFilter("SPRITE ")
            X = X.Substring(7)
            If iGet(GetXDSLine("SPRITE " + X), 3, ",") = "Nitro" Then
                If File.Exists(CompilePath + "gfx\bin\" + iGet(X, 0, ",") + "_Sprite.bin") Then
                    If File.Exists(CompilePath + "nitrofiles\" + iGet(X, 0, ",") + "_Sprite.bin") Then File.Delete(CompilePath + "nitrofiles\" + iGet(X, 0, ",") + "_Sprite.bin")
                    File.Move(CompilePath + "gfx\bin\" + iGet(X, 0, ",") + "_Sprite.bin", CompilePath + "nitrofiles\" + iGet(X, 0, ",") + "_Sprite.bin")
                End If
                Dim PalletNumber As Byte = 0
                For Each PalletString As String In PalletNumbers
                    If PalletString.StartsWith(X + ",") Then
                        PalletNumber = Convert.ToByte(PalletString.Substring(PalletString.IndexOf(",") + 1))
                    End If
                Next

                If File.Exists(CompilePath + "gfx\bin\" + "NitroPal" + PalletNumber.ToString + "_Pal.bin") Then
                    If File.Exists(CompilePath + "nitrofiles\" + "NitroPal" + PalletNumber.ToString + "_Pal.bin") Then File.Delete(CompilePath + "nitrofiles\" + "NitroPal" + PalletNumber.ToString + "_Pal.bin")
                    File.Move(CompilePath + "gfx\bin\" + "NitroPal" + PalletNumber.ToString + "_Pal.bin", CompilePath + "nitrofiles\" + "NitroPal" + PalletNumber.ToString + "_Pal.bin")
                End If
            Else
                Dim SpriteName As String = X.Substring(0, X.IndexOf(","))
                Dim TheSize As Size = GenerateDSSprite(SpriteName).Size
                Dim Timez As Int64 = TheSize.Width * TheSize.Height
                DSGMH += "  extern const unsigned char " + SpriteName + "_Sprite[" + Timez.ToString + "] _GFX_ALIGN;" + vbCrLf
            End If
        Next
        DSGMH += vbCrLf + "//Backgrounds:" + vbCrLf
        For Each X As String In GetXDSFilter("BACKGROUND ")
            X = X.Substring(11)
            If iGet(GetXDSLine("BACKGROUND " + X), 1, ",") = "Nitro" Then

                If File.Exists(CompilePath + "gfx\bin\" + iGet(X, 0, ",") + "_Map.bin") Then
                    If File.Exists(CompilePath + "nitrofiles\" + iGet(X, 0, ",") + "_Map.bin") Then File.Delete(CompilePath + "nitrofiles\" + iGet(X, 0, ",") + "_Map.bin")
                    File.Move(CompilePath + "gfx\bin\" + iGet(X, 0, ",") + "_Map.bin", CompilePath + "nitrofiles\" + iGet(X, 0, ",") + "_Map.bin")
                End If
                If File.Exists(CompilePath + "gfx\bin\" + iGet(X, 0, ",") + "_Tiles.bin") Then
                    If File.Exists(CompilePath + "nitrofiles\" + iGet(X, 0, ",") + "_Tiles.bin") Then File.Delete(CompilePath + "nitrofiles\" + iGet(X, 0, ",") + "_Tiles.bin")
                    File.Move(CompilePath + "gfx\bin\" + iGet(X, 0, ",") + "_Tiles.bin", CompilePath + "nitrofiles\" + iGet(X, 0, ",") + "_Tiles.bin")
                End If
                If File.Exists(CompilePath + "gfx\bin\" + iGet(X, 0, ",") + "_Pal.bin") Then
                    If File.Exists(CompilePath + "nitrofiles\" + iGet(X, 0, ",") + "_Pal.bin") Then File.Delete(CompilePath + "nitrofiles\" + iGet(X, 0, ",") + "_Pal.bin")
                    File.Move(CompilePath + "gfx\bin\" + iGet(X, 0, ",") + "_Pal.bin", CompilePath + "nitrofiles\" + iGet(X, 0, ",") + "_Pal.bin")
                End If
                If File.Exists(CompilePath + "gfx\bin\" + iGet(X, 0, ",") + ".c") Then
                    If File.Exists(CompilePath + "nitrofiles\" + iGet(X, 0, ",") + ".c") Then File.Delete(CompilePath + "nitrofiles\" + iGet(X, 0, ",") + ".c")
                    File.Move(CompilePath + "gfx\bin\" + iGet(X, 0, ",") + ".c", CompilePath + "nitrofiles\" + iGet(X, 0, ",") + ".c")
                End If
            Else
                DSGMH += "  extern const PA_BgStruct " + X + ";" + vbCrLf
            End If
        Next
        If PalletNames.Count > 0 Then
            DSGMH += vbCrLf + "//Pallets:" + vbCrLf
            For i As Byte = 0 To PalletNames.Count - 1
                'BRB!
                DSGMH += "  extern const unsigned short DSGMPal" + i.ToString + "_Pal[256] _GFX_ALIGN;" + vbCrLf
            Next
        End If
        File.WriteAllText(CompilePath + "gfx\dsgm_gfx.h", DSGMH)
        Compile.CustomPerformStep("Compiling Game")
        With MyInfo
            .FileName = CompilePath + "build.bat"
            .WorkingDirectory = CompilePath
        End With
        With MyProcess
            .StartInfo = MyInfo
            .Start()
            .WaitForExit()
        End With
        If File.Exists(CompilePath + CompileName + ".nds") Then
            RedoAllGraphics = False
            RedoSprites = False
            BGsToRedo.Clear()
            SoundsToRedo.Clear()
            FontsUsedLastTime.Clear()
            For Each X As String In FontsUsedThisTime
                FontsUsedLastTime.Add(X)
            Next
            Return True
        End If
        Return False
    End Function

    Public Function FormNOGBAPath() As String
        Dim Returnable As String = AppPath + "NO$GBA"
        If Not Directory.Exists(Returnable) Then Returnable = "C:\NO$GBA"
        Return Returnable
    End Function

    Public Sub NOGBAShizzle()
        If Convert.ToByte(GetSetting("USE_NOGBA")) = 1 Then
            If Not Directory.Exists(FormNOGBAPath()) Then
                MsgError("NO$GBA was not found." + vbcrlf + vbcrlf + "Please reinstall " + Application.ProductName + ".")
                Exit Sub
            End If
            'MsgError(CompilePath + GetXDSLine("PROJECTNAME ").ToString.Substring(12) + ".nds")
            Diagnostics.Process.Start(FormNOGBAPath() + "\NO$GBA.exe", CompilePath + "DSGMTemp" + Session + ".nds")
        Else
            If Not File.Exists(GetSetting("EMULATOR_PATH")) Then
                MsgError("The selected Custom Emulator does not exist.")
                Exit Sub
            End If
            Diagnostics.Process.Start(GetSetting("EMULATOR_PATH"), CompilePath + "DSGMTemp" + Session + ".nds")
        End If
    End Sub

    Function HowManyChar(ByVal TheText As String, ByVal WhichChar As String) As Int16
        If TheText.Length = 0 Then Return 0
        Dim Returnable As Int16 = 0
        For X As Int32 = 0 To TheText.Length - 1
            If TheText.Substring(X, 1) = WhichChar Then Returnable += 1
        Next
        Return Returnable
    End Function

    Function IsNumeric(ByVal val As String, ByVal NumberStyle As System.Globalization.NumberStyles) As Boolean
        Return [Double].TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, 0)
    End Function

    Sub MsgWarn(ByVal msg As String)
        MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Sub MsgError(ByVal msg As String)
        MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Sub MsgInfo(ByVal msg As String, Optional ByVal title As String = "DS Game Maker")
        MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Function CanDevide(ByVal num1 As Int16, ByVal num2 As Int16)
        If num1 = 0 Or num2 = 0 Then Return False
        If num1 Mod num2 = 0 Then Return True Else Return False
    End Function

    Function ImageCountColors(ByVal TheImage As Bitmap) As Int16
        Dim DOn As Int16 = 0
        If TheImage.Palette.Entries.Length = 0 Then
            Dim AllColors As New Collection
            For X As Int16 = 0 To TheImage.Width - 1
                For Y As Int16 = 0 To TheImage.Height - 1
                    Dim TheColor As Color = TheImage.GetPixel(X, Y)
                    Dim TheColorString As String = TheColor.R.ToString + TheColor.G.ToString + TheColor.B.ToString
                    Dim AlreadyThere As Boolean = False
                    For Each P As String In AllColors
                        If P = TheColorString Then AlreadyThere = True : Exit For
                    Next
                    If Not AlreadyThere Then AllColors.Add(TheColorString)
                Next
            Next
            Return AllColors.Count
        Else
            For Each MyColor As Color In TheImage.Palette.Entries
                If Not DOn = 0 And MyColor.R = 0 And MyColor.G = 0 And MyColor.B = 0 Then Exit For
                DOn += 1
            Next
            Return DOn
        End If
    End Function

    Public Function EditImage(ByVal FilePath As String, ByVal ResourceName As String, ByVal CustomMessage As Boolean) As Boolean
        Dim FinalName As String = String.Empty
        Dim FinalEXE As String = String.Empty
        FinalEXE = GetSetting("IMAGE_EDITOR_PATH")
        If File.Exists(FinalEXE) Then
            System.Diagnostics.Process.Start(FinalEXE, """" + FilePath + """")
        Else
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\mspaint.exe", """" + FilePath + """")
        End If
        Dim Message As String = "'" + ResourceName + "' has been opened. When you are finished, click 'OK'." + vbcrlf + vbcrlf + "To reverse any changes, please click 'Cancel'."
        If CustomMessage Then
            Message = "'" + ResourceName + "' has been opened. When you are finished, click 'OK'." + vbcrlf + vbcrlf + "You should then re-add the Frame to the Sprite."
        End If
        Dim Response As Byte = MessageBox.Show(Message, Application.ProductName, If(CustomMessage, MessageBoxButtons.OK, MessageBoxButtons.OKCancel), MessageBoxIcon.Information)
        If Response = MsgBoxResult.Ok Then Return True Else Return False
    End Function

    Public Function EditSound(ByVal FilePath As String, ByVal ResourceName As String) As Boolean
        System.Diagnostics.Process.Start(GetSetting("SOUND_EDITOR_PATH"), """" + FilePath + """")
        Dim Message As String = "'" + ResourceName + "' has been opened. When you are finished, click 'OK'." + vbcrlf + vbcrlf + "To reverse any changes, please click 'Cancel'."
        Dim Response As Byte = MessageBox.Show(Message, Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        If Response = MsgBoxResult.Ok Then Return True Else Return False
    End Function

    Public Enum ValidateLevel As Byte
        None = 0
        NumberStart = 2
        Loose = 4
        Tight = 5
    End Enum

    Public Enum CodeMode As Byte
        DBAS = 0
        XDS = 1
        C = 2
    End Enum

    Public Function ValidateSomething(ByVal ThingToValidate As String, ByVal VMode As Byte) As Boolean
        If VMode = ValidateLevel.None Then Return True
        If ThingToValidate.Contains("!") Then Return False
        If ThingToValidate.Length = 0 Then Return False
        Dim Returnable As Boolean = True
        If VMode = ValidateLevel.NumberStart Or VMode = ValidateLevel.Loose Then
            If ThingToValidate.StartsWith(" ") Then Returnable = False
            For Each Number As String In Numbers
                If ThingToValidate.StartsWith(Number) Then Returnable = False
            Next
        End If
        If VMode = ValidateLevel.Tight Then
            For Each BannedChar As String In BannedChars
                If ThingToValidate.Contains(BannedChar) Then Returnable = False
            Next
        End If
        Return Returnable
    End Function

    Public Function OpenFile(ByVal Directory As String, ByVal Filter As String) As String
        Dim Returnable As String
        Dim OFD As New OpenFileDialog
        With OFD
            .InitialDirectory = Directory
            .FileName = String.Empty
            .Filter = Filter
            .Title = "Open File"
            If Not .ShowDialog() = Windows.Forms.DialogResult.OK Then Returnable = String.Empty Else Returnable = .FileName
            .Dispose()
        End With
        If Returnable.Length > 0 Then
            Dim PR As String = Returnable.Substring(0, Returnable.LastIndexOf("\"))
            LoadDefaultFolder = PR
        End If
        Return Returnable
    End Function

    Sub XDSChangeLine(ByVal Input As String, ByVal ChangeTo As String)
        Dim FinalString As String = String.Empty
        For Each XDSLine As String In StringToLines(CurrentXDS)
            If XDSLine = Input Then XDSLine = ChangeTo
            FinalString += XDSLine + vbcrlf
        Next
        CurrentXDS = FinalString
    End Sub

    Public Function GetInput(ByVal Descriptor As String, ByVal DefaultValue As String, ByVal VM As Byte) As String
        Dim X As New InputBoxForm
        X.Descriptor = Descriptor
        X.TheInput = DefaultValue
        X.Validation = VM
        X.ShowDialog()
        Dim ToGive As String = X.TheInput
        X.Dispose()
        Return ToGive
    End Function

    Public Function SelectColor(ByVal InputColor As Color) As Color
        Dim CPicker As New ColorDialog
        With CPicker
            .AllowFullOpen = False
            .AnyColor = True
            .Color = InputColor
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then Return .Color
        End With
        Return InputColor
    End Function

    Public Function PathToString(ByVal path As String) As String
        Return System.Text.Encoding.ASCII.GetString(SafeGetFileData(path))
    End Function

    Function PathToImage(ByVal path As String) As Image
        Dim imgData() As Byte = SafeGetFileData(path)
        Return New Bitmap(System.Drawing.Image.FromStream(New MemoryStream(imgData)))
    End Function

    Function SafeGetFileData(ByVal filePath As String) As Byte()
        Dim MyFileStream As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim MyBinaryReader As BinaryReader = New BinaryReader(MyFileStream)
        Dim FinalData() As Byte = MyBinaryReader.ReadBytes(CType(MyFileStream.Length, Integer))
        MyBinaryReader.Close()
        MyFileStream.Close()
        Return FinalData
    End Function

    Function MakeBMPTransparent(ByVal InputImage As Image, ByVal InputColor As Color) As Image
        Dim Returnable As Bitmap = InputImage
        Returnable.MakeTransparent(InputColor)
        Return Returnable
        Returnable.Dispose()
    End Function

    Dim Positions As New List(Of Int16)

    Public Enum ResourceIDs
        Sprite = 0
        DObject = 1
        Background = 2
        Sound = 3
        Room = 4
        Path = 5
        Script = 6
    End Enum

    Sub XDSAddLine(ByVal NewLineContent As String)
        CurrentXDS += vbcrlf + NewLineContent
    End Sub

    Function XDSCountLines(ByVal Filter As String) As Int16
        Dim Returnable As Int16 = 0
        For Each XDSLine As String In StringToLines(CurrentXDS)
            If XDSLine.StartsWith(Filter) Then Returnable += 1
        Next
        Return Returnable
    End Function

    Function MakeResourceName(ByVal ResourcePrefix As String, ByVal XDSPrefix As String) As String
        For i As Int16 = 1 To 1024
            If XDSCountLines(XDSPrefix + " " + ResourcePrefix + "_" + i.ToString) = 0 Then Return ResourcePrefix + "_" + i.ToString
        Next
        Return String.Empty
    End Function

    Sub UpdateArrayActionsName(ByVal ResourceTypeString As String, ByVal OldName As String, ByVal NewName As String, ByVal AppliesToAlso As Boolean)
        For Each X As Form In MainForm.MdiChildren
            If Not X.Name = "DObject" Then Continue For
            Dim DForm As DObject = DirectCast(X, DObject)
            For DOn As Int16 = 0 To DForm.ActionArguments.Count - 1
                Dim Y As String = DForm.ActionArguments(DOn)
                'Dim NewString As String = String.Empty
                Dim ActionName As String = DForm.Actions(DOn)
                Dim NewArgumentString = String.Empty
                Dim TypeString As String = GetActionTypes(ActionName)
                For P As Byte = 0 To HowManyChar(TypeString, ",")
                    Dim ToAdd As String = iGet(Y, P, ";")
                    Dim TType As String = iGet(TypeString, P, ",")
                    If TType = ResourceTypeString And ToAdd = OldName Then ToAdd = NewName
                    NewArgumentString += ToAdd + ";"
                Next
                NewArgumentString = NewArgumentString.Substring(0, NewArgumentString.Length - 1)
                'MsgError("Y is " + Y)
                'MsgError("NewString is " + NewArgumentString)
                'Y = iget(Y, 0, ",") + "," + iget(Y, 1, ",") + "," + iget(Y, 2, ",") + "," + ActionName + "," + NewArgumentString + "," + iget(Y, 5, ",")
                If Not NewArgumentString = Y Then
                    DForm.ActionArguments(DOn) = NewArgumentString
                    DForm.ActionDisplays(DOn) = ActionEquateDisplay(ActionName, NewArgumentString)
                End If
                'Something here, James?
                'Damn, shouldn't do more than one thing at once >.<
            Next
            If AppliesToAlso Then
                For Don As Int16 = 0 To DForm.ActionAppliesTos.Count - 1
                    If DForm.ActionAppliesTos(Don) = OldName Then
                        DForm.ActionAppliesTos(Don) = NewName
                    End If
                Next
            End If
            DForm.ActionsList.Refresh()
        Next
    End Sub

    Dim TempSpaces As Byte = 0
    Dim GAmount As Byte = 2

    Public Sub IntelliSense(ByRef TheControl As ScintillaNet.Scintilla)
        Dim Starters() As String = {"if", "while", "for", "with"}
        Dim Enders() As String = {"end if", "end while", "next", "end with"}
        Dim CapsEnders() As String = {"End If", "End While", "Next", "End With"}
        Dim P As String = TheControl.Lines(TheControl.Caret.LineNumber - 1).Text
        P = P.Substring(0, P.Length - 2)
        If P.Length = 0 Then Exit Sub
        Dim SpaceCount As SByte = 0
        For i As Byte = 0 To P.Length - 1
            If Not P.Substring(i).StartsWith(" ") Then Exit For
            SpaceCount += 1
        Next
        Dim F As String = P.Substring(SpaceCount).ToLower
        Dim Amount As Byte = 1
        If SpaceCount Mod 2 = 0 Then Amount = 2
        Dim FID As Byte = 100
        For DOn As Byte = 0 To Starters.Count - 1
            If F.StartsWith(Starters(DOn) + " ") Then FID = DOn : Exit For
        Next
        If Not FID = 100 Then
            TheControl.InsertText(MakeSpaces(SpaceCount + Amount))
            Dim DoAdd As Boolean = True
            For i As Byte = TheControl.Caret.LineNumber To TheControl.Lines.Count - 1
                Dim L As String = TheControl.Lines(i).Text
                L = L.Substring(0, L.Length - 2).ToLower
                If L.Length = 0 Or L.Length <= SpaceCount Then Continue For
                L = L.Substring(SpaceCount)
                If L = Enders(FID).ToLower Then DoAdd = False
            Next
            If DoAdd Then
                Dim BackupPos As Int16 = TheControl.Caret.Position
                TheControl.InsertText(vbcrlf + MakeSpaces(SpaceCount) + CapsEnders(FID))
                TheControl.Caret.Position = BackupPos
                TheControl.Selection.Length = 0
            End If
            Exit Sub
        End If
        Dim IsOne As Boolean = False
        For Each D As String In Enders
            If F = D Then IsOne = True
        Next
        If F.StartsWith("next ") Then IsOne = True
        If IsOne And SpaceCount = TempSpaces Then
            SpaceCount -= Amount
            Dim FX As String = P
            If FX.StartsWith(MakeSpaces(Amount)) Then
                FX = FX.Substring(Amount)
                TheControl.Lines(TheControl.Caret.LineNumber - 1).Text = FX
            End If
        End If
        If SpaceCount < 0 Then SpaceCount = 0
        TempSpaces = SpaceCount
        TheControl.InsertText(MakeSpaces(SpaceCount))
    End Sub

    Sub SilentMoveFile(ByVal FromPath As String, ByVal ToPath As String)
        Dim BackupDate As Date = File.GetLastWriteTime(FromPath)
        File.Move(FromPath, ToPath)
        File.SetLastWriteTime(ToPath, BackupDate)
    End Sub

    Function UpdateActionsName(ByVal StringToChange As String, ByVal ResourceTypeString As String, ByVal OldName As String, ByVal NewName As String, ByVal AppliesToAlso As Boolean) As String
        Dim FinalString As String = String.Empty
        For Each Y As String In StringToLines(StringToChange)
            If Y.StartsWith("ACT ") Then
                Dim ActionName As String = iGet(Y, 3, ",")
                Dim InputtedArgumentString As String = iGet(Y, 4, ",")
                Dim NewArgumentString = String.Empty
                Dim TypeString As String = GetActionTypes(ActionName)
                For P As Byte = 0 To HowManyChar(TypeString, ",")
                    Dim ToAdd As String = iGet(InputtedArgumentString, P, ";")
                    Dim TType As String = iGet(TypeString, P, ",")
                    If TType = ResourceTypeString And ToAdd = OldName Then ToAdd = NewName
                    NewArgumentString += ToAdd + ";"
                Next
                NewArgumentString = NewArgumentString.Substring(0, NewArgumentString.Length - 1)
                Dim Thing As String = iGet(Y, 5, ",")
                If AppliesToAlso Then
                    If Thing = OldName Then Thing = NewName
                End If
                Y = iGet(Y, 0, ",") + "," + iGet(Y, 1, ",") + "," + iGet(Y, 2, ",") + "," + ActionName + "," + NewArgumentString + "," + Thing
            End If
            FinalString += Y + vbcrlf
        Next
        Return FinalString
    End Function

    Sub DeleteResource(ByVal ResourceName As String, ByVal Type As String)
        Dim DOn As Int16 = 0
        If Type = "Room" And GetXDSFilter("ROOM ").Length < 2 Then
            MsgWarn("You must always have at least one room in a Project.")
            Exit Sub
        End If
        Dim Response As Byte = MessageBox.Show("Are you sure you would like to delete '" + ResourceName + "'?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Not Response = MsgBoxResult.Yes Then Exit Sub
        If Type = "Sprite" Then
            DOn = 0
            'For Each X As String In GraphicsToRedo
            '    If X = ResourceName Then GraphicsToRedo.RemoveAt(DOn)
            '    DOn += 1
            'Next
            If Directory.Exists(CompilePath + "build") Then
                For Each X As String In Directory.GetFiles(CompilePath + "build")
                    If X.EndsWith("\" + ResourceName + "_Sprite.h") Or X.EndsWith("\" + ResourceName + "_Sprite.o") Then
                        File.Delete(X)
                    End If
                Next
            End If
            If File.Exists(CompilePath + "gfx\" + ResourceName + ".png") Then
                File.Delete(CompilePath + "gfx\" + ResourceName + ".png")
            End If
            If File.Exists(CompilePath + "gfx\bin\" + ResourceName + "_Sprite.bin") Then
                File.Delete(CompilePath + "gfx\bin\" + ResourceName + "_Sprite.bin")
            End If
            XDSRemoveLine(GetXDSLine("SPRITE " + ResourceName + ","))
            For Each X As String In Directory.GetFiles(SessionPath + "Sprites")
                If X.EndsWith("_" + ResourceName + ".png") Then IO.File.Delete(X)
            Next
            Dim AffectedObjects As New List(Of String)
            For Each X As String In GetXDSFilter("OBJECT ")
                If iGet(X, 1, ",") = ResourceName Then
                    Dim ObjectName As String = iGet(X, 0, ",").Substring(7)
                    Dim NewLine As String = "OBJECT " + ObjectName + ",None,0"
                    XDSChangeLine(X, NewLine)
                    AffectedObjects.Add(ObjectName)
                End If
            Next
            'Update rooms if they contain affected objects >.<
            For Each X As Form In MainForm.MdiChildren
                If X.Name = "Room" Then
                    Dim DForm As Room = DirectCast(X, Room)
                    Dim TopAffected As Byte = 0
                    Dim BottomAffected As Byte = 0
                    DOn = 0
                    For DOn = 0 To DForm.Objects.Count - 1
                        If AffectedObjects.Contains(DForm.Objects(DOn).ObjectName) Then
                            If DForm.Objects(DOn).Screen Then TopAffected += 1 Else BottomAffected += 1
                            DForm.Objects(DOn).CacheImage = ObjectGetImage(DForm.Objects(DOn).ObjectName)
                        End If
                    Next
                    If TopAffected > 0 Then DForm.RefreshRoom(True)
                    If BottomAffected > 0 Then DForm.RefreshRoom(False)
                ElseIf X.Name = "DObject" Then
                    Dim DForm As DObject = DirectCast(X, DObject)
                    Dim SpriteName As String = DForm.GetSpriteName
                    If SpriteName = ResourceName Then DForm.DeleteSprite()
                    DForm.MyXDSLines = UpdateActionsName(DForm.MyXDSLines, "Sprite", ResourceName, "<Unknown>", False)
                    UpdateArrayActionsName("Sprite", ResourceName, "<Unknown>", False)
                End If
            Next
            CurrentXDS = UpdateActionsName(CurrentXDS, "Object", ResourceName, "<Unknown>", False)
            For Each X As TreeNode In MainForm.ResourcesTreeView.Nodes(ResourceIDs.Sprite).Nodes
                If X.Text = ResourceName Then X.Remove() : Exit For
            Next
        ElseIf Type = "DObject" Then
            XDSRemoveLine(GetXDSLine("OBJECT " + ResourceName + ","))
            XDSRemoveFilter("EVENT " + ResourceName + ",")
            XDSRemoveFilter("ACT " + ResourceName + ",")
            XDSRemoveFilter("OBJECTPLOT " + ResourceName + ",")
            For Each X As Form In MainForm.MdiChildren
                If X.Text = ResourceName Then Continue For
                If X.Name = "Room" Then
                    Dim DForm As Room = DirectCast(X, Room)
                    DForm.RemoveObjectFromDropper(ResourceName)
                    Dim TopAffected As Byte = 0
                    Dim BottomAffected As Byte = 0
                    DOn = 0
                    For Each Y As Room.AnObject In DForm.Objects
                        If Y.InUse And Y.ObjectName = ResourceName Then
                            DForm.Objects(DOn).CacheImage = Nothing
                            DForm.Objects(DOn).InUse = False
                            DForm.Objects(DOn).ObjectName = String.Empty
                            DForm.Objects(DOn).X = 0 : DForm.Objects(DOn).Y = 0
                            If DForm.Objects(DOn).Screen Then TopAffected += 1 Else BottomAffected += 1
                        End If
                        DOn += 1
                    Next
                    If TopAffected > 0 Then DForm.RefreshRoom(True)
                    If BottomAffected > 0 Then DForm.RefreshRoom(False)
                ElseIf X.Name = "DObject" Then
                    Dim DForm As DObject = DirectCast(X, DObject)
                    Dim FinalXDS As String = String.Empty
                    For Each Y As String In StringToLines(DForm.MyXDSLines)
                        If Y.Length = 0 Then Continue For
                        If Y.StartsWith("EVENT ") Then
                            If iGet(Y, 1, ",") = "6" And iGet(Y, 2, ",") = ResourceName Then Y = iGet(Y, 0, ",") + ",6,<Unknown>"
                        End If
                        'If Y.StartsWith("ACT ") And Y.EndsWith("," + ResourceName) Then
                        '    Dim Z As String = Y
                        '    Z = Z.Substring(0, Z.Length - iget(Z, 5, ",").ToString.Length) + "<Unknown>"
                        '    Y = Z
                        'End If
                        FinalXDS += Y + vbcrlf
                    Next
                    FinalXDS = UpdateActionsName(FinalXDS, "Object", ResourceName, "<Unknown>", True)
                    DForm.MyXDSLines = FinalXDS
                End If
            Next
            For Each X As TreeNode In MainForm.ResourcesTreeView.Nodes(ResourceIDs.DObject).Nodes
                If X.Text = ResourceName Then X.Remove() : Exit For
            Next
        ElseIf Type = "Background" Then
            XDSRemoveLine(GetXDSLine("BACKGROUND " + ResourceName))
            File.Delete(SessionPath + "Backgrounds\" + ResourceName + ".png")
            If File.Exists(CompilePath + "gfx\" + ResourceName + ".png") Then
                File.Delete(CompilePath + "gfx\" + ResourceName + ".png")
            End If
            If File.Exists(CompilePath + "gfx\bin\" + ResourceName + ".c") Then
                File.Delete(CompilePath + "gfx\bin\" + ResourceName + ".c")
            End If
            If File.Exists(CompilePath + "gfx\bin\" + ResourceName + "_Map.bin") Then
                File.Delete(CompilePath + "gfx\bin\" + ResourceName + "_Map.bin")
            End If
            If File.Exists(CompilePath + "gfx\bin\" + ResourceName + "_Tiles.bin") Then
                File.Delete(CompilePath + "gfx\bin\" + ResourceName + "_Tiles.bin")
            End If
            If File.Exists(CompilePath + "gfx\bin\" + ResourceName + "_Pal.bin") Then
                File.Delete(CompilePath + "gfx\bin\" + ResourceName + "_Pal.bin")
            End If
            If File.Exists(CompilePath + "nitrofiles\" + ResourceName + ".c") Then
                File.Delete(CompilePath + "nitrofiles\" + ResourceName + ".c")
            End If
            If File.Exists(CompilePath + "nitrofiles\" + ResourceName + "_Map.bin") Then
                File.Delete(CompilePath + "nitrofiles\" + ResourceName + "_Map.bin")
            End If
            If File.Exists(CompilePath + "nitrofiles\" + ResourceName + "_Tiles.bin") Then
                File.Delete(CompilePath + "nitrofiles\" + ResourceName + "_Tiles.bin")
            End If
            If File.Exists(CompilePath + "nitrofiles\" + ResourceName + "_Pal.bin") Then
                File.Delete(CompilePath + "nitrofiles\" + ResourceName + "_Pal.bin")
            End If
            If Directory.Exists(CompilePath + "build") Then
                For Each X As String In Directory.GetFiles(CompilePath + "build")
                    Dim FName As String = X.Substring(X.LastIndexOf("\") + 1)
                    FName = FName.Substring(0, FName.LastIndexOf("."))
                    If FName.Contains("_") Then FName = FName.Substring(0, FName.LastIndexOf("_"))
                    If FName = ResourceName Then File.Delete(X)
                Next
            End If
            If BGsToRedo.Contains(ResourceName) Then BGsToRedo.Remove(ResourceName)
            For Each X As String In StringToLines(CurrentXDS)
                If Not X.StartsWith("ROOM ") Then Continue For
                Dim NewLine As String = X.Replace("," + ResourceName, ",")
                If Not NewLine.Length = X.Length Then XDSChangeLine(X, NewLine)
            Next
            For Each X As Form In MainForm.MdiChildren
                If X.Text = ResourceName Then Continue For
                If X.Name = "Room" Then
                    DirectCast(X, Room).RemoveBackground(ResourceName)
                    Continue For
                End If
                If X.Name = "DObject" Then
                    Dim DForm As DObject = DirectCast(X, DObject)
                    DForm.MyXDSLines = UpdateActionsName(DForm.MyXDSLines, "Background", ResourceName, "<Unknown>", False)
                End If
            Next
            CurrentXDS = UpdateActionsName(CurrentXDS, "Background", ResourceName, "<Unknown>", False)
            UpdateArrayActionsName("Background", ResourceName, "<Unknown>", False)
            For Each X As TreeNode In MainForm.ResourcesTreeView.Nodes(ResourceIDs.Background).Nodes
                If X.Text = ResourceName Then X.Remove()
            Next
        ElseIf Type = "Sound" Then
            Dim SoundLine As String = GetXDSLine("SOUND " + ResourceName + ",")
            Dim Extension As String = If(SoundLine.EndsWith(",0"), "wav", "mp3")
            XDSRemoveLine(SoundLine)
            File.Delete(SessionPath + "Sounds\" + ResourceName + "." + Extension)
            CurrentXDS = UpdateActionsName(CurrentXDS, "Sound", ResourceName, "<Unknown>", False)
            UpdateArrayActionsName("Sound", ResourceName, "<Unknown>", False)
            For Each X As TreeNode In MainForm.ResourcesTreeView.Nodes(ResourceIDs.Sound).Nodes
                If X.Text = ResourceName Then X.Remove()
            Next
            If SoundsToRedo.Contains(ResourceName) Then SoundsToRedo.Remove(ResourceName)
        ElseIf Type = "Room" Then
            XDSRemoveLine(GetXDSLine("ROOM " + ResourceName + ","))
            Dim NewString As String = String.Empty
            For Each X As String In StringToLines(CurrentXDS)
                If X.StartsWith("OBJECTPLOT ") Then
                    If iGet(X, 1, ",") = ResourceName Then Continue For
                End If
                NewString += X + vbcrlf
            Next
            CurrentXDS = NewString
            CurrentXDS = UpdateActionsName(CurrentXDS, "Room", ResourceName, "<Unknown>", False)
            UpdateArrayActionsName("Room", ResourceName, "<Unknown>", False)
            For Each X As TreeNode In MainForm.ResourcesTreeView.Nodes(ResourceIDs.Room).Nodes
                If X.Text = ResourceName Then X.Remove()
            Next
            If GetXDSLine("BOOTROOM ").Substring(9) = ResourceName Then
                Dim NewRoomName As String = MainForm.ResourcesTreeView.Nodes(ResourceIDs.Room).Nodes(0).Text
                XDSChangeLine("BOOTROOM " + ResourceName, "BOOTROOM " + NewRoomName)
            End If
        ElseIf Type = "Path" Then
            XDSRemoveLine("PATH " + ResourceName + ",")
            XDSRemoveFilter("PATHPOINT " + ResourceName + ",")
            CurrentXDS = UpdateActionsName(CurrentXDS, "Path", ResourceName, "<Unknown>", False)
            UpdateArrayActionsName("Path", ResourceName, "<Unknown>", False)
            For Each X As TreeNode In MainForm.ResourcesTreeView.Nodes(ResourceIDs.Path).Nodes
                If X.Text = ResourceName Then X.Remove()
            Next
        ElseIf Type = "Script" Then
            XDSRemoveLine(GetXDSLine("SCRIPT " + ResourceName + ","))
            XDSRemoveFilter("SCRIPTARG " + ResourceName + ",")
            File.Delete(SessionPath + "Scripts\" + ResourceName + ".dbas")
            CurrentXDS = UpdateActionsName(CurrentXDS, "Script", ResourceName, "<Unknown>", False)
            UpdateArrayActionsName("Script", ResourceName, "<Unknown>", False)
            For Each X As TreeNode In MainForm.ResourcesTreeView.Nodes(ResourceIDs.Script).Nodes
                If X.Text = ResourceName Then X.Remove()
            Next
        End If
        For Each X As Form In MainForm.MdiChildren
            If X.Text = ResourceName Then X.Close()
        Next
    End Sub

    Sub CopyResource(ByVal OldName As String, ByVal NewName As String, ByVal ResourceType As Byte)
        Select Case ResourceType
            Case ResourceIDs.Sprite
                Dim OldLine As String = GetXDSLine("SPRITE " + OldName + ",")
                OldLine = OldLine.Substring(8 + OldName.Length)
                XDSAddLine("SPRITE " + NewName + "," + OldLine)
                For Each X As String In Directory.GetFiles(SessionPath + "Sprites")
                    Dim Y As String = X
                    X = X.Substring(X.LastIndexOf("\") + 1)
                    Dim FrameNumber As Int16 = Convert.ToInt16(X.Substring(0, X.IndexOf("_")))
                    Dim SpriteName As String = X.Substring(X.IndexOf("_") + 1)
                    SpriteName = SpriteName.Substring(0, SpriteName.Length - 4)
                    If SpriteName = OldName Then IO.File.Copy(Y, SessionPath + "Sprites\" + FrameNumber.ToString + "_" + NewName + ".png")
                Next
                AddResourceNode(ResourceType, NewName, "SpriteNode", True)
            Case ResourceIDs.Background
                File.Copy(SessionPath + "Backgrounds\" + OldName + ".png", SessionPath + "Backgrounds\" + NewName + ".png")
                XDSAddLine("BACKGROUND " + NewName)
                AddResourceNode(ResourceType, NewName, "BackgroundNode", True)
            Case ResourceIDs.Script
                Dim OldLine As String = GetXDSLine("SCRIPT " + OldName + ",")
                OldLine = OldLine.Substring(OldLine.LastIndexOf(",") + 1)
                XDSAddLine("SCRIPT " + NewName + "," + OldLine)
                IO.File.Copy(SessionPath + "Scripts\" + OldName + ".dbas", SessionPath + "Scripts\" + NewName + ".dbas")
                For Each X As String In GetXDSFilter("SCRIPTARG " + OldName + ",")
                    X = X.Substring(8 + OldName.Length)
                    XDSAddLine("SCRIPTARG " + NewName + "," + X)
                Next
                AddResourceNode(ResourceType, NewName, "ScriptNode", True)
            Case ResourceIDs.Sound
                Dim OldLine As String = GetXDSLine("SOUND " + OldName + ",")
                Dim Type As Byte = Convert.ToByte(OldLine.Substring(7 + OldName.Length))
                If Type = 1 Then
                    File.Copy(SessionPath + "Sounds\" + OldName + ".mp3", SessionPath + "Sounds\" + NewName + ".mp3")
                Else
                    File.Copy(SessionPath + "Sounds\" + OldName + ".wav", SessionPath + "Sounds\" + NewName + ".wav")
                End If
            Case ResourceIDs.Path
                XDSAddLine("PATH " + NewName)
                For Each X As String In GetXDSFilter("PATHPOINT " + OldName + ",")
                    X = X.Substring(11 + OldName.Length)
                    Dim XP As String = iGet(X, 0, ",")
                    Dim YP As String = iGet(X, 1, ",")
                    XDSAddLine("PATHPOINT " + NewName + "," + XP + "," + YP)
                Next
                AddResourceNode(ResourceType, NewName, "PathNode", True)
            Case ResourceIDs.Room
                Dim OldLine As String = GetXDSLine("ROOM " + OldName + ",")
                OldLine = OldLine.Substring(6 + OldName.Length)
                XDSAddLine("ROOM " + NewName + "," + OldLine)
                For Each X As String In GetXDSFilter("OBJECTPLOT ")
                    If Not iGet(X, 1, ",") = OldName Then Continue For
                    Dim NewLine As String = iGet(X, 0, ",") + "," + NewName + "," + iGet(X, 2, ",") + "," + iGet(X, 3, ",") + "," + iGet(X, 4, ",")
                    XDSAddLine(NewLine)
                Next
                AddResourceNode(ResourceType, NewName, "RoomNode", True)
            Case ResourceIDs.DObject
                Dim OldLine As String = GetXDSLine("OBJECT " + OldName + ",")
                OldLine = OldLine.Substring(8 + OldName.Length)
                XDSAddLine("OBJECT " + NewName + "," + OldLine)
                For Each X As String In GetXDSFilter("EVENT " + OldName + ",")
                    XDSAddLine("EVENT " + NewName + X.Substring(("EVENT " + OldName).Length))
                Next
                For Each X As String In GetXDSFilter("ACT " + OldName + ",")
                    XDSAddLine("ACT " + NewName + X.Substring(("ACT " + OldName).Length))
                Next
                AddResourceNode(ResourceType, NewName, "ObjectNode", True)
        End Select
    End Sub

    Function GenerateDuplicateResourceName(ByVal OldName As String) As String
        For i As Byte = 2 To 100
            Dim NewName As String = OldName + "_" + i.ToString
            If IsAlreadyResource(NewName).Length = 0 Then Return NewName
        Next
        Return String.Empty 'Hack
    End Function

    Function ResourceToType(ByVal ResourceName As String) As Byte
        If GetXDSFilter("SPRITE " + ResourceName + ",").Length > 0 Then Return ResourceIDs.Sprite
        If GetXDSFilter("OBJECT " + ResourceName + ",").Length > 0 Then Return ResourceIDs.DObject
        If DoesXDSLineExist("BACKGROUND " + ResourceName) Then Return ResourceIDs.Background
        If GetXDSFilter("SOUND " + ResourceName + ",").Length > 0 Then Return ResourceIDs.Sound
        If GetXDSFilter("ROOM " + ResourceName + ",").Length > 0 Then Return ResourceIDs.Room
        If DoesXDSLineExist("PATH " + ResourceName) Then Return ResourceIDs.Path
        If GetXDSFilter("SCRIPT " + ResourceName + ",").Length > 0 Then Return ResourceIDs.Script
        Return 0
    End Function

    Function StringToLines(ByVal InputString As String) As String()
        Return System.Text.RegularExpressions.Regex.Split(InputString, vbNewline)
    End Function

    Sub AddResourceNode(ByRef ResourceID As Byte, ByVal ResourceName As String, ByVal NodeType As String, ByVal DoShowWindow As Boolean)
        Dim MyNewNode As New TreeNode
        With MyNewNode
            .Name = NodeType
            .ImageIndex = ResourceID
            .SelectedImageIndex = ResourceID
            .Text = ResourceName
        End With
        MainForm.ResourcesTreeView.Nodes(ResourceID).Nodes.Add(MyNewNode)
        MainForm.ResourcesTreeView.SelectedNode = MyNewNode
        If DoShowWindow Then OpenResource(ResourceName, ResourceID, True)
    End Sub

    Function GetXDSLine(ByVal FilterString As String) As String
        For Each XDSLine As String In StringToLines(CurrentXDS)
            If XDSLine.StartsWith(FilterString) Then Return XDSLine
        Next
        Return String.Empty
    End Function

    Sub XDSRemoveLine(ByVal line As String)
        Dim FinalString As String = String.Empty
        For Each XDSLine As String In StringToLines(CurrentXDS)
            If Not XDSLine = line Then FinalString += XDSLine + vbcrlf
        Next
        CurrentXDS = FinalString
    End Sub

    Sub XDSRemoveFilter(ByVal Filter As String)
        Dim FinalString As String = String.Empty
        For Each XDSLine As String In StringToLines(CurrentXDS)
            If Not XDSLine.StartsWith(Filter) Then FinalString += XDSLine + vbcrlf
        Next
        CurrentXDS = FinalString
    End Sub

    Function GetXDSFilter(ByVal FilterString As String) As String()
        Dim Returnable As New List(Of String)
        For Each XDSLine As String In StringToLines(CurrentXDS)
            If (Not XDSLine.StartsWith(FilterString)) Or XDSLine.Length = 0 Then Continue For
            Returnable.Add(XDSLine)
        Next
        Return Returnable.ToArray
    End Function

    'Function RemoveDeadLines(ByVal InputString As String) As String
    '    Dim Returnable As String = String.Empty
    '    For Each XDSLine As String In Split(InputString, vbcrlf, -1, CompareMethod.Text)
    '        If Not XDSLine.Length = 0 Then Returnable += XDSLine + vbcrlf
    '    Next
    '    Return Returnable
    'End Function

    Function iGet(ByVal InputString As String, ByVal ReturnableItem As Byte, ByVal SeperatorChar As String) As String
        Try
            Dim TempArray() As String = InputString.Split(SeperatorChar)
            Return TempArray(ReturnableItem)
        Catch
            Return String.Empty
        End Try
    End Function

    Public Sub ClearResourcesTreeView()
        For NodeNo As Byte = 0 To MainForm.ResourcesTreeView.Nodes.Count - 1
            MainForm.ResourcesTreeView.Nodes(NodeNo).Nodes.Clear()
        Next
    End Sub

    Sub CleanFresh(ByVal WishCloseNews As Boolean)
        Try
            If SessionPath.Length > 0 And Directory.Exists(AppPath + "ProjectTemp\" + Session) Then
                Directory.Delete(SessionPath, True)
            End If
            If CompilePath.Length > 0 And Directory.Exists(CompilePath) Then
                Directory.Delete(CompilePath, True)
            End If
        Catch : End Try
        Dim AvoidNewsline As Boolean = If(GetSetting("CLOSE_NEWS") = "0", True, False)
        For Each X As Form In MainForm.MdiChildren
            If X.Name = "Newsline" And AvoidNewsline And WishCloseNews = False Then Continue For
            X.Close()
        Next
        ClearResourcesTreeView()
    End Sub

    Public Sub OpenProject(ByVal Result As String)
        IsNewProject = False
        ProjectPath = Result
        BeingUsed = True
        CleanFresh(False)
        Dim DisplayResult As String = Result.Substring(Result.LastIndexOf("\") + 1)
        DisplayResult = DisplayResult.Substring(0, DisplayResult.LastIndexOf("."))
        DisplayResult = DisplayResult.Replace(" ", String.Empty)
        Dim SessionName As String = String.Empty
        For Looper As Byte = 0 To 10
            SessionName = DisplayResult + MakeSessionName()
            If Not IO.Directory.Exists(AppPath + "ProjectTemp\" + SessionName) Then Exit For
        Next
        FormSession(SessionName)
        BeingUsed = True
        ProjectPath = Result
        FormSessionFS()
        File.Copy(Result, SessionPath + "Project.zip")
        Dim MyBAT As String = "zip.exe x Project.zip -y" + vbcrlf + "exit"
        RunBatchString(MyBAT, SessionPath, True)
        'File.Delete(SessionPath + "Project.zip")
        ClearResourcesTreeView()
        MainForm.Text = TitleDataWorks()
        CurrentXDS = PathToString(SessionPath + "XDS.xds")
        'Project Upgrade
        Dim HasMidPointLine As Boolean = False
        Dim HasWiFiLine As Boolean = False
        Dim FinalString As String = String.Empty
        Dim Change As Boolean = False
        For Each X As String In StringToLines(CurrentXDS)
            If X.StartsWith("MIDPOINT_COLLISIONS ") Then HasMidPointLine = True
            If X.StartsWith("INCLUDE_WIFI_LIB ") Then HasWiFiLine = True
            If X.StartsWith("SCRIPT ") Then
                If Not X.Contains(",") Then X += ",1" : Change = True
            End If
            FinalString += X + vbcrlf
        Next
        If Change Then CurrentXDS = FinalString
        If Not HasMidPointLine Then XDSAddLine("MIDPOINT_COLLISIONS 1")
        If Not HasWiFiLine Then XDSAddLine("INCLUDE_WIFI_LIB 0")
        For Each XDSLine As String In GetXDSFilter("GLOBAL ")
            Dim ChangeTo As String = String.Empty
            If iGet(XDSLine, 1, ",") = "1" Then
                ChangeTo = "Boolean"
            ElseIf iGet(XDSLine, 1, ",") = "0" Then
                ChangeTo = "Integer"
            End If
            If ChangeTo.Length > 0 Then
                XDSChangeLine(XDSLine, iGet(XDSLine, 0, ",") + "," + ChangeTo + "," + iGet(XDSLine, 2, ","))
            End If
        Next
        For Each XDSLine As String In GetXDSFilter(String.Empty)
            If XDSLine.StartsWith("SPRITE ") Then
                XDSLine = XDSLine.Substring(7)
                Dim SpriteName As String = iGet(XDSLine, 0, ",")
                AddResourceNode(ResourceIDs.Sprite, SpriteName, "SpriteNode", False)
            ElseIf XDSLine.StartsWith("OBJECT ") Then
                XDSLine = XDSLine.Substring(7)
                Dim ObjectName As String = iGet(XDSLine, 0, ",")
                AddResourceNode(ResourceIDs.DObject, ObjectName, "ObjectNode", False)
            ElseIf XDSLine.StartsWith("BACKGROUND ") Then
                XDSLine = XDSLine.Substring(11)
                Dim BackgroundName As String = iGet(XDSLine, 0, ",")
                AddResourceNode(ResourceIDs.Background, BackgroundName, "BackgroundNode", False)
            ElseIf XDSLine.StartsWith("SOUND ") Then
                XDSLine = XDSLine.Substring(6)
                Dim SoundName As String = iGet(XDSLine, 0, ",")
                AddResourceNode(ResourceIDs.Sound, SoundName, "SoundNode", False)
            ElseIf XDSLine.StartsWith("ROOM ") Then
                XDSLine = XDSLine.Substring(5)
                Dim RoomName As String = iGet(XDSLine, 0, ",")
                AddResourceNode(ResourceIDs.Room, RoomName, "RoomNode", False)
            ElseIf XDSLine.StartsWith("PATH ") Then
                XDSLine = XDSLine.Substring(5)
                Dim PathName As String = iGet(XDSLine, 0, ",")
                AddResourceNode(ResourceIDs.Path, PathName, "PathNode", False)
            ElseIf XDSLine.StartsWith("SCRIPT ") Then
                XDSLine = XDSLine.Substring(7)
                Dim ScriptName As String = XDSLine.Substring(0, XDSLine.IndexOf(","))
                AddResourceNode(ResourceIDs.Script, ScriptName, "ScriptNode", False)
            End If
        Next
        RedoAllGraphics = True
        RedoSprites = True
        BGsToRedo.Clear()
        FontsUsedLastTime.Clear()
        BuildSoundsRedoFromFile()
        SetSetting("LAST_PROJECT", Result)
        SaveSettings()
    End Sub

    Sub BuildSoundsRedoFromFile()
        SoundsToRedo.Clear()
        For Each X As String In GetXDSFilter("SOUND ")
            X = X.Substring(6)
            X = X.Substring(0, X.Length - 2)
            SoundsToRedo.Add(X)
        Next
    End Sub

    Sub DebugSounds()
        For Each Y As String In SoundsToRedo
            MsgError("""" + Y + """")
        Next
    End Sub

    Sub AddSoundToRedo(ByVal SoundName2 As String)
        If Not SoundsToRedo.Contains(SoundName2) Then SoundsToRedo.Add(SoundName2)
    End Sub

    Sub ShowInternalForm(ByRef Instance)
        Instance.TopLevel = False
        Instance.MdiParent = MainForm
        Instance.Show()
    End Sub

    Sub CleanInternalXDS()
        Dim ToWrite As String = String.Empty
        For Each X As String In StringToLines(CurrentXDS)
            If X.Length > 0 Then ToWrite += X + vbcrlf
        Next
        CurrentXDS = ToWrite
    End Sub

    Sub URL(ByVal URL As String)
        System.Diagnostics.Process.Start(URL)
    End Sub

    Sub ProPlease(ByVal ToDoWhat As String)
        MsgInfo("Please buy the Pro Edition to " + ToDoWhat + ".")
        Pro.ShowDialog()
    End Sub

    Function GetActionTypes(ByVal ActionName) As String
        Dim Returnable As String = String.Empty
        For Each X As String In File.ReadAllLines(AppPath + "Actions\" + ActionName + ".action")
            If Not X.StartsWith("ARG ") Then Continue For
            X = X.Substring(4)
            Dim R As String = ArgumentTypeToString(Convert.ToByte(iGet(X, 1, ",")))
            Returnable += R + ","
        Next
        If Returnable.Length > 0 Then Returnable = Returnable.Substring(0, Returnable.Length - 1)
        Return Returnable
    End Function

    Function IsAlreadyResource(ByVal TheName As String) As String
        'Dim Returnable As String = String.Empty
        If GetXDSFilter("OBJECT " + TheName + ",").Length > 0 Then Return "an Object"
        If GetXDSFilter("SPRITE " + TheName + ",").Length > 0 Then Return "a Sprite"
        If DoesXDSLineExist("BACKGROUND " + TheName) Then Return "a Background"
        If GetXDSFilter("SOUND " + TheName + ",").Length > 0 Then Return "a Sound"
        If GetXDSFilter("ROOM " + TheName + ",").Length > 0 Then Return "a Room"
        If DoesXDSLineExist("PATH " + TheName) Then Return "a Path"
        If GetXDSFilter("SCRIPT " + TheName + ",").Length > 0 Then Return "a Script"
        Return String.Empty
    End Function

    Function GUIResNameChecker(ByVal TheName As String) As Boolean
        Dim Reply As String = IsAlreadyResource(TheName)
        If Reply.Length > 0 Then
            MsgError("There is already " + Reply + " called '" + TheName + "'." + vbcrlf + vbcrlf + "You must choose another name.")
            Return True
        Else
            If Not ValidateSomething(TheName, ValidateLevel.Tight) Then
                MsgError("The name may not contain a space or other unusual character.")
                Return True
            End If
            If Not ValidateSomething(TheName, ValidateLevel.NumberStart) Then
                MsgError("The name may not start with a number.")
                Return True
            End If
        End If
        Return False
    End Function

    Function ObjectGetImage(ByVal ObjectName As String) As Bitmap
        Dim XDSLine As String = GetXDSLine("OBJECT " + ObjectName + ",")
        'MsgError(XDSLine)
        Dim SpriteName As String = iGet(XDSLine, 1, ",")
        If SpriteName = "None" Then Return MakeBMPTransparent(PathToImage(AppPath + "Resources\NoSprite.png"), Color.Magenta)
        Dim FrameNo As Int16 = Convert.ToInt16(iGet(XDSLine, 2, ","))
        'MsgError(iget(XDSLine, 2, ","))
        Return MakeBMPTransparent(PathToImage(SessionPath + "Sprites\" + FrameNo.ToString + "_" + SpriteName + ".png"), Color.Magenta)
    End Function

    Sub RunBatchString(ByVal BatchString As String, ByVal WorkingDirectory As String, ByVal is7Zip As Boolean)
        If is7Zip Then File.Copy(AppPath + "zip.exe", WorkingDirectory + "zip.exe", True)
        File.WriteAllText(WorkingDirectory + "\DSGMBatch.bat", BatchString)
        'MsgError(WorkingDirectory + "DSGMBatch.bat")
        Dim MyProcess As New Process
        Dim MyStartInfo As New ProcessStartInfo(WorkingDirectory + "\DSGMBatch.bat")
        With MyStartInfo
            .WorkingDirectory = WorkingDirectory
            .WindowStyle = ProcessWindowStyle.Hidden
        End With
        MyProcess.StartInfo = MyStartInfo
        MyProcess.Start()
        MyProcess.WaitForExit()
        MyProcess.Dispose()
        File.Delete(WorkingDirectory + "\DSGMBatch.bat")
        Try
            If is7Zip Then File.Delete(WorkingDirectory + "zip.exe")
        Catch
            'Nevermind then eigh
        End Try
    End Sub

    Public Sub ResetPro()
        My.Settings.ProEmail = String.Empty
        My.Settings.ProSerial = String.Empty
        My.Settings.ProActivated = False
        My.Settings.Save()
        SetSetting("PRO_EMAIL", String.Empty)
        SetSetting("PRO_SERIAL", String.Empty)
        SetSetting("PRO", "0")
        MsgInfo("The Reset was successful.")
        IsPro = False
        MainForm.Text = TitleDataWorks()
        'MainForm.EquateProButton()
    End Sub

    Public Function TitleDataWorks() As String
        Dim Returnable As String = String.Empty
        If BeingUsed Then
            If IsNewProject Then
                Returnable = "<New Project>"
            Else
                Returnable = ProjectPath.Substring(ProjectPath.LastIndexOf("\") + 1)
                Returnable = Returnable.Substring(0, Returnable.LastIndexOf("."))
            End If
            CacheProjectName = Returnable
            Returnable += " - "
        End If
        'Returnable += Application.ProductName + " " + If(IsPro, "Pro", "Free")
        Returnable += Application.ProductName
        Return Returnable
    End Function

    Public Function SaveFile(ByVal Directory As String, ByVal Filter As String, ByVal DefaultFileName As String) As String
        If Directory.Length = 0 Then Directory = SaveDefaultFolder
        Dim Returnable As String
        Dim SFD As New SaveFileDialog
        With SFD
            .InitialDirectory = Directory
            .FileName = DefaultFileName
            .Filter = Filter
            .Title = "Save File"
            If Not .ShowDialog() = Windows.Forms.DialogResult.OK Then Returnable = String.Empty Else Returnable = .FileName
            .Dispose()
        End With
        SaveDefaultFolder = Directory
        Return Returnable
    End Function

    Function DoesXDSLineExist(ByVal XDSLine As String) As Boolean
        For Each X As String In StringToLines(CurrentXDS)
            If X = XDSLine Then Return True
        Next
        Return False
    End Function

    Function GetOSVersion() As Byte
        Return Convert.ToByte(System.Environment.OSVersion.Version.ToString.Substring(0, 1))
    End Function

    Sub PrivacyBummer(ByVal Message As String, ByVal Action As String)
        MsgError(Message + "." + vbcrlf + vbcrlf + Application.ProductName + " will " + Action + ".")
    End Sub

    Sub PiracyWorks()
        Dim Baddies As New Collection
        Dim PathBegin As String = CDrive
        If GetOSVersion() = 5 Then
            PathBegin += "Documents and Settings\" + Environment.UserName + "\My Documents"
        Else
            PathBegin += "Users\" + Environment.UserName
        End If
        PathBegin += "\Downloads\"
        '3.0
        Baddies.Add(PathBegin + "DSGameMaker 3.0 + Crack\readme.nfo")
        Baddies.Add(PathBegin + "DSGameMaker 3.0 + Crack\DSGameMaker.exe")
        Baddies.Add(PathBegin + "DSGameMaker 3.0 + Crack\DSGameMaker_3.0.exe")
        '2.6B
        Baddies.Add(PathBegin + "DSGameMaker 2.6B + Crack\readme.nfo")
        Baddies.Add(PathBegin + "DSGameMaker 2.6B + Crack\DSGameMaker_2.6B.exe")
        Baddies.Add(PathBegin + "DSGameMaker 2.6B + Crack\DSGameMaker.exe")
        Baddies.Add(AppPath + "readme.nfo")
        Dim ContainsBaddy As Boolean = False
        For Each Baddy As String In Baddies
            If System.IO.File.Exists(Baddy) Then ContainsBaddy = True : Exit For
        Next
        If ContainsBaddy Then
            PrivacyBummer("An illegal copy of " + Application.ProductName + " was found on your computer", "remove the offending files and downgrade to the Free Edition")
            For Each Baddy As String In Baddies
                If IO.File.Exists(Baddy) Then IO.File.Delete(Baddy)
            Next
            ResetPro()
            MsgInfo("The offending files were removed and your copy of " + Application.ProductName + " has been downgraded to the Free Edition.")
            If Directory.Exists("C:/Program Files/uTorrent") Then
                If MessageBox.Show("Would you like to close and remove µTorrent too?" + vbcrlf + vbcrlf + "This will stop you from distributing more illegal material (by accident!).", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    For Each p As Process In System.Diagnostics.Process.GetProcesses
                        If p.ProcessName.ToLower = "utorrent" Then p.Kill()
                    Next
                    Directory.Delete("C:/Program Files/uTorrent", True)
                    MsgInfo("µTorrent has been successfully closed and removed.")
                End If
            End If
        End If
    End Sub

End Module