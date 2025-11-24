using SwineSyncc.Data;
using SwineSyncc.Login;
using System;
using System.Windows.Forms;

namespace SwineSyncc
{
    public partial class Form1 : Form
    {
        private bool passwordVisible = false;
        private readonly UserRepository _userRepo;

        public Form1()
        {
            InitializeComponent();
            _userRepo = new UserRepository();
            this.AcceptButton = logInBtn;
        }

        private void logInBtn_Click_1(object sender, EventArgs e)
        {
            string username = usernameTxt.Text.Trim();
            string password = passwordTxt.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.",
                                "Missing Info",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            User user = _userRepo.GetUserByUsername(username);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password.",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
          
            if (user.Password != password)
            {
                MessageBox.Show("Invalid username or password.",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
         
            Session.UserID = user.UserID;
            Session.Username = user.Username;
            Session.Role = user.Role;

            MessageBox.Show($"Welcome {Session.Username}! You are logged in as {Session.Role}.",
                            "Login Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void eyeIcon_Click(object sender, EventArgs e)
        {
            if (passwordVisible)
            {
                usernameTxt.UseSystemPasswordChar = true;
                eyeIcon.Image = Properties.Resources.eye_closed; 
                passwordVisible = false;
            }
            else
            {
                passwordTxt.UseSystemPasswordChar = false;
                eyeIcon.Image = Properties.Resources.eye_open; 
                passwordVisible = true;
            }
        }
    }
}
