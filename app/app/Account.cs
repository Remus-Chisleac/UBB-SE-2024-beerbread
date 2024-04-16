using System;
using System.Text;

namespace app
{
    public class Account
    {
        // Properties
        public string Email { get; set; }
        public string Username { get; set; }
        protected string HashedPassword { get; set; }
        public string Salt { get; set; }
        public Guid Id { get; }

        // Empty constructor
        public Account()
        {
            Email = "";
            Username = "";
            HashedPassword = "";
            Salt = "";
            Id = Guid.NewGuid();
        }

        // Constructor
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
    }
}
