using System;
using System.Windows.Forms;
using SwineSyncc.Data;

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

            editPigletBreed.Items.Add("Large White");
            editPigletBreed.Items.Add("Landrace");
            editPigletBreed.Items.Add("Duroc");
            editPigletBreed.Items.Add("Pietrain");
            editPigletBreed.Items.Add("Hampshire");
            editPigletBreed.Items.Add("Berkshire");
            editPigletBreed.Items.Add("Tamworth");
            editPigletBreed.Items.Add("Chester White");
            editPigletBreed.Items.Add("Yorkshire");
            editPigletBreed.Items.Add("Hereford");
            editPigletBreed.Items.Add("Mangalitsa");
            editPigletBreed.Items.Add("Kunekune");
            editPigletBreed.Items.Add("Pot-bellied Pig");


            editPigletStatus.Items.Add("Alive");
            editPigletStatus.Items.Add("For Breeding");
            editPigletStatus.Items.Add("Gestating (Pregnant)");
            editPigletStatus.Items.Add("Lactating");
            editPigletStatus.Items.Add("Weaned");
            editPigletStatus.Items.Add("Sold");
            editPigletStatus.Items.Add("Slaughtered");
            editPigletStatus.Items.Add("Dead");
            editPigletStatus.Items.Add("Sick");
            editPigletStatus.Items.Add("Quarantined");
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
    }
}
