using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    
    internal class Playlist : GenericSongRepo
    {
        public bool isPublic { get; set; }
        public Playlist(int id, string name) : base(id, name)
        {
            isPublic = false; // By default, a playlist is private
        }
        public bool emptyPlaylist()
        {
            return songs.Count == 0;
        }
    }
    
    
}
