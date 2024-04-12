using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    internal class Album: GenericSongRepo

    {
        public string description { get; set; }


        public Album(int id, string name, string description) : base(id, name)
        {
            this.description = description;
        }


    }
}
