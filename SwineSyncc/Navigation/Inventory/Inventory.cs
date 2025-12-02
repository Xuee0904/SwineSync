using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc.Navigation
{
    public partial class Inventory : UserControl
    {
        SwineSyncTable displayTable;
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            displayTable.SetTableQuery("Inventory");
            displayTable.Dock = DockStyle.Fill;
            pnlInventory.Controls.Add(displayTable);
        }
    }
}
