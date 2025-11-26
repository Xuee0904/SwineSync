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

        private void btnDeletePig_Click_1(object sender, EventArgs e)
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
            btnDeletePig.Text = "Delete pig";
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
            int pigletBlockedCount = 0;
            int breedingBlockedCount = 0;

            foreach (int id in _selectedPigIds)
            {              
                if (repo.HasPiglets(id))
                {
                    pigletBlockedCount++;
                    continue;
                }
            
                if (repo.HasBreedingRecords(id))
                {
                    breedingBlockedCount++;
                    continue;
                }
               
                repo.SafeDeletePig(id);
                deletedCount++;

                ActivityLogger.Log(
                    "Delete Pig",
                    $"Pig deleted | PigID: {id}"
                );
            }
          
            if (deletedCount > 0)
            {
             MessageBox.Show(
                  $"Successfully deleted {deletedCount} pig(s).\n\n" +
                  "Some pigs could not be deleted:\n" +
                  $"{pigletBlockedCount} pig(s) have existing piglets.\n" +
                  $"{breedingBlockedCount} pig(s) are part of breeding records.",
                  "Deletion Summary",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information
              );
                    }
            else
            {
             MessageBox.Show(
                "No pigs were deleted.\n\n" +
                "Reasons:\n" +
                $"{pigletBlockedCount} pig(s) have existing piglets.\n" +
                $"{breedingBlockedCount} pig(s) are part of breeding records.",
                "Deletion Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
                    }
        }
      
        _isDeleteMode = false;
        _selectedPigIds.Clear();
        btnDeletePig.Text = "Delete pig";

        LoadPigButtons();
    }

        }

        private void btnRegisterPig_Click_1(object sender, EventArgs e)
        {
            RegisterPigClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
