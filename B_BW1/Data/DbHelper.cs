using Microsoft.Data.SqlClient;
using System.Data;

namespace B_BW1.Data
{
    public static class DbHelper
    {
        private static string _connectionString =
            "Server=T1MP4VE1\\SQLEXPRESS;User Id=sa;Password=7210;Database=B_BW3;TrustServerCertificate=True;";

        // Imposta la connection string (utile se cambia in appsettings.json)
        public static void SetConnectionString(string conn)
        {
            _connectionString = conn;
        }

        // SELECT → ritorna un DataTable
        public static DataTable GetTable(string query, params SqlParameter[] parameters)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            var dt = new DataTable();
            conn.Open();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        // INSERT, UPDATE, DELETE
        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        // SELECT di un singolo valore
        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            conn.Open();
            return cmd.ExecuteScalar();
        }
    }
}
