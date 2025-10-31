using System;
using System.Data.SqlClient;

namespace SwineSyncc.Data
{
    public sealed class DBConnection
    {
        private static readonly Lazy<DBConnection> _instance =
            new Lazy<DBConnection>(() => new DBConnection());

        private readonly string _connectionString =
            //ADRIAN SERVER
            //"Data Source=LAPTOP-SFLC0K1H\\SQLEXPRESS;Initial Catalog=SwineSync;Integrated Security=True;";

            //CEDRIC SERVER
            "Data Source=DESKTOP-2ARRBJ3\\SQLEXPRESS;Initial Catalog=SwineSync;Integrated Security=True;";

            //RUSSEL SERVER
            //"Data Source=LAPTOP-VBK2CP8T\\SQLEXPRESS01;Initial Catalog=SwineSync;Integrated Security=True;";


        private DBConnection() { }
       
        public static DBConnection Instance => _instance.Value;
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
