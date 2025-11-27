using SwineSyncc.Data;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SwineSyncc.Navigation.Pig_Management
{
    public partial class EditPiglet : UserControl
    {
        private int _pigletId;
        private int _motherPigId;
        private Panel _mainPanel;

        public EditPiglet(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel;


            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(editPigletPanel, 20);

            this.BackColor = Color.WhiteSmoke;
            editPigletPanel.BackColor = Color.FromArgb(217, 221, 220);

            buttonGroup1.CancelClicked += (s, e) => CancelHandler(s, e);
            buttonGroup1.ClearClicked += (s, e) => ClearFields();
            buttonGroup1.SaveClicked += (s, e) => SaveHandler(s, e);

            LoadComboBreed();
        }

        public void LoadPigletData(Piglet piglet)
        {
            _pigletId = piglet.PigletID;
            _motherPigId = piglet.MotherPigID;

            editTnPiglet.Text = piglet.TagNumber;
            editPigletBreed.Text = piglet.Breed;

            if (piglet.Sex.Equals("Male", StringComparison.OrdinalIgnoreCase))
                editPigletRbMale.Checked = true;
            else
                editPigletRbFemale.Checked = true;

            editPigletDt.Value = piglet.Birthdate;
            editPigletWeight.Text = piglet.Weight.ToString();
            editPigletStatus.Text = piglet.Status;
        }

        private void LoadComboBreed()
        {
            editPigletBreed.Items.Clear();

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
                            editPigletBreed.Items.Add(reader["BreedName"].ToString());
                        }
                    }

                    editPigletBreed.Items.Add("Other");
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
            if (string.IsNullOrWhiteSpace(editTnPiglet.Text))
            {
                MessageBox.Show("Tag Number is required.");
                return;
            }

            if (!int.TryParse(editPigletWeight.Text, out int weight))
            {
                MessageBox.Show("Weight must be a valid number.");
                return;
            }

            if (weight > 300)
            {
                MessageBox.Show("Weight limit exceeded. A piglet cannot weigh more than 300 kg.",
                                "Weight Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sex = editPigletRbMale.Checked ? "Male" : "Female";

            string breed = string.Empty;

            if (editPigletBreed.SelectedItem?.ToString() == "Other")
            {
                breed = editPigletBreed.Text.Trim();
                if (string.IsNullOrWhiteSpace(breed) || breed.Equals("Other", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Please specify the breed.", "Missing Breed Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (editPigletBreed.SelectedIndex != -1)
            {
                breed = editPigletBreed.SelectedItem.ToString();
            }
            else if (!string.IsNullOrWhiteSpace(editPigletBreed.Text))
            {
                breed = editPigletBreed.Text.Trim();
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

            var repo = new PigletRepository();
            repo.UpdatePiglet(
                _pigletId,
                editTnPiglet.Text,
                breed,
                sex,
                editPigletDt.Value,
                weight,
                editPigletStatus.Text
            );

            var pigRepo = new PigRepository();
            var mother = pigRepo.GetPigById(_motherPigId);
            string motherName = mother != null ? mother.Name : "Unknown Mother";

            ActivityLogger.Log(
                "Edit Piglet",
                $"Piglet updated | Tag: {editTnPiglet.Text}, Breed: {editPigletBreed.Text}, Sex: {sex}, Birthdate: {editPigletDt.Value:yyyy-MM-dd}, Weight: {weight}kg, Status: {editPigletStatus.Text}, Mother: {motherName}"
            );

            MessageBox.Show("Piglet updated successfully!");                

            var pigDetails = new PigDetails(_mainPanel);
            pigDetails.DisplayPigDetails(
                mother.PigID,
                mother.Name,
                mother.Breed,
                mother.Sex,
                mother.Birthdate,
                mother.Weight,
                mother.Status
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
            var pigRepo = new PigRepository();
            var mother = pigRepo.GetPigById(_motherPigId);

            var pigDetails = new PigDetails(_mainPanel);
            pigDetails.DisplayPigDetails(
                mother.PigID,
                mother.Name,
                mother.Breed,
                mother.Sex,
                mother.Birthdate,
                mother.Weight,
                mother.Status
            );

            _mainPanel.Controls.Clear();
            _mainPanel.Controls.Add(pigDetails);
            pigDetails.Dock = DockStyle.Fill;
        }

        private void ClearFields()
        {
            editTnPiglet.Clear();
            editPigletBreed.SelectedIndex = -1;
            editPigletRbMale.Checked = false;
            editPigletRbFemale.Checked = false;
            editPigletDt.Value = DateTime.Now;
            editPigletWeight.Clear();
            editPigletStatus.SelectedIndex = -1;
        }

        private void editPigletPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void editPigletBreed_SelectedIndexChanged(object sender, EventArgs e)
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
