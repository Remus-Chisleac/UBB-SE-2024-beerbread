namespace app.MVVM.ViewModel
{
    public interface ICreateUserAccountViewModel
    {
        bool IsUsernameLengthValid(string username);

        bool IsPasswordLengthValid(string password);

        bool IsEmailValid(string email);

        bool CreateUserAccount(string email, string username, string password);
    }

    public class CreateUserAccountViewModel : ICreateUserAccountViewModel
    {
        private readonly IAccountService accountService;

        public CreateUserAccountViewModel()
        {
            this.accountService = new AccountService();
        }

        public CreateUserAccountViewModel(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public bool IsUsernameLengthValid(string username)
        {
            return !string.IsNullOrEmpty(username) && username.Length >= 6;
        }

        public bool IsPasswordLengthValid(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 8;
        }

        public bool IsEmailValid(string email)
        {
            return !string.IsNullOrEmpty(email) && this.accountService.IsEmailValid(email);
        }

        public bool CreateUserAccount(string email, string username, string password)
        {
            return this.accountService.CreateUserAccount(email, username, password);
        }
    }
}
