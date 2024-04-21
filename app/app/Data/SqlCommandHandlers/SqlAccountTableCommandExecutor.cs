namespace app.Data.SqlCommandHandlers
{
    using System.Data;
    using System.Diagnostics;
    using app;
    using app.Data.ServerHandlers;
    using Microsoft.Data.SqlClient;

    public interface ISqlAccountTableCommandExecutor
    {
        bool ExecuteNonQueryCommandFromString(string query);

        bool ExecuteInsertCommandForAccount(Account account);

        (int id, string guid) GetDatabaseIdAndGuidForAccountWithEmail(string email);

        bool ExecuteCreateHistoryLikedBlockedPlaylistsForAccount(int id, string guid);

        bool ExecuteCreateUserAccount(int id, string guid);

        Account? GetAccountWithEmail(string email);
    }

    internal class SqlAccountTableCommandExecutor : ISqlAccountTableCommandExecutor
    {
        private readonly SqlConnection currentSqlConnection;

        public SqlAccountTableCommandExecutor()
        {
            this.currentSqlConnection = StaticSqlConnectionGenerator.GetConnection();
        }

        public (int id, string guid) GetDatabaseIdAndGuidForAccountWithEmail(string email)
        {
            string get_AccountIdGuid_Query = "SELECT id,guid FROM accounts WHERE email = '" + email + "'";
            try
            {
                this.currentSqlConnection.Open();

                SqlCommand command = new (get_AccountIdGuid_Query, this.currentSqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                int id = reader.GetInt32(0);
                string guid = reader.GetGuid(1).ToString();
                reader.Close();
                this.currentSqlConnection.Close();
                return (id, guid);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return (-1, "none");
            }

        }

        public bool ExecuteInsertCommandForAccount(Account account)
        {
            string insertQuery = "INSERT INTO accounts (guid, email, username, salt, hashedPassword) " +
                "VALUES ('" + account.Id +
                "', '" + account.Email +
                "', '" + account.Username +
                "', '" + account.Salt +
                "', '" + account.GetHashedPassword() + "')";

            return this.ExecuteNonQueryCommandFromString(insertQuery);
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

        public bool ExecuteCreateHistoryLikedBlockedPlaylistsForAccount(int id, string guid)
        {
            string create_HistoryPlaylist_Query = "INSERT INTO playlists (name, isPrivate, owner) " +
               "VALUES ('" + guid + "_History', 1, " + id + ")";
            string create_LikedPlaylist_Query = "INSERT INTO playlists (name, isPrivate, owner) " +
                "VALUES ('" + guid + "_Liked', 1, " + id + ")";
            string create_BlockedPlaylist_Query = "INSERT INTO playlists (name, isPrivate, owner) " +
                "VALUES ('" + guid + "_Blocked', 1, " + id + ")";

            if (!this.ExecuteNonQueryCommandFromString(create_HistoryPlaylist_Query))
            {
                return false;
            }

            if (!this.ExecuteNonQueryCommandFromString(create_LikedPlaylist_Query))
            {
                return false;
            }

            if (!this.ExecuteNonQueryCommandFromString(create_BlockedPlaylist_Query))
            {
                return false;
            }

            return true;
        }

        public bool ExecuteCreateUserAccount(int id, string guid)
        {
            string create_UserAccount_Query = "INSERT INTO users (id, historyPlaylist, likedPlaylist, blockedplaylist) " +
                "VALUES (" + id + ", " +
                "(SELECT id FROM playlists WHERE name = '" + guid + "_History'), " +
                "(SELECT id FROM playlists WHERE name = '" + guid + "_Liked'), " +
                "(SELECT id FROM playlists WHERE name = '" + guid + "_Blocked'))";

            return this.ExecuteNonQueryCommandFromString(create_UserAccount_Query);
        }

        public Account? GetAccountWithEmail(string email)
        {
            string selectQuery = "SELECT guid, username, salt, hashedPassword FROM accounts WHERE email = '" + email + "'";
            try
            {
                this.currentSqlConnection.Open();
                SqlCommand command = new SqlCommand(selectQuery, this.currentSqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Account temp = new Account(reader.GetGuid("guid"), email, reader.GetString("username"), reader.GetString("salt"), reader.GetString("hashedPassword"));
                    this.currentSqlConnection.Close();
                    return temp;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }

            return null;
        }
    }
}
