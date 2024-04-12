using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    internal class Song


    {

        public int id { get; set; }
        public string name { get; set; }
        public string artist { get; set; }
        public string album { get; set; }

        public int likes { get; set; }

        public int duration { get; set; }

        public int timePlayed { get; set; }

        public Song(int id, string name, string artist, string album, int duration)
        {
            this.id = id;
            this.name = name;
            this.artist = artist;
            this.album = album;
            this.duration = duration;
            this.likes = 0;
            this.timePlayed = 0;
        }
    }
}
