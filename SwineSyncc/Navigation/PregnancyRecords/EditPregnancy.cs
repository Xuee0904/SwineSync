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
using static SwineSyncc.Navigation.Pig_Management.AddBreeding;

namespace SwineSyncc.Navigation.PregnancyRecords
{
    public partial class EditPregnancy : Form
    {
        public event EventHandler SaveCompleted;
        private readonly int _PregnancyID;
        private Pregnancy fetchData;

        public EditPregnancy(int id)
        {
            InitializeComponent();
            _PregnancyID = id;

            var repo = new PregnancyRepository();
            fetchData = repo.GetPregnancyById(_PregnancyID);

            buttonGroup1.CancelClicked += (s, e) => Close();
            buttonGroup1.ClearClicked += (s, e) => ClearFields();
            buttonGroup1.SaveClicked += (s, e) => SaveHandler(s, e);
        }

        private void LoadSowNameCombo()
        {
            var sows = new List<SowName>();

            string query = "SELECT PigID, Name FROM Pigs WHERE Sex = 'Female' ORDER BY Name";
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sows.Add(new SowName
                        {
                            PigID = reader.GetInt32(reader.GetOrdinal("PigID")),
                            Name = reader["Name"].ToString()
                        });
                    }
                }
            }

            cbEditSowName.DataSource = sows;
            cbEditSowName.DisplayMember = "Name";
            cbEditSowName.ValueMember = "PigID";

            // Preselect the sow based on fetchData
            cbEditSowName.SelectedValue = fetchData.PregnantPigID;
        }

        private void ClearFields()
        {
            cbEditBreedingID.SelectedIndex = -1;
            cbEditSowName.SelectedIndex = -1;
            dtpEditExpectedFarrowing.Value = DateTime.Now;
            dtpEditConfirmedFarrowing.Value = DateTime.Now;
        }

        private void SaveHandler(object sender, EventArgs e)
        {
            if (cbEditBreedingID.SelectedItem == null)
            {
                MessageBox.Show("Please select a breeding ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbEditSowName.SelectedItem == null)
            {
                MessageBox.Show("Please select a sow.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpEditConfirmedFarrowing.Value > DateTime.Now)
            {
                MessageBox.Show("Confirmation date cannot be in the future.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get values from controls
            int breedingID = Convert.ToInt32(cbEditBreedingID.SelectedItem);
            SowName selectedSow = cbEditSowName.SelectedItem as SowName;
            if (selectedSow == null)
            {
                MessageBox.Show("Invalid sow selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sowID = selectedSow.PigID;
            DateTime expectedFarrowingDate = dtpEditExpectedFarrowing.Value;
            DateTime confirmationDate = dtpEditConfirmedFarrowing.Value;

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                string query = @"
                UPDATE PregnancyRecords
                SET 
                BreedingID = @BreedingID,
                PregnantPigID = @PregnantPigID,
                ExpectedFarrowingDate = @ExpectedFarrowingDate,
                ConfirmationDate = @ConfirmationDate
                WHERE PregnancyID = @PregnancyID;
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BreedingID", breedingID);
                    cmd.Parameters.AddWithValue("@PregnantPigID", sowID);
                    cmd.Parameters.AddWithValue("@ExpectedFarrowingDate", expectedFarrowingDate);
                    cmd.Parameters.AddWithValue("@ConfirmationDate", confirmationDate);
                    cmd.Parameters.AddWithValue("@PregnancyID", _PregnancyID);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("No changes were made. The record may not exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        MessageBox.Show("Pregnancy record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ActivityLogger.Log(
                            "Edit pregnancy",
                            $"Pregnancy Updated (ID: {_PregnancyID}) | Sow: {selectedSow.Name}, BreedingID: {breedingID}, Expected: {expectedFarrowingDate:yyyy-MM-dd}, Confirmed: {confirmationDate:yyyy-MM-dd}"
                        );

                        // Raise event so parent controls can refresh
                        SaveCompleted?.Invoke(this, new BreedingSaveEventArgs(breedingID));

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private const int GestationDays = 114;
        private void cbEditBreedingID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEditBreedingID.SelectedItem == null) return;

            int breedingID = Convert.ToInt32(cbEditBreedingID.SelectedItem);

            string query = @"
            SELECT B.BreedingDate, P.PigID, P.Name
            FROM BreedingRecords B
            INNER JOIN Pigs P ON B.SowID = P.PigID
            WHERE B.BreedingID = @BreedingID;
            ";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BreedingID", breedingID);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DateTime breedingDate = reader.GetDateTime(reader.GetOrdinal("BreedingDate"));
                        int sowID = reader.GetInt32(reader.GetOrdinal("PigID"));

                        // Set expected farrowing date
                        dtpEditExpectedFarrowing.Value = breedingDate.AddDays(GestationDays);

                        // Select sow in ComboBox
                        cbEditSowName.SelectedValue = sowID;
                    }
                }
            }
        }

        private void LoadBreedingIDCombo()
        {
            var breedingIds = new List<int>();

            string query = "SELECT BreedingID FROM BreedingRecords WHERE Result = 'Success' ORDER BY BreedingID";
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        breedingIds.Add(reader.GetInt32(reader.GetOrdinal("BreedingID")));
                    }
                }
            }

            cbEditBreedingID.DataSource = breedingIds;
        }

        private void EditPregnancy_Load(object sender, EventArgs e)
        {
            
            LoadSowNameCombo();
            LoadBreedingIDCombo();

            cbEditBreedingID.SelectedIndexChanged += cbEditBreedingID_SelectedIndexChanged;

            // Preselect values from fetchData
            cbEditBreedingID.SelectedItem = fetchData.BreedingID;
            cbEditSowName.SelectedValue = fetchData.PregnantPigID;
            dtpEditExpectedFarrowing.Value = fetchData.ExpectedFarrowingDate;
            dtpEditConfirmedFarrowing.Value = fetchData.ConfirmationDate;
    }
}


    }
