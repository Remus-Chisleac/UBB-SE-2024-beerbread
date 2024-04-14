
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    internal class User : Account
    {
        public Playlist history { get; set; }
        public Playlist likedSongs { get; set; }
        public Playlist blockedSongs { get; set; }
        public Dictionary<int, Playlist> playlists { get; set; }
        public User(string email, string username, string salt, string hashPassword) : base(email, username, salt, hashPassword)
        {
            //history = new Playlist(0, "History");
            //likedSongs = new Playlist(1, "Liked Songs");
            //blockedSongs = new Playlist(2, "Blocked Songs");
            playlists = new Dictionary<int, Playlist>();
        }

    }
}
