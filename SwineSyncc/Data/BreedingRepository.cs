using SwineSyncc.Navigation.Pig_Management;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using static SwineSyncc.Navigation.Pig_Management.AddBreeding;

namespace SwineSyncc.Data
{
    public class BreedingRepository
    {
        public Breeding GetBreedingById(int breedingId)
        {
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();

                string query;
                query = @"SELECT B.BreedingID, B.SowID, B.BoarID, Sow.Name AS SowName,
                                CASE
                                    WHEN B.BreedingMethod = 'Artificial Insemination' THEN NULL
                                    ELSE Boar.Name
                                END AS BoarName, B.BreedingMethod, B.BreedingDate, B.Result
                                FROM BreedingRecords AS B
                                LEFT JOIN Pigs AS Sow ON B.SowID = Sow.PigID
                                LEFT JOIN Pigs AS Boar ON B.BoarID = Boar.PigID
                                WHERE B.BreedingID = @id;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", breedingId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Breeding
                        {
                            BreedingID = (int)reader["BreedingID"],
                            SowID = (int)reader["SowID"],
                            BoarID = reader["BoarID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["BoarID"]),

                            SowName = reader["SowName"].ToString(),

                            BoarName = reader["BoarName"] == DBNull.Value ? null : reader["BoarName"].ToString(),

                            BreedingMethod = reader["BreedingMethod"].ToString(),
                            BreedingDate = (DateTime)reader["BreedingDate"],
                            Result = reader["Result"].ToString()
                        };
                    }
                }
            }

            return null;
        }
    }


    public class Breeding
    {
        public int BreedingID { get; set; }
        public int SowID { get; set; }
        public int? BoarID { get; set; }
        public string SowName { get; set; }
        public string BoarName { get; set; }
        public string BreedingMethod { get; set; }
        public DateTime BreedingDate { get; set; }
        public string Result { get; set; }
    }
}
