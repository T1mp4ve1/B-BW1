using Microsoft.Data.SqlClient;
using System.Data;

namespace B_BW1.Data
{
    public static class DbHelper
    {
        private static string _connectionString = "";

        public static void SetConnectionString(string conn)
        {
            _connectionString = conn;
        }

        public static DataTable GetTable(string query)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);

            var dt = new DataTable();
            conn.Open();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
    }
}
