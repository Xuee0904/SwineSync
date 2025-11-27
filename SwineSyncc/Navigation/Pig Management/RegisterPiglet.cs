using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SwineSyncc.Data; 

namespace SwineSyncc
{
    public partial class RegisterPiglet : UserControl
    {
        private int _motherPigId;
        public event EventHandler SaveCompleted;
        public event EventHandler CancelClicked;


        public RegisterPiglet(int motherPigId) 
        {
            InitializeComponent();
            _motherPigId = motherPigId; 
           
            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(registerPigletPanel, 15);
            
            this.BackColor = Color.WhiteSmoke;
            registerPigletPanel.BackColor = Color.FromArgb(217, 221, 220);

            buttonGroup1.CancelClicked += (s, e) => CancelClicked?.Invoke(this, EventArgs.Empty);
            buttonGroup1.ClearClicked += (s, e) => ClearFields();
            buttonGroup1.SaveClicked += (s, e) => SaveHandler(s, e);

            LoadComboBreed();
        }

        private string GetMotherPigName(int motherPigId)
        {
            PigRepository repo = new PigRepository();
            Pig mother = repo.GetPigById(motherPigId);

            return mother != null ? mother.Name : "Unknown Mother";
        }

        private void LoadComboBreed()
        {
            comboBreed.Items.Clear();

            string query = "SELECT BreedName FROM PigBreed ORDER BY BreedName ASC";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBreed.Items.Add(reader["BreedName"].ToString());
                        }
                    }

                    comboBreed.Items.Add("Other");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading breed list: " + ex.Message, "Database Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void SaveHandler (object sender, EventArgs e)
        {           
            if (string.IsNullOrWhiteSpace(tagNumberTxt.Text))
            {
                MessageBox.Show("Tag Number is required.", "Validation Error",
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

            if (weight > 300)
            {
                MessageBox.Show("Weight limit exceeded. A piglet cannot weigh more than 300 kg.",
                                "Weight Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string breed = string.Empty;

            if (comboBreed.SelectedItem?.ToString() == "Other")
            {
                breed = comboBreed.Text.Trim();
                if (string.IsNullOrWhiteSpace(breed) || breed.Equals("Other", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Please specify the breed.", "Missing Breed Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (comboBreed.SelectedIndex != -1)
            {
                breed = comboBreed.SelectedItem.ToString();
            }
            else if (!string.IsNullOrWhiteSpace(comboBreed.Text))
            {
                breed = comboBreed.Text.Trim();
            }
            else
            {
                MessageBox.Show("Please select or enter a breed.", "Missing Breed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!BreedExists(breed))
            {
                if (!InsertNewBreed(breed))
                {
                    MessageBox.Show($"Failed to save the new breed: {breed}. Pig registration canceled.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string tagNumber = tagNumberTxt.Text.Trim();
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
                    cmd.Parameters.AddWithValue("@MotherPigID", _motherPigId);
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
                            string motherName = GetMotherPigName(_motherPigId);

                            ActivityLogger.Log(
                                "Add Piglet",
                                $"Piglet Added | Tag: {tagNumber}, Breed: {breed}, Sex: {sex}, Mother: {motherName}"
                            );


                            MessageBox.Show("🐷 Piglet registered successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            tagNumberTxt.Clear();
                            weightTxt.Clear();
                            comboBreed.SelectedIndex = -1;
                            comboStatus.SelectedIndex = -1;
                            dtPicker.Value = DateTime.Now;
                            maleRadioBtn.Checked = false;
                            femaleRadioBtn.Checked = false;

                            
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
            tagNumberTxt.Clear();
            weightTxt.Clear();
            comboBreed.SelectedIndex = -1;
            comboStatus.SelectedIndex = -1;
            dtPicker.Value = DateTime.Now;
            maleRadioBtn.Checked = false;
            femaleRadioBtn.Checked = false;
        }

        private bool BreedExists(string breedName)
        {
            string query = "SELECT COUNT(1) FROM PigBreed WHERE BreedName = @BreedName";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BreedName", breedName);
                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error checking breed existence: {ex.Message}");
                    return true;
                }
            }
        }

        private bool InsertNewBreed(string breedName)
        {
            string query = "INSERT INTO PigBreed (BreedName) VALUES (@BreedName)";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BreedName", breedName);
                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    ActivityLogger.Log("New breed added.", $"New breed '{breedName}' inserted into PigBreed table.");

                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting new breed: {ex.Message}");
                    return false;
                }
            }
        }


        private void registerPigletPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBreed_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedItem = comboBox.SelectedItem?.ToString();

            if (selectedItem == "Other")
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.Text = string.Empty;
                comboBox.Focus();
            }
            else
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
    }
}
