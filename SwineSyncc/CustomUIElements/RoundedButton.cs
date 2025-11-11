using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    private int borderRadious = 9; // Default radius

    public int BorderRadious
    {
        get { return borderRadious; }
        set { borderRadious = value; this.Invalidate(); }
    }

    public RoundedButton()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
    }


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

        // Apply the rounded path to the button
        this.Region = new Region(path);

        using (SolidBrush brush = new SolidBrush(this.BackColor))
        {
            pevent.Graphics.FillPath(brush, path);
        }

        TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, rect, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
    }
}