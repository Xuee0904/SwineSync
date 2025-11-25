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
    public partial class PregnancyRecords : UserControl
    {
        public PregnancyRecords()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void PregnancyReccords_Load(object sender, EventArgs e)
        {
            SwineSyncTable displayTable = new SwineSyncTable();
            displayTable.SetTableQuery("PregnancyRecords");
            displayTable.Dock = DockStyle.Fill;
            pnlPregnancyRecords.Controls.Add(displayTable);
        }

        private void addPregnancyBtn_Click(object sender, EventArgs e)
        {

        }

        private void editPregnancyBtn_Click(object sender, EventArgs e)
        {

        }

        private void deletePregnancyBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
