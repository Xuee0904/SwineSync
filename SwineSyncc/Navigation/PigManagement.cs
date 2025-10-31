using System;
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

        public PigManagement(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel;
            this.Dock = DockStyle.Fill;

            LoadPigButtons();
        }

        private void LoadPigButtons()
        {          
            PigLoader loader = new PigLoader(flpPigs, OnPigSelected);
            loader.LoadPigs();
        }

        private void OnPigSelected(int pigId)
        {
            PigRepository repo = new PigRepository();
            Pig pig = repo.GetPigById(pigId);

            if (pig != null)
            {
                PigDetails details = new PigDetails(_mainPanel);
                details.DisplayPigDetails(
                    pig.PigID,
                    pig.TagNumber,
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
    }
}
