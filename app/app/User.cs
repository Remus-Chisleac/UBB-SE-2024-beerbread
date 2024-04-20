namespace app
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualBasic.FileIO;

    public class User : Account, Interfaces.IUser
    {
        public Playlist History { get; set; }

        public Playlist LikedSongs { get; set; }

        public Playlist BlockedSongs { get; set; }

        public List<Playlist> Playlists { get; set; }
        
        public User(Account account) : base(account)
        {
        }
    }
}
