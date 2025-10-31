using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SwineSyncc
{
    public class PigLoader
    {
        private string _connectionString;

        public PigLoader(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void LoadPigs(FlowLayoutPanel panel)
        {
            panel.Controls.Clear();

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

                    pigButton.Click += (s, e) =>
                    {
                        MessageBox.Show($"Pig ID {pigId} clicked!");
                    };

                    panel.Controls.Add(pigButton);
                }
            }
        }
    }
}
