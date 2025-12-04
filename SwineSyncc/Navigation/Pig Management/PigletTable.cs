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

        public event EventHandler BackToSowTableClicked;

        SwineSyncTable displayPigletTable;

        public PigletTable(Panel mainPanel)
        {
            InitializeComponent();

            _mainPanel = mainPanel;
            this.Dock = DockStyle.Fill;

            displayPigletTable = new SwineSyncTable();
        }

        private void btnPig_Click(object sender, EventArgs e)
        {
            BackToSowTableClicked?.Invoke(this, EventArgs.Empty);
        }

        private void PigletTable_Load(object sender, EventArgs e)
        {
            displayPigletTable.SetTableQuery("PigletTable");
            displayPigletTable.Dock = DockStyle.Fill;
            panelPiglet.Controls.Add(displayPigletTable);
        }
    }
}
