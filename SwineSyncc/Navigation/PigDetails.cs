using System;
using System.Collections.Generic; // ✅ ADDED for List<int>
using System.Windows.Forms;
using SwineSyncc.Data;
using SwineSyncc.DynamicButtonLoader;

namespace SwineSyncc.Navigation
{
    public partial class PigDetails : UserControl
    {
        private Panel _mainPanel;
        private UserControlManager _controlManager;

        private int _motherPigId;

        // ✅ NEW: Delete mode enabled/disabled
        private bool _isDeleteMode = false;

        // ✅ NEW: Stores selected piglet IDs while in delete mode
        private List<int> _selectedPigletIds = new List<int>();


        public PigDetails(Panel mainPanel) : this()
        {
            _mainPanel = mainPanel;
            _controlManager = new UserControlManager(mainPanel);
        }

        public PigDetails()
        {
            InitializeComponent();
            RoundedPanelStyle.ApplyRoundedCorners(pigDetailsPanel, 20);
            pigDetailsPanel.BackColor = System.Drawing.Color.FromArgb(217, 221, 220);
            this.Padding = new Padding(40);
        }

        public void DisplayPigDetails(int id, string name, string breed, string sex, DateTime birthdate, int weight, string status)
        {
            _motherPigId = id;

            lblPig.Text = id.ToString();
            lblpignamelabel.Text = name;
            breedLbl.Text = breed;
            sexLbl.Text = sex;
            birthDateLbl.Text = birthdate.ToShortDateString();
            weightLbl.Text = weight.ToString();
            statusLbl.Text = status;

            if (sex.Equals("Female", StringComparison.OrdinalIgnoreCase))
            {
                // ✅ SHOW piglet-related UI for female pigs
                currentPigletsLbl.Visible = true;
                rightLineLbl.Visible = true;
                leftLineLbl.Visible = true;
                addPigletBtn.Visible = true;
                flpCurrentPiglets.Visible = true;
                deletePigletBtn.Visible = true;   // ✅ NEW delete button enabled

                LoadPiglets();
            }
            else
            {
                // ✅ HIDE piglet-related UI for males
                currentPigletsLbl.Visible = false;
                rightLineLbl.Visible = false;
                leftLineLbl.Visible = false;
                addPigletBtn.Visible = false;
                flpCurrentPiglets.Visible = false;
                deletePigletBtn.Visible = false;
            }
        }

        // ✅ UPDATED: Supports delete mode + selected list
        private void LoadPiglets()
        {
            var loader = new PigletLoader(
                flpCurrentPiglets,
                _motherPigId,
                OnPigletSelected
            );

            // ✅ PASS delete mode + selected piglet IDs
            loader.LoadPiglets(_isDeleteMode, _selectedPigletIds);
        }

        private void OnPigletSelected(int pigletId)
        {
            // ✅ If in delete mode, do not open piglet details
            if (_isDeleteMode)
                return;

            _controlManager.LoadPigletDetails(pigletId);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _controlManager.LoadPigManagement();
        }

        private void addPigletBtn_Click(object sender, EventArgs e)
        {
            _controlManager.LoadRegisterPiglet(_motherPigId);
        }

        private void deletePigletBtn_Click(object sender, EventArgs e)
        {
            if (!_isDeleteMode)
            {
                _isDeleteMode = true;
                _selectedPigletIds.Clear();

                deletePigletBtn.Text = "Confirm Delete";
                MessageBox.Show("Delete mode enabled. Select piglets to delete.");

                LoadPiglets();
            }
            else
            {
                if (_selectedPigletIds.Count == 0)
                {
                    MessageBox.Show("No piglets selected.");
                    _isDeleteMode = false;
                    deletePigletBtn.Text = "Delete Piglet";
                    LoadPiglets();
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Delete {_selectedPigletIds.Count} piglet(s)?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    var repo = new PigletRepository();

                    foreach (int id in _selectedPigletIds)
                    {
                        repo.SafeDeletePiglet(id);
                    }

                    MessageBox.Show("Piglet deletion successful!");
                }

                _isDeleteMode = false;
                _selectedPigletIds.Clear();
                deletePigletBtn.Text = "Delete Piglet";

                LoadPiglets();
            }
        }

    }
}
