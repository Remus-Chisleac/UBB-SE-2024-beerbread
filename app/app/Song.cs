using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    internal class Song


    {

        private int id { get; set; }
        private string name { get; set; }
        private string artist { get; set; }
        private string album { get; set; }

        private int likes { get; set; }

        private int duration { get; set; }

        private int timePlayed { get; set; }

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
