using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc.Navigation.Inventory
{
    public partial class InventoryRecords : UserControl
    {
        SwineSyncTable displayTable;

        public event EventHandler AddItemClicked;

        public InventoryRecords()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            displayTable = new SwineSyncTable();
            displayTable.SetTableQuery("Inventory");
            displayTable.Dock = DockStyle.Fill;
            pnlInventory.Controls.Add(displayTable);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItemClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
