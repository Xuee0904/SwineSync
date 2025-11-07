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
        public NavigationPanel()
        {
            InitializeComponent();
        }

        private void pigManagementBtn_Click(object sender, EventArgs e)
        {
            panelPigSubMenu.Visible = !panelPigSubMenu.Visible;           
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pregnancyBtn_Click(object sender, EventArgs e)
        {
            PregnancyRecordsClicked?.Invoke(this, EventArgs.Empty);
        }


    }
}
