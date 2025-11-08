using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SwineSyncc.Data
{
    public class PigletRepository
    {     
        public Piglet GetPigletById(int pigletId)
        {
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();

                string query = @"SELECT PigletID, MotherPigID, TagNumber, Birthdate, Breed, Sex, Weight, Status
                                 FROM Piglets
                                 WHERE PigletID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", pigletId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Piglet
                        {
                            PigletID = (int)reader["PigletID"],
                            MotherPigID = (int)reader["MotherPigID"],
                            TagNumber = reader["TagNumber"].ToString(),
                            Birthdate = (DateTime)reader["Birthdate"],
                            Breed = reader["Breed"].ToString(),
                            Sex = reader["Sex"].ToString(),
                            Weight = Convert.ToInt32(reader["Weight"]),
                            Status = reader["Status"].ToString()
                        };
                    }
                }
            }

            return null;
        }

        // get all piglets for a mother
        public List<Piglet> GetPigletsByMotherId(int motherId)
        {
            List<Piglet> list = new List<Piglet>();

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();

                string query = @"SELECT PigletID, MotherPigID, TagNumber, Birthdate, Breed, Sex, Weight, Status
                                 FROM Piglets
                                 WHERE MotherPigID = @motherId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@motherId", motherId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Piglet
                        {
                            PigletID = (int)reader["PigletID"],
                            MotherPigID = (int)reader["MotherPigID"],
                            TagNumber = reader["TagNumber"].ToString(),
                            Birthdate = (DateTime)reader["Birthdate"],
                            Breed = reader["Breed"].ToString(),
                            Sex = reader["Sex"].ToString(),
                            Weight = Convert.ToInt32(reader["Weight"]),
                            Status = reader["Status"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        // SAFE DELETE PIGLET        
        public void SafeDeletePiglet(int pigletId)
        {
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();
                //  used a transaction to prevent corrupt data
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // loaded piglet first (inside transaction)
                    string selectQuery = @"SELECT PigletID, MotherPigID, TagNumber, Birthdate, Breed, Sex, Weight, Status
                                           FROM Piglets
                                           WHERE PigletID = @id";

                    SqlCommand selectCmd = new SqlCommand(selectQuery, conn, transaction);
                    selectCmd.Parameters.AddWithValue("@id", pigletId);

                    SqlDataReader reader = selectCmd.ExecuteReader();

                    if (!reader.Read())
                    {
                        reader.Close();
                        transaction.Rollback(); 
                        return;
                    }
                   
                    int PigletID = (int)reader["PigletID"];
                    int MotherPigID = (int)reader["MotherPigID"];
                    string TagNumber = reader["TagNumber"].ToString();
                    DateTime Birthdate = (DateTime)reader["Birthdate"];
                    string Breed = reader["Breed"].ToString();
                    string Sex = reader["Sex"].ToString();
                    int Weight = Convert.ToInt32(reader["Weight"]);
                    string Status = reader["Status"].ToString();

                    reader.Close();
               
                    string insertQuery = @"
                        INSERT INTO DeletedPiglets
                            (PigletID, MotherPigID, TagNumber, Birthdate, Breed, Sex, Weight, Status, DeletedDate)
                        VALUES
                            (@PigletID, @MotherPigID, @TagNumber, @Birthdate, @Breed, @Sex, @Weight, @Status, GETDATE())";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction);

                    insertCmd.Parameters.AddWithValue("@PigletID", PigletID);
                    insertCmd.Parameters.AddWithValue("@MotherPigID", MotherPigID);
                    insertCmd.Parameters.AddWithValue("@TagNumber", TagNumber);
                    insertCmd.Parameters.AddWithValue("@Birthdate", Birthdate);
                    insertCmd.Parameters.AddWithValue("@Breed", Breed);
                    insertCmd.Parameters.AddWithValue("@Sex", Sex);
                    insertCmd.Parameters.AddWithValue("@Weight", Weight);
                    insertCmd.Parameters.AddWithValue("@Status", Status);

                    insertCmd.ExecuteNonQuery();

                    // delete from Piglets
                    string deleteQuery = "DELETE FROM Piglets WHERE PigletID = @id";

                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, transaction);
                    deleteCmd.Parameters.AddWithValue("@id", pigletId);
                    deleteCmd.ExecuteNonQuery();

                    // Commit
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback(); // rollback ensures no partial deletes
                    throw;
                }
            }
        }
    }

    // piglet model
    public class Piglet
    {
        public int PigletID { get; set; }
        public int MotherPigID { get; set; }
        public string TagNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public int Weight { get; set; }
        public string Status { get; set; }
    }
}
