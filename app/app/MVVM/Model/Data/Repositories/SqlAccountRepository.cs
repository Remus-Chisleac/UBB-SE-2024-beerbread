namespace app.MVVM.Model.Data.Repositories
{
    using app.MVVM.Model.Data.SqlCommandHandlers;
    using app.MVVM.Model.Domain;

    public interface ISqlAccountRepository
    {
        public bool AddAccount(Account account);

        public bool AddUserAccount(Account account);

        public Account? GetAccount(string email);
    }

    public class SqlAccountRepository : ISqlAccountRepository
    {
        private ISqlAccountTableCommandExecutor sqlAccountTableCommandExecutor;

        public SqlAccountRepository()
        {
            sqlAccountTableCommandExecutor = new SqlAccountTableCommandExecutor();
        }

        public SqlAccountRepository(ISqlAccountTableCommandExecutor sqlAccountTableCommandExecutor)
        {
            this.sqlAccountTableCommandExecutor = sqlAccountTableCommandExecutor;
        }

        public bool AddAccount(Account account)
        {
            return sqlAccountTableCommandExecutor.ExecuteInsertCommandForAccount(account);
        }

        public bool AddUserAccount(Account account)
        {
            (int databaseId, string guid) = sqlAccountTableCommandExecutor.GetDatabaseIdAndGuidForAccountWithEmail(account.Email);

            if (databaseId == -1)
            {
                return false;
            }

            if (!sqlAccountTableCommandExecutor.ExecuteCreateHistoryLikedBlockedPlaylistsForAccount(databaseId, guid))
            {
                return false;
            }

            if (!sqlAccountTableCommandExecutor.ExecuteCreateUserAccount(databaseId, guid))
            {
                return false;
            }

            return true;
        }

        public Account? GetAccount(string email)
        {
            return sqlAccountTableCommandExecutor.GetAccountWithEmail(email);
        }
    }
}
