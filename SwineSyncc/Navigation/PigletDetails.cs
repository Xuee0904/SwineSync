using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SwineSyncc.Data;

namespace SwineSyncc.Navigation
{
    public partial class PigletDetails : UserControl
    {
        private Panel _mainPanel;
        private int _motherPigId;   // stores the mother pig ID for back navigation
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
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();

                // include MotherPigID in SELECT so we can assign it to _motherPigId
                string query = @"SELECT p.PigletID, p.TagNumber, p.Breed, p.Sex, p.Birthdate, 
                                        p.Weight, p.Status, m.Name AS MotherTag, m.PigID AS MotherPigID
                                 FROM Piglets p
                                 JOIN Pigs m ON p.MotherPigID = m.PigID
                                 WHERE p.PigletID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", pigletId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // store the MotherPigID so btnBack knows where to go
                        _motherPigId = Convert.ToInt32(reader["MotherPigID"]);

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

        private void btnBack_Click(object sender, EventArgs e)
        {          
            BackClicked?.Invoke(this, _motherPigId);
        }
    }
}
