using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    public class GenericSongRepo
    {
        public List<int> songs { get; set; }
        public int id { get; set; }
        public string name { get; set; }

        public int owner { get; }

        public GenericSongRepo(int owner, int id, string name)
        {
            this.owner = owner;
            this.id = id;
            this.name = name;
            this.songs = new List<int>();
        }

        public bool AddSong(int songId)
        {
            try
            {
                songs.Add(songId);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool RemoveSong(int songId)
        {
            try
            {
                songs.Remove(songId);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public int GetSongsNumber()
        {
            return songs.Count;
        }

    }
}

