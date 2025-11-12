using System;
using System.Windows.Forms;
using SwineSyncc.Navigation; // to access UserManagement

namespace SwineSyncc.Navigation.User_Management
{
    public partial class UserDetails : UserControl
    {
        private readonly Panel _mainPanel;

        // 🔹 Event for back button (optional if you want to handle externally)
        public event EventHandler BackClicked;

        public UserDetails(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel;
        }

        /// <summary>
        /// Displays the selected user’s details (Username, Password, Role).
        /// </summary>
        public void DisplayUserDetails(string username, string password, string role)
        {
            lblUsername.Text = username;
            lblPassword.Text = password;
            lblRole.Text = role;
        }

        /// <summary>
        /// When the Back button is clicked, return to UserManagement view.
        /// </summary>
        private void userDetailsBackBtn_Click(object sender, EventArgs e)
        {
            // Fire event (for external handling, like in UserManagement)
            BackClicked?.Invoke(this, EventArgs.Empty);

            // Or directly return to UserManagement here:
            _mainPanel.Controls.Clear();
            var userManagement = new UserManagement(_mainPanel);
            _mainPanel.Controls.Add(userManagement);
            userManagement.Dock = DockStyle.Fill;
        }
    }
}
