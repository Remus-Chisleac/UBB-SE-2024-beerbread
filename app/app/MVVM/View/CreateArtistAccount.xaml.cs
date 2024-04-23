using System.Globalization;
using app.MVVM.ViewModel;

namespace app;

public partial class CreateArtistAccount : ContentPage
{
    ICreateArtistAccountViewModel artistAccountViewModel;
    public CreateArtistAccount()
    {
        InitializeComponent();
        artistAccountViewModel = new CreateArtistAccountViewModel();
    }

    private void UserButton_Clicked(object sender, EventArgs e)
    {
        // Switch to User mode
        CreateUserAccount createUserAccount = new CreateUserAccount();
        Navigation.PushAsync(createUserAccount);
    }

    private void ArtistButton_Clicked(object sender, EventArgs e)
    {
        // Switch to Artist mode
    }

    private void CreateButton_Clicked(object sender, EventArgs e)
    {
        // Perform create action
        string name = ArtistEntryName.Text;
        string username = ArtistEntryUsername.Text;
        string country = ArtistEntryCountry.Text;
        string dateBirth = ArtistEntryDateBirth.Text;
        string email = ArtistEntryEmail.Text;
        string password = ArtistEntryPassword.Text;

        if (!this.artistAccountViewModel.IsNameValid(name))
        {
            DisplayAlert("Name Error", "Can only contain letters", "OK");
            return;
        }

        if (!this.artistAccountViewModel.IsUsernameValid(username))
        {
            DisplayAlert("Username Error", "Must be at least 6 characters", "OK");
            return;
        }

        if (!this.artistAccountViewModel.IsCountryValid(country))
        {
            DisplayAlert("Country Error", "Can only contain letters", "OK");
            return;
        }

        if (!this.artistAccountViewModel.IsBirthDateValid(dateBirth))
        {
            DisplayAlert("Error", "Invalid date of birth format. Please use day/month/year", "OK");
            return;
        }

        if (!this.artistAccountViewModel.IsEmailValid(email))
        {
            DisplayAlert("Error", "Invalid email format. Email should end with @yahoo.com or @gmail.com", "OK");
            return;
        }

        if (this.artistAccountViewModel.IsPasswordValid(password))
        {
            DisplayAlert("Password Error", "Must be at least 8 characters", "OK");
            return;
        }

        //pop up on screen saying "Account created successfully"
        DisplayAlert("Alert", "Account created successfully", "OK");
        // empty the fields
        ArtistEntryName.Text = "";
        ArtistEntryUsername.Text = "";
        ArtistEntryCountry.Text = "";
        ArtistEntryDateBirth.Text = "";
        ArtistEntryEmail.Text = "";
        ArtistEntryPassword.Text = "";

    }

    private void LoginButton_Clicked(object sender, EventArgs e)
    {

        //src.PlaylistsPage playlistsPage = new src.PlaylistsPage();
        //Navigation.PushAsync(playlistsPage);

        src.LogIn logIn = new src.LogIn();
        Navigation.PushAsync(logIn);
    }
}