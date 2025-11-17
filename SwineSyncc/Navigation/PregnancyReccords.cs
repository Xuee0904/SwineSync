using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwineSyncc.Navigation;

namespace SwineSyncc
{
    public partial class PregnancyReccords : UserControl
    {
        public PregnancyReccords()
        {
            InitializeComponent();
            this.Dock = DockStyle.Right;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PregnancyReccords_Load(object sender, EventArgs e)
        {
            SwineSyncTable displayTable = new SwineSyncTable();
            displayTable.Dock = DockStyle.Fill;
            pnlPregnancyRecords.Controls.Add(displayTable);
        }

        private void addPregnancyBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
