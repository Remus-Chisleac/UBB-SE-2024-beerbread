namespace app.src.mockAPI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using app.Data.Repositories;

    public class MockAnalyticsAPI
    {
        private List<int> posibleRecomendedSongs;

        public MockAnalyticsAPI(User user)
        {
            this.posibleRecomendedSongs = new List<int>();
            ISqlSongRepository sqlSongService = new SqlSongRepository();
            this.posibleRecomendedSongs = sqlSongService.GetAllSongIds();
        }

        public List<int> GetRecomendedSongs(int nrRecomended)
        {
            // get 5 random songs
            List<int> result = new List<int>();
            Random random = new Random();
            for (int i = 0; i < nrRecomended && i < this.posibleRecomendedSongs.Count; i++)
            {
                result.Add(this.posibleRecomendedSongs[random.Next(this.posibleRecomendedSongs.Count)]);
            }

            result.Add(0);
            return result;
        }
    }
}
