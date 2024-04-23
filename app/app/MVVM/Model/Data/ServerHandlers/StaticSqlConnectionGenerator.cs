namespace app.MVVM.Model.Data.ServerHandlers
{
    using Microsoft.Data.SqlClient;
    public class StaticSqlConnectionGenerator
    {
        private static string ip = "188.24.47.96";
        private static string port = "1433";
        private static string database = "ISS_beerbread";
        private static string user = "ISS";
        private static string password = "iss";
        private static string otherConfig = "TrustServerCertificate=True;MultiSubnetFailover=True";
        private static SqlConnection? sqlConnection;

        public static SqlConnection GetConnection()
        {
            string connectionString = GetConnectionString();
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection(connectionString);
                // Alex: these lines worked on my computer to get the connection ready. They may or may not solve the connection problems on your computer.
                sqlConnection.Open();
                sqlConnection.Close();
            }
            return sqlConnection;

        }
        public static string GetConnectionString()
        {
            //return "Server=" + ip + "," + port + ";Database=" + database + ";User Id=" + user + ";Password=" + password + ";" + otherConfig;
            return "Data Source=DESKTOP-3O5NAR2\\SQLEXPRESS;Initial Catalog=breadcrumbwhatever;Persist Security Info=True;User ID=sa;Password=iss;Trust Server Certificate=True";
        }
    }
}
