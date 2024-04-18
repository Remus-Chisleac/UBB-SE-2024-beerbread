using app.src.SqlDataStorageAndRetrival;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.src.mockAPI
{
    public class MockAnalyticsAPI
    {
        private List<int> posibleRecomendedSongs;
        public MockAnalyticsAPI(User user)
        {
            posibleRecomendedSongs = new List<int>();
            SqlSongService sqlSongService = new SqlSongService();
            posibleRecomendedSongs = sqlSongService.GetSongIds();
        }
        public List<int> GetRecomendedSongs(int nrRecomended)
        {
            //get 5 random songs
            List<int> result = new List<int>();
            Random random = new Random();
            for (int i = 0; i < nrRecomended && i < posibleRecomendedSongs.Count; i++)
            {
                result.Add(posibleRecomendedSongs[random.Next(posibleRecomendedSongs.Count)]);
            }
            result.Add(0);
            return result;
        }
    }
}
