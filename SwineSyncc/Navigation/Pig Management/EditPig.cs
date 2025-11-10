using System;
using System.Windows.Forms;
using SwineSyncc.Data;
using System.Drawing;

namespace SwineSyncc.Navigation.Pig_Management
{
    public partial class EditPig : UserControl
    {
        private int _pigId;
        private Panel _mainPanel;

        public EditPig(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel;

            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(editPigPanel, 20);

            this.BackColor = Color.WhiteSmoke;
            editPigPanel.BackColor = Color.FromArgb(217, 221, 220);

            editComboBreed.Items.Add("Large White");
            editComboBreed.Items.Add("Landrace");
            editComboBreed.Items.Add("Duroc");
            editComboBreed.Items.Add("Pietrain");
            editComboBreed.Items.Add("Hampshire");
            editComboBreed.Items.Add("Berkshire");
            editComboBreed.Items.Add("Tamworth");
            editComboBreed.Items.Add("Chester White");
            editComboBreed.Items.Add("Yorkshire");
            editComboBreed.Items.Add("Hereford");
            editComboBreed.Items.Add("Mangalitsa");
            editComboBreed.Items.Add("Kunekune");
            editComboBreed.Items.Add("Pot-bellied Pig");


            editComboStatus.Items.Add("Alive");
            editComboStatus.Items.Add("For Breeding");
            editComboStatus.Items.Add("Gestating (Pregnant)");
            editComboStatus.Items.Add("Lactating");
            editComboStatus.Items.Add("Weaned");
            editComboStatus.Items.Add("Sold");
            editComboStatus.Items.Add("Slaughtered");
            editComboStatus.Items.Add("Dead");
            editComboStatus.Items.Add("Sick");
            editComboStatus.Items.Add("Quarantined");
        }

        public void LoadPigData(Pig pig)
        {
            _pigId = pig.PigID;

            editNameTxt.Text = pig.Name;
            editComboBreed.Text = pig.Breed;

            if (pig.Sex.Equals("Male", StringComparison.OrdinalIgnoreCase))
                editRbMale.Checked = true;
            else
                editRbFemale.Checked = true;

            editDtPicker.Value = pig.Birthdate;
            editWeightTxt.Text = pig.Weight.ToString();
            editComboStatus.Text = pig.Status;
        }

        private void editSaveBtn_Click(object sender, EventArgs e)
        {         
          
            if (string.IsNullOrWhiteSpace(editNameTxt.Text))
            {
                MessageBox.Show("Please enter the pig's name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                editNameTxt.Focus();
                return;
            }
         
            if (string.IsNullOrWhiteSpace(editComboBreed.Text))
            {
                MessageBox.Show("Please select a breed.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                editComboBreed.Focus();
                return;
            }
          
            if (!editRbMale.Checked && !editRbFemale.Checked)
            {
                MessageBox.Show("Please select the pig's sex.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(editComboStatus.Text))
            {
                MessageBox.Show("Please select a status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                editComboStatus.Focus();
                return;
            }
           
            if (!int.TryParse(editWeightTxt.Text, out int weight))
            {
                MessageBox.Show("Weight must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                editWeightTxt.Focus();
                return;
            }

            if (weight <= 0)
            {
                MessageBox.Show("Weight must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                editWeightTxt.Focus();
                return;
            }
       
            if (editDtPicker.Value > DateTime.Now)
            {
                MessageBox.Show("Birthdate cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                editDtPicker.Focus();
                return;
            }
           
            string sex = editRbMale.Checked ? "Male" : "Female";

            PigRepository repo = new PigRepository();

            repo.UpdatePig(
                _pigId,
                editNameTxt.Text,
                editComboBreed.Text,
                sex,
                editDtPicker.Value,
                weight,
                editComboStatus.Text
            );

            MessageBox.Show("Pig updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
            Pig updatedPig = repo.GetPigById(_pigId);

            var pigDetails = new PigDetails(_mainPanel);
            pigDetails.DisplayPigDetails(
                updatedPig.PigID,
                updatedPig.Name,
                updatedPig.Breed,
                updatedPig.Sex,
                updatedPig.Birthdate,
                updatedPig.Weight,
                updatedPig.Status
            );

            _mainPanel.Controls.Clear();
            _mainPanel.Controls.Add(pigDetails);
            pigDetails.Dock = DockStyle.Fill;
        }

        private void editCancelBtn_Click(object sender, EventArgs e)
        {
            PigRepository repo = new PigRepository();
            Pig pig = repo.GetPigById(_pigId);

            var pigDetails = new PigDetails(_mainPanel);
            pigDetails.DisplayPigDetails(
                pig.PigID,
                pig.Name,
                pig.Breed,
                pig.Sex,
                pig.Birthdate,
                pig.Weight,
                pig.Status
            );

            _mainPanel.Controls.Clear();
            _mainPanel.Controls.Add(pigDetails);
            pigDetails.Dock = DockStyle.Fill;
        }

        private void editClearBtn_Click(object sender, EventArgs e)
        {
            editNameTxt.Clear();
            editComboBreed.SelectedIndex = -1;
            editRbMale.Checked = false;
            editRbFemale.Checked = false;
            editDtPicker.Value = DateTime.Now;
            editWeightTxt.Clear();
            editComboStatus.SelectedIndex = -1;
        }
    }
}
