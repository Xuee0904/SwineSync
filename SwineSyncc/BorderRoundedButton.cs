using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class BorderRoundedButton : Button
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

    public BorderRoundedButton()
    {
        // 1. Set to FlatStyle to eliminate standard control styling
        this.FlatStyle = FlatStyle.Flat;
        // 2. Set BorderSize to 0. We must draw the border manually.
        this.FlatAppearance.BorderSize = 0;
    }

    // Helper method to create the rounded path
    private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();

        // Ensure the radius doesn't exceed half the smallest dimension
        if (radius > rect.Width / 2) radius = rect.Width / 2;
        if (radius > rect.Height / 2) radius = rect.Height / 2;

        int diameter = radius * 2;
        Rectangle arc = new Rectangle(rect.Location, new Size(diameter, diameter));

        // Top Left
        path.AddArc(arc, 180, 90);

        // Top Right
        arc.X = rect.Right - diameter;
        path.AddArc(arc, 270, 90);

        // Bottom Right
        arc.Y = rect.Bottom - diameter;
        path.AddArc(arc, 0, 90);

        // Bottom Left
        arc.X = rect.Left;
        path.AddArc(arc, 90, 90);

        path.CloseFigure();
        return path;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        Rectangle rect = this.ClientRectangle;

        // 1. Define the clipping region for the rounded shape
        using (GraphicsPath buttonPath = GetRoundedPath(rect, borderRadious))
        {
            this.Region = new Region(buttonPath);

            // 2. Draw the BACKGROUND FILL
            using (SolidBrush backBrush = new SolidBrush(this.BackColor))
            {
                pevent.Graphics.FillPath(backBrush, buttonPath);
            }

            // 3. Draw the BORDER MANUALLY 
            // We need to slightly inset the border path for a clean look
            Rectangle borderRect = rect;

            // Adjust the rectangle to account for the border thickness
            borderRect.Inflate(-borderThickness / 2, -borderThickness / 2);

            using (GraphicsPath borderPath = GetRoundedPath(borderRect, borderRadious))
            using (Pen borderPen = new Pen(borderColor, borderThickness))
            {
                pevent.Graphics.DrawPath(borderPen, borderPath);
            }
        }

        // 4. Draw the TEXT
        TextRenderer.DrawText(
            pevent.Graphics,
            this.Text,
            this.Font,
            rect,
            this.ForeColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
        );
    }
}