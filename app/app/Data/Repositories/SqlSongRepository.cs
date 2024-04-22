namespace app.src.SqlDataStorageAndRetrival
{
    using System.Collections.Generic;
    using app.Data.SqlCommandHandlers;

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
            this.sqlSongTableCommandExecutor = new SqlSongTableCommandExecutor();
        }

        public List<int> GetAllSongIds()
        {
            return this.sqlSongTableCommandExecutor.GetAllSongIdsInDatabase();
        }

        public List<Song> GetSongsWithIds(List<int> songIds)
        {
            return this.sqlSongTableCommandExecutor.GetSongsWithIds(songIds);
        }
    }
}
