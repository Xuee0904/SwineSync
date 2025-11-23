using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class SaveButtonGroup : Button
{
    private int borderRadious = 9; // Default radius

    public int BorderRadious
    {
        get { return borderRadious; }
        set { borderRadious = value; this.Invalidate(); }
    }

    public SaveButtonGroup()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        this.Padding = new Padding(0); // Ensure button doesn't have extra padding
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        // Enable anti-aliasing for smoother edges
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        GraphicsPath path = new GraphicsPath();
        Rectangle rect = this.ClientRectangle;
        int radius = borderRadious;
        int diameter = radius * 2;

        // Ensure radius is not larger than half the smallest dimension
        if (radius > rect.Width / 2) radius = rect.Width / 2;
        if (radius > rect.Height / 2) radius = rect.Height / 2;

        // --- Draw the shape with ONLY Top-Right and Bottom-Right rounded ---

        // 1. Top Left Corner (Square)
        // Move to the starting point (top-left)
        path.AddLine(rect.X, rect.Y + radius, rect.X, rect.Y);
        path.AddLine(rect.X, rect.Y, rect.Right - radius, rect.Y);

        // 2. Top Right Corner (Rounded)
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);

        // 3. Bottom Right Corner (Rounded)
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);

        // 4. Bottom Left Corner (Square)
        // Add a line from the end of the Bottom-Right arc to the bottom-left corner
        path.AddLine(rect.X + radius, rect.Bottom, rect.X, rect.Bottom);
        // Add a line from the bottom-left corner back up to the starting point
        path.AddLine(rect.X, rect.Bottom, rect.X, rect.Y + radius);

        path.CloseAllFigures();

        // Apply the rounded path to the button's clipping region
        this.Region = new Region(path);

        // Fill the path with the button's background color
        using (SolidBrush brush = new SolidBrush(this.BackColor))
        {
            pevent.Graphics.FillPath(brush, path);
        }

        // Draw the text centered on the button
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