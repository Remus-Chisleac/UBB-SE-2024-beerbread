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
    public interface IAlbum
    {
        string Description { get; set; }
        int Owner { get; }
        int Id { get; }
        string Name { get; }
        bool AddSong(int songId);
        bool RemoveSong(int songId);
        int GetSongsNumber();
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

}
