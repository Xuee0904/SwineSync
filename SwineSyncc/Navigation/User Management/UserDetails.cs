using System;
using System.Windows.Forms;
using SwineSyncc.Navigation; 
using System.Drawing;

namespace SwineSyncc.Navigation.User_Management
{
    public partial class UserDetails : UserControl
    {
        private readonly Panel _mainPanel;
     
        public event EventHandler BackClicked;

        public UserDetails(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel;

            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(userDetailsPanel, 20);

            this.BackColor = Color.WhiteSmoke;
            userDetailsPanel.BackColor = Color.FromArgb(217, 221, 220);
        }
       
        public void DisplayUserDetails(string username, string password, string role)
        {
            lblUsername.Text = username;
            lblPassword.Text = password;
            lblRole.Text = role;
        }
     
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

        private void editAccBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
