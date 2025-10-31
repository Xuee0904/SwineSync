using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedPictureBox : PictureBox
{
    private int cornerRadius = 9; // default radius

    private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
    {
        RectangleF rectF = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);

        GraphicsPath path = new GraphicsPath();
        float diameter = radius * 2;
        float x = rectF.X;
        float y = rectF.Y;
        float w = rectF.Width;
        float h = rectF.Height;

        if (diameter > w) diameter = w;
        if (diameter > h) diameter = h;

        // Top-left corner
        path.AddArc(x, y, diameter, diameter, 180, 90);

        // Top-right corner
        path.AddArc(x + w - diameter, y, diameter, diameter, 270, 90);

        // Bottom-right corner
        path.AddArc(x + w - diameter, y + h - diameter, diameter, diameter, 0, 90);

        // Bottom-left corner
        path.AddArc(x, y + h - diameter, diameter, diameter, 90, 90);

        path.CloseAllFigures();
        return path;
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);

        using (GraphicsPath path = GetRoundedRectPath(this.ClientRectangle, cornerRadius))
        {
            this.Region = new Region(path);

            // Optional: Draw a border (if you want one)
            // pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // using (Pen borderPen = new Pen(Color.Gray, 1))
            // {
            //     pe.Graphics.DrawPath(borderPen, path);
            // }
        }
    }

    protected override void OnResize(EventArgs e)
    {
        this.Invalidate();
        base.OnResize(e);
    }
}