using SwineSyncc.Data;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SwineSyncc.Navigation.Pig_Management
{
    public partial class EditPig : UserControl
    {
        private int _pigId;
        private Panel _mainPanel;

        public EditPig(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel;

            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(editPigPanel, 20);

            this.BackColor = Color.WhiteSmoke;
            editPigPanel.BackColor = Color.FromArgb(217, 221, 220);

            buttonGroup1.CancelClicked += (s, e) => CancelHandler(s, e);
            buttonGroup1.ClearClicked += (s, e) => ClearFields();
            buttonGroup1.SaveClicked += (s, e) => SaveHandler(s, e);

            LoadComboBreed();
        }

        public void LoadPigData(Pig pig)
        {
            _pigId = pig.PigID;

            editNameTxt.Text = pig.Name;
            editComboBreed.Text = pig.Breed;

            if (pig.Sex.Equals("Male", StringComparison.OrdinalIgnoreCase))
                editRbMale.Checked = true;
            else
                editRbFemale.Checked = true;

            editDtPicker.Value = pig.Birthdate;
            editWeightTxt.Text = pig.Weight.ToString();
            editComboStatus.Text = pig.Status;
        }

        private void LoadComboBreed()
        {
            editComboBreed.Items.Clear();

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
                            editComboBreed.Items.Add(reader["BreedName"].ToString());
                        }
                    }

                    editComboBreed.Items.Add("Other");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading breed list: " + ex.Message, "Database Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveHandler(object sender, EventArgs e)
        {         
          
            if (string.IsNullOrWhiteSpace(editNameTxt.Text))
            {
                MessageBox.Show("Please enter the pig's name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                editNameTxt.Focus();
                return;
            }
          
            if (!editRbMale.Checked && !editRbFemale.Checked)
            {
                MessageBox.Show("Please select the pig's sex.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(editComboStatus.Text))
            {
                MessageBox.Show("Please select a status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                editComboStatus.Focus();
                return;
            }
           
            if (!int.TryParse(editWeightTxt.Text, out int weight))
            {
                MessageBox.Show("Weight must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                editWeightTxt.Focus();
                return;
            }

            if (weight > 300)
            {
                MessageBox.Show("Weight limit exceeded. A pig cannot weigh more than 300 kg.",
                                "Weight Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (weight <= 0)
            {
                MessageBox.Show("Weight must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                editWeightTxt.Focus();
                return;
            }
       
            if (editDtPicker.Value > DateTime.Now)
            {
                MessageBox.Show("Birthdate cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                editDtPicker.Focus();
                return;
            }
           
            string sex = editRbMale.Checked ? "Male" : "Female";

            string breed = string.Empty;

            if (editComboBreed.SelectedItem?.ToString() == "Other")
            {
                breed = editComboBreed.Text.Trim();
                if (string.IsNullOrWhiteSpace(breed) || breed.Equals("Other", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Please specify the breed.", "Missing Breed Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (editComboBreed.SelectedIndex != -1)
            {
                breed = editComboBreed.SelectedItem.ToString();
            }
            else if (!string.IsNullOrWhiteSpace(editComboBreed.Text))
            {
                breed = editComboBreed.Text.Trim();
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

            PigRepository repo = new PigRepository();

            repo.UpdatePig(
                _pigId,
                editNameTxt.Text,
                breed,
                sex,
                editDtPicker.Value,
                weight,
                editComboStatus.Text
            );

            ActivityLogger.Log(
                action: "Edit Pig",
                description: $"Pig updated | ID: {_pigId}, Name: {editNameTxt.Text}, Breed: {editComboBreed.Text}, Sex: {sex}, Birthdate: {editDtPicker.Value:yyyy-MM-dd}, Weight: {weight}kg, Status: {editComboStatus.Text}"
            );

            MessageBox.Show("Pig updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
            Pig updatedPig = repo.GetPigById(_pigId);

            var pigDetails = new PigDetails(_mainPanel);
            pigDetails.DisplayPigDetails(
                updatedPig.PigID,
                updatedPig.Name,
                updatedPig.Breed,
                updatedPig.Sex,
                updatedPig.Birthdate,
                updatedPig.Weight,
                updatedPig.Status
            );

            _mainPanel.Controls.Clear();
            _mainPanel.Controls.Add(pigDetails);
            pigDetails.Dock = DockStyle.Fill;
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

        private void CancelHandler(object sender, EventArgs e)
        {
            PigRepository repo = new PigRepository();
            Pig pig = repo.GetPigById(_pigId);

            var pigDetails = new PigDetails(_mainPanel);
            pigDetails.DisplayPigDetails(
                pig.PigID,
                pig.Name,
                pig.Breed,
                pig.Sex,
                pig.Birthdate,
                pig.Weight,
                pig.Status
            );

            _mainPanel.Controls.Clear();
            _mainPanel.Controls.Add(pigDetails);
            pigDetails.Dock = DockStyle.Fill;
        }

        private void ClearFields()
        {
            editNameTxt.Clear();
            editComboBreed.SelectedIndex = -1;
            editRbMale.Checked = false;
            editRbFemale.Checked = false;
            editDtPicker.Value = DateTime.Now;
            editWeightTxt.Clear();
            editComboStatus.SelectedIndex = -1;
        }

        private void editComboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void editPigPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void editComboBreed_SelectedIndexChanged(object sender, EventArgs e)
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
