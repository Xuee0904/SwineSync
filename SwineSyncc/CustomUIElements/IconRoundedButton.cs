using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class IconRoundedButton : Button
{
    private int borderRadious = 9; // Default radius
    private int TextPadding = 5; // Default text padding

    public int BorderRadious
    {
        get { return borderRadious; }
        set { borderRadious = value; this.Invalidate(); }
    }

    public IconRoundedButton()
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

        //FOR IMAGE
        if (this.Image != null)
        {
            int padding = 5;


            int x = rect.X + padding;
            int y = (rect.Height - this.Image.Height) / 2;

            pevent.Graphics.DrawImage(this.Image, x, y, this.Image.Width, this.Image.Height);
        }


        //FOR TEXT
        int imagePadding = 5; //Padding to avoid overlapping of the image and text
        int imageWidth = (this.Image != null) ? this.Image.Width : 0;


        int textX = rect.X + TextPadding;
        int textY = rect.Y + TextPadding;
        int textWidth = rect.Width - (2 * TextPadding);
        int textHeight = rect.Height - (2 * TextPadding);

        if (this.Image != null)
        {
            textX = rect.X + imagePadding + imageWidth + TextPadding;

            textWidth = rect.Width - (imagePadding + imageWidth + TextPadding) - TextPadding;
        }

        Rectangle textRect = new Rectangle(textX, textY, textWidth, textHeight);

        TextRenderer.DrawText(
            pevent.Graphics,
            this.Text,
            this.Font,
            textRect,
            this.ForeColor,

            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis
        );



    }
}