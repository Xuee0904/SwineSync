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
        public static readonly Font RadioFont = new Font("Segoe UI", 14, FontStyle.Bold);
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
            btn.FlatAppearance.BorderSize = 2;
            btn.FlatAppearance.BorderColor = AccentColor;
            btn.BackColor = Color.White;
            btn.ForeColor = AccentColor;
            btn.Font = ButtonFont;
            
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(245, 245, 245);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.White;
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
