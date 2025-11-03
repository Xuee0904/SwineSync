using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc.Navigation
{
    public partial class PigDetails : UserControl
    {

        private Panel _mainPanel;
        private UserControlManager _controlManager;

        public PigDetails(Panel mainPanel) : this()
        {
            _mainPanel = mainPanel;
            _controlManager = new UserControlManager(mainPanel);
        }

        public PigDetails()
        {
            InitializeComponent();
            RoundedPanelStyle.ApplyRoundedCorners(pigDetailsPanel, 20);
            pigDetailsPanel.BackColor = Color.FromArgb(217, 221, 220);
            this.Padding = new Padding(40);
        }       

        public void DisplayPigDetails(int id, string tag, string breed, string sex, DateTime birthdate, int weight, string status)
        {
            lblPig.Text = id.ToString();
            tagNumberLbl.Text = tag;
            breedLbl.Text = breed;
            sexLbl.Text = sex;
            birthDateLbl.Text = birthdate.ToShortDateString();
            weightLbl.Text = weight.ToString();
            statusLbl.Text = status;

            
            if (sex.Equals("Female", StringComparison.OrdinalIgnoreCase))
            {
                currentPigletsLbl.Visible = true;
                rightLineLbl.Visible = true;
                leftLineLbl.Visible = true;
                addPigletBtn.Visible = true;
                flpCurrentPiglets.Visible = true; 
            }
            else
            {
                currentPigletsLbl.Visible = false;
                rightLineLbl.Visible = false;
                leftLineLbl.Visible = false;
                addPigletBtn.Visible = false;
                flpCurrentPiglets.Visible = false;
            }
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _controlManager.LoadPigManagement();
        }

        private void addPigletBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
