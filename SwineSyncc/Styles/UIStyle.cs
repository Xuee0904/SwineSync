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
