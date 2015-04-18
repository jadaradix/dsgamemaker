Public Class clsToolstripRenderer
    Inherits System.Windows.Forms.ToolStripProfessionalRenderer

    '// Render container background gradient
    Protected Overrides Sub OnRenderToolStripBackground(ByVal e As ToolStripRenderEventArgs)
        MyBase.OnRenderToolStripBackground(e)

        Dim b As New Drawing2D.LinearGradientBrush(e.AffectedBounds, clrVerBG_White, clrVerBG_GrayBlue, _
            Drawing2D.LinearGradientMode.Vertical)
        Dim shadow As New Drawing.SolidBrush(clrVerBG_Shadow)
        Dim rect As New Rectangle(0, e.ToolStrip.Height - 2, e.ToolStrip.Width, 1)
        e.Graphics.FillRectangle(b, e.AffectedBounds)
        e.Graphics.FillRectangle(shadow, rect)
    End Sub

    '// Render button selected and pressed state
    Protected Overrides Sub OnRenderButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
        MyBase.OnRenderButtonBackground(e)
        If e.Item.Selected Or CType(e.Item, ToolStripButton).Checked Then
            Dim rectBorder As New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1)
            Dim rect As New Rectangle(1, 1, e.Item.Width - 2, e.Item.Height - 2)
            Dim b As New Drawing2D.LinearGradientBrush(rect, clrToolstripBtnGrad_White, clrToolstripBtnGrad_Blue, _
                Drawing2D.LinearGradientMode.Vertical)
            Dim b2 As New Drawing.SolidBrush(clrToolstripBtn_Border)

            e.Graphics.FillRectangle(b2, rectBorder)
            e.Graphics.FillRectangle(b, rect)
        End If
        If e.Item.Pressed Then
            Dim rectBorder As New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1)
            Dim rect As New Rectangle(1, 1, e.Item.Width - 2, e.Item.Height - 2)
            Dim b As New Drawing2D.LinearGradientBrush(rect, clrToolstripBtnGrad_White_Pressed, clrToolstripBtnGrad_Blue_Pressed, _
                Drawing2D.LinearGradientMode.Vertical)
            Dim b2 As New Drawing.SolidBrush(clrToolstripBtn_Border)

            e.Graphics.FillRectangle(b2, rectBorder)
            e.Graphics.FillRectangle(b, rect)
        End If
    End Sub



End Class