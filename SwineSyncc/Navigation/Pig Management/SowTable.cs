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
        SwineSyncTable displaySowTable;
        SwineSyncTable displayBoarTable;
        public event EventHandler BackToCardViewClicked;
        public event EventHandler ProceedToPigletTableClicked;
        private readonly Panel _mainPanel;
        public SowTable(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel; 
            this.Dock = DockStyle.Fill;

            togglePicBox.Image = Properties.Resources.PigNose;

            displaySowTable = new SwineSyncTable();
            displayBoarTable = new SwineSyncTable();
        }

        private void panelSowTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SowTable_Load(object sender, EventArgs e)
        {
            displaySowTable.SetTableQuery("SowTable");
            displayBoarTable.SetTableQuery("BoarTable");
            displaySowTable.Dock = DockStyle.Fill;
            panelSow.Controls.Add(displaySowTable);
            panelBoar.Controls.Add(displayBoarTable);
        }

        private void togglePicBox_Click(object sender, EventArgs e)
        {
            BackToCardViewClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnPiglet_Click(object sender, EventArgs e)
        {
            ProceedToPigletTableClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
