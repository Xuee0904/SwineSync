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

            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(addPregnancyPanel, 40);

            this.BackColor = Color.WhiteSmoke;
            addPregnancyPanel.BackColor = Color.FromArgb(217, 221, 220);

            //buttonGroup1.CancelClicked += (s, e) => CancelClicked?.Invoke(this, EventArgs.Empty);
            //buttonGroup1.ClearClicked += (s, e) => ClearFields();
            buttonGroup1.SaveClicked += (s, e) => SaveHandler(s, e);

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

        private void SaveHandler(object sender, EventArgs e)
        {
            if (comboPregnantSow.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a pregnant sow.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBreedingID.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Breeding ID.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
          
            if (!int.TryParse(comboBreedingID.Text, out int breedingID))
            {
                MessageBox.Show("Invalid Breeding ID format.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int sowID = Convert.ToInt32(comboPregnantSow.SelectedValue);
           
            string sowName = comboPregnantSow.Text;

            DateTime confirmationDate = dtConfirmation.Value;
            DateTime expectedFarrowingDate = dtExpected.Value;

          
            if (confirmationDate > DateTime.Now)
            {
                MessageBox.Show("Confirmation date cannot be in the future.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }                           

            string query = @"
                INSERT INTO PregnancyRecords
                (PregnantPigID, BreedingID, ConfirmationDate, ExpectedFarrowingDate)
                VALUES (@PregnantPigID, @BreedingID, @ConfirmationDate, @ExpectedFarrowingDate)
            ";

            try
            {
                using (SqlConnection conn = DBConnection.Instance.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PregnantPigID", sowID);
                    cmd.Parameters.AddWithValue("@BreedingID", breedingID);
                    cmd.Parameters.AddWithValue("@ConfirmationDate", confirmationDate);
                    cmd.Parameters.AddWithValue("@ExpectedFarrowingDate", expectedFarrowingDate);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                ActivityLogger.Log(
                    "Register pregnancy",
                    $"Pregnancy record added | Sow: {sowName} (ID: {sowID}), Breeding ID: {breedingID}, " +
                    $"Confirmation Date: {confirmationDate:yyyy-MM-dd}, Expected Farrowing Date: {expectedFarrowingDate:yyyy-MM-dd}"
                );

                MessageBox.Show("Pregnancy record saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addPregnancyPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
