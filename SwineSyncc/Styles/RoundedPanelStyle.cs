using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SwineSyncc
{
    public static class RoundedPanelStyle
    {
        public static void ApplyRoundedCorners(Panel panel, int borderRadius = 20)
        {
            if (panel == null) return;

            panel.Paint += (sender, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, panel.Width, panel.Height);
                GraphicsPath path = new GraphicsPath();

                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                path.AddArc(rect.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
                path.AddArc(rect.Width - borderRadius, rect.Height - borderRadius, borderRadius, borderRadius, 0, 90);
                path.AddArc(0, rect.Height - borderRadius, borderRadius, borderRadius, 90, 90);
                path.CloseAllFigures();

                panel.Region = new Region(path);
            };
        }
    }
}
