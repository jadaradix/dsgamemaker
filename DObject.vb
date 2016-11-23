Imports System.IO
Imports System.Drawing.Drawing2D

Public Class DObject

    Public ObjectName As String
    Dim SpriteName As String
    Dim Frame As Int16
    Dim FrameLimit As Int16
    Public MyXDSLines As String
    Dim DEventMainClasses As New List(Of String)
    Dim DEventSubClasses As New List(Of String)

    Public Actions As New List(Of String)
    Public ActionImages As New List(Of String)
    Public ActionArguments As New List(Of String)
    Public ActionDisplays As New List(Of String)
    Public ActionAppliesTos As New List(Of String)

    Dim SelectedEvent As Int16 = 0
    Dim CurrentIndents As New List(Of SByte)

    Dim DragFromBottom As Boolean
    Dim DragInternal As Boolean
    Dim DraggingInternal As Int16
    Dim DraggingFromBottom As Panel
    Dim MouseInBox As Boolean = False

    Dim SaveOnNextChange As Boolean = False
    Dim ThinList As Boolean = True

    Sub ActionMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        DragFromBottom = True
        DraggingFromBottom = sender
        Me.Cursor = Cursors.NoMove2D
        'DirectCast(sender, Panel).DoDragDrop(DirectCast(sender, Panel).Tag, DragDropEffects.Move)
    End Sub

    Sub ActionMouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ActionName As String = DirectCast(sender, Panel).Tag
        ActionNameLabel.Text = ActionName
        ArgumentsListLabel.Text = String.Empty
        Dim ArgumentCount As Byte = 0
        For Each X As String In IO.File.ReadAllLines(AppPath + "Actions\" + ActionName + ".action")
            If X.StartsWith("ARG ") Then
                X = X.Substring(4)
                Dim ArgumentName As String = iGet(X, 0, ",")
                ArgumentsListLabel.Text += ArgumentName + vbCrLf
                ArgumentCount += 1
            End If
        Next
        If ArgumentCount = 0 Then ArgumentsListLabel.Text = "<No Arguments>"
        Dim RequiresPro As Boolean = False
        For Each X As String In ProActions
            If X = ActionName Then RequiresPro = True
        Next
        RequiresProBanner.Visible = RequiresPro
        If RequiresPro Then
            ArgumentsHeaderLabel.Height = 94
            ArgumentsListLabel.Height = 68
        Else
            ArgumentsHeaderLabel.Height = 120
            ArgumentsListLabel.Height = 94
        End If
    End Sub

    Sub ActionMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.Cursor = Cursors.Default
        Dim ActionName As String = DirectCast(DraggingFromBottom, Panel).Tag
        If SelectedEvent = 100 Then
            MsgWarn("You must add an Event, to which to add Actions.")
            Exit Sub
        End If
        If Not DragFromBottom Then Exit Sub
        'MsgError(Location.X.ToString)
        'MsgError(Location.Y.ToString)
        'Dim MDIID As Byte = 10
        'Dim DOn As Byte = 0
        'MsgError(ObjectName)
        'For Each X As Form In MainForm.MdiChildren
        '    If X.Text = ObjectName Then MDIID = DOn
        '    DOn += 1
        'Next
        'MsgError(MDIID.ToString)
        'If Not ActionsList.PointToClient(Cursor.Position).X > 0 Then Exit Sub
        'MsgError(Cursor.Position.X.ToString)
        'MsgError(Me.PointToScreen(ActionsList.Location).X.ToString)
        Dim TheX As Int16 = ActionsList.PointToClient(Cursor.Position).X ' - Location.X
        Dim TheY As Int16 = ActionsList.PointToClient(Cursor.Position).Y ' - Location.Y
        If TheX < 0 Then Exit Sub
        If TheX > ActionsList.Width Then Exit Sub
        If TheY < 0 Then Exit Sub
        If TheY > ActionsList.Height Then Exit Sub
        Dim ArgCount As Byte = 0
        Dim NoAppliesTo As Boolean = False
        For Each X As String In File.ReadAllLines(AppPath + "Actions\" + ActionName + ".action")
            If X.StartsWith("ARG ") Then ArgCount += 1
            If X = "NOAPPLIES" Then NoAppliesTo = True
        Next
        Dim Code As Boolean = (ActionName = "Execute Code")
        Dim JustAdd As Boolean = Not (ActionsList.SelectedIndices.Count = 1)
        Dim Position As Int16 = ActionsList.SelectedIndex + 1
        If NoAppliesTo And ArgCount = 0 Then
            If JustAdd Then
                Actions.Add(ActionName)
                ActionImages.Add(ActionGetIconPath(ActionName, False))
                ActionArguments.Add(String.Empty)
                ActionDisplays.Add(ActionEquateDisplay(ActionName, String.Empty))
                ActionAppliesTos.Add("this")
                GenerateIndentIndices()
                ActionsList.Items.Add(String.Empty)
                ActionsList.SelectedItems.Clear()
                ActionsList.SelectedIndex = ActionsList.Items.Count - 1
            Else
                Actions.Insert(Position, ActionName)
                ActionImages.Insert(Position, ActionGetIconPath(ActionName, False))
                ActionArguments.Insert(Position, String.Empty)
                ActionDisplays.Insert(Position, ActionEquateDisplay(ActionName, String.Empty))
                ActionAppliesTos.Insert(Position, "this")
                GenerateIndentIndices()
                ActionsList.Items.Insert(Position, String.Empty)
                ActionsList.SelectedItems.Clear()
                ActionsList.SelectedIndex = Position
            End If
            DragFromBottom = False
            Exit Sub
        End If
        If Not Code Then
            Action.ActionName = ActionName
            Action.AppliesTo = "this"
            Action.ArgumentString = String.Empty
        End If
        If ArgCount > 1 Then
            Dim MyShizzle As String = String.Empty
            For X As Byte = 0 To ArgCount - 2
                MyShizzle += ";"
            Next
            Action.ArgumentString = MyShizzle
        End If
        If Code Then
            EditCode.ReturnableCode = String.Empty
            EditCode.ImportExport = True
            If Not EditCode.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        Else
            Action.AppliesToGroupBox.Enabled = True
            If NoAppliesTo Then
                Action.AppliesToGroupBox.Enabled = False
            End If
            Action.ShowDialog()
            If Not Action.UseData Then Me.Cursor = Cursors.Default : Exit Sub
        End If
        If JustAdd Then
            Actions.Add(ActionName)
            ActionImages.Add(ActionGetIconPath(ActionName, False))
        Else
            Actions.Insert(Position, ActionName)
            ActionImages.Insert(Position, ActionGetIconPath(ActionName, False))
        End If
        If Code Then
            If JustAdd Then
                ActionArguments.Add(EditCode.ReturnableCode)
                ActionDisplays.Add(ActionEquateDisplay(ActionName, EditCode.ReturnableCode))
                ActionAppliesTos.Add("this")
            Else
                ActionArguments.Insert(Position, EditCode.ReturnableCode)
                ActionDisplays.Insert(Position, ActionEquateDisplay(ActionName, EditCode.ReturnableCode))
                ActionAppliesTos.Insert(Position, "this")
            End If
        Else
            If JustAdd Then
                ActionArguments.Add(Action.ArgumentString)
                ActionDisplays.Add(ActionEquateDisplay(ActionName, Action.ArgumentString))
                ActionAppliesTos.Add(Action.AppliesTo)
            Else
                ActionArguments.Insert(Position, Action.ArgumentString)
                ActionDisplays.Insert(Position, ActionEquateDisplay(ActionName, Action.ArgumentString))
                ActionAppliesTos.Insert(Position, Action.AppliesTo)
            End If
        End If
        GenerateIndentIndices()
        ActionsList.SelectedItems.Clear()
        If JustAdd Then
            ActionsList.Items.Add(String.Empty)
            ActionsList.SelectedIndex = ActionsList.Items.Count - 1
        Else
            ActionsList.Items.Insert(Position, String.Empty)
            ActionsList.SelectedIndex = Position
        End If

        'MsgError((ActionsList.PointToClient(Cursor.Position).X).ToString + " v.s. " + ActionsList.Location.X.ToString + " and " + ActionsList.Width.ToString)
        'MsgError(TheY)
        'If ActionsList.PointToClient(Cursor.Position).X > ActionsList.Width Then Exit Sub
        'If Not ActionsList.PointToClient(Cursor.Position).Y > 0 Then Exit Sub
        'If ActionsList.PointToClient(Cursor.Position).Y > ActionsList.Height Then Exit Sub
        DragFromBottom = False
    End Sub

    Sub GenerateIndentIndices()
        CurrentIndents.Clear()
        If Actions.Count = 0 Then Exit Sub
        Dim RunningIndent As Byte = 0
        For X As Int16 = 0 To Actions.Count - 1
            Dim ActionName As String = Actions(X)
            Dim IndentChange As Byte = 0
            For Each Y As String In IO.File.ReadAllLines(AppPath + "Actions\" + ActionName + ".action")
                If Y = "INDENT" Then IndentChange = 2 : Exit For
                If Y = "DEDENT" Then IndentChange = 1 : Exit For
            Next
            If IndentChange = 2 Then RunningIndent += 1
            CurrentIndents.Add(RunningIndent)
            If RunningIndent > 0 Then
                If IndentChange = 1 Then RunningIndent -= 1
            End If
        Next
        'Dim IndentChange As Byte = 0
        'Dim CurrentIndent As Byte = 1
        'Dim Thingy As Byte = 0
        'For X As Int16 = 0 To Actions.Count - 1
        '    IndentChange = 0
        '    Dim ActionName As String = Actions(X)
        '    For Each Y As String In IO.File.ReadAllLines(AppPath + "Actions\" + ActionName + ".action")
        '        If Y = "INDENT" Then IndentChange = 2 : Exit For
        '        If Y = "DEDENT" Then IndentChange = 1 : Exit For
        '    Next
        '    If IndentChange = 1 Then
        '        If CurrentIndent > 1 Then
        '            For i = 0 To CurrentIndent - 2
        '                Thingy += 1
        '            Next
        '            CurrentIndent -= 1
        '        End If
        '    Else
        '        If CurrentIndent > 0 Then
        '            For i = 0 To CurrentIndent - 1
        '                Thingy += 1
        '            Next
        '        End If
        '    End If
        '    CurrentIndents.Add(Thingy)
        '    If IndentChange = 2 Then CurrentIndent += 1
        'Next
    End Sub

    Sub RenderSprite()
        Dim Final As New Bitmap(64, 64)
        Dim FinalGFX As Graphics = Graphics.FromImage(Final)
        FinalGFX.Clear(Color.White)
        Dim ImagePath As String
        If SpriteDropper.Text = "None" Then
            ImagePath = AppPath + "Resources\NoSprite.png"
        Else
            ImagePath = SessionPath + "Sprites\" + Frame.ToString + "_" + SpriteDropper.Text + ".png"
        End If
        Dim Drawable As Image = PathToImage(ImagePath)
        Drawable = MakeBMPTransparent(Drawable, Color.Magenta)
        FinalGFX.DrawImage(Drawable, New Point(32 - (Drawable.Width / 2), 32 - (Drawable.Height / 2)))
        SpritePanel.BackgroundImage = Final
    End Sub

    Public Sub PopulateActionsTabControl(ByRef RAppliesTo As TabControl)
        Dim Hide As Boolean = (GetSetting("HIDE_OLD_ACTIONS") = "1")
        Dim BannedActions As New List(Of String)
        With BannedActions
            .Add("load collision map")
            .Add("if position free")
            .Add("if position occupied")
            .Add("palib")
            .Add("run c script")
            .Add("enable guitar controller")
            .Add("set color")
        End With
        Dim BackupIndex As Byte = 100
        Try
            BackupIndex = RAppliesTo.SelectedIndex
        Catch : End Try
        For Each X As TabPage In RAppliesTo.TabPages
            Try
                If X.Controls.Count > 0 Then
                    For Y = 0 To X.Controls.Count - 1
                        RemoveHandler X.Controls(Y).MouseDown, AddressOf ActionMouseDown
                        RemoveHandler X.Controls(Y).MouseEnter, AddressOf ActionMouseEnter
                        RemoveHandler X.Controls(Y).MouseUp, AddressOf ActionMouseUp
                        X.Controls.RemoveAt(Y)
                    Next
                End If
            Catch : End Try
            RAppliesTo.TabPages.Remove(X)
        Next
        RAppliesTo.TabPages.Clear()
        For X As Byte = 0 To 5
            Dim Y As New TabPage
            Y.Text = ActionTypeToString(X)
            Y.Name = ActionTypeToString(X) + "TabPage"

            Y.AutoScroll = True
            Y.SetAutoScrollMargin(8, 8)

            Dim Actions As New List(Of String)
            For Each Z As String In Directory.GetFiles(AppPath + "Actions")
                Dim ActionName As String = Z.Substring(Z.LastIndexOf("\") + 1)
                ActionName = ActionName.Substring(0, ActionName.LastIndexOf("."))
                If Hide Then
                    If BannedActions.Contains(ActionName.ToLower) Then Continue For
                End If
                Dim ActionType As Byte = 100
                For Each I As String In File.ReadAllLines(Z)
                    If I.StartsWith("TYPE ") Then ActionType = Convert.ToByte(I.Substring(5))
                Next
                If ActionType = 100 Then Continue For 'Bad action
                If Not ActionType = X Then Continue For
                Actions.Add(ActionName)
            Next
            Dim DOn As Int16 = 0
            Dim XOn As Int16 = 0
            Dim YOn As Int16 = 0
            For Each Z As String In Actions
                Dim NewPanel As New Panel
                With NewPanel
                    .Size = New Size(32, 32)
                    .Tag = Z
                    .Name = Z.Replace(" ", "_") + "ActionPanel"
                    .Location = New Point(10 + (XOn * 32) + (XOn * 10), 10 + (YOn * 32) + (YOn * 10))
                    'MsgError(Z + " at " + NewPanel.Location.ToString)
                    .BackgroundImage = ActionGetIcon(Z)
                End With
                Y.Controls.Add(NewPanel)
                'AddHandler NewPanel.Click, AddressOf ActionPanelClicked
                AddHandler NewPanel.MouseDown, AddressOf ActionMouseDown
                AddHandler NewPanel.MouseEnter, AddressOf ActionMouseEnter
                AddHandler NewPanel.MouseUp, AddressOf ActionMouseUp
                If XOn = 6 Then
                    YOn += 1 : XOn = 0
                Else
                    XOn += 1
                End If
                DOn += 1
            Next
            RAppliesTo.TabPages.Add(Y)
        Next
        If Not BackupIndex = 100 Then RAppliesTo.SelectedIndex = BackupIndex
    End Sub

    Public Sub ChangeSprite(ByVal OldName As String, ByVal NewName As String)
        For DOn As Byte = 0 To SpriteDropper.Items.Count - 1
            If SpriteDropper.Items(DOn) = OldName Then SpriteDropper.Items.Item(DOn) = NewName
        Next
        If SpriteDropper.Text = OldName Then SpriteDropper.Text = NewName
    End Sub

    Private Sub DObject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelectedEvent = 100
        ThinList = (GetSetting("SHRINK_ACTIONS_LIST") = "1")
        MainToolStrip.Renderer = New clsToolstripRenderer
        ActionRightClickMenu.Renderer = New clsMenuRenderer
        EventRightClickMenu.Renderer = New clsMenuRenderer
        Text = ObjectName
        PopulateActionsTabControl(ActionsToAddTabControl)
        NameTextBox.Text = ObjectName
        Dim XDSLine As String = GetXDSLine("OBJECT " + ObjectName + ",")
        MyXDSLines = String.Empty
        'MyXDSLines += XDSLine
        EventsListBox.Items.Clear()
        For Each X As String In GetXDSFilter("EVENT " + ObjectName + ",")
            MyXDSLines += X + vbCrLf
            DEventMainClasses.Add(MainClassTypeToString(iGet(X, 1, ",")))
            DEventSubClasses.Add(iGet(X, 2, ","))
        Next
        For Each X As String In GetXDSFilter("ACT " + ObjectName + ",")
            MyXDSLines += X + vbCrLf
        Next
        For Each X As String In DEventSubClasses
            EventsListBox.Items.Add(X)
        Next
        SpriteName = iGet(XDSLine, 1, ",")
        'MsgError(iget(XDSLine, 1, ","))
        Frame = Convert.ToInt16(iGet(XDSLine, 2, ","))
        SpriteDropper.Items.Clear()
        SpriteDropper.Items.Add("None")
        For Each X As String In GetXDSFilter("SPRITE ")
            SpriteDropper.Items.Add(iGet(X.Substring(7), 0, ","))
        Next
        SpriteDropper.Text = SpriteName
        If EventsListBox.Items.Count > 0 Then
            SaveOnNextChange = False
            SelectedEvent = 0
            EventsListBox.SelectedIndex = 0
        End If
        ArgumentsHeaderLabel.Height = 120
        ArgumentsListLabel.Height = 94
    End Sub

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        If MyXDSLines.Length > 0 Then SaveCurrentData()
        Dim NewName As String = NameTextBox.Text
        If Not ObjectName = NewName Then
            If GUIResNameChecker(NameTextBox.Text) Then Exit Sub
        End If
        If NewName = "NoData" Then MsgWarn("'NoData' is not a valid name. You must choose another name.") : Exit Sub
        If NewName = "this" Then MsgWarn("'this' is not a valid name. You must choose another name.") : Exit Sub
        Dim OldLine As String = GetXDSLine("OBJECT " + ObjectName + ",")
        Dim NewLine As String = "OBJECT " + NewName + "," + SpriteDropper.Text + "," + Frame.ToString
        XDSChangeLine(OldLine, NewLine)
        XDSRemoveFilter("EVENT " + ObjectName + ",")
        XDSRemoveFilter("ACT " + ObjectName + ",")
        For Each X As String In GetXDSFilter("OBJECTPLOT " + ObjectName + ",")
            XDSChangeLine(X, "OBJECTPLOT " + NewName + X.Substring(X.IndexOf(",")))
        Next
        Dim FinalString As String = String.Empty
        If NewName = ObjectName Then
            FinalString = MyXDSLines
        Else
            If MyXDSLines.Length > 0 Then
                For Each X As String In StringToLines(MyXDSLines)
                    If X.StartsWith("EVENT ") Then
                        X = "EVENT " + NewName + X.Substring(X.IndexOf(","))
                    End If
                    If X.StartsWith("ACT ") Then
                        X = "ACT " + NewName + X.Substring(X.IndexOf(","))
                    End If
                    FinalString += X + vbCrLf
                Next
            End If
        End If
        'FinalString = UpdateActionsName(FinalString, "Object", ObjectName, NewName, True)
        CurrentXDS += vbCrLf + FinalString + vbCrLf
        For Each X As Form In MainForm.MdiChildren
            If X.Name = "Room" Then
                Dim DForm As Room = DirectCast(X, Room)
                DForm.RenameObjectDropper(ObjectName, NewName)
                For DOn As Byte = 0 To DForm.Objects.Length - 1
                    If DForm.Objects(DOn).InUse And DForm.Objects(DOn).ObjectName = ObjectName Then DForm.Objects(DOn).ObjectName = NewName
                Next
            End If
        Next
        For Each X As String In GetXDSFilter("ACT ")
            Dim SubPoint As Int16 = iGet(X, 0, ",").Length + 1 + iGet(X, 1, ",").Length
            Dim SubPoint2 As Int16 = SubPoint + 1 + iGet(X, 2, ",").Length + 1
            If iGet(X, 1, ",") = "6" Then
                If iGet(X, 2, ",") = ObjectName Then
                    XDSChangeLine(X, X.Substring(0, SubPoint) + "," + NewName + "," + X.Substring(SubPoint2))
                End If
            End If
        Next
        For Each X As String In GetXDSFilter("EVENT ")
            If iGet(X, 1, ",") = "6" And iGet(X, 2, ",") = ObjectName Then XDSChangeLine(X, iGet(X, 0, ",") + ",6," + NewName)
        Next
        CurrentXDS = UpdateActionsName(CurrentXDS, "Object", ObjectName, NewName, True)
        For Each X As Form In MainForm.MdiChildren
            If Not IsObject(X.Text) Then Continue For
            Dim DForm As DObject = DirectCast(X, DObject)
            If DForm.MyXDSLines.Length = 0 Then Continue For
            Dim LF As String = String.Empty
            For Each Y As String In StringToLines(DForm.MyXDSLines)
                If Y.StartsWith("EVENT ") Then
                    If iGet(Y, 1, ",") = "6" And iGet(Y, 2, ",") = ObjectName Then Y = iGet(Y, 0, ",") + ",6," + NewName
                End If
                If Y.StartsWith("ACT ") Then
                    Dim SubPoint As Int16 = iGet(Y, 0, ",").Length + 1 + iGet(Y, 1, ",").Length
                    Dim SubPoint2 As Int16 = SubPoint + 1 + iGet(Y, 2, ",").Length + 1
                    If iGet(Y, 1, ",") = "6" And iGet(Y, 2, ",") = ObjectName Then
                        Y = Y.Substring(0, SubPoint) + "," + NewName + "," + Y.Substring(SubPoint2)
                    End If
                End If
                LF += Y + vbCrLf
            Next
            DForm.MyXDSLines = LF
        Next
        For Each X As Form In MainForm.MdiChildren
            If Not X.Name = "DObject" Then Continue For
            Dim DForm As DObject = DirectCast(X, DObject)
            DForm.MyXDSLines = UpdateActionsName(DForm.MyXDSLines, "Object", ObjectName, NewName, True)
        Next
        UpdateArrayActionsName("Object", ObjectName, NewName, True)
        For Each X As Form In MainForm.MdiChildren
            If Not X.Name = "DObject" Then Continue For
            If DirectCast(X, DObject).DEventMainClasses.Count = 0 Then Continue For
            'MsgError("processing form " + X.Text)
            For Y As Byte = 0 To DirectCast(X, DObject).DEventMainClasses.Count - 1
                'MsgError("mainclass " + Y.ToString + " is " + DirectCast(X, DObject).DEventMainClasses(Y))
                'MsgError("subclass " + Y.ToString + " is " + DirectCast(X, DObject).DEventSubClasses(Y))
                If DirectCast(X, DObject).DEventMainClasses(Y) = "Collision" And DirectCast(X, DObject).DEventSubClasses(Y) = ObjectName Then
                    DirectCast(X, DObject).DEventSubClasses(Y) = NewName
                End If
            Next
            For Each Y As Control In X.Controls
                If Not Y.Name = "ObjectPropertiesPanel" Then Continue For
                For Each Z As Control In Y.Controls
                    If Z.Name = "EventsListBox" Then DirectCast(Z, ListBox).Invalidate()
                Next
            Next
        Next
        For Each X As TreeNode In MainForm.ResourcesTreeView.Nodes(ResourceIDs.DObject).Nodes
            If X.Text = ObjectName Then X.Text = NewName
        Next
        Me.Close()
    End Sub

    Public Sub AddSprite(ByVal SpriteName As String)
        SpriteDropper.Items.Add(SpriteName)
    End Sub

    Public Function GetSpriteName() As String
        Return SpriteDropper.Text
    End Function

    Public Sub DeleteSprite()
        SpriteDropper.Text = "None"
    End Sub

    Private Sub SpriteDropper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpriteDropper.SelectedIndexChanged
        OpenSpriteButton.Enabled = True
        Dim ImageCount As Int16 = 0
        If SpriteDropper.Text = "None" Then
            ImageCount = 1
            OpenSpriteButton.Enabled = False
        Else
            For Each X As String In Directory.GetFiles(SessionPath + "Sprites")
                X = X.Substring(X.LastIndexOf("\") + 1)
                X = X.Substring(0, X.LastIndexOf("."))
                X = X.Substring(X.IndexOf("_") + 1)
                If X = SpriteDropper.Text Then ImageCount += 1
            Next
        End If
        FrameLimit = ImageCount
        If Not Frame <= FrameLimit - 1 Then Frame = 0
        FrameLeftButton.Enabled = True
        FrameRightButton.Enabled = True
        If FrameLimit = 1 Then FrameRightButton.Enabled = False
        If Frame = 0 Then FrameLeftButton.Enabled = False
        If Frame = FrameLimit - 1 Then FrameRightButton.Enabled = False
        RenderSprite()
    End Sub

    Private Sub FrameLeftButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrameLeftButton.Click
        Frame -= 1
        FrameRightButton.Enabled = True
        RenderSprite()
        If Frame = 0 Then FrameLeftButton.Enabled = False
    End Sub

    Private Sub FrameRightButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrameRightButton.Click
        Frame += 1
        FrameLeftButton.Enabled = True
        RenderSprite()
        If Frame = FrameLimit - 1 Then FrameRightButton.Enabled = False
    End Sub

    Private Sub AddEventButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEventButton.Click, AddEventRightClickButton.Click
        DEvent.Text = "Add Event"
        DEvent.ShowDialog()
        If Not DEvent.UseData Then Exit Sub
        Dim MainClass As String = DEvent.MainClass
        Dim SubClass As String = DEvent.SubClass
        If MainClass = "NoData" Then Exit Sub
        For X As Int16 = 0 To DEventMainClasses.Count - 1
            If DEventMainClasses(X) = MainClass And DEventSubClasses(X) = SubClass Then
                SaveOnNextChange = True
                EventsListBox.SelectedIndex = X - 1
                Exit Sub
            End If
        Next
        Dim NewLine As String = "EVENT " + NameTextBox.Text + "," + MainClassStringToType(MainClass).ToString + "," + SubClass
        MyXDSLines += NewLine + vbCrLf
        If DEventMainClasses.Count = 0 Then
            SaveOnNextChange = False
        Else
            SaveOnNextChange = True
        End If
        DEventMainClasses.Add(MainClass)
        DEventSubClasses.Add(SubClass)
        EventsListBox.Items.Add(SubClass)
        EventsListBox.SelectedIndex = EventsListBox.Items.Count - 1
    End Sub

    Private Sub EventsListBox_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles EventsListBox.MeasureItem
        e.ItemHeight = 24
    End Sub

    Private Sub EventsListBox_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles EventsListBox.DrawItem
        If e.Index < 0 Then Exit Sub
        Dim IsSelected As Boolean = False
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then IsSelected = True
        Dim Drawable As New Bitmap(16, 16)
        Dim FinalText As String = String.Empty
        Select Case MainClassStringToType(DEventMainClasses(e.Index))
            Case 0
                Drawable = My.Resources.QuestionIcon
                FinalText = "<Unkown>"
            Case 1
                Drawable = My.Resources.CreateEventIcon
                FinalText = "Create"
            Case 2, 3, 4
                Drawable = My.Resources.KeyIcon
                FinalText = DEventSubClasses(e.Index) + " " + DEventMainClasses(e.Index)
            Case 5
                Drawable = My.Resources.StylusIcon
                FinalText += "Touch (" + DEventSubClasses(e.Index) + ")"
            Case 6
                Drawable = My.Resources.Collision
                Dim TheWith As String = DEventSubClasses(e.Index)
                If TheWith = "NoData" Then TheWith = "<Unknown>"
                FinalText += "Collision with " + TheWith
            Case 7
                Drawable = My.Resources.ClockIcon
                FinalText = "Step"
            Case 8
                Drawable = My.Resources.OtherIcon
                FinalText += DEventSubClasses(e.Index)
        End Select
        e.Graphics.FillRectangle(Brushes.White, e.Bounds)
        If IsSelected Then e.Graphics.DrawImage(My.Resources.BarBGSmall, e.Bounds)
        If IsSelected Then e.Graphics.DrawImageUnscaled(My.Resources.RoundedBlock, New Point(2, e.Bounds.Y + 2))
        e.Graphics.DrawImage(Drawable, New Point(4, e.Bounds.Y + 4))
        'If IsSelected Then
        '    e.Graphics.DrawString(FinalText, New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, 24, 5 + e.Bounds.Y)
        '    e.Graphics.DrawString(FinalText, New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.White, 24, 4 + e.Bounds.Y)
        'Else
        '    e.Graphics.DrawString(FinalText, New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, 24, 4 + e.Bounds.Y)
        'End If
        If IsSelected Then
            e.Graphics.DrawString(FinalText, New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.White, 24, 5 + e.Bounds.Y)
            e.Graphics.DrawString(FinalText, New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, 24, 4 + e.Bounds.Y)
        Else
            e.Graphics.DrawString(FinalText, New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, 24, 4 + e.Bounds.Y)
        End If
    End Sub

    Sub DeleteEvent(ByVal TheIndex As Int16)
        SaveOnNextChange = False
        Dim FI As Int16 = 0
        If EventsListBox.Items.Count > 1 Then
            If TheIndex = 0 Then FI = 1 Else FI = 0
            EventsListBox.SelectedIndex = FI
            'SelectedEvent = FI
        Else
            SelectedEvent = 100
        End If
        Dim FinalString As String = String.Empty
        For Each X As String In StringToLines(MyXDSLines)
            If X.StartsWith("EVENT " + ObjectName + "," + MainClassStringToType(DEventMainClasses(TheIndex)).ToString + "," + DEventSubClasses(TheIndex)) Then
                Continue For
            End If
            If X.StartsWith("ACT " + ObjectName + "," + MainClassStringToType(DEventMainClasses(TheIndex)).ToString + "," + DEventSubClasses(TheIndex) + ",") Then
                Continue For
            End If
            FinalString += X + vbCrLf
        Next
        MyXDSLines = FinalString
        EventsListBox.Items.RemoveAt(TheIndex)
        If EventsListBox.Items.Count > 0 Then SelectedEvent = EventsListBox.SelectedIndex
        DEventMainClasses.RemoveAt(TheIndex)
        DEventSubClasses.RemoveAt(TheIndex)
        'If EventsListBox.SelectedIndex = TheIndex Then
        '    ActionsList.Items.Clear()
        '    Actions.Clear()
        '    ActionDisplays.Clear()
        '    ActionAppliesTos.Clear()
        '    ActionArguments.Clear()
        '    ActionImages.Clear()
        'End If
        'EventsListBox.Items.RemoveAt(TheIndex)
        'DEventMainClasses.RemoveAt(TheIndex)
        'DEventSubClasses.RemoveAt(TheIndex)
    End Sub

    Private Sub DeleteEventButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteEventButton.Click, DeleteEventRightClickButton.Click
        'MsgError(MyXDSLines)
        'Exit Sub
        If EventsListBox.SelectedIndices.Count = 0 Then Exit Sub
        Dim Response As Byte = MessageBox.Show("Are you sure you want to remove the Event and all of its Actions?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Not Response = MsgBoxResult.Yes Then Exit Sub
        DeleteEvent(EventsListBox.SelectedIndices(0))
    End Sub

    Private Sub ChangeEventButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeEventButton.Click, ChangeEventRightClickButton.Click
        If EventsListBox.SelectedIndices.Count = 0 Then Exit Sub
        DEvent.ShowDialog()
        If DEvent.UseData = False Then Exit Sub
        Dim I As Int16 = EventsListBox.SelectedIndex
        Dim OldMC As Byte = MainClassStringToType(DEventMainClasses(I))
        Dim OldSC As String = DEventSubClasses(I)
        Dim MC As Byte = MainClassStringToType(DEvent.MainClass)
        Dim SC As String = DEvent.SubClass
        If MC = OldMC And SC = OldSC Then Exit Sub
        If DEventMainClasses.Contains(DEvent.MainClass) And DEventSubClasses.Contains(DEvent.SubClass) Then
            MsgWarn("That event is already in-use.")
            Exit Sub
        End If
        Dim FinalString As String = String.Empty
        For Each P As String In StringToLines(MyXDSLines)
            If P.Length = 0 Then Continue For
            If P.StartsWith("EVENT ") And P.EndsWith("," + OldMC.ToString + "," + OldSC) Then
                P = P.Substring(0, P.Length - ("," + OldMC.ToString + "," + OldSC).Length)
                P += "," + MC.ToString + "," + SC
            End If
            If P.StartsWith("ACT " + ObjectName + "," + OldMC.ToString + "," + OldSC + ",") Then
                P = P.Substring(("ACT " + ObjectName + "," + MC.ToString + "," + SC + ",").Length)
                P = "ACT " + ObjectName + "," + MC.ToString + "," + SC + "," + P
            End If
            FinalString += P + vbCrLf
        Next
        MyXDSLines = FinalString
        DEventMainClasses(I) = DEvent.MainClass
        DEventSubClasses(I) = SC
        EventsListBox.Refresh()
        'MsgError(Actions.Count.ToString)
        'MsgError(ActionArguments.Count.ToString)
        'MsgError(ActionAppliesTos.Count.ToString)
        'MsgError(ActionDisplays.Count.ToString)
        'MsgError(ActionImages.Count.ToString)
        'For i As Byte = 0 To Actions.Count - 1
        '    MsgError(Actions(i))
        '    MsgError(ActionArguments(i))
        '    MsgError(ActionAppliesTos(i))
        'Next
        'MsgError(MyXDSLines)
        'For Each X As String In ActionAppliesTos
        '    MsgError(X)
        'Next
        'MsgError(FS)
        'Actions(DraggingInternal) = Actions(DraggingInternal - 1)
        'Exit Sub
        'DEvent.Text = "Change Event"
        'MsgError(MyXDSLines)
    End Sub

    Private Sub ActionsList_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ActionsList.DrawItem
        If e.Index < 0 Then Exit Sub
        Dim IsSelected As Boolean = False
        Dim ThinNum As Byte = If(ThinList, 24, 36)
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then IsSelected = True
        Dim MyX As Int16 = CurrentIndents(e.Index) * If(ThinList, 16, 24)
        e.Graphics.FillRectangle(Brushes.White, New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
        If IsSelected Then e.Graphics.DrawImage(My.Resources.BarBG, New Rectangle(0, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
        Dim ThingString As String = ActionAppliesTos(e.Index)
        Dim ArgString As String = String.Empty
        Dim NiceArgs As String = ArgumentsMakeAttractive(ActionArguments(e.Index), True)
        If ThinList Then
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            e.Graphics.DrawImage(ActionGetIcon(Actions(e.Index)), New Rectangle(MyX + 2, e.Bounds.Y + 2, 20, 20))
            e.Graphics.DrawString(ActionDisplays(e.Index), New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.White, MyX + ThinNum, e.Bounds.Y + 5 + 1)
            e.Graphics.DrawString(ActionDisplays(e.Index), New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, MyX + ThinNum, e.Bounds.Y + 5)
            Exit Sub
        Else
            e.Graphics.DrawImageUnscaled(ActionGetIcon(Actions(e.Index)), New Point(MyX + 2, e.Bounds.Y + 2))
            If NiceArgs.Length > 0 Then
                If ThingString = "this" Then
                    If Actions(e.Index) = "Execute Code" Then
                        ArgString = NiceArgs
                    Else
                        ArgString = "Arguments of " + NiceArgs
                    End If
                ElseIf IsObject(ThingString) Then
                    If Actions(e.Index) = "Execute Code" Then
                        ArgString = "Applies to instances of " + ThingString + ": " + NiceArgs
                    Else
                        ArgString = "Applies to instances of " + ThingString + " with Args. " + NiceArgs
                    End If
                Else
                    If Actions(e.Index) = "Execute Code" Then
                        ArgString = "Applies to instance IDs " + ThingString + ": " + NiceArgs
                    Else
                        ArgString = "Applies to instance IDs " + ThingString + " with Args. " + NiceArgs
                    End If
                End If
                'Else
                '    If IsObject(ThingString) Then
                '        ArgString = "Applies to instances of " + ThingString
                '    Else
                '        ArgString = "Applies to instance IDs " + ThingString
                '    End If
            End If
            Dim TheY As Int16 = e.Bounds.Y + If(NiceArgs.Length > 0, 5, 10)
            If IsSelected Then
                e.Graphics.DrawString(ArgString, New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.White, MyX + ThinNum, e.Bounds.Y + (ThinNum / 2) + 1)
                e.Graphics.DrawString(ArgString, New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Gray, MyX + ThinNum, e.Bounds.Y + 18)
                e.Graphics.DrawString(ActionDisplays(e.Index), New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.White, MyX + ThinNum, e.Bounds.Y + If(NiceArgs.Length > 0, 5, 10) + 1)
                e.Graphics.DrawString(ActionDisplays(e.Index), New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, MyX + ThinNum, e.Bounds.Y + If(NiceArgs.Length > 0, 5, 10))
                e.Graphics.DrawImageUnscaled(My.Resources.Corners, New Point(-7, e.Bounds.Y - 6))
                e.Graphics.DrawImageUnscaled(My.Resources.Corners, New Point(-7, e.Bounds.Y + ThinNum - 6))
                e.Graphics.DrawImageUnscaled(My.Resources.Corners, New Point(e.Bounds.Width - 7, e.Bounds.Y - 7))
                e.Graphics.DrawImageUnscaled(My.Resources.Corners, New Point(e.Bounds.Width - 7, e.Bounds.Y + 29))
            Else
                e.Graphics.DrawString(ArgString, New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.LightGray, MyX + ThinNum, e.Bounds.Y + (ThinNum / 2))
                e.Graphics.DrawString(ActionDisplays(e.Index), New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, MyX + ThinNum, e.Bounds.Y + If(NiceArgs.Length > 0, 5, 10))
            End If
        End If
    End Sub

    Private Sub ActionsList_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles ActionsList.MeasureItem
        e.ItemHeight = If(ThinList, 24, 36)
    End Sub

    Public Function ArgumentsMakeAttractive(ByVal InputArguments As String, ByVal HideSymbols As Boolean) As String
        Dim Returnable As String = InputArguments
        Returnable = Returnable.Replace(";", ", ").Replace("<com>", ",").Replace("<sem>", ";")
        If HideSymbols Then Returnable = Returnable.Replace("<br|>", " .. ")
        Return Returnable
    End Function

    Sub SaveCurrentData()
        'MsgError(SelectedEvent.ToString)
        'MsgError("Saved Current Data")
        If EventsListBox.SelectedIndices.Count = 0 Then Exit Sub
        'If DEventMainClasses.Count = 0 Then Exit Sub
        'MsgError("SaveCurrentData 2")
        Dim FinalString As String = String.Empty
        'MsgError("filter is ACT " + ObjectName + "," + DEventMainClasses(TempIndex) + "," + DEventSubClasses(TempIndex) + ",")
        'MsgError("filter is ACT " + ObjectName + "," + MainClassStringToType(DEventMainClasses(SelectedEvent)).ToString + "," + DEventSubClasses(SelectedEvent) + ",")
        'MsgError(MainClassStringToType(DEventMainClasses(SelectedEvent)).ToString)
        For Each X As String In StringToLines(MyXDSLines)
            If X.Length = 0 Then Continue For
            'MsgError(X + vbcrlf + vbcrlf + "against" + vbcrlf + vbcrlf + "ACT " + ObjectName + "," + MainClassStringToType(DEventMainClasses(SelectedEvent)).ToString + "," + DEventSubClasses(SelectedEvent) + ",")
            If Not X.StartsWith("ACT " + ObjectName + "," + MainClassStringToType(DEventMainClasses(SelectedEvent)).ToString + "," + DEventSubClasses(SelectedEvent) + ",") Then
                FinalString += X + vbCrLf
            End If
        Next
        'MsgError(FinalString)
        'MsgError("new index is " + EventsListBox.SelectedIndex.ToString)
        'Dim TempIndex As Byte = EventsListBox.SelectedIndex
        For X As Int16 = 0 To Actions.Count - 1
            Dim TheNewLine As String = "ACT " + ObjectName + "," + MainClassStringToType(DEventMainClasses(SelectedEvent)).ToString + "," + DEventSubClasses(SelectedEvent) + ","
            TheNewLine += Actions(X) + "," + ActionArguments(X) + "," + ActionAppliesTos(X)
            FinalString += TheNewLine + vbCrLf
        Next
        MyXDSLines = FinalString
    End Sub

    Private Sub EventsListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EventsListBox.SelectedIndexChanged
        'MsgBox(If(SaveDataOnEventChange, "true", "false"))
        If EventsListBox.Items.Count = 0 Then Exit Sub
        If EventsListBox.SelectedIndex < 0 Then Exit Sub
        If EventsListBox.SelectedIndex > DEventMainClasses.Count - 1 Then Exit Sub
        'If SelectedEvent = 100 Then Exit Sub
        If SaveOnNextChange Then SaveCurrentData()
        SaveOnNextChange = True
        Actions.Clear()
        ActionArguments.Clear()
        ActionDisplays.Clear()
        ActionAppliesTos.Clear()
        ActionImages.Clear()
        ActionsList.Items.Clear()
        'GenerateIndentIndices()
        Dim MainClass As Byte = MainClassStringToType(DEventMainClasses(EventsListBox.SelectedIndex))
        Dim SubClass As String = DEventSubClasses(EventsListBox.SelectedIndex)
        'MsgError("Mainclass is " + MainClass.ToString)
        'MsgError("Subclass is " + SubClass.ToString)
        'MsgError("Gonna work on:" + vbcrlf + vbcrlf + MyXDSLines)
        Dim TempCount As Int16 = 0
        If MyXDSLines.Length > 0 Then
            For Each X As String In StringToLines(MyXDSLines)
                If X.Length = 0 Then Continue For
                If Not X.StartsWith("ACT ") Then Continue For
                X = SillyFixMe(X)
                'MsgError(X(X.Length - 1))
                If Not (iGet(X, 1, ",") = MainClass.ToString) Or Not (iGet(X, 2, ",") = SubClass) Then Continue For
                'MsgError("On X at " + X)
                Dim ActionName As String = iGet(X, 3, ",")
                'MsgError("ActionName is " + ActionName)
                Dim ActionArgs As String = iGet(X, 4, ",")
                'ActionArgs = ActionArgs.Replace("<com>", ",")
                'MsgError("Action Arguments are " + ActionArgs.ToString)
                Actions.Add(ActionName)
                ActionArguments.Add(ActionArgs)
                Dim AppliesTo As String = iGet(X, 5, ",")
                'MsgError(ActionEquateDisplay(ActionName, ActionArgs))
                ActionDisplays.Add(ActionEquateDisplay(ActionName, ActionArgs))
                ActionAppliesTos.Add(AppliesTo)
                ActionImages.Add(ActionGetIconPath(ActionName, False))
                'MsgError(ActionGetIconPath(ActionName, False))
                TempCount += 1
            Next
        End If
        GenerateIndentIndices()
        If TempCount > 0 Then
            For X = 0 To TempCount - 1
                ActionsList.Items.Add(String.Empty)
            Next
        End If
        'Hmm
        'SaveDataOnEventChange = False
        SelectedEvent = EventsListBox.SelectedIndex
        'MsgError(SelectedEvent)
    End Sub

    Private Sub OpenSpriteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenSpriteButton.Click
        For Each TheForm As Form In Me.MdiChildren
            If TheForm.Text = SpriteDropper.Text Then
                TheForm.Focus()
                Exit Sub
            End If
        Next
        Dim SpriteForm As New Sprite
        SpriteForm.SpriteName = SpriteDropper.Text
        ShowInternalForm(SpriteForm)
    End Sub

    Sub EditAction()
        If ActionsList.SelectedIndices.Count = 0 Then Exit Sub
        If ActionsList.SelectedIndices.Count > 1 Then
            MsgWarn("You may only edit one Action at once.")
            Exit Sub
        End If
        Dim EditingIndex As Int16 = ActionsList.SelectedIndices(0)
        If Actions(EditingIndex) = "Execute Code" Then
            EditCode.ReturnableCode = ActionArguments(EditingIndex)
            EditCode.CodeMode = CodeMode.DBAS
            EditCode.ImportExport = True
            If EditCode.ShowDialog = Windows.Forms.DialogResult.OK Then
                ActionArguments(EditingIndex) = EditCode.ReturnableCode
            End If
        Else
            'MsgError("Previous to Opening the dialogue")
            'MsgError("AppliesTo: """ + ActionAppliesTos(EditingIndex) + """")
            With Action
                .ArgumentString = ActionArguments(EditingIndex)
                .ActionName = Actions(EditingIndex)
                .AppliesTo = ActionAppliesTos(EditingIndex)
                .ShowDialog()
                If Not .UseData Then Exit Sub
                ActionAppliesTos.Item(EditingIndex) = .AppliesTo
                ActionArguments.Item(EditingIndex) = .ArgumentString
                ActionDisplays.Item(EditingIndex) = ActionEquateDisplay(.ActionName, .ArgumentString)
            End With
            ActionsList.Invalidate()
        End If
    End Sub

    Function ShouldAllowDialog(ByVal ActionName As String) As Boolean
        Dim NoAppliesTo As Boolean = False
        Dim ArgCount As Byte = 0
        For Each X As String In File.ReadAllLines(AppPath + "Actions\" + Actions(ActionsList.SelectedIndices(0)) + ".action")
            If X = "NOAPPLIES" Then NoAppliesTo = True
            If X.StartsWith("ARG ") Then ArgCount += 1
        Next
        If ArgCount = 0 And NoAppliesTo Then Return False
        Return True
    End Function

    Private Sub ActionsList_MouseDoubleClick() Handles ActionsList.MouseDoubleClick, EditValuesRightClickButton.Click
        If ActionsList.SelectedIndices.Count = 0 Then Exit Sub
        If ShouldAllowDialog(Actions(ActionsList.SelectedIndices(0))) Then EditAction()
    End Sub

    Private Sub DeleteRightClickButton_Click() Handles DeleteActionRightClickButton.Click
        While ActionsList.SelectedIndices.Count > 0
            Dim TheIndex As Int16 = ActionsList.SelectedIndices(0)
            Actions.RemoveAt(TheIndex)
            ActionDisplays.RemoveAt(TheIndex)
            ActionArguments.RemoveAt(TheIndex)
            ActionAppliesTos.RemoveAt(TheIndex)
            ActionImages.RemoveAt(TheIndex)
            ActionsList.Items.RemoveAt(TheIndex)
        End While
        'ActionsList.Items.RemoveAt(ActionsList.SelectedIndex)
        GenerateIndentIndices()
    End Sub

    Private Sub ActionRightClickMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ActionRightClickMenu.Opening
        Dim HasActions As Boolean = If(ActionsList.Items.Count > 0, True, False)
        DeleteActionRightClickButton.Enabled = HasActions
        CutActionRightClickButton.Enabled = HasActions
        CopyActionRightClickButton.Enabled = HasActions
        ClearActionsRightClickButton.Enabled = HasActions
        If ActionsList.Items.Count > 0 Then
            ActionsList.SelectedIndex = ActionsList.IndexFromPoint(ActionsList.PointToClient(Control.MousePosition))
        End If
        Dim CanPaste As Boolean = Clipboard.ContainsText()
        If CanPaste Then 'Attempt to disprove paste ability
            Dim DOn As Int32 = 0
            Dim TheItems As New List(Of String)
            For Each X As String In StringToLines(Clipboard.GetText)
                If X.Length > 0 Then
                    If DOn = 0 And Not X = "DSGMACTS" Then CanPaste = False : Exit For
                    If DOn > 0 Then
                        TheItems.Add(X)
                    End If
                    DOn += 1
                End If
            Next
            If TheItems.Count = 0 Then CanPaste = False
        End If
        EditValuesRightClickButton.Enabled = If(ActionsList.SelectedIndices.Count = 1, True, False)
        PasteActionBelowRightClickButton.Enabled = CanPaste
        If ActionsList.Items.Count > 0 Then
            If Not ShouldAllowDialog(Actions(ActionsList.SelectedIndex)) Then
                EditValuesRightClickButton.Enabled = False
            End If
        End If
    End Sub

    Private Sub ActionsList_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ActionsList.MouseDown
        If Not ActionsList.SelectionMode = SelectionMode.One Then Exit Sub
        DragInternal = True
        DraggingInternal = ActionsList.SelectedIndex
        Me.Cursor = Cursors.NoMove2D
    End Sub

    Private Sub ActionsList_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ActionsList.MouseUp
        If Not ActionsList.SelectionMode = SelectionMode.One Then Exit Sub
        DragInternal = False
        GenerateIndentIndices()
        ActionsList.Invalidate()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ActionsList_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ActionsList.MouseMove
        If Not ActionsList.SelectionMode = SelectionMode.One Then Exit Sub
        If Not DragInternal Then Exit Sub
        If DraggingInternal = ActionsList.SelectedIndex Then Exit Sub
        If DraggingInternal > ActionsList.SelectedIndex Then
            Dim TextForCurrent As String = Actions(DraggingInternal - 1)
            Dim TextForAbove As String = Actions(DraggingInternal)
            Actions(DraggingInternal) = TextForCurrent
            Actions(DraggingInternal - 1) = TextForAbove
            Dim ImageForCurrent As String = ActionImages(DraggingInternal - 1)
            Dim ImageForAbove As String = ActionImages(DraggingInternal)
            ActionImages(DraggingInternal) = ImageForCurrent
            ActionImages(DraggingInternal - 1) = ImageForAbove
            Dim ArgumentForCurrent As String = ActionArguments(DraggingInternal - 1)
            Dim ArgumentForAbove As String = ActionArguments(DraggingInternal)
            ActionArguments(DraggingInternal) = ArgumentForCurrent
            ActionArguments(DraggingInternal - 1) = ArgumentForAbove
            Dim DisplayForCurrent As String = ActionDisplays(DraggingInternal - 1)
            Dim DisplayForAbove As String = ActionDisplays(DraggingInternal)
            ActionDisplays(DraggingInternal) = DisplayForCurrent
            ActionDisplays(DraggingInternal - 1) = DisplayForAbove
            Dim ApplyForCurrent As String = ActionAppliesTos(DraggingInternal - 1)
            Dim ApplyForAbove As String = ActionAppliesTos(DraggingInternal)
            ActionAppliesTos(DraggingInternal) = ApplyForCurrent
            ActionAppliesTos(DraggingInternal - 1) = ApplyForAbove
            DraggingInternal -= 1
        Else
            Dim TextForCurrent As String = Actions(DraggingInternal + 1)
            Dim TextForAbove As String = Actions(DraggingInternal)
            Actions(DraggingInternal) = TextForCurrent
            Actions(DraggingInternal + 1) = TextForAbove
            Dim ImageForCurrent As String = ActionImages(DraggingInternal + 1)
            Dim ImageForAbove As String = ActionImages(DraggingInternal)
            ActionImages(DraggingInternal) = ImageForCurrent
            ActionImages(DraggingInternal + 1) = ImageForAbove
            Dim ArgumentForCurrent As String = ActionArguments(DraggingInternal + 1)
            Dim ArgumentForAbove As String = ActionArguments(DraggingInternal)
            ActionArguments(DraggingInternal) = ArgumentForCurrent
            ActionArguments(DraggingInternal + 1) = ArgumentForAbove
            Dim DisplayForCurrent As String = ActionDisplays(DraggingInternal + 1)
            Dim DisplayForAbove As String = ActionDisplays(DraggingInternal)
            ActionDisplays(DraggingInternal) = DisplayForCurrent
            ActionDisplays(DraggingInternal + 1) = DisplayForAbove
            Dim ApplyForCurrent As String = ActionAppliesTos(DraggingInternal + 1)
            Dim ApplyForAbove As String = ActionAppliesTos(DraggingInternal)
            ActionAppliesTos(DraggingInternal) = ApplyForCurrent
            ActionAppliesTos(DraggingInternal + 1) = ApplyForAbove
            DraggingInternal += 1
        End If
        ActionsList.Invalidate()
    End Sub

    'Function GenerateForumLine(ByVal RowID As Int16) As String
    '    Dim Returnable As String = Actions(RowID) + " " + ArgumentsMakeAttractive(ActionArguments(RowID))
    '    Dim ApplyTo As String = ActionAppliesTos(RowID)
    '    If Not ApplyTo = "this" Then
    '        If IsObject(ApplyTo) Then
    '            ApplyTo = "instances of " + ApplyTo
    '        Else
    '            ApplyTo = "instances IDs " + ApplyTo
    '        End If
    '        Returnable += " (applying to " + ApplyTo + ")"
    '    End If
    '    Return Returnable
    'End Function

    Sub RepopulateLibrary()
        PopulateActionsTabControl(ActionsToAddTabControl)
    End Sub

    'Private Sub CopyAllForForumButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim FinalString As String = "Actions for " + DEventMainClasses(SelectedEvent) + " Event on " + ObjectName + vbcrlf + vbcrlf
    '    For X As Int16 = 0 To ActionsList.Items.Count - 1
    '        FinalString += GenerateForumLine(X) + vbcrlf
    '    Next
    '    Clipboard.SetText(FinalString)
    'End Sub

    'Private Sub ActionsDropper_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    For X As Byte = 0 To ActionsDropper.DropDownItems.Count - 1
    '        ActionsDropper.DropDownItems(X).Enabled = True
    '    Next
    '    If ActionsList.Items.Count = 0 Then
    '        CopyAllForForumButton.Enabled = False
    '        'FUTURE ADDITION??
    '    End If
    'End Sub

    Private Sub ClearRightClickButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearActionsRightClickButton.Click
        Dim Response As Byte = MessageBox.Show("Are you sure you want to clear the list of Actions?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Not Response = MsgBoxResult.Yes Then Exit Sub
        Actions.Clear()
        ActionImages.Clear()
        ActionDisplays.Clear()
        ActionAppliesTos.Clear()
        ActionArguments.Clear()
        ActionsList.Items.Clear()
        GenerateIndentIndices()
    End Sub

    Private Sub CutRightClickButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutActionRightClickButton.Click
        CopyActionRightClickButton_Click()
        DeleteRightClickButton_Click()
    End Sub

    Private Sub EventRightClickMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EventRightClickMenu.Opening
        If Not EventsListBox.Items.Count = 0 Then EventsListBox.SelectedIndex = EventsListBox.IndexFromPoint(EventsListBox.PointToClient(Control.MousePosition))
        For X As Byte = 0 To EventRightClickMenu.Items.Count - 1
            EventRightClickMenu.Items(X).Enabled = True
        Next
        If EventsListBox.Items.Count = 0 Then
            ChangeEventRightClickButton.Enabled = False
            DeleteEventRightClickButton.Enabled = False
            ClearEventsButton.Enabled = False
            Exit Sub
        End If
    End Sub

    Private Sub ClearEventsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearEventsButton.Click
        Dim Response As Byte = MessageBox.Show("Are you sure you want to clear the list of Events?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Not Response = MsgBoxResult.Yes Then Exit Sub
        EventsListBox.Items.Clear()
        DEventMainClasses.Clear()
        DEventSubClasses.Clear()
        Actions.Clear()
        ActionImages.Clear()
        ActionDisplays.Clear()
        ActionAppliesTos.Clear()
        ActionArguments.Clear()
        ActionsList.Items.Clear()
        GenerateIndentIndices()
        MyXDSLines = String.Empty
    End Sub

    Private Sub SelectAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllButton.Click
        For i As Int16 = 0 To ActionsList.Items.Count - 1
            ActionsList.SelectedIndices.Add(i)
        Next
        'Dim FinalString As String = "DSGMALL" + vbcrlf
        'For i As Int16 = 0 To Actions.Count - 1
        '    FinalString += Actions(i) + ","
        '    FinalString += ActionArguments(i) + ","
        '    FinalString += ActionAppliesTos(i) + vbcrlf
        'Next
        'Clipboard.SetText(FinalString)
    End Sub

    Private Sub CopyActionRightClickButton_Click() Handles CopyActionRightClickButton.Click
        Dim FinalString As String = "DSGMACTS" + vbCrLf
        For Each X As Int16 In ActionsList.SelectedIndices
            FinalString += Actions(X) + "," + ActionArguments(X) + "," + ActionAppliesTos(X) + vbCrLf
        Next
        FinalString = FinalString.Substring(0, FinalString.Length - 1)
        Clipboard.SetText(FinalString)
    End Sub

    'Private Sub PasteAtBottomButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Not Clipboard.ContainsText Then Exit Sub
    '    If Not Clipboard.GetText.StartsWith("DSGMALL") Then Exit Sub
    '    For Each X As String In StringToLines(Clipboard.GetText)
    '        If X.StartsWith("DSGMALL") Then Continue For
    '        If X.Length = 0 Then Continue For
    '        Dim ActionName As String = iget(X, 0, ",")
    '        Dim ActionArgs As String = iget(X, 1, ",")
    '        Dim ActionApply As String = iget(X, 2, ",")
    '        Actions.Add(ActionName)
    '        ActionArguments.Add(ActionArgs)
    '        ActionAppliesTos.Add(ActionApply)
    '        ActionDisplays.Add(ActionEquateDisplay(ActionName, ActionArgs))
    '        ActionImages.Add(ActionGetIconPath(ActionName, False))
    '        ActionsList.Items.Add(String.Empty)
    '    Next
    '    GenerateIndentIndices()
    'End Sub

    Private Sub SelectOneButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectOneButton.Click, SelectOneRightClickButton.Click
        ActionsList.SelectionMode = SelectionMode.One
    End Sub

    Private Sub SelectManyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectManyButton.Click, SelectManyRightClickButton.Click
        ActionsList.SelectionMode = SelectionMode.MultiExtended
    End Sub

End Class