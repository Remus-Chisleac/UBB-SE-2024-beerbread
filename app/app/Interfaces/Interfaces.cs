using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Interfaces
{
    public interface IAccountService
    {
        bool CreateUserAccount(string email, string username, string password);
        bool Authenticate(string email, string password);
    }

    public interface ISqlAccountService
    {
        bool AddAccount(Account account);
        bool AddUserAccount(Account account);
        Account GetAccount(string email);
        string GetAccountHashedPassword(string email);
    }
    public interface IGenericSongRepo
    {
        List<int> songs { get; set; }
        int id { get; }
        string name { get; }
        int owner { get; }
        bool AddSong(int songId);
        bool RemoveSong(int songId);
        int GetSongsNumber();
    }

    public interface IAlbum : IGenericSongRepo
    {
        string description { get; set; }
    }

    public interface ISong
    {
        int id { get; set; }
        string name { get; set; }
        string artist { get; set; }
        int likes { get; set; }
        int timePlayed { get; set; }
        string urlSong { get; set; }
        string urlImage { get; set; }
    }

    public interface IUser : IAccount
    {
        Playlist history { get; set; }
        Playlist likedSongs { get; set; }
        Playlist blockedSongs { get; set; }
        List<Playlist> playlists { get; set; }
    }
    public interface IPlaylist : IGenericSongRepo
    {
        bool isPrivate { get; set; }
        string imagePath { get; set; }
        bool emptyPlaylist();
    }

}
