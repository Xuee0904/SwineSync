using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc.Navigation.Pig_Management
{
    public partial class PigletTable : UserControl
    {

        private readonly Panel _mainPanel;

        public PigletTable(Panel mainPanel)
        {
            InitializeComponent();

            _mainPanel = mainPanel;
            this.Dock = DockStyle.Fill;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
