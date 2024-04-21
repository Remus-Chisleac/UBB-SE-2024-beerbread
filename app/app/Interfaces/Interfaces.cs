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
        List<int> Songs { get; set; }
        int Id { get; }
        string Name { get; }
        int Owner { get; }
        bool AddSong(int songId);
        bool RemoveSong(int songId);
        int GetSongsNumber();
    }

    public interface IAlbum : IGenericSongRepo
    {
        string Description { get; set; }
    }

    public interface ISong
    {
        int Id { get; set; }
        string Name { get; set; }
        string Artist { get; set; }
        int Likes { get; set; }
        int TimePlayed { get; set; }
        string UrlSong { get; set; }
        string UrlImage { get; set; }
    }

    public interface IUser : IAccount
    {
        Playlist History { get; set; }
        Playlist LikedSongs { get; set; }
        Playlist BlockedSongs { get; set; }
        List<Playlist> Playlists { get; set; }
    }
    public interface IPlaylist : IGenericSongRepo
    {
        bool IsPrivate { get; set; }
        string ImagePath { get; set; }
        bool EmptyPlaylist();
    }
    public interface IAccount
    {
        string Email { get; set; }
        string Username { get; set; }
        string Salt { get; set; }
        Guid Id { get; }
        bool VerifyPassword(string hashedPasswordAttempt);
        string GetHashedPassword();
    }

    public interface ISqlUserService
    {
        public List<IPlaylist> GetPlaylists(int id);
    }

}
