using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SwineSyncc.Data;
using SwineSyncc.Navigation.Pig_Management;

namespace SwineSyncc.Navigation
{
    public partial class PigletDetails : UserControl
    {
        private Panel _mainPanel;
        private int _motherPigId;
        private int _currentPigletId;

        public event EventHandler<int> BackClicked;

        public PigletDetails(Panel mainPanel)
        {
            InitializeComponent();
            _mainPanel = mainPanel;

            RoundedPanelStyle.ApplyRoundedCorners(pigletDetailsPanel, 20);
            this.Padding = new Padding(40);
            pigletDetailsPanel.BackColor = System.Drawing.Color.FromArgb(217, 221, 220);
        }

        public void DisplayPigletDetails(int pigletId)
        {
            _currentPigletId = pigletId;

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT p.PigletID, p.TagNumber, p.Breed, p.Sex, p.Birthdate,
                           p.Weight, p.Status, 
                           m.Name AS MotherTag, 
                           m.PigID AS MotherPigID
                    FROM Piglets p
                    JOIN Pigs m ON p.MotherPigID = m.PigID
                    WHERE p.PigletID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", pigletId);

                    using (SqlDataReader reader = cmd.ExecuteReader()) // will auto-close
                    {
                        if (reader.Read())
                        {
                            _motherPigId = reader.GetInt32(reader.GetOrdinal("MotherPigID"));

                            motherTagLbl.Text = reader["MotherTag"].ToString();
                            lblTag.Text = reader["TagNumber"].ToString();
                            lblBreed.Text = reader["Breed"].ToString();
                            lblSex.Text = reader["Sex"].ToString();
                            lblBirthDate.Text = Convert.ToDateTime(reader["Birthdate"]).ToShortDateString();
                            lblWeight.Text = reader["Weight"].ToString();
                            lblStatus.Text = reader["Status"].ToString();
                        }
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackClicked?.Invoke(this, _motherPigId);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PigletRepository repo = new PigletRepository();
            Piglet piglet = repo.GetPigletById(_currentPigletId);

            if (piglet == null)
            {
                MessageBox.Show("Error: Piglet not found.");
                return;
            }
          
            var editScreen = new EditPiglet(_mainPanel);
            editScreen.LoadPigletData(piglet);
          
            _mainPanel.Controls.Clear();
            _mainPanel.Controls.Add(editScreen);
            editScreen.Dock = DockStyle.Fill;
        }
    }
}
