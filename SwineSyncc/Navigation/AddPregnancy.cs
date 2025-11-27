using SwineSyncc.Data;
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

namespace SwineSyncc.Navigation
{
    public partial class AddPregnancy : UserControl
    {

        private DataTable pregnantSowData = new DataTable();
        private int gestationDays = 114;

        public AddPregnancy()
        {
            InitializeComponent();

            LoadComboBreedingID();
            LoadComboPregnantSow(); 
        }

        private void LoadComboBreedingID()
        {
            string query = "SELECT BreedingID FROM BreedingRecords WHERE Result = 'Success' ORDER BY BreedingID";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboBreedingID.Items.Clear();
                        while (reader.Read())
                        {
                            comboBreedingID.Items.Add(reader["BreedingID"].ToString());
                        }
                    }
                }
            }
        }

        private void LoadComboPregnantSow()
        {
            string query = "SELECT P.Name, B.BreedingID FROM Pigs AS P INNER JOIN BreedingRecords AS B ON P.PigID = B.SowID WHERE B.Result = 'Success';";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboPregnantSow.Items.Clear();
                        while (reader.Read())
                        {
                            comboPregnantSow.Items.Add(reader["Name"].ToString());
                        }
                    }
                }
            }
        }

        private void LoadSowAndBreedingInfo()
        {
            pregnantSowData.Clear();
            pregnantSowData.Columns.Clear();

            pregnantSowData.Columns.Add("SowID", typeof(int));
            pregnantSowData.Columns.Add("Name", typeof(string));
            pregnantSowData.Columns.Add("BreedingID", typeof(int));
            pregnantSowData.Columns.Add("BreedingDate", typeof(DateTime));

            string query = @"SELECT P.PigID AS SowID, P.Name AS Name, B.BreedingID, B.BreedingDate FROM Pigs AS P
                            INNER JOIN BreedingRecords AS B ON P.PigID = B.SowID 
                            WHERE B.Result = 'Success' ORDER BY P.Name, B.BreedingID;";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        pregnantSowData.Load(reader);
                    }
                }
            }

            comboBreedingID.DataSource = pregnantSowData;
            comboPregnantSow.DataSource = pregnantSowData;

            comboBreedingID.DisplayMember = "BreedingID";
            comboBreedingID.ValueMember = "SowID";

            comboPregnantSow.DisplayMember = "Name";
            comboPregnantSow.ValueMember = "SowID";

            comboBreedingID.SelectedIndex = -1;
            comboPregnantSow.SelectedIndex = -1;
        }

        private void comboPregnantSow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPregnantSow.SelectedIndex != -1)
            {
                DataRowView currentRow = (DataRowView)comboBreedingID.SelectedItem;

                if (currentRow != null)
                {
                    DateTime breedingDate = (DateTime)currentRow["BreedingDate"];

                    DateTime expectedFarrowingDate = breedingDate.AddDays(gestationDays);

                    dtExpected.Value = expectedFarrowingDate;
                }

                comboBreedingID.SelectedIndexChanged -= comboBreedingID_SelectedIndexChanged;

                comboBreedingID.SelectedIndex = comboPregnantSow.SelectedIndex;

                comboBreedingID.SelectedIndexChanged += comboBreedingID_SelectedIndexChanged;
            }
        }

        private void comboBreedingID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBreedingID.SelectedIndex != -1)
            {

                DataRowView currentRow = (DataRowView)comboBreedingID.SelectedItem;

                if (currentRow != null)
                {
                    DateTime breedingDate = (DateTime)currentRow["BreedingDate"];

                    DateTime expectedFarrowingDate = breedingDate.AddDays(gestationDays);

                    dtExpected.Value = expectedFarrowingDate;
                }

                comboPregnantSow.SelectedIndexChanged -= comboPregnantSow_SelectedIndexChanged;

                comboPregnantSow.SelectedIndex = comboBreedingID.SelectedIndex;

                comboPregnantSow.SelectedIndexChanged += comboPregnantSow_SelectedIndexChanged;
            }
        }

        private void AddPregnancy_Load(object sender, EventArgs e)
        {
            LoadSowAndBreedingInfo(); //to ensure both combo boxes data are synchronized
        }
    }
}
