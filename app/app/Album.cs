using app.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    public class Album : GenericSongRepo,IAlbum
    {

        public string Description { get; set; }
        public Album(int owner, int id, string name, string description) : base(owner, id, name)
        {
            this.Description = description;
        }
    }
}
