Public Class Room

    Public RoomName As String

    Structure AnObject
        Dim InUse As Boolean
        Dim Screen As Boolean
        Dim ObjectName As String
        Dim CacheImage As Bitmap
        Dim X As Int16
        Dim Y As Int16
    End Structure

    Dim TopWidth As Int16
    Dim TopHeight As Int16
    Dim TopScroll As Boolean
    Public TopBG As String = String.Empty

    Dim BottomWidth As Int16
    Dim BottomHeight As Int16
    Dim BottomScroll As Boolean
    Public BottomBG As String = String.Empty

    Public Objects(128) As AnObject
    Dim SlotAppliesTo As New List(Of Byte)
    Dim VisualAppliesTo As New List(Of Byte)

    Dim InstanceOn As Byte = 0
    Public ObjectToPlot As String = String.Empty

    Sub ClearObjects()
        For Each X As AnObject In Objects
            X.InUse = False
            X.X = 0
            X.Y = 0
            X.Screen = True
        Next
    End Sub

    Dim SnapX As Byte = 16
    Dim SnapY As Byte = 16
    Dim ShowGrid As Boolean = False
    Dim SnapToGrid As Boolean = False
    Dim GridColor As Color = Color.Black
    Dim TX As Int16 = 0
    Dim TY As Int16 = 0
    Dim TS As Boolean = False

    Function GetBGImage(ByVal BackgroundName As String) As Bitmap
        Return MakeBMPTransparent(PathToImage(SessionPath + "Backgrounds\" + BackgroundName + ".png"), Color.Magenta)
    End Function

    Function MakeRoomImage(ByVal WhichScreen As Boolean) As Bitmap
        Dim Returnable As Bitmap
        Dim ReturnableGFX As Graphics
        If WhichScreen Then
            Returnable = New Bitmap(TopWidth, TopHeight)
        Else
            Returnable = New Bitmap(BottomWidth, BottomHeight)
        End If
        ReturnableGFX = Graphics.FromImage(Returnable)
        ReturnableGFX.Clear(Color.Black)
        Dim BGSize As Size
        If WhichScreen And TopBG.Length > 0 Then
            BGSize = GetBGImage(TopBG).Size
            If BGSize.Height = 192 Then BGSize.Height = 256
            'If BGSize.Width > 256 Then

            '    NewWidth = 256
            'Else
            '    'Dim Remainder As Int16 = BGSize.Width Mod 256
            'End If
            Dim XRepeat As Int16 = (TopWidth - (TopWidth Mod 256)) / 256
            Dim YRepeat As Int16 = (TopHeight - (TopHeight Mod 256)) / 256
            For X As Byte = 0 To XRepeat
                For Y As Byte = 0 To YRepeat
                    ReturnableGFX.DrawImage(GetBGImage(TopBG), New Point(X * 256, Y * 256))
                Next
            Next
        ElseIf Not WhichScreen And BottomBG.Length > 0 Then
            BGSize = GetBGImage(BottomBG).Size
            If BGSize.Height = 192 Then BGSize.Height = 256
            Dim XRepeat As Int16 = (BottomWidth - (BottomWidth Mod 256)) / 256
            Dim YRepeat As Int16 = (BottomHeight - (BottomHeight Mod 256)) / 256
            For X As Byte = 0 To XRepeat
                For Y As Byte = 0 To YRepeat
                    ReturnableGFX.DrawImage(GetBGImage(BottomBG), New Point(X * 256, Y * 256))
                Next
            Next
        End If
        'If WhichScreen And TopBG.Length > 0 Then

        '    ReturnableGFX.DrawImage(GetBGImage(TopBG), New Point(0, 0))
        'ElseIf Not WhichScreen And BottomBG.Length > 0 Then
        '    ReturnableGFX.DrawImage(GetBGImage(BottomBG), New Point(0, 0))
        'End If
        For Each X As AnObject In Objects
            If Not X.InUse Then Continue For
            If Not X.Screen = WhichScreen Then Continue For
            ReturnableGFX.DrawImageUnscaled(X.CacheImage, New Point(X.X, X.Y))
        Next
        Dim Screen As Panel = If(WhichScreen, TopScreen, BottomScreen)
        If ShowGrid Then
            For i As Int16 = 0 To If(WhichScreen, TopWidth, BottomWidth)
                If Not i Mod SnapX = 0 Then Continue For
                ReturnableGFX.DrawLine(New Pen(GridColor), i, 0, i, If(WhichScreen, TopHeight, BottomHeight))
                'ReturnableGFX.DrawLine(New Pen(GridColor), Screen.AutoScrollPosition.X + i, Screen.AutoScrollPosition.Y, Screen.AutoScrollPosition.X + i, If(WhichScreen, TopHeight, BottomHeight))
            Next
            For i As Int16 = 0 To If(WhichScreen, TopHeight, BottomHeight)
                If Not i Mod SnapY = 0 Then Continue For
                ReturnableGFX.DrawLine(New Pen(GridColor), 0, i, If(WhichScreen, TopWidth, BottomWidth), i)
                'ReturnableGFX.DrawLine(New Pen(GridColor), Screen.AutoScrollPosition.X, Screen.AutoScrollPosition.Y + i, If(WhichScreen, TopWidth, BottomWidth), Screen.AutoScrollPosition.Y + i)
            Next
        End If
        ReturnableGFX.DrawRectangle(New Pen(Color.FromArgb(127, 255, 255, 255), 1), New Rectangle(0, 0, 255, 191))
        'ReturnableGFX.DrawImage(TheBitmap, New Point(0, 0))
        'OriginalBitmapGFX.Dispose()
        Return Returnable
    End Function

    Public Sub AddObjectToDropper(ByVal ObjectName As String)
        ObjectDropper.Items.Add(ObjectName)
    End Sub

    Public Sub AddBackgroundToDropper(ByVal BackgroundName As String)
        TopScreenBGDropper.Items.Add(BackgroundName)
        BottomScreenBGDropper.Items.Add(BackgroundName)
    End Sub

    Public Sub RemoveObjectFromDropper(ByVal ObjectName As String)
        Dim TheIndex As Int16 = 0
        Dim DOn As Int16 = 0
        For Each X As String In ObjectDropper.Items
            If X = ObjectName Then TheIndex = DOn : Exit For
            DOn += 1
        Next
        ObjectDropper.Items.RemoveAt(TheIndex)
    End Sub

    Public Sub RemoveBackground(ByVal BackgroundName As String)
        Dim TheIndex As Int16 = 0
        Dim DOn As Int16 = 0
        For Each X As String In TopScreenBGDropper.Items
            If X = BackgroundName Then TheIndex = DOn : Exit For
            DOn += 1
        Next
        TopScreenBGDropper.Items.RemoveAt(TheIndex)
        BottomScreenBGDropper.Items.RemoveAt(TheIndex)
        If TopBG = BackgroundName Then
            TopBG = String.Empty
            TopScreenBGDropper.Text = String.Empty
            RefreshRoom(True)
        End If
        If BottomBG = BackgroundName Then
            BottomBG = String.Empty
            BottomScreenBGDropper.Text = String.Empty
            RefreshRoom(False)
        End If
    End Sub

    Public Sub RenameBackground(ByVal OldName As String, ByVal NewName As String)
        Dim TheIndex As Int16 = 0
        Dim DOn As Int16 = 0
        For Each X As String In TopScreenBGDropper.Items
            If X = OldName Then TheIndex = DOn : Exit For
            DOn += 1
        Next
        TopScreenBGDropper.Items(TheIndex) = NewName
        BottomScreenBGDropper.Items(TheIndex) = NewName
        If TopBG = OldName Then
            TopBG = NewName
            TopScreenBGDropper.Text = NewName
        End If
        If BottomBG = OldName Then
            BottomBG = NewName
            BottomScreenBGDropper.Text = NewName
        End If
    End Sub

    Public Sub RenameObjectDropper(ByVal OldName As String, ByVal NewName As String)
        For X As Int16 = 0 To ObjectDropper.Items.Count - 1
            If ObjectDropper.Items(X) = OldName Then ObjectDropper.Items(X) = NewName : Exit For
        Next
    End Sub

    Public Sub RenameBackgroundDropper(ByVal BackgroundName As String)
        For X As Int16 = 0 To TopScreenBGDropper.Items.Count - 1
            If TopScreenBGDropper.Items(X) = BackgroundName Then
                TopScreenBGDropper.Items(X) = BackgroundName
                BottomScreenBGDropper.Items(X) = BackgroundName
                Exit For
            End If
        Next
    End Sub

    Public Sub RefreshRoom(ByVal WhichScreen As Boolean)
        If WhichScreen Then : TopScreen.Invalidate() : Else : BottomScreen.Invalidate() : End If
    End Sub

    Private Sub Room_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SnapToGrid = (GetSetting("SNAP_OBJECTS") = "1")
        ShowGrid = (GetSetting("SHOW_GRID") = "1")
        UseRightClickMenuChecker.Checked = (GetSetting("RIGHT_CLICK") = "1")
        SnapX = Convert.ToByte(GetSetting("SNAP_X"))
        SnapY = Convert.ToByte(GetSetting("SNAP_Y"))
        Dim ColorString As String = GetSetting("GRID_COLOR")
        Dim R As Byte = Convert.ToByte(iGet(ColorString, 0, ","))
        Dim G As Byte = Convert.ToByte(iGet(ColorString, 1, ","))
        Dim B As Byte = Convert.ToByte(iGet(ColorString, 2, ","))
        ShowGridChecker.Checked = ShowGrid
        SnapToGridChecker.Checked = SnapToGrid
        SnapXTextBox.Text = SnapX.ToString
        SnapYTextBox.Text = SnapY.ToString
        GridColor = Color.FromArgb(R, G, B)
        ObjectRightClickMenu.Renderer = New clsMenuRenderer
        Dim XDSLine As String = GetXDSLine("ROOM " + RoomName + ",")
        XDSLine = XDSLine.Substring(6 + RoomName.Length)
        TopWidth = Convert.ToInt16(iGet(XDSLine, 0, ","))
        TopHeight = Convert.ToInt16(iGet(XDSLine, 1, ","))
        BottomWidth = Convert.ToInt16(iGet(XDSLine, 4, ","))
        'MsgError("Extracted BottomWidth is " + BottomWidth.ToString)
        BottomHeight = Convert.ToInt16(iGet(XDSLine, 5, ","))
        Dim MidWidth As Int16 = TopWidth
        If BottomWidth > MidWidth Then MidWidth = BottomWidth
        If MidWidth > 700 Then MidWidth = 700
        Dim BackupWidth As Int16 = Me.Width
        Dim BackupHeight As Int16 = Me.Height
        'XXX
        'Dim DoTopScroll As Boolean = If(TopWidth > TopScreen.Width, True, False)
        'Dim DoBottomScroll As Boolean = If(BottomWidth > BottomScreen.Width, True, False)
        'If DoTopScroll Then Me.Height += 36
        'If DoBottomScroll Then Me.Height += 36
        MainToolStrip.Renderer = New clsToolstripRenderer
        NameTextBox.Text = RoomName
        Text = RoomName
        TopScreenBGDropper.Items.Clear()
        TopScreenBGDropper.Items.Add(String.Empty)
        BottomScreenBGDropper.Items.Clear()
        BottomScreenBGDropper.Items.Add(String.Empty)
        For Each X As String In GetXDSFilter("BACKGROUND ")
            X = X.Substring(11)
            TopScreenBGDropper.Items.Add(iGet(X, 0, ","))
            BottomScreenBGDropper.Items.Add(iGet(X, 0, ","))
        Next
        ObjectDropper.Items.Clear()
        For Each X As String In GetXDSFilter("OBJECT ")
            X = X.Substring(7)
            ObjectDropper.Items.Add(iGet(X, 0, ","))
        Next
        TopScroll = (iGet(XDSLine, 2, ",") = "1")
        TopBG = iGet(XDSLine, 3, ",")
        BottomWidthDropper.Value = BottomWidth
        'MsgError(BottomHeight.ToString)
        BottomHeightDropper.Value = BottomHeight
        TopWidthDropper.Value = TopWidth
        TopHeightDropper.Value = TopHeight
        TopScreenScrollChecker.Checked = TopScroll
        BottomScroll = (iGet(XDSLine, 6, ",") = "1")
        BottomBG = iGet(XDSLine, 7, ",")
        Me.Width = MidWidth + 194
        Me.Height = ((TopHeight + BottomHeight) / 2) + 259
        TopScreen.Width = 256 + (Me.Width - BackupWidth)
        BottomScreen.Width = 256 + (Me.Width - BackupWidth)
        BottomScreenScrollChecker.Checked = BottomScroll
        TopScreenBGDropper.Text = TopBG
        BottomScreenBGDropper.Text = BottomBG
        ClearObjects()
        For Each TheLine As String In GetXDSFilter("OBJECTPLOT ")
            TheLine = TheLine.Substring(11)
            If Not iGet(TheLine, 1, ",") = RoomName Then Continue For
            Dim ObjectName As String = iGet(TheLine, 0, ",")
            Dim Screen As Boolean = (iGet(TheLine, 2, ",") = "1")
            Dim X As Int16 = Convert.ToInt16(iGet(TheLine, 3, ","))
            Dim Y As Int16 = Convert.ToInt16(iGet(TheLine, 4, ","))
            PlotObject(ObjectName, Screen, X, Y)
        Next
        RefreshRoom(True) : RefreshRoom(False)
        ObjectToPlot = String.Empty
    End Sub

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        Dim NewName As String = NameTextBox.Text
        If Not NewName = RoomName Then
            If GUIResNameChecker(NewName) Then Exit Sub
        End If
        Dim OldLine As String = GetXDSLine("ROOM " + RoomName + ",")
        Dim NewLine As String = "ROOM " + NewName + ","
        NewLine += TopWidthDropper.Value.ToString + "," + TopHeightDropper.Value.ToString + "," + If(TopScreenScrollChecker.Checked, "1", "0") + "," + TopBG + ","
        NewLine += BottomWidthDropper.Value.ToString + "," + BottomHeightDropper.Value.ToString + "," + If(BottomScreenScrollChecker.Checked, "1", "0") + "," + BottomBG
        XDSChangeLine(OldLine, NewLine)
        UpdateArrayActionsName("Room", RoomName, NewName, False)
        CurrentXDS = UpdateActionsName(CurrentXDS, "Room", RoomName, NewName, False)
        For Each X As String In GetXDSFilter("OBJECTPLOT ")
            If iGet(X, 1, ",") = RoomName Then XDSRemoveLine(X)
        Next
        For Each X As AnObject In Objects
            If Not X.InUse Then Continue For
            Dim TheLine As String = "OBJECTPLOT " + X.ObjectName + "," + NewName + ","
            If X.Screen Then TheLine += "1" Else TheLine += "0"
            TheLine += "," + X.X.ToString + "," + X.Y.ToString
            XDSAddLine(TheLine)
        Next
        If Not NewName = RoomName Then
            If GetXDSLine("BOOTROOM ").Substring(9) = RoomName Then
                XDSChangeLine("BOOTROOM " + RoomName, "BOOTROOM " + NewName)
            End If
        End If
        For Each X As TreeNode In MainForm.ResourcesTreeView.Nodes(ResourceIDs.Room).Nodes
            If X.Text = RoomName Then X.Text = NewName
        Next
        SetSetting("SNAP_OBJECTS", If(SnapToGrid, "1", "0"))
        SetSetting("SHOW_GRID", If(ShowGrid, "1", "0"))
        SetSetting("RIGHT_CLICK", If(UseRightClickMenuChecker.Checked, "1", "0"))
        Me.Close()
    End Sub

    Sub PlotObject(ByVal ObjectName As String, ByVal Screen As Boolean, ByVal X As Int16, ByVal Y As Int16)
        Dim ToAdd As New AnObject
        With ToAdd
            .InUse = True
            .X = X
            .Y = Y
            .Screen = Screen
            .ObjectName = ObjectName
            .CacheImage = ObjectGetImage(ObjectName)
        End With
        Objects(InstanceOn) = ToAdd
        InstanceOn += 1
        RefreshRoom(Screen)
    End Sub

    Public Sub ScreenBGDropper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopScreenBGDropper.SelectedIndexChanged, BottomScreenBGDropper.SelectedIndexChanged
        If DirectCast(sender, ComboBox).Name.StartsWith("Top") Then
            TopBG = TopScreenBGDropper.Text
            RefreshRoom(True)
        Else
            BottomBG = BottomScreenBGDropper.Text
            RefreshRoom(False)
        End If
    End Sub

    Private Sub TopScreen_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TopScreen.MouseClick
        Dim PlottedCount As Byte = 0
        For Each Z As AnObject In Objects
            If Z.InUse Then PlottedCount += 1
        Next
        If PlottedCount >= 128 Then MsgError("You can only plot 128 instances.") : Exit Sub
        Dim X As Int16 = e.Location.X
        Dim Y As Int16 = e.Location.Y
        X += (0 - TopScreen.AutoScrollPosition.X)
        Y += (0 - TopScreen.AutoScrollPosition.Y)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If UseRightClickMenuChecker.Checked Then
                TX = X : TY = Y : TS = True
                ObjectRightClickMenu.Show(TopScreen, e.Location)
            Else
                DeleteShizzle(X, Y, True)
            End If
            Exit Sub
        End If
        If ObjectToPlot.Length = 0 Then Exit Sub
        If SnapToGridChecker.Checked Then
            Dim NewX, NewY As Int16
            For i As Int16 = 1 To TopWidth
                If Not CanDevide(i, SnapX) Then Continue For
                If X >= i Then NewX = i
            Next
            For i As Int16 = 1 To TopHeight
                If Not CanDevide(i, SnapY) Then Continue For
                If Y >= i Then NewY = i
            Next
            PlotObject(ObjectToPlot, True, NewX, NewY)
        Else
            PlotObject(ObjectToPlot, True, X, Y)
        End If
    End Sub

    Sub DeleteShizzle(ByVal X As Int16, ByVal Y As Int16, ByVal WhichScreen As Boolean)
        Dim AppliesTo As New List(Of Byte)
        Dim DOn As Byte = 0
        For Each Z As AnObject In Objects
            If Z.InUse Then
                'MsgError("(" + DOn.ToString + ") name: " + Z.ObjectName + " at pos. " + Z.X.ToString + ", " + Z.Y.ToString)
                If Z.Screen = WhichScreen And X >= Z.X And Y >= Z.Y And X < (Z.X + Z.CacheImage.Width) And Y < (Z.Y + Z.CacheImage.Height) Then
                    AppliesTo.Add(DOn)
                End If
            End If
            DOn += 1
        Next
        For Each Z As Byte In AppliesTo
            Objects(Z).CacheImage = Nothing
            Objects(Z).InUse = False
            Objects(Z).ObjectName = String.Empty
            Objects(Z).X = 0 : Objects(Z).Y = 0
        Next
        If AppliesTo.Count > 0 Then
            RefreshRoom(WhichScreen)
        End If
    End Sub

    Private Sub BottomScreen_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BottomScreen.MouseClick
        Dim X As Int16 = e.Location.X
        Dim Y As Int16 = e.Location.Y
        X += (0 - BottomScreen.AutoScrollPosition.X)
        Y += (0 - BottomScreen.AutoScrollPosition.Y)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If UseRightClickMenuChecker.Checked Then
                TX = X : TY = Y : TS = False
                ObjectRightClickMenu.Show(BottomScreen, e.Location)
            Else
                DeleteShizzle(X, Y, False)
            End If
            Exit Sub
        End If
        If ObjectToPlot.Length = 0 Then Exit Sub
        If SnapToGridChecker.Checked Then
            Dim NewX, NewY As Int16
            For i As Int16 = 1 To BottomWidth
                If Not CanDevide(i, SnapX) Then Continue For
                If X >= i Then NewX = i
            Next
            For i As Int16 = 1 To BottomHeight
                If Not CanDevide(i, SnapY) Then Continue For
                If Y >= i Then NewY = i
            Next
            PlotObject(ObjectToPlot, False, NewX, NewY)
        Else
            PlotObject(ObjectToPlot, False, X, Y)
        End If
    End Sub

    Private Sub ObjectDropper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjectDropper.SelectedIndexChanged
        ObjectToPlot = DirectCast(sender, ComboBox).Text
    End Sub

    Private Sub Room_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Dim TotalHeight As Int16 = ClientRectangle.Height - MainToolStrip.Height
        TopScreen.Height = (TotalHeight / 2) - 2
        BottomScreen.Location = New Point(BottomScreen.Location.X, 27 + (TotalHeight / 2))
        'If TotalHeight Mod 2 = 0 Then
        '    BottomScreen.Location = New Point(BottomScreen.Location.X, (TotalHeight / 2) + 2)
        'Else
        '    BottomScreen.Location = New Point(BottomScreen.Location.X, (TotalHeight / 2) + 1)
        'End If
        BottomScreen.Height = (TotalHeight / 2) - 1
        TopScreen.Width = 256 + (Me.Width - 450)
        BottomScreen.Width = 256 + (Me.Width - 450)
    End Sub

    Private Sub TopScreen_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TopScreen.Paint
        e.Graphics.DrawImageUnscaled(MakeRoomImage(True), New Point(TopScreen.AutoScrollPosition.X, TopScreen.AutoScrollPosition.Y))
    End Sub

    Private Sub BottomScreen_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles BottomScreen.Paint
        e.Graphics.DrawImageUnscaled(MakeRoomImage(False), New Point(BottomScreen.AutoScrollPosition.X, BottomScreen.AutoScrollPosition.Y))
    End Sub

    Private Sub TopWidthDropper_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopWidthDropper.ValueChanged
        Me.Size = New System.Drawing.Size(450 + TopWidthDropper.Value - 256, 452 + TopHeightDropper.Value - 192)
        TopScreen.AutoScrollMinSize = New Size(TopWidthDropper.Value, TopHeight)
        TopWidth = TopWidthDropper.Value
        TopScreen_Scroll()
    End Sub

    Private Sub TopHeightDropper_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopHeightDropper.ValueChanged
        Me.Size = New System.Drawing.Size(450 + TopWidthDropper.Value - 256, 452 + TopHeightDropper.Value - 192)
        TopScreen.AutoScrollMinSize = New Size(TopWidth, TopHeightDropper.Value)
        TopHeight = TopHeightDropper.Value
        TopScreen_Scroll()
    End Sub

    Private Sub BottomWidthDropper_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BottomWidthDropper.ValueChanged
        Me.Size = New System.Drawing.Size(450 + BottomWidthDropper.Value - 256, 452 + BottomHeightDropper.Value - 192)
        BottomScreen.AutoScrollMinSize = New Size(BottomWidthDropper.Value, BottomHeight)
        BottomWidth = BottomWidthDropper.Value
        BottomScreen_Scroll()
    End Sub

    Private Sub BottomHeightDropper_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BottomHeightDropper.ValueChanged
        Me.Size = New System.Drawing.Size(450 + BottomWidthDropper.Value - 256, 452 + BottomHeightDropper.Value - 192)
        BottomScreen.AutoScrollMinSize = New Size(BottomWidth, BottomHeightDropper.Value)
        BottomHeight = BottomHeightDropper.Value
        BottomScreen_Scroll()
    End Sub

    Private Sub TopScreen_Scroll() Handles TopScreen.Scroll
        TopScreen.Invalidate()
    End Sub

    Private Sub BottomScreen_Scroll() Handles BottomScreen.Scroll
        BottomScreen.Invalidate()
    End Sub

    Private Sub Snappers_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SnapYTextBox.TextChanged, SnapXTextBox.TextChanged
        Dim TheValue As String = DirectCast(sender, TextBox).Text
        If Not IsNumeric(TheValue, Globalization.NumberStyles.Integer) Then Exit Sub
        If Convert.ToInt16(TheValue) = 0 Or Convert.ToInt16(TheValue) > 255 Then Exit Sub
        If sender.name.ToString.Contains("X") Then
            SnapX = Convert.ToByte(TheValue)
            SetSetting("SNAP_X", TheValue)
        Else
            SnapY = Convert.ToByte(TheValue)
            SetSetting("SNAP_Y", TheValue)
        End If
        If ShowGrid Then
            TopScreen.Refresh()
            BottomScreen.Refresh()
        End If
    End Sub

    Private Sub SnapToGridChecker_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SnapToGridChecker.CheckedChanged
        SnapToGrid = SnapToGridChecker.Checked
    End Sub

    Private Sub ShowGridChecker_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowGridChecker.CheckedChanged
        ShowGrid = ShowGridChecker.Checked
        TopScreen.Refresh()
        BottomScreen.Refresh()
    End Sub

    Private Sub GridColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridColorButton.Click
        'Dim DOn As Byte = 0
        'For Each Z As AnObject In Objects
        '    If Z.InUse Then
        '        MsgError("(" + DOn.ToString + ") name: " + Z.ObjectName + " at pos. " + Z.X.ToString + ", " + Z.Y.ToString)
        '        DOn += 1
        '    End If
        'Next
        GridColor = SelectColor(GridColor)
        If ShowGrid Then
            TopScreen.Refresh()
            BottomScreen.Refresh()
        End If
        SetSetting("GRID_COLOR", GridColor.R.ToString + "," + GridColor.G.ToString + "," + GridColor.B.ToString)
    End Sub

    Private Sub Screens_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BottomScreen.MouseMove, TopScreen.MouseMove
        Dim WhichScreen As Boolean = If(sender.name.ToString.StartsWith("T"), True, False)
        Dim X As Int16 = e.Location.X
        Dim Y As Int16 = e.Location.Y
        X += (0 - DirectCast(sender, Panel).AutoScrollPosition.X)
        Y += (0 - DirectCast(sender, Panel).AutoScrollPosition.Y)
        Dim NewX, NewY As Int16
        For i As Int16 = 1 To BottomWidth
            If Not CanDevide(i, SnapX) Then Continue For
            If X >= i Then NewX = i
        Next
        For i As Int16 = 1 To BottomHeight
            If Not CanDevide(i, SnapY) Then Continue For
            If Y >= i Then NewY = i
        Next
        SlotAppliesTo.Clear()
        VisualAppliesTo.Clear()
        Dim DOn As Byte = 0
        Dim AOn As Byte = 0
        For Each Z As AnObject In Objects
            If Z.InUse Then
                'If UseRightClickMenuChecker.Checked = True Then MsgError("(" + DOn.ToString + ") name: " + Z.ObjectName + " at pos. " + Z.X.ToString + ", " + Z.Y.ToString)
                If Z.Screen = WhichScreen And X >= Z.X And Y >= Z.Y And X < (Z.X + Z.CacheImage.Width) And Y < (Z.Y + Z.CacheImage.Height) Then
                    VisualAppliesTo.Add(AOn)
                    SlotAppliesTo.Add(DOn)
                End If
                AOn += 1
            End If
            DOn += 1
        Next
        Dim FinalString As String = String.Empty
        DOn = 0
        For Each Z As Byte In SlotAppliesTo
            FinalString += "[" + VisualAppliesTo(DOn).ToString + "] " + Objects(Z).ObjectName + " at " + Objects(Z).X.ToString + ", " + Objects(Z).Y.ToString + vbcrlf
            DOn += 1
        Next
        ObjectInfoLabel.Text = FinalString
        CursorPositionLabel.Text = "Cursor Position: " + X.ToString + ", " + Y.ToString
        CursorPositionSnapLabel.Text = "Cursor Position (snap): " + NewX.ToString + ", " + NewY.ToString
    End Sub

    Private Sub ObjectRightClickMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ObjectRightClickMenu.Opening
        OpenObjectButton.Text = "Open Object"
        DeleteObjectButton.Text = "Delete Instance"
        ObjectRightClickMenu.Enabled = False
        SetCoOrdinatesButton.Enabled = False
        DeleteObjectButton.Enabled = False
        If SlotAppliesTo.Count = 0 Then Exit Sub
        ObjectRightClickMenu.Enabled = True
        DeleteObjectButton.Enabled = True
        Dim ObjectsToOpen As New List(Of String)
        For Each X As Byte In SlotAppliesTo
            Dim CanAdd As Boolean = True
            For Each Y As String In ObjectsToOpen
                If Y = Objects(X).ObjectName Then CanAdd = False
            Next
            If CanAdd Then ObjectsToOpen.Add(Objects(X).ObjectName)
        Next
        If ObjectsToOpen.Count > 1 Then
            OpenObjectButton.Text += "s"
        End If
        If SlotAppliesTo.Count > 1 Then
            DeleteObjectButton.Text += "s"
        Else
            SetCoOrdinatesButton.Enabled = True
        End If
    End Sub

    Private Sub DeleteObjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteObjectButton.Click
        DeleteShizzle(TX, TY, TS)
    End Sub

    Private Sub OpenObjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenObjectButton.Click
        Dim ObjectsToOpen As New List(Of String)
        For Each X As Byte In SlotAppliesTo
            Dim CanAdd As Boolean = True
            For Each Y As String In ObjectsToOpen
                If Y = Objects(X).ObjectName Then CanAdd = False
            Next
            If CanAdd Then ObjectsToOpen.Add(Objects(X).ObjectName)
        Next
        For Each X As String In ObjectsToOpen
            Dim DoShow As Boolean = True
            For Each TheForm As Form In MainForm.MdiChildren
                If TheForm.Text = X Then
                    TheForm.Focus()
                    DoShow = False
                End If
            Next
            If DoShow Then
                Dim ObjectForm As New DObject
                ObjectForm.ObjectName = X
                ShowInternalForm(ObjectForm)
            End If
        Next
    End Sub

    Private Sub SetCoOrdinatesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetCoOrdinatesButton.Click
        Dim ID As Int16 = SlotAppliesTo(0)
        SetCoOrdinates.X = Objects(ID).X
        SetCoOrdinates.Y = Objects(ID).Y
        SetCoOrdinates.ShowDialog()
        'If Not SetCoOrdinates.ShowDialog() = Windows.Forms.DialogResult.OK Then Exit Sub
        Objects(ID).X = SetCoOrdinates.X
        Objects(ID).Y = SetCoOrdinates.Y
        RefreshRoom(Objects(ID).Screen)
    End Sub
End Class