using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc
{
    public static class UIStyle
    {
        
        public static readonly Color AccentColor = Color.FromArgb(88, 72, 60);
        public static readonly Color BackgroundColor = Color.FromArgb(221, 223, 222);

      
        public static readonly Font HeaderFont = new Font("Segoe UI", 24, FontStyle.Bold);
        public static readonly Font LabelFont = new Font("Segoe UI", 14, FontStyle.Bold);
        public static readonly Font RadioFont = new Font("Segoe UI", 9, FontStyle.Bold);
        public static readonly Font ButtonFont = new Font("Segoe UI", 14, FontStyle.Bold);


        
        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public static void ApplyRounded(Button btn, int radius = 9)
        {
            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, radius, radius));
        }

        
        public static void StyleFilledButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = AccentColor;
            btn.ForeColor = BackgroundColor;
            btn.Font = ButtonFont;
            ApplyRounded(btn);

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(70, 55, 45);
            btn.MouseLeave += (s, e) => btn.BackColor = AccentColor;
        }

        
        public static void StyleOutlineButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 2;
            btn.FlatAppearance.BorderColor = AccentColor;
            btn.BackColor = Color.White;
            btn.ForeColor = AccentColor;
            btn.Font = ButtonFont;
            ApplyRounded(btn);

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(245, 245, 245);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.White;
        }
    }
}
