using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SwineSyncc.Data;
using SwineSyncc.Navigation;

namespace SwineSyncc
{
    public partial class PigManagement : UserControl
    {
        public event EventHandler RegisterPigClicked;

        private readonly Panel _mainPanel;
      
        private bool _isDeleteMode = false;
       
        private List<int> _selectedPigIds = new List<int>();

        public PigManagement(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel;
            this.Dock = DockStyle.Fill;
            
            LoadPigButtons();
        }
       
        private void LoadPigButtons()
        {          
            PigLoader loader = new PigLoader(flpFemalePigs, flpMalePigs, OnPigSelected);
            loader.LoadPigs(_isDeleteMode, _selectedPigIds);
        }
       
        private void OnPigSelected(int pigId)
        {
            if (_isDeleteMode) return; 

            PigRepository repo = new PigRepository();
            Pig pig = repo.GetPigById(pigId);

            if (pig != null)
            {
                PigDetails details = new PigDetails(_mainPanel);
              
                details.DisplayPigDetails(
                    pig.PigID,
                    pig.Name,
                    pig.Breed,
                    pig.Sex,
                    pig.Birthdate,
                    pig.Weight,
                    pig.Status
                );

                _mainPanel.Controls.Clear();
                _mainPanel.Controls.Add(details);
                details.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("Pig not found.");
            }
        }
      
        public void RefreshPigList()
        {
            LoadPigButtons();
        }

        private void btnRegisterPig_Click(object sender, EventArgs e)
        {
            RegisterPigClicked?.Invoke(this, EventArgs.Empty);
        }
  
        private void btnDeletePig_Click(object sender, EventArgs e)
        {
            
            if (!_isDeleteMode)
            {
                _isDeleteMode = true;
                _selectedPigIds.Clear();

                MessageBox.Show("Delete mode enabled. Select pigs to delete.");
                btnDeletePig.Text = "Confirm Delete";

                LoadPigButtons(); 
            }
            else
            {               
                if (_selectedPigIds.Count == 0)
                {
                    MessageBox.Show("No pigs selected for deletion.");
                    _isDeleteMode = false;
                    btnDeletePig.Text = "Delete Mode";
                    LoadPigButtons();
                    return;
                }
          
                var confirm = MessageBox.Show(
                    $"Are you sure you want to delete {_selectedPigIds.Count} selected pig(s)?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

               
                if (confirm == DialogResult.Yes)
                {
                    PigRepository repo = new PigRepository();

                    int deletedCount = 0;  
                    int skippedCount = 0;  

                    foreach (int id in _selectedPigIds)
                    {                  
                        if (repo.HasPiglets(id))
                        {
                            skippedCount++;
                            continue;
                        }

                
                        repo.SafeDeletePig(id);
                        deletedCount++;
                    }
                    if (deletedCount > 0 && skippedCount == 0)
                    {
                        MessageBox.Show("Selected pigs have been deleted successfully!");
                    }
                    else if (deletedCount > 0 && skippedCount > 0)
                    {
                        MessageBox.Show(
                            $"Deleted {deletedCount} pig(s). " +
                            $"{skippedCount} pig(s) were skipped because they have piglets."
                        );
                    }
                    else if (deletedCount == 0 && skippedCount > 0)
                    {
                        MessageBox.Show("No pigs were deleted because they still have piglets.");
                    }
                }
        
                _isDeleteMode = false;
                _selectedPigIds.Clear();
                btnDeletePig.Text = "Delete Mode";

                LoadPigButtons(); 
            }
        }
    }
}
