using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    internal class GenericSongRepo
    {
        public Dictionary<int, Song> songs { get; set; }
        public int id { get; set; }
        public string name { get; set; }

        public Guid owner { get;}

        public GenericSongRepo(Guid owner, int id, string name)
        {
            this.owner = owner;
            this.id = id;
            this.name = name;
            songs = new Dictionary<int, Song>();
        }



        public bool AddSong(Song songToAdd)
        {
            try
            {
                songs.Add(songToAdd.id, songToAdd);
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }

        public bool RemoveSong(Song songToRemove)
        {
            return songs.Remove(songToRemove.id);

        }
        public int GetSongNumbert()
        {
            return songs.Count;
        }

    }
}

