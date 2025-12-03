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

namespace SwineSyncc.Navigation
{
    public partial class DashboardUI : UserControl
    {
        public event EventHandler TotalPigsPanelClicked;

        public DashboardUI()
        {
            InitializeComponent();
            dashboardPigPb.Image = Properties.Resources.PigIcon;

            panelTotalPigs.Click += PanelTotalPigs_Click;
            lblTotalPigs.Click += PanelTotalPigs_Click;  // makes label also clickable

            LoadTotalPigs();
        }

        private void PanelTotalPigs_Click(object sender, EventArgs e)
        {
            TotalPigsPanelClicked?.Invoke(this, EventArgs.Empty);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadTotalPigs()
        {
            string query = "SELECT COUNT(*) FROM Pigs";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                int totalPigs = (int)cmd.ExecuteScalar();
                lblTotalPigs.Text = totalPigs.ToString();
            }
        }       

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                LoadTotalPigs();
            }
        }

        private void panelTotalPigs_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
