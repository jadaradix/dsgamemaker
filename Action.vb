Imports System.IO
Public Class Action

    Public UseData As Boolean = False
    Public ActionName As String
    Public ArgumentString As String
    Public AppliesTo As String

    Sub InstancesBugger()
        MsgWarn("The instance numbers must be separated by single spaces. You may also the IRandom function." + vbCrLf + vbCrLf + "For more information, see the manual.")
        InstancesTextBox.Focus()
    End Sub

    Private Sub DOkayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOkayButton.Click
        If ControlsPanel.Visible Then
            Dim IsOneEmpty As Boolean = False
            Dim FirstEmpty As Byte = 100
            Dim DOn As Byte = 0
            For Each X As Control In ControlsPanel.Controls
                If X.Name.StartsWith("Unrestricted") Then DOn += 1 : Continue For
                If X.Text.Length = 0 Then
                    If Not IsOneEmpty Then FirstEmpty = DOn
                    IsOneEmpty = True
                End If
                DOn += 1
            Next
            If IsOneEmpty Then
                MsgWarn("You must put something in every Argument box or selector.")
                ControlsPanel.Controls(DOn - 1).Focus()
                Exit Sub
            End If
        End If
        ArgumentString = String.Empty
        If ThisRadioButton.Checked Then
            AppliesTo = "this"
        ElseIf InstancesOfRadioButton.Checked Then
            AppliesTo = InstancesOfDropper.Text
        ElseIf InstancesRadioButton.Checked Then
            AppliesTo = InstancesTextBox.Text.Replace(",", "<comma>")
            'If AppliesTo.Length = 0 Or Not AppliesTo.Contains(" ") Then
            '    InstancesBugger()
            '    Exit Sub
            'End If
            'Dim OverallValid As Boolean = True
            'For X As Byte = 0 To HowManyChar(AppliesTo, " ")
            '    If iGet(AppliesTo, X, " ").ToString.StartsWith("IRandom(") Then Continue For
            '    Dim AllNumCharsAlright As Boolean = True
            '    For Each Y As String In iGet(AppliesTo, X, " ")
            '        Dim IsANumber As Boolean = False
            '        For Each C As String In Numbers
            '            If Y = C Then IsANumber = True
            '        Next
            '        If Not IsANumber Then AllNumCharsAlright = False
            '    Next
            '    If AllNumCharsAlright Then
            '        Dim ThatNumber As Int16 = Convert.ToInt16(iGet(AppliesTo, X, " "))
            '        If ThatNumber > 255 Then OverallValid = False
            '    Else
            '        OverallValid = False
            '    End If
            'Next
            'If Not OverallValid Then
            '    InstancesBugger()
            '    Exit Sub
            'End If
        End If
        UseData = True
        If ControlsPanel.Visible Then
            For Each X As Control In ControlsPanel.Controls
                Dim TheText As String = X.Text
                TheText = TheText.Replace(",", "<com>")
                If X.Name.StartsWith("Screen") Then
                    If TheText = "Top Screen" Then TheText = "1"
                    If TheText = "Bottom Screen" Then TheText = "0"
                ElseIf X.Name.StartsWith("TrueFalse") Then
                    If TheText = "True" Then TheText = "1"
                    If TheText = "False" Then TheText = "0"
                ElseIf X.Name.StartsWith("Comparative") Then
                    TheText = StringToComparative(TheText)
                End If
                ArgumentString += TheText + ";"
            Next
            ArgumentString = ArgumentString.Substring(0, ArgumentString.Length - 1)
        End If
        'MsgError(ArgumentString)
        Me.Close()
    End Sub

    'Private Sub DCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Close()
    'End Sub

    Private Sub Action_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UseData = False
        InstancesTextBox.Text = String.Empty
        InstancesOfDropper.Text = String.Empty
        Text = ActionName
        Dim DOn As Byte = 0
        LabelsPanel.Controls.Clear()
        ControlsPanel.Controls.Clear()
        For Each X As String In File.ReadAllLines(AppPath + "Actions\" + ActionName + ".action")
            If X.StartsWith("ARG ") Then
                X = X.Substring(4)
                Dim ArgumentName As String = X.Substring(0, X.IndexOf(","))
                Dim ArgumentType As Byte = Convert.ToByte(X.Substring(ArgumentName.Length + 1))
                Dim NewLabel As New Label
                NewLabel.Text = ArgumentName
                NewLabel.Location = New Point(1, 8 + (DOn * 24))
                LabelsPanel.Controls.Add(NewLabel)
                Dim InputControl As Control
                Dim TheContent As String = iGet(ArgumentString, DOn, ";").ToString.Replace("<com>", ",")
                If ArgumentType = 0 Or ArgumentType = 12 Then
                    InputControl = New TextBox
                    DirectCast(InputControl, TextBox).Location = New Point(5, 5 + (DOn * 24))
                    DirectCast(InputControl, TextBox).Width = 123
                    If ArgumentType = 0 Then InputControl.Name = "Generic" + DOn.ToString
                    If ArgumentType = 12 Then InputControl.Name = "Unrestricted" + DOn.ToString
                Else
                    InputControl = New ComboBox
                    DirectCast(InputControl, ComboBox).Location = New Point(5, 5 + (DOn * 24))
                    DirectCast(InputControl, ComboBox).Width = 123
                End If
                If ArgumentType = 1 Then
                    If TheContent = "1" Then TheContent = "Top Screen"
                    If TheContent = "0" Then TheContent = "Bottom Screen"
                    DirectCast(InputControl, ComboBox).Items.Add("Top Screen")
                    DirectCast(InputControl, ComboBox).Items.Add("Bottom Screen")
                    InputControl.Name = "Screen" + DOn.ToString
                ElseIf ArgumentType = 2 Then
                    If TheContent = "1" Then TheContent = "True"
                    If TheContent = "0" Then TheContent = "False"
                    DirectCast(InputControl, ComboBox).Items.Add("True")
                    DirectCast(InputControl, ComboBox).Items.Add("False")
                    InputControl.Name = "TrueFalse" + DOn.ToString
                ElseIf ArgumentType = 3 Then
                    For Each Y As String In GetXDSFilter("GLOBAL ")
                        Y = Y.Substring(7)
                        Dim VariableName As String = Y.Substring(0, Y.IndexOf(","))
                        DirectCast(InputControl, ComboBox).Items.Add(VariableName)
                    Next
                    InputControl.Name = "Variable" + DOn.ToString
                ElseIf ArgumentType = 4 Then
                    For Each Y As String In GetXDSFilter("OBJECT ")
                        Y = Y.Substring(7)
                        Dim ObjectName As String = Y.Substring(0, Y.IndexOf(","))
                        DirectCast(InputControl, ComboBox).Items.Add(ObjectName)
                    Next
                    InputControl.Name = "Object" + DOn.ToString
                ElseIf ArgumentType = 5 Then
                    For Each Y As String In GetXDSFilter("BACKGROUND ")
                        DirectCast(InputControl, ComboBox).Items.Add(Y.Substring(11))
                    Next
                    InputControl.Name = "Background" + DOn.ToString
                ElseIf ArgumentType = 6 Then
                    For Each Y As String In GetXDSFilter("SOUND ")
                        Y = Y.Substring(6)
                        Dim SoundName As String = Y.Substring(0, Y.IndexOf(","))
                        DirectCast(InputControl, ComboBox).Items.Add(SoundName)
                    Next
                ElseIf ArgumentType = 7 Then
                    For Each Y As String In GetXDSFilter("ROOM ")
                        Y = Y.Substring(5)
                        Dim RoomName As String = Y.Substring(0, Y.IndexOf(","))
                        DirectCast(InputControl, ComboBox).Items.Add(RoomName)
                    Next
                    InputControl.Name = "Room" + DOn.ToString
                ElseIf ArgumentType = 9 Then
                    For Each Y As String In GetXDSFilter("SCRIPT ")
                        Dim ScriptName As String = Y.Substring(7)
                        ScriptName = ScriptName.Substring(0, ScriptName.LastIndexOf(","))
                        DirectCast(InputControl, ComboBox).Items.Add(ScriptName)
                    Next
                    InputControl.Name = "Script" + DOn.ToString
                ElseIf ArgumentType = 10 Then
                    DirectCast(InputControl, ComboBox).Items.Add("Less than")
                    DirectCast(InputControl, ComboBox).Items.Add("Equal to")
                    DirectCast(InputControl, ComboBox).Items.Add("Greater than")
                    DirectCast(InputControl, ComboBox).Items.Add("Less than or Equal to")
                    DirectCast(InputControl, ComboBox).Items.Add("Greater than or Equal to")
                    DirectCast(InputControl, ComboBox).Items.Add("Not Equal to")
                    TheContent = ComparativeToString(TheContent)
                    InputControl.Name = "Comparative" + DOn.ToString
                ElseIf ArgumentType = 11 Then
                    For Each F As String In Fonts
                        DirectCast(InputControl, ComboBox).Items.Add(F)
                    Next
                    '12 Unrestrictive = no difference
                ElseIf ArgumentType = 13 Then
                    For Each Y As String In GetXDSFilter("SPRITE ")
                        Dim SpriteName As String = Y
                        SpriteName = SpriteName.Substring(7)
                        SpriteName = SpriteName.Substring(0, SpriteName.IndexOf(","))
                        DirectCast(InputControl, ComboBox).Items.Add(SpriteName)
                    Next
                    InputControl.Name = "Sprite" + DOn.ToString
                ElseIf ArgumentType = 14 Then
                    'For compatibility only, folks
                    InputControl.Name = "CScript" + DOn.ToString
                ElseIf ArgumentType = 15 Then
                    For Each Y As String In GetXDSFilter("ARRAY ")
                        Dim ArrayName As String = Y
                        ArrayName = ArrayName.Substring(6)
                        ArrayName = ArrayName.Substring(0, ArrayName.IndexOf(","))
                        DirectCast(InputControl, ComboBox).Items.Add(ArrayName)
                    Next
                    InputControl.Name = "Array" + DOn.ToString
                ElseIf ArgumentType = 16 Then
                    For Each Y As String In GetXDSFilter("STRUCTURE ")
                        Y = Y.Substring(10)
                        Dim StructureName As String = Y.Substring(0, Y.IndexOf(","))
                        DirectCast(InputControl, ComboBox).Items.Add(StructureName)
                    Next
                    InputControl.Name = "Structure" + DOn.ToString
                End If
                If ArgumentType = 0 Or ArgumentType = 12 Then
                    DirectCast(InputControl, TextBox).Text = TheContent
                Else
                    DirectCast(InputControl, ComboBox).Text = TheContent
                End If
                ControlsPanel.Controls.Add(InputControl)
                DOn += 1
            End If
        Next
        If DOn = 0 Then
            Me.Height = 180
            LabelsPanel.Visible = False
            ControlsPanel.Visible = False
        Else
            Me.Height = 350
            LabelsPanel.Visible = True
            ControlsPanel.Visible = True
        End If
        InstancesOfDropper.Items.Clear()
        For Each X As String In GetXDSFilter("OBJECT ")
            X = X.Substring(7)
            InstancesOfDropper.Items.Add(X.Substring(0, X.IndexOf(",")))
        Next
        Dim CheckedSomething As Boolean = False
        If AppliesTo = "this" Then
            ThisRadioButton.Checked = True
            CheckedSomething = True
        Else
            If IsObject(AppliesTo) Then
                InstancesOfRadioButton.Checked = True
                InstancesOfDropper.Text = AppliesTo
                CheckedSomething = True
            Else
                InstancesTextBox.Text = AppliesTo
                InstancesRadioButton.Checked = True
                CheckedSomething = True
            End If
        End If
        If Not CheckedSomething Then ThisRadioButton.Checked = True
    End Sub

    Private Sub Action_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If ControlsPanel.Visible Then
            ControlsPanel.Height = ControlsPanel.Controls(ControlsPanel.Controls.Count - 1).Location.Y + 30
            LabelsPanel.Height = ControlsPanel.Height
            Me.Height = ControlsPanel.Location.Y + ControlsPanel.Height + 68
            ControlsPanel.Controls(0).Focus()
        End If
    End Sub

    Private Sub ThisRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThisRadioButton.CheckedChanged, InstancesRadioButton.CheckedChanged, InstancesRadioButton.CheckedChanged
        InstancesOfDropper.Enabled = InstancesOfRadioButton.Checked
        InstancesTextBox.Enabled = InstancesRadioButton.Checked
    End Sub

End Class