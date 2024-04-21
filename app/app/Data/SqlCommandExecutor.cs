namespace app.Data
{
    using Microsoft.Data.SqlClient;

    public class SqlCommandExecutor
    {
        private readonly SqlConnection currentSqlConnection;

        public SqlCommandExecutor()
        {
            this.currentSqlConnection = SqlConnectionGenerator.GetConnection();
        }

        public bool ExecuteNonQueryCommandFromString(string query)
        {
            try
            {
                this.currentSqlConnection.Open();
                SqlCommand command = new SqlCommand(query, this.currentSqlConnection);
                command.ExecuteNonQuery();
                this.currentSqlConnection.Close();
            }
            return false;
        }
    }
}
