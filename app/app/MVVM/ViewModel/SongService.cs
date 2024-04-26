using app.MVVM.Model.Data.Repositories;
using app.MVVM.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.MVVM.ViewModel
{
    internal class SongService
    {
        private ISqlSongRepository songRepository;

        public SongService()
        {
            this.songRepository = new SqlSongRepository();
        }

        public List<Song> GetSongsWithIds(List<int> ids)
        {
            return this.songRepository.GetSongsWithIds(ids);
        }

    }
}
