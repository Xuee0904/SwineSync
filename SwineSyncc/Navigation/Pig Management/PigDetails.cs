using System;
using System.Collections.Generic; 
using System.Windows.Forms;
using SwineSyncc.Data;
using SwineSyncc.DynamicButtonLoader;
using SwineSyncc.Navigation.Pig_Management;

namespace SwineSyncc.Navigation
{
    public partial class PigDetails : UserControl
    {
        private Panel _mainPanel;
        private UserControlManager _controlManager;

        private int _motherPigId;
      
        private bool _isDeleteMode = false;
   
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
                currentPigletsLbl.Visible = true;
                rightLineLbl.Visible = true;
                leftLineLbl.Visible = true;
                addPigletBtn.Visible = true;
                flpCurrentPiglets.Visible = true;
                deletePigletBtn.Visible = true;

                btnEdit.Visible = true;        
                editBtnMale.Visible = false;   

                LoadPiglets();
            }
            else
            {
                
                currentPigletsLbl.Visible = false;
                rightLineLbl.Visible = false;
                leftLineLbl.Visible = false;
                addPigletBtn.Visible = false;
                flpCurrentPiglets.Visible = false;
                deletePigletBtn.Visible = false;

                btnEdit.Visible = false;       
                editBtnMale.Visible = true;    
            }
        }
        
        private void LoadPiglets()
        {
            var loader = new PigletLoader(
                flpCurrentPiglets,
                _motherPigId,
                OnPigletSelected
            );

            
            loader.LoadPiglets(_isDeleteMode, _selectedPigletIds);
        }

        private void OnPigletSelected(int pigletId)
        {
           
            if (_isDeleteMode)
                return;

            _controlManager.LoadPigletDetails(pigletId);
        }

        private void OpenEditPig()
        {
            PigRepository repo = new PigRepository();
            Pig pig = repo.GetPigById(_motherPigId);

            EditPig edit = new EditPig(_mainPanel);
            edit.LoadPigData(pig);

            _mainPanel.Controls.Clear();
            _mainPanel.Controls.Add(edit);
            edit.Dock = DockStyle.Fill;
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

                        ActivityLogger.Log(
                            "Delete Piglet",
                            $"Piglet ID {id} from Mother Pig ID {_motherPigId} was deleted."
                        );

                    }

                    MessageBox.Show("Piglet deletion successful!");
                }

                _isDeleteMode = false;
                _selectedPigletIds.Clear();
                deletePigletBtn.Text = "Delete Piglet";

                LoadPiglets();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenEditPig();
        }

        private void pigDetailsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void editBtnMale_Click(object sender, EventArgs e)
        {
            OpenEditPig();
        }
    }
}
