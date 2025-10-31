using System;
using System.Drawing;
using System.Windows.Forms;
using SwineSyncc.Data;      
using SwineSyncc.Navigation; 

namespace SwineSyncc
{
    public partial class PigManagement : UserControl
    {
        private string _connectionString = "Data Source=LAPTOP-SFLC0K1H\\SQLEXPRESS;Initial Catalog=SwineSync;Integrated Security=True;";

        public event EventHandler RegisterPigClicked;

        private Panel _mainPanel;
        public PigManagement(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel;
            this.Dock = DockStyle.Fill; 
            LoadPigButtons();
        }

        private void LoadPigButtons()
        {
            PigLoader loader = new PigLoader(_connectionString, flpPigs, OnPigSelected);
            loader.LoadPigs();
        }

        private void OnPigSelected(int pigId)
        {
            PigRepository repo = new PigRepository(_connectionString);
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

        private void btnRegisterPig_Click_1(object sender, EventArgs e)
        {
            RegisterPigClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
