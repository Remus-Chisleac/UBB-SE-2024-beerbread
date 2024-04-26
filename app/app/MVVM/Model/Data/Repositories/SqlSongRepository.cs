namespace app.MVVM.Model.Data.Repositories
{
    using System.Collections.Generic;
    using app.MVVM.Model.Data.SqlCommandHandlers;
    using app.MVVM.Model.Domain;

    public interface ISqlSongRepository
    {
        List<int> GetAllSongIds();

        List<Song> GetSongsWithIds(List<int> songIds);
    }

    public class SqlSongRepository : ISqlSongRepository
    {
        private ISqlSongTableCommandExecutor sqlSongTableCommandExecutor;

        public SqlSongRepository()
        {
            sqlSongTableCommandExecutor = new SqlSongTableCommandExecutor();
        }

        public List<int> GetAllSongIds()
        {
            return sqlSongTableCommandExecutor.GetAllSongIdsInDatabase();
        }

        public List<Song> GetSongsWithIds(List<int> songIds)
        {
            return sqlSongTableCommandExecutor.GetSongsWithIds(songIds);
        }
    }
}
