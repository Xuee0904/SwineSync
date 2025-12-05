using SwineSyncc.Navigation.HealthRecords;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace SwineSyncc.Data
{
    using SwineSyncc.Models;
    internal class HealthRepository
    {

        public Health GetHealthById(int healthRecordId)
        {
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();

                string query = @"
                SELECT 
                    H.HealthRecordID,
                    H.PigID,
                    H.PigletID,
                    H.CheckupDate,
                    H.Condition,
                    H.Treatment,
                    H.VetName,
                    H.Notes
                FROM HealthRecords AS H
                WHERE H.HealthRecordID = @id;
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", healthRecordId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Health
                            {
                                HealthRecordID = (int)reader["HealthRecordID"],
                                PigID = reader["PigID"] == DBNull.Value ? (int?)null : (int)reader["PigID"],
                                PigletID = reader["PigletID"] == DBNull.Value ? (int?)null : (int)reader["PigletID"],
                                CheckupDate = (DateTime)reader["CheckupDate"],
                                Condition = reader["Condition"].ToString(),
                                Treatment = reader["Treatment"].ToString(),
                                VeterinarianName = reader["VetName"].ToString(),
                                Notes = reader["Notes"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }



        public static void PopulatePigComboBox(ComboBox pigOrPigletMerge)
        {

            string query = @"
            SELECT 
                P.PigID,
                NULL AS PigletID,
                P.Name + ' (' + 
                    CASE 
                        WHEN P.Sex = 'Female' THEN 'Sow'
                        WHEN P.Sex = 'Male' THEN 'Boar'
                        ELSE 'Pig'
                    END + ')' AS DisplayText
            FROM Pigs P

            UNION ALL

            SELECT 
                NULL AS PigID,
                T.PigletID,
                CAST(T.TagNumber AS NVARCHAR(50)) + ' (Mother: ' + M.Name + ')' + ' (Piglet)' AS DisplayText
            FROM Piglets T
            INNER JOIN Pigs M ON T.MotherPigID = M.PigID;
            ";

            pigOrPigletMerge.Items.Clear();
            pigOrPigletMerge.DisplayMember = "DisplayText"; // ensures proper binding

            // Add default item
            pigOrPigletMerge.Items.Add(new PigComboDetails
            {
                PigID = null,
                PigletID = null,
                DisplayText = "-- Select Pig --"
            });

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            var item = new PigComboDetails
                            {
                                PigID = reader["PigID"] is DBNull ? (int?)null : (int)reader["PigID"],
                                PigletID = reader["PigletID"] is DBNull ? (int?)null : (int)reader["PigletID"],
                                DisplayText = reader["DisplayText"].ToString()
                            };

                            pigOrPigletMerge.Items.Add(item);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading pig/piglet data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            pigOrPigletMerge.SelectedIndex = 0; // default to "-- Select Pig --"
        }

    }
    public class Health {
        public int? HealthRecordID { get; set; }
        public int? PigID { get; set; }
        public int? PigletID { get; set; }
        public DateTime CheckupDate { get; set; }
        public string Condition { get; set; }
        public string Treatment { get; set; }
        public string VeterinarianName { get; set; }
        public string Notes { get; set; }
    }

    

}

namespace SwineSyncc.Models{
    public class PigComboDetails
    {
        public int? PigID { get; set; }
        public int? PigletID { get; set; }

        public string DisplayText { get; set; }

        public bool IsAdultPig => PigID.HasValue && !PigletID.HasValue;

        public override string ToString()
        {
            return DisplayText;
        }
    }
}


    
