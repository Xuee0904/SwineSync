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
        public static readonly Font LabelFont = new Font("Segoe UI", 18, FontStyle.Bold);
        public static readonly Font RadioFont = new Font("Segoe UI", 18, FontStyle.Bold);
        public static readonly Font ButtonFont = new Font("Segoe UI", 17, FontStyle.Bold);
        
        public static void StyleFilledButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = AccentColor;
            btn.ForeColor = BackgroundColor;
            btn.Font = ButtonFont;          

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(70, 55, 45);
            btn.MouseLeave += (s, e) => btn.BackColor = AccentColor;
        }


        public static void StyleOutlineButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 5;
            btn.FlatAppearance.BorderColor = AccentColor;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = AccentColor;
            btn.Font = ButtonFont;

            // Add rounded corners to match the panel's border radius
            int borderRadius = 20;  // Same as the panel in RegisterPig
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(btn.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(btn.Width - borderRadius, btn.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(0, btn.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseAllFigures();
            btn.Region = new Region(path);

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(245, 245, 245);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.Transparent;
        }


        public static void BoxHeight(TextBox txt)
        {
            txt.Multiline = true;     
            txt.AutoSize = false;     
            txt.Height = 30;          
        }

        public static void BoxHeight(DateTimePicker txt)
        {          
            txt.AutoSize = false;
            txt.Height = 30;
        }

        public static void BoxHeight(ComboBox txt)
        {
            txt.AutoSize = false;
            txt.Height = 30;
        }

    }
}
