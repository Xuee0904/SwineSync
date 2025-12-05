using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineSyncc.Data
{
    internal class PregnancyRepository
    {
        public Pregnancy GetPregnancyById(int breedingId)
        {
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();

                string query;
                query = @"SELECT P.PregnancyID, P.PregnantPigID, Psow.Name AS PregnantPigName, P.BreedingID, P.ConfirmationDate, P.ExpectedFarrowingDate
                                FROM PregnancyRecords AS P
                                LEFT JOIN Pigs AS Psow ON P.PregnantPigID = Psow.PigID
                                WHERE P.PregnancyID = @id;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", breedingId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Pregnancy
                        {
                            PregnancyID = (int)reader["PregnancyID"],
                            PregnantPigID = (int)reader["PregnantPigID"],
                            PregnantPigName = reader["PregnantPigName"].ToString(),
                            BreedingID = (int)reader["BreedingID"],
                            ConfirmationDate = (DateTime)reader["ConfirmationDate"],
                            ExpectedFarrowingDate = (DateTime)reader["ExpectedFarrowingDate"]
                        };
                    }
                }
            }

            return null;
        }
    }
    public class Pregnancy
    {
        public int PregnancyID { get; set; }
        public int PregnantPigID { get; set; }

        public string PregnantPigName { get; set; }
        public int BreedingID { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public DateTime ExpectedFarrowingDate { get; set; }
    }
}
