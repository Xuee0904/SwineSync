using System;
using System.Data.SqlClient;

namespace SwineSyncc.Data
{
    public class PigRepository
    {
        private readonly string _connectionString;

        public PigRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Pig GetPigById(int pigId)
        {
            Pig pig = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"SELECT PigID, TagNumber, Breed, Sex, Birthdate, Weight, Status 
                                 FROM Pigs WHERE PigID = @PigID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PigID", pigId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    pig = new Pig
                    {
                        PigID = (int)reader["PigID"],
                        TagNumber = reader["TagNumber"].ToString(),
                        Breed = reader["Breed"].ToString(),
                        Sex = reader["Sex"].ToString(),
                        Birthdate = Convert.ToDateTime(reader["Birthdate"]),
                        Weight = reader["Weight"] != DBNull.Value ? Convert.ToInt32(reader["Weight"]) : 0,
                        Status = reader["Status"].ToString()
                    };
                }
            }

            return pig;
        }
    }

    public class Pig
    {
        public int PigID { get; set; }
        public string TagNumber { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public int Weight { get; set; }
        public string Status { get; set; }
    }
}
