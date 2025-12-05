using SwineSyncc.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SwineSyncc.Navigation.Pig_Management
{
    public partial class BreedingRecords : UserControl
    {

        public event EventHandler AddBreedingRecordClicked;

        public BreedingRecords()
        {
            InitializeComponent();

            TableRefresh();
        }

        private void BreedingRecords_Load(object sender, EventArgs e)
        {
            LoadTableData();
        }

        public void TableRefresh()
        {
            LoadTableData();
        }

        private void LoadTableData()
        {
            SwineSyncTable displayTable = new SwineSyncTable();
            displayTable.SetTableQuery("BreedingRecords");
            displayTable.Dock = DockStyle.Fill;
            pnlBreedingRecords.Controls.Clear();
            pnlBreedingRecords.Controls.Add(displayTable);
        }

        private void addBreedingBtn_Click(object sender, EventArgs e)
        {
            AddBreedingRecordClicked?.Invoke(this, EventArgs.Empty);
        }

        
    }
}
