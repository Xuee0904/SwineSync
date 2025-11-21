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
        public NavigationPanel()
        {
            InitializeComponent();
        }                        

        private void pigManagementBtn_Click(object sender, EventArgs e)
        {
            panelPigSubMenu.Visible = !panelPigSubMenu.Visible;
            PigManagementClicked?.Invoke(this, EventArgs.Empty);
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {

        }

        private void userManagementBtn_Click(object sender, EventArgs e)
        {
            UserManagementClicked?.Invoke(this, EventArgs.Empty);
        }

        public void HideUserManagementButton()
        {
            userManagementBtn.Visible = false;
            userManagementBtn.Enabled = false;
        }

        private void pregnancyRecordsBtn_Click(object sender, EventArgs e)
        {
            PregnancyRecordsClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
