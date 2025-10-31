using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SwineSyncc
{
    public class PigLoader
    {
        private readonly string _connectionString;
        private readonly FlowLayoutPanel _panel;
        private readonly Action<int> _onPigClicked; 

        public PigLoader(string connectionString, FlowLayoutPanel panel, Action<int> onPigClicked = null)
        {
            _connectionString = connectionString;
            _panel = panel;
            _onPigClicked = onPigClicked;
        }

        public void LoadPigs()
        {
            _panel.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT PigID, TagNumber FROM Pigs";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int pigId = Convert.ToInt32(reader["PigID"]);
                    string tagNumber = reader["TagNumber"].ToString();

                    Button pigButton = new Button
                    {
                        Text = tagNumber,
                        Width = 120,
                        Height = 100,
                        Tag = pigId,
                        Margin = new Padding(10),
                        BackColor = Color.White,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold)
                    };

                 
                    pigButton.Click += (s, e) => _onPigClicked?.Invoke(pigId);

                    _panel.Controls.Add(pigButton);
                }
            }
        }
    }
}
