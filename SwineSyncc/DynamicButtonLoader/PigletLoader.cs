using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SwineSyncc.Data;

namespace SwineSyncc.DynamicButtonLoader
{
    public class PigletLoader
    {
        private FlowLayoutPanel _flpPiglets;
        private int _motherPigId;
        private Action<int> _onPigletSelected;

        public PigletLoader(FlowLayoutPanel flpPiglets, int motherPigId, Action<int> onPigletSelected = null)
        {
            _flpPiglets = flpPiglets;
            _motherPigId = motherPigId;
            _onPigletSelected = onPigletSelected;
        }

        public void LoadPiglets()
        {
            _flpPiglets.Controls.Clear();

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                string query = "SELECT PigletID, TagNumber FROM Piglets WHERE MotherPigID = @MotherPigID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MotherPigID", _motherPigId);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            int pigletId = reader.GetInt32(0);
                            string tagNumber = reader.GetString(1);

                            Button pigletButton = new Button
                            {
                                Text = tagNumber,
                                Tag = pigletId,
                                Width = 110,
                                Height = 50,
                                BackColor = Color.LightPink,
                                FlatStyle = FlatStyle.Flat,
                                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                                Cursor = Cursors.Hand,
                                Margin = new Padding(6)
                            };

                            pigletButton.Click += (s, e) => _onPigletSelected?.Invoke(pigletId);
                            _flpPiglets.Controls.Add(pigletButton);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading piglets: " + ex.Message);
                    }
                }
            }
        }
    }
}
