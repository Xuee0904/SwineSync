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
        }

        private string GetMotherPigName(int motherPigId)
        {
            PigRepository repo = new PigRepository();
            Pig mother = repo.GetPigById(motherPigId);

            return mother != null ? mother.Name : "Unknown Mother";
        }


        private void savebtn_Click(object sender, EventArgs e)
        {           
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


        private void cancelbtn_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void registerPigletPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
