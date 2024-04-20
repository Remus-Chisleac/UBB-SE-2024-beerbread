using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{

    public class Playlist : GenericSongRepo,Interfaces.IPlaylist
    {
        public bool IsPrivate { get; set; }
        public string ImagePath { get; set; }
        public Playlist(int id, int owner, string name, bool isPrivate = false, string imagePath = "") : base(owner, id, name)
        {
            this.IsPrivate = isPrivate;
            this.ImagePath = imagePath;
        }
        public bool EmptyPlaylist()
        {
            return Songs.Count == 0;
        }
    }


}
