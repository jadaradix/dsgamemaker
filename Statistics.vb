Public Class Statistics

    Dim ProjectCoolness As Int16 = 0

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        Me.Close()
    End Sub

    Private Sub Statistics_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainToolStrip.Renderer = New clsToolstripRenderer
        Dim ResSentences As New List(Of String)
        Dim LogicSentences As New List(Of String)
        Dim ToAdd As String = "You have " + GetXDSFilter("ROOM ").Length.ToString + " rooms, encompassing " + GetXDSFilter("OBJECTPOS ").Length.ToString + " instances"
        ToAdd += " of " + GetXDSFilter("OBJECT ").Length.ToString + " objects which are using " + GetXDSFilter("SPRITE ").Length.ToString + " sprites"
        ResSentences.Add(ToAdd)
        ToAdd = "There are also " + GetXDSFilter("SCRIPT ").Length.ToString + " scripts, " + GetXDSFilter("PATH ").Length.ToString + " paths,"
        ToAdd += " " + GetXDSFilter("SOUND ").Length.ToString + " sounds and " + GetXDSFilter("BACKGROUND ").Length.ToString + " backgrounds"
        ResSentences.Add(ToAdd)
        Dim ResourcesText As String = String.Empty
        For Each X As String In ResSentences
            ResourcesText += X + ". "
        Next
        ResourcesText = ResourcesText.Substring(0, ResourcesText.Length - 1)
        'Efficient Defines
        Dim EventCount As Int16 = GetXDSFilter("EVENT ").Length
        Dim ObjectCount As Int16 = GetXDSFilter("OBJECT ").Length
        Dim ActionsCount As Int32 = GetXDSFilter("ACT ").Length
        'Defines
        Dim EventAverage As Int16 = 0
        Dim ActionAverage As Int16 = 0
        Dim ActionAverage2 As Int16 = 0
        If EventCount > 0 And ObjectCount > 0 Then
            EventAverage = EventCount / ObjectCount
            ActionAverage2 = ObjectCount / EventCount
        End If
        If ActionsCount > 0 And EventCount > 0 Then ActionAverage = ActionsCount / EventCount
        ToAdd = "In your " + GetXDSFilter("OBJECT ").Length.ToString + " objects there is a total of " + GetXDSFilter("EVENT ").Length.ToString
        ToAdd += " events (an average of " + EventAverage.ToString + " events per object)"
        LogicSentences.Add(ToAdd)
        ToAdd = "There is a total of " + GetXDSFilter("OBJECT ").Length.ToString + " actions (phew!). That's an average of " + ActionAverage.ToString + " actions per event, or "
        ToAdd += ActionAverage2.ToString + " actions per object"
        LogicSentences.Add(ToAdd)
        Dim LogicText As String = String.Empty
        For Each X As String In LogicSentences
            LogicText += X + ". "
        Next
        LogicText = LogicText.Substring(0, LogicText.Length - 1)
        ResoucesLabel.Text = ResourcesText
        LogicLabel.Text = LogicText
    End Sub

    Private Sub CopytoClipboardButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopytoClipboardButton.Click
        Dim Returnable As String = "Resources:" + vbcrlf + vbcrlf
        Returnable += ResoucesLabel.Text + vbcrlf + vbcrlf
        Returnable += "Logic:" + vbcrlf + vbcrlf
        Returnable += LogicLabel.Text + vbcrlf + vbcrlf
        If ProjectCoolness > 0 Then
            Returnable += "Calculated Project Coolness was " + ProjectCoolness.ToString + "%."
        Else
            Returnable += "Project Coolness was not calculated."
        End If
        Clipboard.SetText(Returnable)
    End Sub

    Private Sub CalculateUsageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculateUsageButton.Click
        ProjectCoolness += Convert.ToInt16(GetXDSFilter("ACT ").Length / 2)
        ProjectCoolness += Convert.ToInt16(GetXDSFilter("SCRIPT ").Length * 10)
        ProjectCoolness += Convert.ToInt16(GetXDSFilter("EVENT ").Length * 2)
        ProjectCoolness += Convert.ToInt16(GetXDSFilter("EVENT ").Length * 2)
        ProjectCoolness -= Convert.ToInt16(GetXDSFilter("SPRITE ").Length * 5)
        If ProjectCoolness > 1000 Then ProjectCoolness /= 10
        If ProjectCoolness > 11 Then ProjectCoolness /= 10
        CoolBar.Value = ProjectCoolness
    End Sub
End Class