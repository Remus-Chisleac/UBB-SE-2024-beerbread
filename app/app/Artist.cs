using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    internal class Artist : User
    {
        public Dictionary<int, Album> albums { get; set; }
        public Artist(string email, string username, string salt, string hashPassword) : base(email, username, salt, hashPassword)
        {
            albums = new Dictionary<int, Album>();
        }
    }
}
