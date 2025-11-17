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
using System.Windows.Markup;
using SwineSyncc.Data;

namespace SwineSyncc.Navigation
{
    public partial class SwineSyncTable : UserControl
    {
        public SwineSyncTable()
        {
            InitializeComponent();
        }

        CheckBox headerCheckBox = new CheckBox();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void AddHeaderCheckBox()
        {
            headerCheckBox.Size = new Size(15, 15);
            headerCheckBox.BackColor = Color.Transparent;

            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

            Rectangle rect = dataGridView1.GetCellDisplayRectangle(0, -1, true);
            headerCheckBox.Location = new Point(
                rect.X + (rect.Width - headerCheckBox.Width) / 2,
                rect.Y + (rect.Height - headerCheckBox.Height) / 2
            );

            dataGridView1.Controls.Add(headerCheckBox);
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool checkStatus = headerCheckBox.Checked;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["Select"].Value = checkStatus;
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void SwineSyncTable_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = DBConnection.Instance.GetConnection())
            {
                string query = "SELECT * FROM PregnancyRecords";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";  // leaves the header empty
            chk.Name = "Select";
            chk.Width = 15;
            chk.ReadOnly = false;
            chk.TrueValue = true;
            chk.FalseValue = false;

            dataGridView1.Columns.Insert(0, chk);

            AddHeaderCheckBox();
        }
    }
}
