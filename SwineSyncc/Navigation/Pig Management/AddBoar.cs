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
    public partial class AddBoar : UserControl
    {

        public event EventHandler CancelClicked;
        public event EventHandler SaveCompleted;

        private PigManagement _parentPigManagement;

        public AddBoar()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(addBoarPanel, 40);

            this.BackColor = Color.WhiteSmoke;
            addBoarPanel.BackColor = Color.FromArgb(217, 221, 220);

            buttonGroup1.CancelClicked += (s, e) => CancelClicked?.Invoke(this, EventArgs.Empty);
            buttonGroup1.ClearClicked += (s, e) => ClearFields();
            buttonGroup1.SaveClicked += (s, e) => SaveHandler(s, e);

            LoadComboBreed();
        }

        private void LoadComboBreed()
        {
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

        private void ClearFields()
        {
            pigNameTxt.Clear();
            weightTxt.Clear();
            comboBreed.SelectedIndex = -1;
            comboStatus.SelectedIndex = -1;
            dtPicker.Value = DateTime.Now;
        }

        private void SaveHandler(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pigNameTxt.Text))
            {
                MessageBox.Show("Please enter a pig name.", "Missing Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status.", "Missing Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(weightTxt.Text, out int weight) || weight <= 0)
            {
                MessageBox.Show("Please enter a valid weight (must be a positive number).", "Invalid Weight",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (weight > 300)
            {
                MessageBox.Show("Weight limit exceeded. A boar cannot weigh more than 300 kg.",
                                "Weight Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtPicker.Value > DateTime.Now)
            {
                MessageBox.Show("Birthdate cannot be in the future.", "Invalid Birthdate",
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

            string name = pigNameTxt.Text.Trim();
            string sex = "Male";
            string status = comboStatus.Text;
            DateTime birthdate = dtPicker.Value;

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                string query = @"INSERT INTO Pigs (Name, Birthdate, Breed, Sex, Weight, Status)
                         VALUES (@Name, @Birthdate, @Breed, @Sex, @Weight, @Status)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
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
                            ActivityLogger.Log(
                                "Register Boar",
                                $"Boar added | Name: {name}, Breed: {breed}, Birthdate: {birthdate.ToShortDateString()}, Weight: {weight}, Status: {status}"
                             );

                            MessageBox.Show("🐷 Pig registered successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            _parentPigManagement?.RefreshPigList();

                            ClearFields();
                            SaveCompleted?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show("Failed to register pig.", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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

                    ActivityLogger.Log("New Breed Added", $"New breed '{breedName}' inserted into PigBreed table.");

                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting new breed: {ex.Message}");
                    return false;
                }
            }
        }

        /*        private void cancelbtn_Click(object sender, EventArgs e)
                {
                    CancelClicked?.Invoke(this, EventArgs.Empty);
                }

                private void clearbtn_Click(object sender, EventArgs e)
                {
                    ClearFields();
                }*/

        private void addBoarPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void savebtn_Click(object sender, EventArgs e)
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
