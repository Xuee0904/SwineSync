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

        public PigManagement()
        {
            InitializeComponent();
            this.Dock = DockStyle.Right;
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
                PigDetails details = new PigDetails();
                details.DisplayPigDetails(
                    pig.PigID,
                    pig.TagNumber,
                    pig.Breed,
                    pig.Sex,
                    pig.Birthdate,
                    pig.Weight,
                    pig.Status
                );

                // ✅ safer way
                Form parentForm = this.FindForm();
                if (parentForm != null)
                {
                    parentForm.Controls.Clear();
                    parentForm.Controls.Add(details);
                    details.Dock = DockStyle.Fill;
                }
                else
                {
                    MessageBox.Show("Parent form not found.");
                }
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
