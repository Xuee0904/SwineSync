using System;
using System.Data.SqlClient;

namespace SwineSyncc.Data
{
    public class PigRepository
    {
        public Pig GetPigById(int pigId)
        {
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Pigs WHERE PigID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", pigId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Pig
                    {
                        PigID = (int)reader["PigID"],
                        TagNumber = reader["TagNumber"].ToString(),
                        Breed = reader["Breed"].ToString(),
                        Sex = reader["Sex"].ToString(),
                        Birthdate = (DateTime)reader["Birthdate"],
                        Weight = Convert.ToInt32(reader["Weight"]),
                        Status = reader["Status"].ToString()
                    };
                }
            }

            return null;
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
