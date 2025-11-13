using System;
using System.Drawing;
using System.Windows.Forms;
using SwineSyncc.Data;

namespace SwineSyncc.Navigation.User_Management
{
    public partial class UserDetails : UserControl
    {
        private readonly Panel _mainPanel;
        private int _userId = -1;
        private bool _isEditMode = false;

        
        private string _originalUsername;
        private string _originalPassword;
        private string _originalRole;

        public event EventHandler BackClicked;

        public UserDetails(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel;
        
            this.Dock = DockStyle.Fill;

            btnCancel.Visible = false;
            txtUsername.Visible = false;
            txtPassword.Visible = false;
            cmbRole.Visible = false;

            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Assistant");
        }
       
        public void DisplayUserDetails(int userId, string username, string password, string role)
        {
            _userId = userId;

            _originalUsername = username;
            _originalPassword = password;
            _originalRole = role;

            lblUsername.Text = username;
            lblPassword.Text = password;
            lblRole.Text = role;

            txtUsername.Text = username;
            txtPassword.Text = password;
            cmbRole.SelectedItem = role;
        }

        private void userDetailsBackBtn_Click(object sender, EventArgs e)
        {        
            BackClicked?.Invoke(this, EventArgs.Empty);
        }

        private void editAccBtn_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                EnterEditMode();
                return;
            }
         
            string newUsername = txtUsername.Text.Trim();
            string newPassword = txtPassword.Text.Trim();
            string newRole = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(newRole))
            {
                MessageBox.Show("Please fill out Username, Password, and Role.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UserRepository repo = new UserRepository();
                repo.UpdateUserById(_userId, newUsername, newPassword, newRole);
               
                _originalUsername = newUsername;
                _originalPassword = newPassword;
                _originalRole = newRole;

                lblUsername.Text = newUsername;
                lblPassword.Text = newPassword;
                lblRole.Text = newRole;

                ExitEditMode();

                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       

        private void EnterEditMode()
        {
            _isEditMode = true;
            editAccBtn.Text = "Save";
            btnCancel.Visible = true;
          
            lblUsername.Visible = false;
            lblPassword.Visible = false;
            lblRole.Visible = false;

            txtUsername.Visible = true;
            txtPassword.Visible = true;
            cmbRole.Visible = true;
        }

        private void ExitEditMode()
        {
            _isEditMode = false;
            editAccBtn.Text = "Edit";
            btnCancel.Visible = false;
          
            lblUsername.Visible = true;
            lblPassword.Visible = true;
            lblRole.Visible = true;

            txtUsername.Visible = false;
            txtPassword.Visible = false;
            cmbRole.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = _originalUsername;
            txtPassword.Text = _originalPassword;
            cmbRole.SelectedItem = _originalRole;

            ExitEditMode();
        }
    }
}
