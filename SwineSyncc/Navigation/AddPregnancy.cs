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

namespace SwineSyncc.Navigation
{
    public partial class AddPregnancy : UserControl
    {
        public AddPregnancy()
        {
            InitializeComponent();

            LoadComboBreedingID();
            LoadComboPregnantSow();
        }

        private void LoadComboBreedingID()
        {
            string query = "SELECT BreedingID FROM BreedingRecords WHERE Result = 'Success' ORDER BY BreedingID";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboBreedingID.Items.Clear();
                        while (reader.Read())
                        {
                            comboBreedingID.Items.Add(reader["BreedingID"].ToString());
                        }
                    }
                }
            }
        }

        private void LoadComboPregnantSow()
        {
            string query = "SELECT P.Name, B.BreedingID FROM Pigs AS P INNER JOIN BreedingRecords AS B ON P.PigID = B.SowID WHERE B.Result = 'Success';";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboPregnantSow.Items.Clear();
                        while (reader.Read())
                        {
                            comboPregnantSow.Items.Add(reader["Name"].ToString());
                        }
                    }
                }
            }
        }



    }
}
