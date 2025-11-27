using SwineSyncc.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SwineSyncc.Navigation
{
    public partial class AddUser : UserControl
    {

        public event EventHandler CancelClicked;
        public event EventHandler SaveCompleted;

        public AddUser()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(addUserPanel, 20);

            this.BackColor = Color.WhiteSmoke;
            addUserPanel.BackColor = Color.FromArgb(217, 221, 220);
        }

        private void ClearFields()
        {
            usernameTxt.Clear();
            passwordTxt.Clear();
            adminRadioBtn.Checked = false;
            assistantRadioBtn.Checked = false;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTxt.Text))
            {
                MessageBox.Show("Please enter a username.", "Missing name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(passwordTxt.Text))
            {
                MessageBox.Show("Please enter a password.", "Missing password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!adminRadioBtn.Checked && !assistantRadioBtn.Checked)
            {
                MessageBox.Show("Please select a role.", "Missing role", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = usernameTxt.Text;
            string password = passwordTxt.Text;
            string role = adminRadioBtn.Checked ? "Admin" : "Assistant";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                string query = @"INSERT INTO Users (Username, Password, Role)
                     VALUES (@Username, @Password, @Role)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Account added successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            ClearFields();
                            SaveCompleted?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add account.", "Error",
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
