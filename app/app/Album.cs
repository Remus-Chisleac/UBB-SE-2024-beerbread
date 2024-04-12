using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    internal class Album: GenericSongRepo
    {

        public bool isPublic { get; set; }
        public Album(int id, string name, bool isPublic): base(id, name)
        {
            this.isPublic = isPublic;
        }

        public bool EmptyPlaylist()
        {
            try {
                this.songs.Clear();
                return true;
            }
            catch(Exception exception)
            {
                return false;
            }
        }

    }
}
