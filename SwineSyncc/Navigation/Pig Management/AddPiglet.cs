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

namespace SwineSyncc.Navigation.Pig_Management
{
    
    public partial class AddPiglet : UserControl
    {
        public event EventHandler SaveCompleted;
        public event EventHandler CancelClicked;

        public AddPiglet()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(addPigletPanel, 40);

            this.BackColor = Color.WhiteSmoke;
            addPigletPanel.BackColor = Color.FromArgb(217, 221, 220);

            LoadMotherPigCombo();
        }

        public class MotherPig
        {
            public int PigID { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private void LoadMotherPigCombo()
        {
            string query = "SELECT PigID, Name FROM Pigs WHERE Sex = 'Female' ORDER BY Name";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        motherPigCombo.Items.Clear();

                        while (reader.Read())
                        {
                            motherPigCombo.Items.Add(new MotherPig
                            {
                                PigID = reader.GetInt32(reader.GetOrdinal("PigID")),
                                Name = reader["Name"].ToString()
                            });
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error laoding data: " + ex.Message);
                    }
                }
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (motherPigCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a mother pig.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tagNumberTxt.Text))
            {
                MessageBox.Show("Tag Number is required.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBreed.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a breed.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!maleRadioBtn.Checked && !femaleRadioBtn.Checked)
            {
                MessageBox.Show("Please select a sex.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(weightTxt.Text, out int weight) || weight <= 0)
            {
                MessageBox.Show("Weight must be a positive number.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MotherPig selectedMotherPig = (MotherPig)motherPigCombo.SelectedItem;
            int motherPigId = selectedMotherPig.PigID;
            string tagNumber = tagNumberTxt.Text.Trim();
            string breed = comboBreed.Text.Trim();
            string sex = maleRadioBtn.Checked ? "Male" : "Female";
            string status = comboStatus.Text.Trim();
            DateTime birthdate = dtPicker.Value;

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                string query = @"INSERT INTO Piglets 
                         (MotherPigID, TagNumber, Birthdate, Breed, Sex, Weight, Status)
                         VALUES (@MotherPigID, @TagNumber, @Birthdate, @Breed, @Sex, @Weight, @Status)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MotherPigID", motherPigId);
                    cmd.Parameters.AddWithValue("@TagNumber", tagNumber);
                    cmd.Parameters.AddWithValue("@Birthdate", birthdate);
                    cmd.Parameters.AddWithValue("@Breed", breed);
                    cmd.Parameters.AddWithValue("@Sex", sex);
                    cmd.Parameters.AddWithValue("@Weight", weight);
                    cmd.Parameters.AddWithValue("@Status", status);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("🐷 Piglet registered successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearFields();

                            SaveCompleted?.Invoke(this, EventArgs.Empty);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearFields()
        {
            motherPigCombo.SelectedIndex = -1;
            tagNumberTxt.Clear();
            weightTxt.Clear();
            comboBreed.SelectedIndex = -1;
            comboStatus.SelectedIndex = -1;
            dtPicker.Value = DateTime.Now;
            maleRadioBtn.Checked = false;
            femaleRadioBtn.Checked = false;
        }              

        private void addPigletPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
