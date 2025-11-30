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
    public partial class SowTable : UserControl
    {
        SwineSyncTable displayTable;
        public event EventHandler BackToCardViewClicked;
        private readonly Panel _mainPanel;
        public SowTable(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel; 
            this.Dock = DockStyle.Fill;

            togglePicBox.Image = Properties.Resources.PigNose;

            displayTable = new SwineSyncTable();
        }

        private void panelSowTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SowTable_Load(object sender, EventArgs e)
        {
            displayTable.SetTableQuery("SowTable");
            displayTable.Dock = DockStyle.Fill;
            panelSowTable.Controls.Add(displayTable);
        }

        private void togglePicBox_Click(object sender, EventArgs e)
        {
            BackToCardViewClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
