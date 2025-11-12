using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SwineSyncc.Data
{
    public class UserRepository
    {
        public User GetUserById(int userId)
        {
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();

                string query = @"SELECT UserID, Username, Password, Role 
                                 FROM Users 
                                 WHERE UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3)
                            };
                        }
                    }
                }
            }

            return null;
        }

        public User GetUserByUsername(string username)
        {
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();

                string query = @"SELECT UserID, Username, Password, Role 
                                 FROM Users 
                                 WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3)
                            };
                        }
                    }
                }
            }

            return null;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();
                string query = "SELECT UserID, Username, Role FROM Users";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserID = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Role = reader.GetString(2)
                        });
                    }
                }
            }

            return users;
        }

        public void SafeDeleteUser(int userId)
        {
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1️⃣ Fetch the user to be deleted
                    string selectQuery = @"SELECT UserID, Username, Password, Role 
                                   FROM Users WHERE UserID = @UserID";
                    SqlCommand selectCmd = new SqlCommand(selectQuery, conn, transaction);
                    selectCmd.Parameters.AddWithValue("@UserID", userId);

                    SqlDataReader reader = selectCmd.ExecuteReader();

                    if (!reader.Read())
                    {
                        reader.Close();
                        transaction.Rollback();
                        return;
                    }

                    int id = (int)reader["UserID"];
                    string username = reader["Username"].ToString();
                    string password = reader["Password"].ToString();
                    string role = reader["Role"].ToString();

                    reader.Close();

                    // 2️⃣ Insert into DeletedUsers
                    string insertQuery = @"INSERT INTO DeletedUsers 
                                   (UserID, Username, Password, Role, DeletedDate)
                                   VALUES (@UserID, @Username, @Password, @Role, GETDATE())";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction);
                    insertCmd.Parameters.AddWithValue("@UserID", id);
                    insertCmd.Parameters.AddWithValue("@Username", username);
                    insertCmd.Parameters.AddWithValue("@Password", password);
                    insertCmd.Parameters.AddWithValue("@Role", role);

                    insertCmd.ExecuteNonQuery();

                    // 3️⃣ Delete from Users
                    string deleteQuery = "DELETE FROM Users WHERE UserID = @UserID";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, transaction);
                    deleteCmd.Parameters.AddWithValue("@UserID", userId);
                    deleteCmd.ExecuteNonQuery();

                    // 4️⃣ Commit
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

    }

    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
