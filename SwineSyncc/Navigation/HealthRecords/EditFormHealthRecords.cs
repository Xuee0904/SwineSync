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

namespace SwineSyncc.Navigation.HealthRecords
{
    using SwineSyncc.Models;
    public partial class EditFormHealthRecords : Form
    {
        private readonly int _HealthRecordID;
        private Health fetchData;
        public EditFormHealthRecords(int id)
        {
            InitializeComponent();
            HealthRepository.PopulatePigComboBox(editComboHealth);

            _HealthRecordID = id;

            var repo = new HealthRepository();
            fetchData = repo.GetHealthById(_HealthRecordID);
            LoadHealthRecordData();

            buttonGroup1.CancelClicked += (s, e) => Close();
            buttonGroup1.ClearClicked += (s, e) => ClearFields();
            buttonGroup1.SaveClicked += (s, e) => SaveHandler(s, e);
        }


        private void LoadHealthRecordData()
        {
            if (fetchData == null)
            {
                MessageBox.Show("No health record found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Preselect pig/piglet in ComboBox
            foreach (PigComboDetails item in editComboHealth.Items)
            {
                if ((fetchData.PigID.HasValue && item.PigID == fetchData.PigID) ||
                    (fetchData.PigletID.HasValue && item.PigletID == fetchData.PigletID))
                {
                    editComboHealth.SelectedItem = item;
                    break;
                }
            }

            // 2. Set date
            dtEditCheckup.Value = fetchData.CheckupDate;

            // 3. Set text fields
            editConditionTxt.Text = fetchData.Condition;
            editTreatmentTxt.Text = fetchData.Treatment;
            editVetNameTxt.Text = fetchData.VeterinarianName;
            editNotesTxt.Text = fetchData.Notes;
        }

        private void buttonGroup1_Load(object sender, EventArgs e)
        {

        }

        private void EditFormHealthRecords_Load(object sender, EventArgs e)
        {

        }

        private void ClearFields()
        {
            // Reset pig/piglet ComboBox
            editComboHealth.SelectedIndex = -1;

            // Reset date picker to today (or MinDate if you prefer a neutral default)
            dtEditCheckup.Value = DateTime.Today;

            // Clear text fields
            editConditionTxt.Clear();
            editTreatmentTxt.Clear();
            editVetNameTxt.Clear();
            editNotesTxt.Clear();
        }

        private void SaveHandler(object sender, EventArgs e)
        {
            if (editComboHealth.SelectedItem == null)
            {
                MessageBox.Show("Please select a pig or piglet.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(editConditionTxt.Text))
            {
                MessageBox.Show("Condition is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(editTreatmentTxt.Text))
            {
                MessageBox.Show("Treatment is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(editVetNameTxt.Text))
            {
                MessageBox.Show("Veterinarian name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Extract selected pig/piglet
            var selected = editComboHealth.SelectedItem as PigComboDetails;
            int? pigId = selected?.PigID;
            int? pigletId = selected?.PigletID;

            // 3. Build Health object
            var healthRecord = new Health
            {
                HealthRecordID = fetchData.HealthRecordID, // existing record ID
                PigID = pigId,
                PigletID = pigletId,
                CheckupDate = dtEditCheckup.Value,
                Condition = editConditionTxt.Text.Trim(),
                Treatment = editTreatmentTxt.Text.Trim(),
                VeterinarianName = editVetNameTxt.Text.Trim(),
                Notes = editNotesTxt.Text.Trim()
            };
            try
            {
                using (SqlConnection conn = DBConnection.Instance.GetConnection())
                {
                    conn.Open();

                    string query = @"
                UPDATE HealthRecords
                SET PigID = @PigID,
                    PigletID = @PigletID,
                    CheckupDate = @CheckupDate,
                    Condition = @Condition,
                    Treatment = @Treatment,
                    VetName = @VetName,
                    Notes = @Notes
                WHERE HealthRecordID = @HealthRecordID;
            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@HealthRecordID", healthRecord.HealthRecordID);
                        cmd.Parameters.AddWithValue("@PigID", (object)healthRecord.PigID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@PigletID", (object)healthRecord.PigletID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CheckupDate", healthRecord.CheckupDate);
                        cmd.Parameters.AddWithValue("@Condition", healthRecord.Condition);
                        cmd.Parameters.AddWithValue("@Treatment", healthRecord.Treatment);
                        cmd.Parameters.AddWithValue("@VetName", healthRecord.VeterinarianName);
                        cmd.Parameters.AddWithValue("@Notes", healthRecord.Notes);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Health record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // close form with success
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving health record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
