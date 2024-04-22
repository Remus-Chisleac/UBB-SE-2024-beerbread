using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.MVVM.ViewModel;

namespace app
{
    public partial class CreateUserAccount : ContentPage
    {
        public CreateUserAccount()
        {
            InitializeComponent();
        }

        private void UserButton_Clicked(object sender, EventArgs e)
        {
            // Switch to User mode
        }

        private void ArtistButton_Clicked(object sender, EventArgs e)
        {
            // Switch to Artist mode
            CreateArtistAccount createArtistAccount = new CreateArtistAccount();
            Navigation.PushAsync(createArtistAccount);
        }

        private void CreateButton_Clicked(object sender, EventArgs e)
        {
            // Perform create action
            string username = UserEntryUsername.Text;
            string password = UserEntryPassword.Text;
            string email = UserEntryEmail.Text;

            if (username.Length < 6)
            {
                DisplayAlert("Username Error", "Must be at least 6 characters", "OK");
                return;
            }

            if (password.Length < 8)
            {
                DisplayAlert("Password Error", "Must be at least 8 characters", "OK");
                return;
            }
            //check if email
            AccountService service = new();
            if (!service.IsValidEmail(email))
            {
                DisplayAlert("Email Error", "Should end with @gmail.com or @yahoo.com", "OK");
                return;
            }

            bool ret = service.CreateUserAccount(email, username, password);

            if (ret)
            {
                DisplayAlert("Success", "Account created successfully", "OK");
                Navigation.PushAsync(new src.LogIn());
            }
            else
            {
                DisplayAlert("Error", "Account creation failed", "OK");
            }

            //clear the text fields
            UserEntryUsername.Text = "";
            UserEntryPassword.Text = "";
            UserEntryEmail.Text = "";
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {

            src.LogIn logIn = new src.LogIn();
            Navigation.PushAsync(logIn);

        }
    }
}
