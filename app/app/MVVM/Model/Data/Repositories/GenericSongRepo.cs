namespace app.MVVM.Model.Data.Repositories
{
    public interface IGenericSongRepo
    {
        List<int> Songs { get; set; }

        int Id { get; }

        string Name { get; }

        int Owner { get; }

        bool AddSong(int songId);

        bool RemoveSong(int songId);

        int GetSongsNumber();
    }

    public class GenericSongRepo : IGenericSongRepo
    {
        public List<int> Songs { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Owner { get; }

        public GenericSongRepo(int owner, int id, string name)
        {
            Owner = owner;
            Id = id;
            Name = name;
            Songs = new List<int>();
        }

        public bool AddSong(int songId)
        {
            if (Songs.Contains(songId))
            {
                return false;
            }

            Songs.Add(songId);
            return true;
        }

        public bool RemoveSong(int songId)
        {
            return Songs.Remove(songId);
        }

        public int GetSongsNumber()
        {
            return Songs.Count;
        }
    }
}