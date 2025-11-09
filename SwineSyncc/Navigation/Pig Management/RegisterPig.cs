using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SwineSyncc.Data;

namespace SwineSyncc
{
    public partial class RegisterPig : UserControl
    {
        public event EventHandler CancelClicked;
        private PigManagement _parentPigManagement;
        public event EventHandler SaveCompleted;

        public RegisterPig(PigManagement pigManagement)
        {
            InitializeComponent();

            _parentPigManagement = pigManagement;
            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(registerPigPanel, 20);

            this.BackColor = Color.WhiteSmoke;
            registerPigPanel.BackColor = Color.FromArgb(217, 221, 220);
            ApplyTextBoxHeight();

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

        private void ApplyTextBoxHeight()
        {
            UIStyle.BoxHeight(pigNameTxt);
            UIStyle.BoxHeight(weightTxt);
            UIStyle.BoxHeight(dtPicker);
            UIStyle.BoxHeight(comboBreed);
            UIStyle.BoxHeight(comboStatus);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {           
            if (string.IsNullOrWhiteSpace(pigNameTxt.Text))
            {
                MessageBox.Show("Please enter a pig name.", "Missing Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBreed.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a breed.", "Missing Breed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!maleRadioBtn.Checked && !femaleRadioBtn.Checked)
            {
                MessageBox.Show("Please select a sex.", "Missing Sex", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (dtPicker.Value > DateTime.Now)
            {
                MessageBox.Show("Birthdate cannot be in the future.", "Invalid Birthdate",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string name = pigNameTxt.Text.Trim();
            string breed = comboBreed.Text;
            string sex = maleRadioBtn.Checked ? "Male" : "Female";
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
                            MessageBox.Show("🐷 Pig registered successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            _parentPigManagement.RefreshPigList();

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

        private void ClearFields()
        {
            pigNameTxt.Clear();
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

        private void clearbtn_Click_1(object sender, EventArgs e)
        {
           ClearFields();
        }

        private void registerPigPanel_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
