using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SwineSyncc.Data; 

namespace SwineSyncc
{
    public class PigLoader
    {
        private readonly FlowLayoutPanel _panel;
        private readonly Action<int> _onPigClicked;
      
        public PigLoader(FlowLayoutPanel panel, Action<int> onPigClicked = null)
        {
            _panel = panel;
            _onPigClicked = onPigClicked;
        }

        public void LoadPigs(bool isDeleteMode = false, List<int> selectedPigIds = null)
        {
            _panel.Controls.Clear();
            if (selectedPigIds == null)
                selectedPigIds = new List<int>();


            using (SqlConnection conn = DBConnection.Instance.GetConnection())
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
                        BackColor = selectedPigIds.Contains(pigId) ? Color.Red : Color.White,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold)
                    };

                    pigButton.Click += (s, e) =>
                    {
                        if (isDeleteMode)
                        {
                            if (selectedPigIds.Contains(pigId))
                            {
                                selectedPigIds.Remove(pigId);
                                pigButton.BackColor = Color.White;
                            }
                            else
                            {
                                selectedPigIds.Add(pigId);
                                pigButton.BackColor = Color.Red;
                            }
                        }
                        else
                        {
                            _onPigClicked?.Invoke(pigId);
                        }
                    };

                    _panel.Controls.Add(pigButton);
                }
            }
        }

    }
}
