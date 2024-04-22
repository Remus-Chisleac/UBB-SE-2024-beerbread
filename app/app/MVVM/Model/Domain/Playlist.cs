using app.MVVM.Model.Data.Repositories;

namespace app.MVVM.Model.Domain
{
    public interface IPlaylist : IGenericSongRepo
    {
        bool IsPrivate { get; set; }

        string ImagePath { get; set; }

        bool EmptyPlaylist();
    }

    public class Playlist : GenericSongRepo, IPlaylist
    {
        public bool IsPrivate { get; set; }

        public string ImagePath { get; set; }

        public Playlist(int id, int owner, string name, bool isPrivate = false, string imagePath = "")
            : base(owner, id, name)
        {
            IsPrivate = isPrivate;
            ImagePath = imagePath;
        }

        public bool EmptyPlaylist()
        {
            return Songs.Count == 0;
        }
    }


}
