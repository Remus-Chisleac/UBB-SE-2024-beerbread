using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    public class Song : Interfaces.ISong
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }

        public int Likes { get; set; }

        public int TimePlayed { get; set; }

        public string UrlSong { get; set; }
        public string UrlImage { get; set; }

        public Song(int id, string name, string artist, string urlSong, string urlImage = "")
        {
            this.Id = id;
            this.Name = name;
            this.Artist = artist;
            this.Likes = 0;
            this.TimePlayed = 0;
            this.UrlSong = urlSong;
            this.UrlImage = urlImage;
        }
    }
}
