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
    public partial class AddUser : UserControl
    {
        public AddUser()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(addUserPanel, 20);

            this.BackColor = Color.WhiteSmoke;
            addUserPanel.BackColor = Color.FromArgb(217, 221, 220);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {

        }
    }
}
