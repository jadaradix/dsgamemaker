Public Class Pro

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        If IsPro Then
            Dim Response As Byte = MessageBox.Show("Are you sure you want to reset your Pro registration data on this machine?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Not Response = MsgBoxResult.Yes Then Exit Sub
            ResetPro()
            Me.Close()
        End If
        Me.Close()
    End Sub

    Private Sub EnterSerialButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnterSerialButton.Click
        If EnterSerial.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub BuyProButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuyProButton.Click
        URL(OrderURL)
    End Sub

    Sub EquateProLabel()
        If IsPro Then
            MainInfoLabel.Text = "Pro Edition Activated - Thanks!" + vbcrlf + "Email: " + My.Settings.ProEmail
        Else
            MainInfoLabel.Text = "Thanks for using DSGM. This is the Free Edition. To remove all limitations, please buy the software."
        End If
    End Sub

    Sub EquateButton()
        If IsPro Then
            CloseButton.Text = "Revert to Free"
            CloseButton.Font = New Font("Tahoma", 8, FontStyle.Regular)
        Else
            CloseButton.Text = "Continue using Free"
            CloseButton.Font = New Font("Tahoma", 8, FontStyle.Bold)
        End If
    End Sub

    Private Sub Pro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EquateProLabel()
        EquateButton()
    End Sub

    Private Sub Pro_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If IsPro Then BuyProButton.Focus() Else CloseButton.Focus()
    End Sub
End Class