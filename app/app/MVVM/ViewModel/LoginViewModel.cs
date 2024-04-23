namespace app.MVVM.ViewModel
{
    using app.MVVM.Model.Domain;
    public interface ILoginViewModel
    {
        bool IsEmailValid(string email);

        bool IsPasswordValid(string password);

        bool AreAuthenticationCredentialsValid(string email, string password);

        User? AuthenticateAndGetCurrentUser(string username, string password);
    }

    public class LoginViewModel : ILoginViewModel
    {
        private readonly IAccountService accountService;

        public LoginViewModel()
        {
            this.accountService = new AccountService();
        }

        public LoginViewModel(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public bool IsEmailValid(string email)
        {
            return !string.IsNullOrEmpty(email) && this.accountService.IsEmailValid(email);
        }

        public bool IsPasswordValid(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 8;
        }

        public bool AreAuthenticationCredentialsValid(string email, string password)
        {
            return this.accountService.AreAuthenticationCredentialsValid(email, password);
        }

        public User? AuthenticateAndGetCurrentUser(string email, string password)
        {
            return this.accountService.GetAccountWithCredentials(email, password);
        }
    }
}
