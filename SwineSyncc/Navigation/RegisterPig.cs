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
          
            comboBreed.Items.Add("SAMPLE BREED 1");
            comboBreed.Items.Add("SAMPLE BREED 2");
            comboBreed.Items.Add("SAMPLE BREED 3");

            comboStatus.Items.Add("ALIVE");
            comboStatus.Items.Add("SOLD (BINARAT)");
            comboStatus.Items.Add("NILECHON NG KAPITBAHAY");
        }

        private void ApplyTextBoxHeight()
        {
            UIStyle.BoxHeight(tagNumberTxt);
            UIStyle.BoxHeight(weightTxt);
            UIStyle.BoxHeight(dtPicker);
            UIStyle.BoxHeight(comboBreed);
            UIStyle.BoxHeight(comboStatus);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            string tagNumber = tagNumberTxt.Text;
            string breed = comboBreed.Text;
            string sex = "";
          
            if (maleRadioBtn.Checked)
                sex = "Male";
            else if (femaleRadioBtn.Checked)
                sex = "Female";
            else
            {
                MessageBox.Show("Please select a sex before registering.", "Missing Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string status = comboStatus.Text;
            int weight = 0;
            int.TryParse(weightTxt.Text, out weight);
            DateTime birthdate = dtPicker.Value;

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                string query = @"INSERT INTO Pigs (TagNumber, Birthdate, Breed, Sex, Weight, Status)
                                 VALUES (@TagNumber, @Birthdate, @Breed, @Sex, @Weight, @Status)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
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
                            MessageBox.Show("🐷 Pig registered successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            _parentPigManagement.RefreshPigList();
                         
                            tagNumberTxt.Clear();
                            weightTxt.Clear();
                            comboBreed.SelectedIndex = -1;
                            comboStatus.SelectedIndex = -1;
                            dtPicker.Value = DateTime.Now;
                            maleRadioBtn.Checked = false;
                            femaleRadioBtn.Checked = false;
                        }
                        else
                        {
                            MessageBox.Show("Failed to register pig.", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void clearbtn_Click_1(object sender, EventArgs e)
        {
            tagNumberTxt.Clear();
            weightTxt.Clear();
            comboBreed.SelectedIndex = -1;
            comboStatus.SelectedIndex = -1;
            dtPicker.Value = DateTime.Now;
            maleradiobtn.Checked = false;
            femaleradiobtn.Checked = false;
        }

        private void registerPigPanel_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
