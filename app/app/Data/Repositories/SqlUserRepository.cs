namespace app.Data.Repositories
{
    using System.Collections.Generic;
    using app.Data.SqlCommandHandlers;
    using app.Interfaces;

    public interface ISqlUserRepository
    {
        public List<IPlaylist> GetPlaylists(int id);
    }

    public class SqlUserRepository : ISqlUserRepository
    {
        private readonly ISqlUserTableCommandExecutor sqlUserTableCommandExecutor;

        public SqlUserRepository()
        {
            this.sqlUserTableCommandExecutor = new SqlUserTableCommandExecutor();
        }

        public SqlUserRepository(ISqlUserTableCommandExecutor sqlUserTableCommandExecutor)
        {
            this.sqlUserTableCommandExecutor = sqlUserTableCommandExecutor;
        }

        public List<IPlaylist> GetPlaylists(int id)
        {
            List<IPlaylist> playlists = [];

            IPlaylist? historyPlaylist = this.sqlUserTableCommandExecutor.GetHistoryPlaylistForUserWithId(id);

            if (historyPlaylist != null)
            {
                playlists.Add(historyPlaylist);
            }

            IPlaylist? blockedPlaylist = this.sqlUserTableCommandExecutor.GetBlockedPlaylistForUserWithId(id);

            if (blockedPlaylist != null)
            {
                playlists.Add(blockedPlaylist);
            }

            IPlaylist? likedPlaylist = this.sqlUserTableCommandExecutor.GetLikedPlaylistForUserWithId(id);

            if (likedPlaylist != null)
            {
                playlists.Add(likedPlaylist);
            }

            if (historyPlaylist != null && blockedPlaylist != null && likedPlaylist != null)
            {
                foreach (IPlaylist playlist in this.sqlUserTableCommandExecutor.GetUserDefinedPlaylistsForUserWithId(id, historyPlaylist.Id, likedPlaylist.Id, blockedPlaylist.Id))
                {
                    playlists.Add(playlist);
                }
            }


            return playlists;
        }
    }
}
