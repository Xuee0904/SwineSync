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
                        Name = reader["Name"].ToString(),
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

        public void SafeDeletePig(int pigId)
        {
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();
                string selectQuery = "SELECT PigID, Name, Breed, Sex, Birthdate, Weight, Status FROM Pigs WHERE PigID = @id";
                SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                selectCmd.Parameters.AddWithValue("@id", pigId);

                SqlDataReader reader = selectCmd.ExecuteReader();

                if (reader.Read())
                {
                    int PigID = (int)reader["PigID"];
                    string Name = reader["Name"].ToString();
                    string Breed = reader["Breed"].ToString();
                    string Sex = reader["Sex"].ToString();
                    DateTime Birthdate = Convert.ToDateTime(reader["Birthdate"]);
                    int Weight = Convert.ToInt32(reader["Weight"]);
                    string Status = reader["Status"].ToString();

                    reader.Close();

                    string insertQuery = @"
                        INSERT INTO DeletedPigs (PigID, Name, Breed, Sex, Birthdate, Weight, Status)
                        VALUES (@PigID, @Name, @Breed, @Sex, @Birthdate, @Weight, @Status)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@PigID", PigID);
                    insertCmd.Parameters.AddWithValue("@Name", Name);
                    insertCmd.Parameters.AddWithValue("@Breed", Breed);
                    insertCmd.Parameters.AddWithValue("@Sex", Sex);
                    insertCmd.Parameters.AddWithValue("@Birthdate", Birthdate);
                    insertCmd.Parameters.AddWithValue("@Weight", Weight);
                    insertCmd.Parameters.AddWithValue("@Status", Status);
                    insertCmd.ExecuteNonQuery();

                    string deleteQuery = "DELETE FROM Pigs WHERE PigID = @id";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                    deleteCmd.Parameters.AddWithValue("@id", pigId);
                    deleteCmd.ExecuteNonQuery();
                }
                else
                {
                    reader.Close();
                }
            }
        }
    }

    public class Pig
    {
        public int PigID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public int Weight { get; set; }
        public string Status { get; set; }
    }
}
