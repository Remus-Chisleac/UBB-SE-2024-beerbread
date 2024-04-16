using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    internal class ServiceSong
    {
        private GenericSongRepo songRepo;

        public ServiceSong(GenericSongRepo songRepo)
        {
            this.songRepo = songRepo;
        }

        public bool Like(int songId)
        {
            if (songRepo.songs.ContainsKey(songId))
            {
                songRepo.songs[songId].likes++;
                return true;
            }
            return false;
        }

        public bool Play(int songId)
        {
            if (songRepo.songs.ContainsKey(songId))
            {
                //play logic
                return true;
            }
            return false;
        }

        public bool Skip(int songId)
        {
            // Skipping logic goes here
            return false; // Placeholder return value
        }

        public bool Report(int songId)
        {
            // Reporting logic goes here
            return false; // Placeholder return value
        }

        public bool Play(int songId, int timestamp)
        {
            // Play at specific timestamp logic goes here
            return false; // Placeholder return value
        }

        public bool Pause(int songId)
        {
            // Pause logic goes here
            return false; // Placeholder return value
        }

        public bool Resume(int songId)
        {
            // Resume logic goes here
            return false; // Placeholder return value
        }
    }
}
