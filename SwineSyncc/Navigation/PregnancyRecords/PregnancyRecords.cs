using SwineSyncc.Navigation;
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
using SwineSyncc.Data;

namespace SwineSyncc
{
    public partial class PregnancyRecords : UserControl
    {
        SwineSyncTable displayTable;
        public event EventHandler AddPregnancyRecordClicked;
        public PregnancyRecords()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            displayTable = new SwineSyncTable();

            TableRefresh();
        }

        private void addPregnancyBtn_Click(object sender, EventArgs e)
        {
            AddPregnancyRecordClicked?.Invoke(this, EventArgs.Empty);
        }

        
        private void editPregnancyBtn_Click(object sender, EventArgs e)
        {

        }

        private void deletePregnancyBtn_Click(object sender, EventArgs e)
        {

        }

        private void PregnancyRecords_Load(object sender, EventArgs e)
        {
            LoadTableData();
        }

        public void TableRefresh()
        {
            LoadTableData();
        }

        private void LoadTableData()
        {
            displayTable.SetTableQuery("PregnancyRecords");
            displayTable.Dock = DockStyle.Fill;
            pnlPregnancyRecords.Controls.Clear();
            pnlPregnancyRecords.Controls.Add(displayTable);
        }

        private void customTextBox1__TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pnlPregnancyRecords_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
