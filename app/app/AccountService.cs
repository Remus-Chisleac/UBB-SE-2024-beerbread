using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace app
{
    internal class AccountService
    {
        private Dictionary<string, Account> accounts;

        public AccountService()
        {
            accounts = new Dictionary<string, Account>();
        }

        // Creation
        public void CreateAccount(string email, string username, string password)
        {
            string salt = GenerateSalt();
            string hashedPassword = HashPassword(password, salt);
            Account newAccount = new Account(email, username, salt, hashedPassword);
            accounts[email] = newAccount;
        }

        // Authentication
        public bool Authenticate(string email, string password)
        {
            // Check account existance
            if (accounts.ContainsKey(email))
            {
                Account account = accounts[email];
                // Check password
                string hashedPasswordAttempt = HashPassword(password, account.Salt);
                return account.VerifyPassword(hashedPasswordAttempt);
            }
            else
            {
                // Account doesn't exist
                return false;
            }
        }

        // Salt generator
        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
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
