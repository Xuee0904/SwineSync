using System;
using System.Collections.Generic;   
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SwineSyncc.Data;

namespace SwineSyncc.DynamicButtonLoader
{
    public class PigletLoader
    {
        private readonly FlowLayoutPanel _flpPiglets;
        private readonly int _motherPigId;
        private readonly Action<int> _onPigletSelected;

        public PigletLoader(FlowLayoutPanel flpPiglets, int motherPigId, Action<int> onPigletSelected = null)
        {
            _flpPiglets = flpPiglets;
            _motherPigId = motherPigId;
            _onPigletSelected = onPigletSelected;
        }
      
        public void LoadPiglets(bool isDeleteMode = false, List<int> selectedIds = null)
        {
            _flpPiglets.Controls.Clear();
          
            if (selectedIds == null)
            {
                selectedIds = new List<int>();
            }

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                string query =
                    "SELECT PigletID, TagNumber FROM Piglets WHERE MotherPigID = @MotherPigID";

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
                          
                            Color normalColor = Color.LightPink;
                            Color selectedColor = Color.Red;
                          
                            Button pigletButton = new Button
                            {
                                Text = tagNumber,
                                Tag = pigletId,
                                Width = 110,
                                Height = 50,
                                Margin = new Padding(6),
                                BackColor = selectedIds.Contains(pigletId)
                                            ? selectedColor
                                            : normalColor,
                                FlatStyle = FlatStyle.Flat,
                                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                                Cursor = Cursors.Hand
                            };

                            pigletButton.Click += (s, e) =>
                            {
                                if (isDeleteMode)
                                {                                 
                                    if (selectedIds.Contains(pigletId))
                                    {
                                        selectedIds.Remove(pigletId);
                                        pigletButton.BackColor = normalColor;
                                    }
                                    else
                                    {
                                        selectedIds.Add(pigletId);
                                        pigletButton.BackColor = selectedColor;
                                    }
                                }
                                else
                                {                                   
                                    _onPigletSelected?.Invoke(pigletId);
                                }
                            };

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
