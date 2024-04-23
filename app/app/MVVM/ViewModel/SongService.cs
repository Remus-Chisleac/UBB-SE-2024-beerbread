using app.MVVM.Model.Data.Repositories;
using app.MVVM.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.MVVM.ViewModel
{
    public class SongService
    {
        private ISqlSongRepository songRepository;

        public SongService()
        {
            this.songRepository = new SqlSongRepository();
        }

        // New constructor to allow injection of ISqlSongRepository
        public SongService(ISqlSongRepository repository)
        {
            this.songRepository = repository;
        }

        public List<Song> GetSongsWithIds(List<int> ids)
        {
            return this.songRepository.GetSongsWithIds(ids);
        }

    }
}
