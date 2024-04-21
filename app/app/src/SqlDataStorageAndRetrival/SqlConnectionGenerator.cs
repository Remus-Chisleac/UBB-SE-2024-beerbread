using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.src.SqlDataStorageAndRetrival
{
    internal class SqlConnectionGenerator
    {
        private static string ip = "188.24.47.96";
        private static string port = "1433";
        private static string database = "ISS_beerbread";
        private static string user = "ISS";
        private static string password = "iss";
        private static string otherConfig = "TrustServerCertificate=True;MultiSubnetFailover=True";
        private static Microsoft.Data.SqlClient.SqlConnection? sqlConnection;

        public static Microsoft.Data.SqlClient.SqlConnection GetConnection()
        {
            string connectionString = GetConnectionString();
            if (sqlConnection == null)
            {
                sqlConnection = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
                // Alex: these lines worked on my computer to get the connection ready. They may or may not solve the connection problems on your computer.
                sqlConnection.Open();
                sqlConnection.Close();
            }
            return sqlConnection;

        }
        public static string GetConnectionString()
        {
            return "Server=" + ip + "," + port + ";Database=" + database + ";User Id=" + user + ";Password=" + password + ";" + otherConfig;
        }
    }
}
