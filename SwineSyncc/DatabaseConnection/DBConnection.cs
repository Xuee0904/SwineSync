using System;
using System.Data.SqlClient;

namespace SwineSyncc.Data
{
    public sealed class DBConnection
    {
        // singleton instance
        private static readonly Lazy<DBConnection> InstanceHolder =
            new Lazy<DBConnection>(() => new DBConnection());
       
        private readonly string connectionString =
            // ADRIAN SERVER
            //"Data Source=LAPTOP-SFLC0K1H\\SQLEXPRESS;Initial Catalog=SwineSyncDB;Integrated Security=True;";

            // CEDRIC SERVER
            //"Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=SwineSync;Integrated Security=True;";

        // RUSSEL SERVER
        "Data Source=LAPTOP-VBK2CP8T\\SQLEXPRESS01;Initial Catalog=SwineSync;Integrated Security=True;";

        private DBConnection()
        {
        }

        // public access to singleton instance
        public static DBConnection Instance => InstanceHolder.Value;
       
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
