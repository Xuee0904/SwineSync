using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SwineSyncc.Data;

namespace SwineSyncc.DynamicButtonLoader
{
    public class UserLoader
    {
        private readonly FlowLayoutPanel _flpAdmin;
        private readonly FlowLayoutPanel _flpAssistant;
        private readonly Action<int> _onUserSelected;

        public UserLoader(FlowLayoutPanel flpAdmin, FlowLayoutPanel flpAssistant, Action<int> onUserSelected)
        {
            _flpAdmin = flpAdmin;
            _flpAssistant = flpAssistant;
            _onUserSelected = onUserSelected;
        }

        public void LoadUsers()
        {
            _flpAdmin.Controls.Clear();
            _flpAssistant.Controls.Clear();

            _flpAdmin.Enabled = true;
            _flpAssistant.Enabled = true;

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();
                string query = "SELECT UserID, Username, Role FROM Users";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string username = reader.GetString(1);
                        string role = reader.GetString(2);

                        Button btn = new Button
                        {
                            Text = $"{username}\n({role})",
                            Width = 120,
                            Height = 120,
                            Margin = new Padding(10),
                            Tag = id,
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                            Image = Properties.Resources.UserIcon,
                            ImageAlign = ContentAlignment.MiddleCenter,
                            TextImageRelation = TextImageRelation.ImageAboveText,
                            BackColor = Color.White,
                            ForeColor = Color.Black,
                            FlatStyle = FlatStyle.Standard
                        };

                        btn.Click += (s, e) =>
                        {
                            _onUserSelected?.Invoke(id);
                        };

                        btn.BringToFront();

                        if (role == "Admin")
                            _flpAdmin.Controls.Add(btn);
                        else
                            _flpAssistant.Controls.Add(btn);
                    }
                }
            }
        }
    }
}
