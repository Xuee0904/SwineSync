using System;
using System.Data;
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
      
        public static DataTable GetLogsByUser(int userId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                string sql = @"SELECT LogID, Action, Description, DateTime
                               FROM ActivityLog
                               WHERE UserID = @UserID
                               ORDER BY DateTime DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }
    }
}
