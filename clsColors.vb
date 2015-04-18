Module clsColors
    Public clrHorBG_GrayBlue As Color = Color.FromArgb(255, 233, 236, 250)
    Public clrHorBG_White As Color = Color.FromArgb(255, 244, 247, 252)
    Public clrSubmenuBG As Color = Color.FromArgb(255, 240, 240, 240)
    Public clrImageMarginBlue As Color = Color.FromArgb(255, 212, 216, 230)
    Public clrImageMarginWhite As Color = Color.FromArgb(255, 244, 247, 252)
    Public clrImageMarginLine As Color = Color.FromArgb(255, 160, 160, 180)
    Public clrSelectedBG_Blue As Color = Color.FromArgb(255, 186, 228, 246)
    Public clrSelectedBG_Header_Blue As Color = Color.FromArgb(255, 146, 202, 230)
    Public clrSelectedBG_White As Color = Color.FromArgb(255, 241, 248, 251)
    Public clrSelectedBG_Border As Color = Color.FromArgb(255, 150, 217, 249)
    Public clrSelectedBG_Drop_Blue As Color = Color.FromArgb(255, 139, 195, 225)
    Public clrSelectedBG_Drop_Border As Color = Color.FromArgb(255, 48, 127, 177)
    Public clrMenuBorder As Color = Color.FromArgb(255, 160, 160, 160)
    Public clrCheckBG As Color = Color.FromArgb(255, 206, 237, 250)

    Public clrVerBG_GrayBlue As Color = Color.FromArgb(255, 196, 203, 219)
    Public clrVerBG_White As Color = Color.FromArgb(255, 250, 250, 253)
    Public clrVerBG_Shadow As Color = Color.FromArgb(255, 181, 190, 206)

    Public clrToolstripBtnGrad_Blue As Color = Color.FromArgb(255, 129, 192, 224)
    Public clrToolstripBtnGrad_White As Color = Color.FromArgb(255, 237, 248, 253)
    Public clrToolstripBtn_Border As Color = Color.FromArgb(255, 41, 153, 255)
    Public clrToolstripBtnGrad_Blue_Pressed As Color = Color.FromArgb(255, 124, 177, 204)
    Public clrToolstripBtnGrad_White_Pressed As Color = Color.FromArgb(255, 228, 245, 252)

    Public Sub DrawRoundedRectangle(ByVal objGraphics As Graphics, _
                                ByVal m_intxAxis As Integer, _
                                ByVal m_intyAxis As Integer, _
                                ByVal m_intWidth As Integer, _
                                ByVal m_intHeight As Integer, _
                                ByVal m_diameter As Integer, ByVal color As Color)

        Dim MyPen As New Pen(color)
        Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))

        'Top Left Arc
        objGraphics.DrawArc(MyPen, ArcRect, 180, 90)
        objGraphics.DrawLine(MyPen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis)

        'Top Right Arc
        ArcRect.X = BaseRect.Right - m_diameter
        objGraphics.DrawArc(MyPen, ArcRect, 270, 90)
        objGraphics.DrawLine(MyPen, m_intxAxis + m_intWidth, m_intyAxis + CInt(m_diameter / 2), m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

        'Bottom Right Arc
        ArcRect.Y = BaseRect.Bottom - m_diameter
        objGraphics.DrawArc(MyPen, ArcRect, 0, 90)
        objGraphics.DrawLine(MyPen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis + m_intHeight, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis + m_intHeight)

        'Bottom Left Arc
        ArcRect.X = BaseRect.Left
        objGraphics.DrawArc(MyPen, ArcRect, 90, 90)
        objGraphics.DrawLine(MyPen, m_intxAxis, m_intyAxis + CInt(m_diameter / 2), m_intxAxis, m_intyAxis + m_intHeight - CInt(m_diameter / 2))
    End Sub
End Module