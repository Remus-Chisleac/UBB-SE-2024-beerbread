using System;
using System.Text;

namespace app
{
    public class Account: Interfaces.IAccount
    {
        // Properties
        public string Email { get; set; }
        public string Username { get; set; }
        private string HashedPassword { get; set; }
        public string Salt { get; set; }
        public Guid Id { get; }

        // Constructor
        public Account(Account account)
        {
            Email = account.Email;
            Username = account.Username;
            Id = account.Id;
            Salt = account.Salt;
            HashedPassword = account.HashedPassword;
        }
        public Account(Guid id, string email, string username, string salt, string hashPassword)
        {
            Email = email;
            Username = username;
            Id = id;
            Salt = salt;
            HashedPassword = hashPassword;
        }
        public Account(string email, string username, string salt, string hashPassword)
        {
            Email = email;
            Username = username;
            Id = Guid.NewGuid();
            Salt = salt;
            HashedPassword = hashPassword;
        }

        // Verify password (for authentication)
        public bool VerifyPassword(string hashedPasswordAttempt)
        {
            return HashedPassword == hashedPasswordAttempt;
        }
        public string GetHashedPassword()
        {
            return HashedPassword;
        }
    }
}
