

namespace app.src.SqlDataStorageAndRetrival
{
    using app.Data.SqlCommandHandlers;

    public class SqlAccountRepository
    {
        private ISqlAccountTableCommandExecutor sqlAccountTableCommandExecutor;

        public SqlAccountRepository()
        {
            this.sqlAccountTableCommandExecutor = new SqlAccountTableCommandExecutor();
        }

        public SqlAccountRepository(ISqlAccountTableCommandExecutor sqlAccountTableCommandExecutor)
        {
            this.sqlAccountTableCommandExecutor = sqlAccountTableCommandExecutor;
        }

        public bool AddAccount(Account account)
        {
            return this.sqlAccountTableCommandExecutor.ExecuteInsertCommandForAccount(account);
        }

        public bool AddUserAccount(Account account)
        {
            (int databaseId, string guid) = this.sqlAccountTableCommandExecutor.GetDatabaseIdAndGuidForAccountWithEmail(account.Email);

            if (databaseId == -1)
            {
                return false;
            }

            if (!this.sqlAccountTableCommandExecutor.ExecuteCreateHistoryLikedBlockedPlaylistsForAccount(databaseId, guid))
            {
                return false;
            }

            if (!this.sqlAccountTableCommandExecutor.ExecuteCreateUserAccount(databaseId, guid))
            {
                return false;
            }

            return true;
        }

        public Account? GetAccount(string email)
        {
            return this.sqlAccountTableCommandExecutor.GetAccountWithEmail(email);
        }
    }
}
