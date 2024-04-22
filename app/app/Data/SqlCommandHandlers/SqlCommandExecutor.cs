namespace app.Data.SqlCommandHandlers
{
    using System.Diagnostics;
    using app.Data.ServerHandlers;
    using Microsoft.Data.SqlClient;

    public interface ISqlCommandExecutor
    {
        bool ExecuteNonQueryCommandFromString(string query);
    }

    public class SqlCommandExecutor : ISqlCommandExecutor
    {
        private readonly SqlConnection currentSqlConnection;

        public SqlCommandExecutor()
        {
            this.currentSqlConnection = StaticSqlConnectionGenerator.GetConnection();
        }

        public bool ExecuteNonQueryCommandFromString(string query)
        {
            try
            {
                this.currentSqlConnection.Open();
                SqlCommand command = new SqlCommand(query, this.currentSqlConnection);
                command.ExecuteNonQuery();
                this.currentSqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return false;
            }
        }

    }

}
