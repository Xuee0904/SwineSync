using System;
using System.Windows.Forms;
using SwineSyncc.Data;
using SwineSyncc.DynamicButtonLoader;
using SwineSyncc.Navigation.User_Management; 

namespace SwineSyncc.Navigation
{
    public partial class UserManagement : UserControl
    {     
        public event EventHandler AddUserClicked;

        private readonly Panel _mainPanel; 

        public UserManagement(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel;
         
            LoadUserButtons();
        }
     
        private void LoadUserButtons()
        {          
            UserLoader loader = new UserLoader(flpAdmin, flpAssistant, OnUserSelected);
            loader.LoadUsers();
        }

        public void RefreshUserList()
        {
            LoadUserButtons();
        }

        private void OnUserSelected(int userId)
        {
            UserRepository repo = new UserRepository();
            User user = repo.GetUserById(userId);

            if (user != null)
            {              
                UserDetails userDetails = new UserDetails(_mainPanel);
               
                userDetails.DisplayUserDetails(user.Username, user.Password, user.Role);
            
                userDetails.BackClicked += (s, e) =>
                {
                    _mainPanel.Controls.Clear();
                    _mainPanel.Controls.Add(this);
                    this.Dock = DockStyle.Fill;
                };
              
                _mainPanel.Controls.Clear();
                _mainPanel.Controls.Add(userDetails);
                userDetails.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void addAccountBtn_Click(object sender, EventArgs e)
        {
            AddUserClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
