using System;
using System.Windows.Forms;
using SwineSyncc.Data;
using System.Drawing;

namespace SwineSyncc.Navigation.Pig_Management
{
    public partial class EditPiglet : UserControl
    {
        private int _pigletId;
        private int _motherPigId;
        private Panel _mainPanel;

        public EditPiglet(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel;


            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(editPigletPanel, 20);

            this.BackColor = Color.WhiteSmoke;
            editPigletPanel.BackColor = Color.FromArgb(217, 221, 220);                   
        }

        public void LoadPigletData(Piglet piglet)
        {
            _pigletId = piglet.PigletID;
            _motherPigId = piglet.MotherPigID;

            editTnPiglet.Text = piglet.TagNumber;
            editPigletBreed.Text = piglet.Breed;

            if (piglet.Sex.Equals("Male", StringComparison.OrdinalIgnoreCase))
                editPigletRbMale.Checked = true;
            else
                editPigletRbFemale.Checked = true;

            editPigletDt.Value = piglet.Birthdate;
            editPigletWeight.Text = piglet.Weight.ToString();
            editPigletStatus.Text = piglet.Status;
        }
      
        private void editPigletSave_Click(object sender, EventArgs e)
        {        
            if (string.IsNullOrWhiteSpace(editTnPiglet.Text))
            {
                MessageBox.Show("Tag Number is required.");
                return;
            }

            if (!int.TryParse(editPigletWeight.Text, out int weight))
            {
                MessageBox.Show("Weight must be a valid number.");
                return;
            }

            string sex = editPigletRbMale.Checked ? "Male" : "Female";
           
            var repo = new PigletRepository();
            repo.UpdatePiglet(
                _pigletId,
                editTnPiglet.Text,
                editPigletBreed.Text,
                sex,
                editPigletDt.Value,
                weight,
                editPigletStatus.Text
            );

            MessageBox.Show("Piglet updated successfully!");
         
            var pigRepo = new PigRepository();
            var mother = pigRepo.GetPigById(_motherPigId);

            var pigDetails = new PigDetails(_mainPanel);
            pigDetails.DisplayPigDetails(
                mother.PigID,
                mother.Name,
                mother.Breed,
                mother.Sex,
                mother.Birthdate,
                mother.Weight,
                mother.Status
            );

            _mainPanel.Controls.Clear();
            _mainPanel.Controls.Add(pigDetails);
            pigDetails.Dock = DockStyle.Fill;
        }
     
        private void editPigletCancel_Click(object sender, EventArgs e)
        {
            var pigRepo = new PigRepository();
            var mother = pigRepo.GetPigById(_motherPigId);

            var pigDetails = new PigDetails(_mainPanel);
            pigDetails.DisplayPigDetails(
                mother.PigID,
                mother.Name,
                mother.Breed,
                mother.Sex,
                mother.Birthdate,
                mother.Weight,
                mother.Status
            );

            _mainPanel.Controls.Clear();
            _mainPanel.Controls.Add(pigDetails);
            pigDetails.Dock = DockStyle.Fill;
        }

        private void editPigletClear_Click(object sender, EventArgs e)
        {
            editTnPiglet.Clear();
            editPigletBreed.SelectedIndex = -1;
            editPigletRbMale.Checked = false;
            editPigletRbFemale.Checked = false;
            editPigletDt.Value = DateTime.Now;
            editPigletWeight.Clear();
            editPigletStatus.SelectedIndex = -1;
        }

        private void editPigletPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
