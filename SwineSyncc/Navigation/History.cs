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
    public partial class History : UserControl
    {
        SwineSyncTable displayDeletedPigs;
        SwineSyncTable displayDeletedPiglets;
        public History()
        {
            InitializeComponent();
            displayDeletedPigs = new SwineSyncTable();
            displayDeletedPiglets = new SwineSyncTable();
        }

        private void History_Load(object sender, EventArgs e)
        {
            displayDeletedPigs.Dock = DockStyle.Fill;
            displayDeletedPigs.SetTableQuery("DeletedPigs");
            pnlDeletedPigs.Controls.Add(displayDeletedPigs);
            displayDeletedPiglets.Dock = DockStyle.Fill;
            displayDeletedPiglets.SetTableQuery("DeletedPiglets");
            pnlDeletedPiglets.Controls.Add(displayDeletedPigs);
        }
    }
}
