namespace app
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    public class Song : Interfaces.ISong
    {
        public int id { get; set; }
        public string name { get; set; }
        public string artist { get; set; }

        public int likes { get; set; }

        public int timePlayed { get; set; }

        public string urlSong { get; set; }
        public string urlImage { get; set; }

        public Song(int id, string name, string artist, string urlSong, string urlImage = "")
        {
            this.id = id;
            this.name = name;
            this.artist = artist;
            this.likes = 0;
            this.timePlayed = 0;
            this.urlSong = urlSong;
            this.urlImage = urlImage;
        }
    }
}
