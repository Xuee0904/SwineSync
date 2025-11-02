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

        public void DisplayPigDetails(int pigId, string tagNumber, string breed, string sex, DateTime birthDate, int weight, string status)
        {
            lblPig.Text = $"Pig ID: {pigId}";
            tagNumberLbl.Text = tagNumber;
            breedLbl.Text = breed;
            sexLbl.Text = sex;
            birthDateLbl.Text = birthDate.ToString("MMMM dd, yyyy");
            weightLbl.Text = $"{weight} kg";
            statusLbl.Text = status;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _controlManager.LoadPigManagement();
        }
    }
}
