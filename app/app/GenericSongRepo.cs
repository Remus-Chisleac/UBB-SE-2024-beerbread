using app.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    public class GenericSongRepo:IGenericSongRepo
    {
        public List<int> Songs { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public int Owner { get; }

        public GenericSongRepo(int owner, int id, string name)
        {
            this.Owner = owner;
            this.Id = id;
            this.Name = name;
            this.Songs = new List<int>();
        }

        public bool AddSong(int songId)
        {
            try
            {
                Songs.Add(songId);
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
                Songs.Remove(songId);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public int GetSongsNumber()
        {
            return Songs.Count;
        }

    }
}

