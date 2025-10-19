using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    // Property to easily set the corner radius from the Properties window
    private int borderRadious = 9; // Default radius

    public int BorderRadious
    {
        get { return borderRadious; }
        set { borderRadious = value; this.Invalidate(); } // Redraws the button when changed
    }

    // Constructor is required
    public RoundedButton()
    {
        this.FlatStyle = FlatStyle.Flat; // Ensures we can control the appearance
        this.FlatAppearance.BorderSize = 0; // Remove the default border
    }

    // Core method: Overrides how the button is drawn
    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        GraphicsPath path = new GraphicsPath();
        Rectangle rect = this.ClientRectangle;

        // Draw the rounded rectangle path
        path.AddArc(rect.X, rect.Y, borderRadious * 2, borderRadious * 2, 180, 90);
        path.AddArc(rect.Right - borderRadious * 2, rect.Y, borderRadious * 2, borderRadious * 2, 270, 90);
        path.AddArc(rect.Right - borderRadious * 2, rect.Bottom - borderRadious * 2, borderRadious * 2, borderRadious * 2, 0, 90);
        path.AddArc(rect.X, rect.Bottom - borderRadious * 2, borderRadious * 2, borderRadious * 2, 90, 90);
        path.CloseAllFigures();

        // Apply the rounded path to the button's region
        this.Region = new Region(path);

        // Fill the button's background with the specified back color
        using (SolidBrush brush = new SolidBrush(this.BackColor))
        {
            pevent.Graphics.FillPath(brush, path);
        }

        // Draw the text (similar to the base class)
        TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, rect, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
}