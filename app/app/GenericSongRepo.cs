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
        Dictionary<int, Song> songs;
        public int id { get; set; }
        public string name { get; set; }

        public GenericSongRepo(int id, string name)
        {
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
    }
    }
