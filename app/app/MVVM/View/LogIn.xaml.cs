namespace app.src
{
    using app.MVVM.Model.Data.Repositories;
    using app.MVVM.Model.Domain;
    using app.MVVM.ViewModel;
    using app.src.Main_page;

    public partial class LogIn : ContentPage
    {
        private ILoginViewModel loginViewModel = new LoginViewModel();

        public LogIn()
        {
            this.InitializeComponent();
        }

        private void LogInButton_Clicked(object sender, EventArgs e)
        {
            string password = this.LogInEntryPassword.Text;
            string email = this.LogInEntryEmail.Text;

            if (!this.loginViewModel.IsEmailValid(email))
            {
                this.DisplayAlert("Validation Error", "Invalid email format", "OK");
                return;
            }

            if (!this.loginViewModel.IsPasswordValid(password))
            {
                this.DisplayAlert("Validation Error", "Password must be at least 8 characters long", "OK");
                return;
            }

            if (!this.loginViewModel.AreAuthenticationCredentialsValid(email, password))
            {
                this.DisplayAlert("Error", "Invalid email or password", "OK");
                return;
            }

            User? currentUser = this.loginViewModel.AuthenticateAndGetCurrentUser(email, password);
            if (currentUser != null)
            {
                MainPage mainPage = new MainPage(currentUser);
                this.Navigation.PushAsync(mainPage);

                // Navigation.RemovePage(this); this breaks the app on my pc
            }
            else
            {
                this.DisplayAlert("Error", "Invalid email or password", "OK");
            }
        }

        private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}