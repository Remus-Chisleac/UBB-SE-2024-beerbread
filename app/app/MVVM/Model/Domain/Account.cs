namespace app.MVVM.Model.Domain
{
    public interface IAccount
    {
        string Email { get; set; }

        string Username { get; set; }

        string Salt { get; set; }

        Guid Id { get; }

        bool VerifyPassword(string hashedPasswordAttempt);

        string GetHashedPassword();
    }
    public class Account : IAccount
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string Salt { get; set; }

        public Guid Id { get; }

        private string HashedPassword { get; set; }

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
