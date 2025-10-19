using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc
{
    public partial class RegisterPig : UserControl
    {
        public event EventHandler CancelClicked;
        public RegisterPig()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.WhiteSmoke;

            panel1.BackColor = Color.FromArgb(217, 221, 220);

            ApplyTheme();
            ApplyButtonStyles();
        }

        private void ApplyTheme()
        {           
            this.BackColor = Color.White;

            registerpiglbl.ForeColor = UIStyle.AccentColor;
            registerpiglbl.Font = UIStyle.HeaderFont;

            foreach (var label in new[] { tagnumberlbl, birthdatelbl, breedlbl, weightlbl, sexlbl, statuslbl })
            {
                label.ForeColor = UIStyle.AccentColor;
                label.Font = UIStyle.LabelFont;
            }

            foreach (var radio in new[] { maleradiobtn, femaleradiobtn })
            {
                radio.ForeColor = UIStyle.AccentColor;
                radio.Font = UIStyle.RadioFont;
            }           
        }

        private void ApplyButtonStyles()
        {            
            UIStyle.StyleFilledButton(savebtn);
            UIStyle.StyleOutlineButton(clearbtn);
            UIStyle.StyleOutlineButton(cancelbtn);
        }

        private void RegisterPig_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 20;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, panel1.Width, panel1.Height);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(rect.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(rect.Width - borderRadius, rect.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(0, rect.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseAllFigures();

            panel1.Region = new Region(path);
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
