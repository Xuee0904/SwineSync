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

namespace SwineSyncc.Navigation
{
    public partial class AddHealthRec : UserControl
    {
        public AddHealthRec()
        {
            InitializeComponent();

            PopulatePigComboBox();
        }

        private void PopulatePigComboBox()
        {
            string query = @"SELECT Name, 
            CASE 
                WHEN Sex = 'Female' THEN 'Sow'
                WHEN Sex = 'Male' THEN 'Boar'
                ELSE 'Pig'
            END AS Type FROM Pigs

            UNION ALL

            SELECT 
                CAST(P.TagNumber AS NVARCHAR(50)) + ' (Mother: ' + M.Name + ')' AS Name, 
                'Piglet' AS Type
            FROM Piglets P
            INNER JOIN Pigs M ON P.MotherPigID = M.PigID;";

            var comboBox = comboHealthPigName;

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        comboBox.Items.Clear();

                        while (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            string type = reader["Type"].ToString();

                            comboBox.Items.Add($"{name} ({type})");
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

        private void savebtn_Click(object sender, EventArgs e)
        {

        }

    }
}
