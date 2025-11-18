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

            comboBreed.Items.Add("Large White");
            comboBreed.Items.Add("Landrace");
            comboBreed.Items.Add("Duroc");
            comboBreed.Items.Add("Pietrain");
            comboBreed.Items.Add("Hampshire");
            comboBreed.Items.Add("Berkshire");
            comboBreed.Items.Add("Tamworth");
            comboBreed.Items.Add("Chester White");
            comboBreed.Items.Add("Yorkshire");
            comboBreed.Items.Add("Hereford");
            comboBreed.Items.Add("Mangalitsa");
            comboBreed.Items.Add("Kunekune");
            comboBreed.Items.Add("Pot-bellied Pig");


            comboStatus.Items.Add("Alive");
            comboStatus.Items.Add("For Breeding");
            comboStatus.Items.Add("Gestating (Pregnant)");
            comboStatus.Items.Add("Lactating");
            comboStatus.Items.Add("Weaned");
            comboStatus.Items.Add("Sold");
            comboStatus.Items.Add("Slaughtered");
            comboStatus.Items.Add("Dead");
            comboStatus.Items.Add("Sick");
            comboStatus.Items.Add("Quarantined");

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


        private void cancelbtn_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void registerPigletPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
