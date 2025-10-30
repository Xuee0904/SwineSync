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
        private PigManagement _parentPigManagement;
        public event EventHandler SaveCompleted;

        public RegisterPig(PigManagement pigManagement)
        {
            InitializeComponent();

            _parentPigManagement = pigManagement;
            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40); 

           
            this.BackColor = Color.WhiteSmoke;

            panel1.BackColor = Color.FromArgb(217, 221, 220);                        
            ApplyTextBoxHeight();

            //ADD VALUES TO COMBO BOXES
            comboBreed.Items.Add("SAMPLE BREED 1");
            comboBreed.Items.Add("SAMPLE BREED 2");
            comboBreed.Items.Add("SAMPLE BREED 3");

            comboStatus.Items.Add("ALIVE");
            comboStatus.Items.Add("SOLD (BINARAT)");
            comboStatus.Items.Add("NILECHON NG KAPITBAHAY");
        }

        

        private void ApplyTextBoxHeight() 
        {
            UIStyle.BoxHeight(tagNumberTxt);
            UIStyle.BoxHeight(weightTxt);
            UIStyle.BoxHeight(dtPicker);
            UIStyle.BoxHeight(comboBreed);
            UIStyle.BoxHeight(comboStatus);
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
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }       

        private void savebtn_Click(object sender, EventArgs e)
        {
            // TODO: save pig to database here

            int newPigId = 1; // example, later will come from DB
            string newPigTag = tagNumberTxt.Text; // tag num eto lang kinuha ko hahaha

            _parentPigManagement.AddPigButton(newPigId, newPigTag);

            MessageBox.Show("Pig registered successfully!");
            SaveCompleted?.Invoke(this, EventArgs.Empty);
        }

        private void sexlbl_Click(object sender, EventArgs e)
        {

        }

        private void maleradiobtn_CheckedChanged(object sender, EventArgs e)
        {

        }
     
        private void femaleradiobtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void clearbtn_Click_1(object sender, EventArgs e)
        {
            tagNumberTxt.Clear();
            weightTxt.Clear();

            comboBreed.SelectedIndex = -1;
            comboStatus.SelectedIndex = -1;

            dtPicker.Value = DateTime.Now;
        }
    }
}
