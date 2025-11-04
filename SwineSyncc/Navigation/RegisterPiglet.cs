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
            this.BackColor = Color.WhiteSmoke;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            string tagNumber = tagNumberTxt.Text.Trim();
            string breed = comboBreed.Text.Trim();
            string sex = "";

            if (maleRadioBtn.Checked)
                sex = "Male";
            else if (femaleRadioBtn.Checked)
                sex = "Female";
            else
            {
                MessageBox.Show("Please select a sex before saving.", "Missing Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string status = comboStatus.Text.Trim();
            int weight = 0;
            int.TryParse(weightTxt.Text, out weight);
            DateTime birthdate = dtPicker.Value;
           
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                string query = @"INSERT INTO Piglets (MotherPigID, TagNumber, Birthdate, Breed, Sex, Weight, Status)
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
                        else
                        {
                            MessageBox.Show("Failed to register piglet.", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
