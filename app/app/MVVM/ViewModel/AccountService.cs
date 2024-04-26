namespace app.MVVM.ViewModel
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using app.MVVM.Model.Data.Repositories;
    using app.MVVM.Model.Domain;

    public interface IAccountService
    {
        bool CreateUserAccount(string email, string username, string password);

        bool AreAuthenticationCredentialsValid(string email, string password);

        bool CreateArtistAccount(string email, string username, string password);

        bool IsEmailValid(string email);

        User? GetAccountWithCredentials(string email, string password);
    }

    public class AccountService : IAccountService
    {
        private readonly ISqlAccountRepository sqlAccountRepository;

        public AccountService()
        {
            this.sqlAccountRepository = new SqlAccountRepository();
        }

        public AccountService(ISqlAccountRepository sqlAccountRepository)
        {
            this.sqlAccountRepository = sqlAccountRepository;
        }

        public bool CreateUserAccount(string email, string username, string password)
        {
            string salt = GenerateSalt();
            string hashedPassword = HashPassword(password, salt);
            Account newAccount = new (email, username, salt, hashedPassword);
            if (!this.sqlAccountRepository.AddAccount(newAccount))
            {
                return false;
            }

            return this.sqlAccountRepository.AddUserAccount(newAccount);
        }

        public bool CreateArtistAccount(string email, string username, string password)
        {
            // todo never
            return false;
        }

        public bool AreAuthenticationCredentialsValid(string email, string password)
        {
            Account? account = this.sqlAccountRepository.GetAccount(email);

            if (account == null)
            {
                return false;
            }

            string hashedPasswordAttempt = HashPassword(password, account.Salt);
            return account.VerifyPassword(hashedPasswordAttempt);
        }

        public bool IsEmailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public User? GetAccountWithCredentials(string email, string password)
        {
            if (!this.AreAuthenticationCredentialsValid(email, password))
            {
                return null;
            }

            Account? account = this.sqlAccountRepository.GetAccount(email);
            if (account == null)
            {
                return null;
            }

            return new User(account);
        }

        private static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = password + salt;
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
    }
}
