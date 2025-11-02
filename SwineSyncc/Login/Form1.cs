using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SwineSyncc.Data;
using SwineSyncc.Login;

namespace SwineSyncc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
       

        private void logInBtn_Click_1(object sender, EventArgs e)
        {
            string username = usernameRichTxt.Text.Trim();
            string password = passwordRichTxt.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Missing Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                string query = "SELECT UserID, Username, Role FROM Users WHERE Username = @u AND Password = @p";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            Session.UserID = (int)reader["UserID"];
                            Session.Username = reader["Username"].ToString();
                            Session.Role = reader["Role"].ToString();

                            MessageBox.Show($"Welcome {Session.Username}! You are logged in as {Session.Role}.",
                                            "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Dashboard dashboard = new Dashboard();
                            dashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed",
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
    }
}
