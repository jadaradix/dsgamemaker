Public Class DEvent

    Public MainClass As String
    Public SubClass As String
    Public UseData As Boolean
    Dim OwnedBy As String

    Private Sub DCancelButton_Click() Handles DCancelButton.Click
        MainClass = "NoData"
        SubClass = "NoData"
        Me.Close()
    End Sub

    Private Sub DEvent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dropper.Renderer = New clsMenuRenderer
        UseData = False
    End Sub

    Sub EquateDropper()
        Dropper.Items.Clear()
        Dim NewItems As New List(Of String)
        Select Case MainClassStringToType(MainClass)
            Case 2, 3, 4
                NewItems.Add("A")
                NewItems.Add("B")
                NewItems.Add("X")
                NewItems.Add("Y")
                NewItems.Add("L")
                NewItems.Add("R")
                NewItems.Add("Up")
                NewItems.Add("Down")
                NewItems.Add("Left")
                NewItems.Add("Right")
                NewItems.Add("Start")
                NewItems.Add("Select")
            Case 5
                NewItems.Add("New Press")
                NewItems.Add("Double Press")
                NewItems.Add("Held")
                NewItems.Add("Released")
            Case 6
                For Each X As String In GetXDSFilter("OBJECT ")
                    X = X.Substring(7)
                    Dim ObjectName As String = X.Substring(0, X.IndexOf(","))
                    'If ObjectName = OwnedBy Then Continue For
                    NewItems.Add(ObjectName)
                Next
        End Select
        For Each X As String In NewItems
            Dropper.Items.Add(X)
        Next
    End Sub

    Private Sub EventButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TouchEventButton.Click, StepEventButton.Click, CreateEventButton.Click, CollisionEventButton.Click, ButtonReleaseEventButton.Click, ButtonPressEventButton.Click, ButtonHeldEventButton.Click
        MainClass = DirectCast(sender, Button).Text.Substring(6)
        Dim X As Byte = MainClassStringToType(MainClass)
        If X = 1 Or X = 7 Then
            SubClass = "NoData"
            UseData = True
            Me.Close()
            Exit Sub
        End If
        Dim PT As Point = DirectCast(sender, Button).Location
        EquateDropper()
        Dropper.Show(sender, 0, DirectCast(sender, Control).Height + 2)
    End Sub

    Private Sub EventDropper_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Dropper.ItemClicked
        SubClass = e.ClickedItem.Text
        UseData = True
        Me.Close()
    End Sub

    Private Sub DEvent_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'MainClass = "NoData"
        'SubClass = "NoData"
    End Sub
End Class