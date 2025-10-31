using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc
{
    public partial class PigManagement : UserControl
    {
        public event EventHandler RegisterPigClicked;

        public PigManagement()
        {
            InitializeComponent();
            this.Dock = DockStyle.Right;
            LoadPigButtons();
        }

        private void LoadPigButtons()
        {
            string connectionString = "Data Source=LAPTOP-SFLC0K1H\\SQLEXPRESS;Initial Catalog=SwineSync;Integrated Security=True;";

            PigLoader loader = new PigLoader(connectionString);
            loader.LoadPigs(flpPigs);
        }

        public void RefreshPigList()
        {
            LoadPigButtons();
        }


        public void AddPigButton(int pigId, string pigTag)
        {
            Button pigButton = new Button
            {
                Text = pigTag,
                Width = 120,
                Height = 100,
                Tag = pigId,
                Margin = new Padding(10),
                BackColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            pigButton.Click += (s, e) =>
            {
                MessageBox.Show($"Pig ID {pigId} clicked!");
            };

            flpPigs.Controls.Add(pigButton);
        }
      
        private void btnRegisterPig_Click_1(object sender, EventArgs e)
        {
            RegisterPigClicked?.Invoke(this, EventArgs.Empty);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
