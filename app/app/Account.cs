using System;
using System.Security.Cryptography;
using System.Text;

namespace app
{
    internal class Account
    {
        // Properties
        public string Email { get; set; }
        public string Username { get; set; }
        protected string HashedPassword { get; set; }
        private string Salt { get; set; }
        public Guid Id { get; }

        // Constructor
        public Account(string email, string username, string password, string salt)
        {
            Email = email;
            Username = username;
            Id = Guid.NewGuid();
            Salt = salt;
            HashedPassword = HashPassword(password, Salt);
        }

        // Method to hash the password
        protected string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = password + salt;
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                return Convert.ToBase64String(hashedBytes);
            }
        }

    }
}
