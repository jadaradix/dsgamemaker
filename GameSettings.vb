Public Class GameSettings

    Private Sub GameSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StartingRoomDropper.Items.Clear()
        For Each X As TreeNode In MainForm.ResourcesTreeView.Nodes(ResourceIDs.Room).Nodes
            StartingRoomDropper.Items.Add(X.Text)
        Next
        StartingRoomDropper.Text = GetXDSLine("BOOTROOM ").Substring(9)
        ProjectNameTextBox.Text = GetXDSLine("PROJECTNAME ").Substring(12)
        Text2TextBox.Text = GetXDSLine("TEXT2 ").Substring(6)
        Text3TextBox.Text = GetXDSLine("TEXT3 ").Substring(6)
        ScoreDropper.Value = Convert.ToInt16(GetXDSLine("SCORE ").Substring(6))
        LivesDropper.Value = Convert.ToInt16(GetXDSLine("LIVES ").Substring(6))
        HealthDropper.Value = Convert.ToInt16(GetXDSLine("HEALTH ").ToString.Substring(7))
        FATCallCheckBox.Checked = If(GetXDSLine("FAT_CALL ").Substring(9) = "1", True, False)
        NitroFSCallCheckBox.Checked = If(GetXDSLine("NITROFS_CALL ").Substring(13) = "1", True, False)
        MidPointCheckBox.Checked = If(GetXDSLine("MIDPOINT_COLLISIONS ").Substring(20) = "1", True, False)
        IncludeWiFiLibChecker.Checked = If(GetXDSLine("INCLUDE_WIFI_LIB ").Substring(17) = "1", True, False)

        IncludeFilesList.Items.Clear()
        NitroFSFilesList.Items.Clear()
        For Each P As String In GetXDSFilter("INCLUDE ")
            IncludeFilesList.Items.Add(P.Substring(8))
        Next
        For Each P As String In GetXDSFilter("NITROFS ")
            NitroFSFilesList.Items.Add(P.Substring(8))
        Next
    End Sub

    Private Sub DCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DCancelButton.Click
        Me.Close()
    End Sub

    Private Sub DOkayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOkayButton.Click
        XDSChangeLine(GetXDSLine("BOOTROOM "), "BOOTROOM " + StartingRoomDropper.Text)
        XDSChangeLine(GetXDSLine("PROJECTNAME "), "PROJECTNAME " + ProjectNameTextBox.Text)
        CacheProjectName = ProjectNameTextBox.Text
        XDSChangeLine(GetXDSLine("TEXT2 "), "TEXT2 " + Text2TextBox.Text)
        XDSChangeLine(GetXDSLine("TEXT3 "), "TEXT3 " + Text3TextBox.Text)
        XDSChangeLine(GetXDSLine("SCORE "), "SCORE " + ScoreDropper.Value.ToString)
        XDSChangeLine(GetXDSLine("LIVES "), "LIVES " + LivesDropper.Value.ToString)
        XDSChangeLine(GetXDSLine("HEALTH "), "HEALTH " + HealthDropper.Value.ToString)
        XDSChangeLine(GetXDSLine("FAT_CALL "), "FAT_CALL " + If(FATCallCheckBox.Checked, "1", "0"))
        XDSChangeLine(GetXDSLine("NITROFS_CALL "), "NITROFS_CALL " + If(NitroFSCallCheckBox.Checked, "1", "0"))
        XDSChangeLine(GetXDSLine("MIDPOINT_COLLISIONS "), "MIDPOINT_COLLISIONS " + If(MidPointCheckBox.Checked, "1", "0"))
        XDSChangeLine(GetXDSLine("INCLUDE_WIFI_LIB "), "INCLUDE_WIFI_LIB " + If(IncludeWiFiLibChecker.Checked, "1", "0"))
        Me.Close()
    End Sub

    Private Sub DeleteIncludeFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteIncludeFileButton.Click
        If IncludeFilesList.SelectedIndices.Count = 0 Then Exit Sub
        Dim TheName As String = IncludeFilesList.Items(IncludeFilesList.SelectedIndex)
        IO.File.Delete(SessionPath + "IncludeFiles\" + TheName)
        XDSRemoveLine("INCLUDE " + TheName)
        IncludeFilesList.Items.RemoveAt(IncludeFilesList.SelectedIndex)
    End Sub

    Private Sub DeleteNitroFSFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteNitroFSFileButton.Click
        If NitroFSFilesList.SelectedIndices.Count = 0 Then Exit Sub
        Dim TheName As String = NitroFSFilesList.Items(NitroFSFilesList.SelectedIndex)
        IO.File.Delete(SessionPath + "NitroFSFiles\" + TheName)
        XDSRemoveLine("NITROFS " + TheName)
        NitroFSFilesList.Items.RemoveAt(NitroFSFilesList.SelectedIndex)
    End Sub

    Sub AddThing(ByVal SysName As String)
        Dim Result As String = OpenFile(String.Empty, "All Files|*.*")
        If Result.Length = 0 Then Exit Sub
        Dim ShortName As String = Result.Substring(Result.LastIndexOf("\") + 1)
        XDSAddLine(SysName.ToUpper + " " + ShortName)
        For Each P As Control In CodingTabPage.Controls
            If P.Name = SysName + "FilesList" Then
                DirectCast(P, ListBox).Items.Add(ShortName)
            End If
        Next
        IO.File.Copy(Result, SessionPath + SysName + "Files\" + ShortName, True)
    End Sub

    Private Sub AddIncludeFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddIncludeFileButton.Click
        AddThing("Include")
    End Sub

    Private Sub AddNitroFSFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNitroFSFileButton.Click
        AddThing("NitroFS")
    End Sub

    Private Sub EditIncludeFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditIncludeFileButton.Click
        If IncludeFilesList.SelectedIndices.Count = 0 Then Exit Sub
        URL(SessionPath + "IncludeFiles\" + IncludeFilesList.Items(IncludeFilesList.SelectedIndex))
    End Sub

    Private Sub EditNitroFSFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditNitroFSFileButton.Click
        If NitroFSFilesList.SelectedIndices.Count = 0 Then Exit Sub
        MsgError(SessionPath + "NitroFSFiles\" + NitroFSFilesList.Items(NitroFSFilesList.SelectedIndex))
        URL(SessionPath + "NitroFSFiles\" + NitroFSFilesList.Items(NitroFSFilesList.SelectedIndex))
    End Sub
End Class