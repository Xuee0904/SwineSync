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
        public PigDetails()
        {
            InitializeComponent();
            RoundedPanelStyle.ApplyRoundedCorners(pigDetailsPanel, 20);
        }

        public void DisplayPigDetails(int pigId, string tagNumber, string breed, string sex, DateTime birthDate, int weight, string status)
        {
            lblPig.Text = $"Pig ID: {pigId}";
            tagNumberLbl.Text = tagNumber;
            pigDetailsPanel.Text = breed;
            sexLbl.Text = sex;
            birthDateLbl.Text = birthDate.ToString("MMMM dd, yyyy");
            weightLbl.Text = $"{weight} kg";
            statusLbl.Text = status;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        
    }
}
