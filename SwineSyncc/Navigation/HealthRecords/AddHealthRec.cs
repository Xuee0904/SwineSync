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
using static SwineSyncc.Navigation.Pig_Management.AddPiglet;

namespace SwineSyncc.Navigation
{
    using SwineSyncc.Models;
    using SwineSyncc.Navigation.HealthRecords;

    public partial class AddHealthRec : UserControl
    {
        public event EventHandler CancelClicked;


        public event EventHandler SaveCompleted;


        public AddHealthRec()
        {
            InitializeComponent();

            HealthRepository.PopulatePigComboBox(comboHealthPigName);
            comboHealthPigName.DisplayMember = "DisplayText"; 
            comboHealthPigName.SelectedIndex = 0;

            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(addHealthRecPanel, 40);

            this.BackColor = Color.WhiteSmoke;
            addHealthRecPanel.BackColor = Color.FromArgb(217, 221, 220);

            PopulatePigComboBox();


            buttonGroup1.CancelClicked += (s, e) => CancelClicked?.Invoke(this, EventArgs.Empty);
            buttonGroup1.ClearClicked += (s, e) => ClearFields();
            buttonGroup1.SaveClicked += (s, e) => SaveHandler(s, e);
        }

        
        public void PopulatePigComboBox()
        {
            string query = @"SELECT 
            P.PigID,
            NULL AS PigletID,
            P.Name + ' (' + 
                CASE 
                    WHEN P.Sex = 'Female' THEN 'Sow'
                    WHEN P.Sex = 'Male' THEN 'Boar'
                    ELSE 'Pig'
                END + ')' AS DisplayText FROM Pigs P

            UNION ALL

            SELECT 
            NULL AS PigID,
            T.PigletID,
            CAST(T.TagNumber AS NVARCHAR(50)) + ' (Mother: ' + M.Name + ')' + ' (Piglet)' AS DisplayText
            FROM Piglets T
            INNER JOIN Pigs M ON T.MotherPigID = M.PigID;";

            comboHealthPigName.Items.Clear();

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            var item = new PigComboDetails
                            {
                                PigID = reader["PigID"] is DBNull ? (int?)null : (int)reader["PigID"],
                                PigletID = reader["PigletID"] is DBNull ? (int?)null : (int)reader["PigletID"],

                                DisplayText = reader["DisplayText"].ToString()
                            };

                            comboHealthPigName.Items.Add(item);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading data: " + ex.Message);
                    }
                }
            }
        }

        private void SaveHandler(object sender, EventArgs e)
        {           
         
            if (comboHealthPigName.SelectedItem == null)
            {
                MessageBox.Show("Please select a pig or piglet.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboHealthPigName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(conditionTxt.Text))
            {
                MessageBox.Show("Condition field is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conditionTxt.Focus();
                return;
            }
    
            if (string.IsNullOrWhiteSpace(treatmentTxt.Text))
            {
                MessageBox.Show("Treatment field is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                treatmentTxt.Focus();
                return;
            }
         
            if (string.IsNullOrWhiteSpace(vetNameTxt.Text))
            {
                MessageBox.Show("Vet Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vetNameTxt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(notesTxt.Text))
            {
                MessageBox.Show("Notes field is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                notesTxt.Focus();
                return;
            }

            if (dtCheckUp.Value > DateTime.Now)
            {
                MessageBox.Show("Checkup date cannot be in the future.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtCheckUp.Focus();
                return;
            }

            var selectedPigItem = comboHealthPigName.SelectedItem as PigComboDetails;

                int? pigIDToSave = selectedPigItem.PigID;
                int? pigletIDToSave = selectedPigItem.PigletID;

                DateTime checkUpDate = dtCheckUp.Value;
                string condition = conditionTxt.Text;
                string treatment = treatmentTxt.Text;
                string vetName = vetNameTxt.Text;
                string notes = notesTxt.Text;

            string query = @"INSERT INTO HealthRecords 
            (PigID, PigletID, CheckupDate, Condition, Treatment, VetName, Notes)
            VALUES (@PigID, @PigletID, @Date, @Condition, @Treatment, @VetName, @Notes);";


                using (SqlConnection conn = DBConnection.Instance.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PigID", pigIDToSave.HasValue ? (object)pigIDToSave.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@PigletID", pigletIDToSave.HasValue ? (object)pigletIDToSave.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@Date", checkUpDate);
                        cmd.Parameters.AddWithValue("@Condition", condition);
                        cmd.Parameters.AddWithValue("@Treatment", treatment);
                        cmd.Parameters.AddWithValue("@VetName", vetName);
                        cmd.Parameters.AddWithValue("@Notes", notes);

                        try
                        {
                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Health record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            SaveCompleted?.Invoke(this, EventArgs.Empty);
                            ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("Record was not saved. Database operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Database Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }
        }


        private void ClearFields()
        {
            comboHealthPigName.SelectedIndex = -1;
            conditionTxt.Clear();
            treatmentTxt.Clear();
            vetNameTxt.Clear();
            notesTxt.Clear();
            dtCheckUp.Value = DateTime.Now;
        }

        private void buttonGroup1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
