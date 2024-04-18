using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{

    public class Playlist : GenericSongRepo
    {
        public bool isPrivate { get; set; }
        public string imagePath { get; set; }
        public Playlist(int id, int owner, string name, bool isPrivate = false, string imagePath = "") : base(owner, id, name)
        {
            this.isPrivate = isPrivate;
            this.imagePath = imagePath;
        }
        public bool emptyPlaylist()
        {
            return songs.Count == 0;
        }
    }


}
