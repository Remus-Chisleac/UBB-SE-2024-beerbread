namespace app.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using app.Data.SqlCommandHandlers;
    using app.Interfaces;

    public interface ISqlPlaylistRepository
    {
        List<IPlaylist> GetUserPlaylists(Guid userGuid);

        bool AddPlaylist(IPlaylist playlist, Guid userGuid);

    }

    internal class SqlPlaylistRepository : ISqlPlaylistRepository
    {
        private readonly ISqlPlaylistTableCommandExecutor sqlPlaylistTableCommandExecutor;

        public SqlPlaylistRepository()
        {
            this.sqlPlaylistTableCommandExecutor = new SqlPlaylistTableCommandExecutor();
        }

        public SqlPlaylistRepository(ISqlPlaylistTableCommandExecutor sqlPlaylistTableCommandExecutor)
        {
            this.sqlPlaylistTableCommandExecutor = sqlPlaylistTableCommandExecutor;
        }

        public List<IPlaylist> GetUserPlaylists(Guid userGuid)
        {
            List<IPlaylist> userPlaylists = sqlPlaylistTableCommandExecutor.GetUserPlaylistIdsWithGuid(userGuid);
            foreach (IPlaylist playlist in userPlaylists)
            {
                string topSongImagePath = sqlPlaylistTableCommandExecutor.GetImagePathForTopSongInPlaylistWithId(playlist.Id);
                playlist.ImagePath = topSongImagePath;
            }

            return userPlaylists;
        }

        public bool AddPlaylist(IPlaylist playlist, Guid userGuid)
        {
            return sqlPlaylistTableCommandExecutor.ExecuteInsertPlaylistNonQueryCommand(userGuid.ToString(), playlist.Name, playlist.IsPrivate ? 1 : 0);
        }
    }
}
