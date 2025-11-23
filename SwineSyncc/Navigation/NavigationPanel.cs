using SwineSyncc.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc
{
    public partial class NavigationPanel : UserControl
    {
        public event EventHandler PregnancyRecordsClicked;
        public event EventHandler UserManagementClicked;
        public event EventHandler PigManagementClicked;

        private Button activeButton = null;
        private Color activeColor = Color.FromArgb(59, 44, 29);   // dark brown
        private Color defaultColor = Color.Transparent; // normal button color

        public NavigationPanel()
        {
            InitializeComponent();
        }

        private void SetActiveButton(Button clickedButton)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = defaultColor;
                activeButton.FlatAppearance.MouseOverBackColor = defaultColor;
                activeButton.FlatAppearance.MouseDownBackColor = defaultColor;
            }

            activeButton = clickedButton;

            activeButton.BackColor = activeColor;  // click color
            activeButton.FlatAppearance.MouseOverBackColor = activeColor;
            activeButton.FlatAppearance.MouseDownBackColor = activeColor;
        }




        private void dashboardBtn_Click(object sender, EventArgs e)
        {

        }
        
        public void HideUserManagementButton()
        {
            userManagementBtn.Visible = false;
            userManagementBtn.Enabled = false;
        }       

        private void pigManagementBtn_Click(object sender, EventArgs e)
        {
            SetActiveButton(pigManagementBtn);
            panelPigSubMenu.Visible = !panelPigSubMenu.Visible;
            PigManagementClicked?.Invoke(this, EventArgs.Empty);
        }

        private void pregnancyRecordsBtn_Click(object sender, EventArgs e)
        {
            SetActiveButton(pregnancyRecordsBtn);
            PregnancyRecordsClicked?.Invoke(this, EventArgs.Empty);
        }      

        private void breedingRecordsBtn_Click(object sender, EventArgs e)
        {

        }

        private void healthRecordsBtn_Click(object sender, EventArgs e)
        {

        }

        private void inventoryBtn_Click(object sender, EventArgs e)
        {

        }

        private void transactionsBtn_Click(object sender, EventArgs e)
        {

        }

        private void analyticsBtn_Click(object sender, EventArgs e)
        {

        }

        private void remindersBtn_Click(object sender, EventArgs e)
        {

        }

        private void userManagementBtn_Click(object sender, EventArgs e)
        {
            SetActiveButton(userManagementBtn);
            UserManagementClicked?.Invoke(this, EventArgs.Empty);
        }

        private void dashboardBtn_Click_1(object sender, EventArgs e)
        {

        }
    }
}
