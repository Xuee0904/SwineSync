using SwineSyncc.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SwineSyncc.Navigation.Pig_Management.AddPiglet;

namespace SwineSyncc.Navigation.Pig_Management
{
    public partial class AddBreeding : UserControl
    {

        public event EventHandler SaveCompleted;
        public event EventHandler CancelClicked;

        public AddBreeding()
        {
            InitializeComponent();

            LoadBoarNameCombo();
            LoadSowNameCombo();
        }
        public class SowName
        {
            public int PigID { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public class BoarName
        {
            public int PigID { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private void LoadSowNameCombo()
        {
            string query = "SELECT PigID, Name FROM Pigs WHERE Sex = 'Female' ORDER BY Name";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        comboSow.Items.Clear();

                        while (reader.Read())
                        {
                            comboSow.Items.Add(new MotherPig
                            {
                                PigID = reader.GetInt32(reader.GetOrdinal("PigID")),
                                Name = reader["Name"].ToString()
                            });
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error laoding data: " + ex.Message);
                    }
                }
            }
        }

        private void LoadBoarNameCombo()
        {
            string query = "SELECT PigID, Name FROM Pigs WHERE Sex = 'Male' ORDER BY Name";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        comboBoar.Items.Clear();

                        while (reader.Read())
                        {
                            comboBoar.Items.Add(new MotherPig
                            {
                                PigID = reader.GetInt32(reader.GetOrdinal("PigID")),
                                Name = reader["Name"].ToString()
                            });
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error laoding data: " + ex.Message);
                    }
                }
            }
        }

        private void ClearFields()
        {
            comboSow.SelectedIndex = -1;
            comboBoar.SelectedIndex = -1;
            dtBreeding.Value = DateTime.Now;
            comboMethod.SelectedIndex = -1;
            comboResult.SelectedIndex = -1;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {

        }
    }
}
