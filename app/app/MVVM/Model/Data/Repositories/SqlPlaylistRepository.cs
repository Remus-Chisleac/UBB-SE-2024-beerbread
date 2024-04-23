namespace app.MVVM.Model.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using app.MVVM.Model.Data.SqlCommandHandlers;
    using app.MVVM.Model.Domain;

    public interface ISqlPlaylistRepository
    {
        List<IPlaylist> GetUserPlaylists(Guid userGuid);

        bool AddPlaylist(IPlaylist playlist, Guid userGuid);

    }

    public class SqlPlaylistRepository : ISqlPlaylistRepository
    {
        private readonly ISqlPlaylistTableCommandExecutor sqlPlaylistTableCommandExecutor;

        public SqlPlaylistRepository()
        {
            sqlPlaylistTableCommandExecutor = new SqlPlaylistTableCommandExecutor();
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
