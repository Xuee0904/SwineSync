using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CancelButtonGroup : Button
{
    private int borderRadious = 9; // Default radius
    private Color borderColor = ColorTranslator.FromHtml("#58483C"); // Border color
    private int borderThickness = 3; // Border thickness

    public int BorderRadious
    {
        get { return borderRadious; }
        set { borderRadious = value; this.Invalidate(); }
    }

    public Color BorderColor
    {
        get { return borderColor; }
        set { borderColor = value; this.Invalidate(); }
    }

    public int BorderThickness
    {
        get { return borderThickness; }
        set { borderThickness = value; this.Invalidate(); }
    }

    public CancelButtonGroup()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
    }

    private GraphicsPath GetSpecificRoundedPath(Rectangle rect, int radius, bool topLeft, bool topRight, bool bottomRight, bool bottomLeft)
    {
        GraphicsPath path = new GraphicsPath();

        if (radius > rect.Width / 2) radius = rect.Width / 2;
        if (radius > rect.Height / 2) radius = rect.Height / 2;

        int diameter = radius * 2;
        Rectangle arc = new Rectangle(rect.Location, new Size(diameter, diameter));

        // Top Left Corner
        if (topLeft)
        {
            path.AddArc(arc, 180, 90);
        }
        else
        {
            path.AddLine(rect.Left, rect.Top + diameter, rect.Left, rect.Top);
            path.AddLine(rect.Left, rect.Top, rect.Left + diameter, rect.Top);
        }

        // Top Right Corner
        arc.X = rect.Right - diameter;
        if (topRight)
        {
            path.AddArc(arc, 270, 90);
        }
        else
        {
            path.AddLine(rect.Right - diameter, rect.Top, rect.Right, rect.Top);
            path.AddLine(rect.Right, rect.Top, rect.Right, rect.Top + diameter);
        }

        // Bottom Right Corner
        arc.Y = rect.Bottom - diameter;
        if (bottomRight)
        {
            path.AddArc(arc, 0, 90);
        }
        else
        {
            path.AddLine(rect.Right, rect.Bottom - diameter, rect.Right, rect.Bottom);
            path.AddLine(rect.Right, rect.Bottom, rect.Right - diameter, rect.Bottom);
        }

        // Bottom Left Corner
        arc.X = rect.Left;
        if (bottomLeft)
        {
            path.AddArc(arc, 90, 90);
        }
        else
        {
            path.AddLine(rect.Left + diameter, rect.Bottom, rect.Left, rect.Bottom);
            path.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Bottom - diameter);
        }

        path.CloseFigure();
        return path;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        Rectangle rect = this.ClientRectangle;

        using (GraphicsPath buttonPath = GetSpecificRoundedPath(rect, borderRadious, true, false, false, true))
        {
            this.Region = new Region(buttonPath);

            using (SolidBrush backBrush = new SolidBrush(this.BackColor))
            {
                pevent.Graphics.FillPath(backBrush, buttonPath);
            }

            Rectangle borderRect = rect;

            borderRect.Inflate(-borderThickness / 2, -borderThickness / 2);

            using (GraphicsPath borderPath = GetSpecificRoundedPath(borderRect, borderRadious, true, false, false, true))
            using (Pen borderPen = new Pen(borderColor, borderThickness))
            {
                pevent.Graphics.DrawPath(borderPen, borderPath);
            }
        }

        TextRenderer.DrawText(
            pevent.Graphics,
            this.Text,
            this.Font,
            rect,
            this.ForeColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak
        );
    }
}