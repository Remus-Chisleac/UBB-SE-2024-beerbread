using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    public class Song
    {

        public int id { get; set; }
        public string name { get; set; }
        public string artist { get; set; }
        public string album { get; set; }

        public int likes { get; set; }

        public int duration { get; set; }

        public int timePlayed { get; set; }

        public string path { get; set; }
        public string img_path { get; set; }

        public Song(int id, string name, string artist, string album, int duration, string path, string img_path = "")
        {
            this.id = id;
            this.name = name;
            this.artist = artist;
            this.album = album;
            this.duration = duration;
            this.likes = 0;
            this.timePlayed = 0;
            this.path = path;
            this.img_path = img_path;
        }
        public string GetTimeString()
        {
            int minutes = duration / 60;
            int seconds = duration % 60;
            return minutes + ":" + seconds;
        }
    }
}
