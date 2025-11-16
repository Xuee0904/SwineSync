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
        
        private readonly FlowLayoutPanel _femalePanel;
        private readonly FlowLayoutPanel _malePanel;

        private readonly Action<int> _onPigClicked;
        
        public PigLoader(FlowLayoutPanel femalePanel, FlowLayoutPanel malePanel, Action<int> onPigClicked = null)
        {
            _femalePanel = femalePanel;
            _malePanel = malePanel;
            _onPigClicked = onPigClicked;
        }

        public void LoadPigs(bool isDeleteMode = false, List<int> selectedPigIds = null)
        {           
            _femalePanel.Controls.Clear();
            _malePanel.Controls.Clear();

            if (selectedPigIds == null)
                selectedPigIds = new List<int>();

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();

                string query = "SELECT PigID, Name, Sex FROM Pigs"; 
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int pigId = Convert.ToInt32(reader["PigID"]);
                        string pigName = reader["Name"].ToString();
                        string sex = reader["Sex"].ToString();


                        Color defaultColor = sex.Equals("Female", StringComparison.OrdinalIgnoreCase)
                           ? Color.FromArgb(210, 140, 70)
                           : Color.FromArgb(180, 110, 50);

                        Color buttonColor = selectedPigIds.Contains(pigId) ? Color.Red : defaultColor;

                        Button pigButton = new Button
                        {
                            Text = pigName,
                            Width = 90,  
                            Height = 90,  
                            Tag = pigId,
                            Margin = new Padding(10),
                            BackColor = buttonColor,
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),                           
                            Image = Properties.Resources.PigIcon,
                            ImageAlign = ContentAlignment.MiddleCenter,
                            TextImageRelation = TextImageRelation.ImageAboveText,                          
                            TextAlign = ContentAlignment.BottomCenter
                        };

                        pigButton.Click += (s, e) =>
                        {
                            if (isDeleteMode)
                            {
                                if (selectedPigIds.Contains(pigId))
                                {
                                    selectedPigIds.Remove(pigId);
                                    pigButton.BackColor = defaultColor;
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
                     
                        if (sex.Equals("Female", StringComparison.OrdinalIgnoreCase))
                            _femalePanel.Controls.Add(pigButton);
                        else
                            _malePanel.Controls.Add(pigButton);
                    }
                }
            }
        }
    }
}
