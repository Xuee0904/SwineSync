using System;
using System.Collections.Generic;
using System.Drawing;
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
        private bool _isDeleteMode = false; 
        private readonly List<int> _selectedUserIds = new List<int>(); 

        public UserManagement(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel;
            LoadUserButtons();
        }
       
        private void LoadUserButtons()
        {
            flpAdmin.Controls.Clear();
            flpAssistant.Controls.Clear();

            UserLoader loader = new UserLoader(flpAdmin, flpAssistant, OnUserSelected);
            loader.LoadUsers(_isDeleteMode, _selectedUserIds); 
        }

        public void RefreshUserList()
        {
            LoadUserButtons();
        }
     
        private void OnUserSelected(int userId)
        {
            if (_isDeleteMode)
            {              
                if (_selectedUserIds.Contains(userId))
                    _selectedUserIds.Remove(userId);
                else
                    _selectedUserIds.Add(userId);

                LoadUserButtons(); 
                return;
            }
       
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
   
        private void deleteAccountBtn_Click(object sender, EventArgs e)
        {
            if (!_isDeleteMode)
            {              
                _isDeleteMode = true;
                _selectedUserIds.Clear();

                MessageBox.Show("Delete mode enabled. Select users to delete.", "Delete Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                deleteAccountBtn.Text = "Confirm Delete";

                LoadUserButtons();
            }
            else
            {             
                if (_selectedUserIds.Count == 0)
                {
                    MessageBox.Show("No users selected for deletion.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _isDeleteMode = false;
                    deleteAccountBtn.Text = "Delete Mode";
                    LoadUserButtons();
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Are you sure you want to safely delete {_selectedUserIds.Count} selected user(s)?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        UserRepository repo = new UserRepository();
                        int deletedCount = 0;

                        foreach (int userId in _selectedUserIds)
                        {
                            repo.SafeDeleteUser(userId);
                            deletedCount++;
                        }

                        MessageBox.Show($"{deletedCount} user(s) safely deleted and moved to DeletedUsers table.",
                            "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                _isDeleteMode = false;
                _selectedUserIds.Clear();
                deleteAccountBtn.Text = "Delete Mode";
                LoadUserButtons();
            }
        }
    }
}
