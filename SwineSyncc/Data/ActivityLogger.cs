using System;
using System.Data.SqlClient;
using SwineSyncc.Login;

namespace SwineSyncc.Data
{
    public static class ActivityLogger
    {
        public static void Log(string action, string description)
        {
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                string query = @"INSERT INTO ActivityLog (UserID, Action, Description, DateTime)
                                 VALUES (@UserID, @Action, @Description, @DateTime)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", Session.UserID);
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
