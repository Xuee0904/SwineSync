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
using System.Data.SqlClient;
using SwineSyncc.Data;

namespace SwineSyncc
{
    public partial class PregnancyRecords : UserControl
    {
        SwineSyncTable displayTable;
        public PregnancyRecords()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            displayTable = new SwineSyncTable();
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

        private void PregnancyRecords_Load(object sender, EventArgs e)
        {
            displayTable.SetTableQuery("PregnancyRecords");
            displayTable.Dock = DockStyle.Fill;
            pnlPregnancyRecords.Controls.Add(displayTable);
        }

        private void customTextBox1__TextChanged(object sender, EventArgs e)
        {
            displayTable.FilterData(customTextBox1.Texts.Trim());
        }
    }
}
