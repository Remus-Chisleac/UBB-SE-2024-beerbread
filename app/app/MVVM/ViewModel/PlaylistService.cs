using app.MVVM.Model.Data.Repositories;
using app.MVVM.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.MVVM.ViewModel
{
    internal class PlaylistService
    {
        private ISqlPlaylistRepository playlistRepository;

        public PlaylistService()
        {
            this.playlistRepository = new SqlPlaylistRepository();
        }

        public List<IPlaylist> GetUserPlaylists(Guid userId)
        {
            return this.playlistRepository.GetUserPlaylists(userId);
        }

        internal void AddPlaylist(IPlaylist playlist, Guid id)
        {
            this.playlistRepository.AddPlaylist(playlist, id);
        }
    }
}
