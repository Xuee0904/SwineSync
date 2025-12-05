using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc.Navigation.HealthRecords
{
    public partial class HealthRecords : UserControl
    {
        SwineSyncTable displayTable;

        public event EventHandler AddHealthRecordClicked;

        public HealthRecords()
        {
            InitializeComponent();
            displayTable = new SwineSyncTable();
        }

        private void HealthRecords_Load(object sender, EventArgs e)
        {
            displayTable.SetTableQuery("HealthRecords");
            displayTable.Dock = DockStyle.Fill;
            pnlHealthRecords.Controls.Add(displayTable);
        }

        private void btnAddHealth_Click(object sender, EventArgs e)
        {
            AddHealthRecordClicked?.Invoke(this, EventArgs.Empty);
        }

        private void pnlHealthRecords_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
