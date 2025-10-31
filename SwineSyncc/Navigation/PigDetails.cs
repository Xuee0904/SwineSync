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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
