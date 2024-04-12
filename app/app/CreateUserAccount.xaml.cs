using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (!email.EndsWith("@gmail.com") && !email.EndsWith("@yahoo.com"))
            {
                DisplayAlert("Email Error", "Should end with @gmail.com or @yahoo.com", "OK");
                return;
            }

            //pop up on screen saying "Account created successfully"
            DisplayAlert("Alert", "Account created successfully", "OK");

            //clear the text fields
            UserEntryUsername.Text = "";
            UserEntryPassword.Text = "";
            UserEntryEmail.Text = "";
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {

            //pop up on screen saying "Login page not implemented yet"
            DisplayAlert("Alert", "Login page not implemented yet", "OK");

        }
    }
}
