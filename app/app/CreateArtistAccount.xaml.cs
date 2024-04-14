using System.Globalization;

namespace app;

public partial class CreateArtistAccount : ContentPage
{
    public CreateArtistAccount()
    {
        InitializeComponent();
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

        if (!IsNameValid(name))
        {
            DisplayAlert("Name Error", "Can only contain letters", "OK");
            return;
        }

        if (username.Length < 6)
        {
            DisplayAlert("Username Error", "Must be at least 6 characters", "OK");
            return;
        }

        if (!IsCountryValid(country))
        {
            DisplayAlert("Country Error", "Can only contain letters", "OK");
            return;
        }

        if (!IsDateOfBirthValid(dateBirth))
        {
            DisplayAlert("Error", "Invalid date of birth format. Please use day/month/year", "OK");
            return;
        }

        if (!IsEmailValid(email))
        {
            DisplayAlert("Error", "Invalid email format. Email should end with @yahoo.com or @gmail.com", "OK");
            return;
        }

        if (password.Length < 8)
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

    private bool IsNameValid(string name)
    {
        return !string.IsNullOrEmpty(name) && name.All(char.IsLetter);
    }

    private bool IsCountryValid(string country)
    {
        return !string.IsNullOrEmpty(country) && country.All(char.IsLetter);
    }

    private bool IsDateOfBirthValid(string dateOfBirth)
    {
        // Split the input date by "/"
        string[] dateParts = dateOfBirth.Split('/');

        // Check if there are exactly three parts (day, month, year)
        if (dateParts.Length != 3)
        {
            // Invalid date format
            return false;
        }

        // Validate day
        if (!int.TryParse(dateParts[0], out int day) || day < 1 || day > 31)
        {
            // Invalid day
            return false;
        }

        // Validate month
        if (!int.TryParse(dateParts[1], out int month) || month < 1 || month > 12)
        {
            // Invalid month
            return false;
        }

        // Validate year
        if (!int.TryParse(dateParts[2], out int year) || year < 1990 || year > 2023)
        {
            // Invalid year
            return false;
        }

        // Date format is valid
        return true;
    }


    private bool IsEmailValid(string email)
    {
        return !string.IsNullOrEmpty(email) && (email.EndsWith("@gmail.com") || email.EndsWith("@yahoo.com"));
    }

    private void LoginButton_Clicked(object sender, EventArgs e)
    {

        //src.PlaylistsPage playlistsPage = new src.PlaylistsPage();
        //Navigation.PushAsync(playlistsPage);

        src.LogIn logIn = new src.LogIn();
        Navigation.PushAsync(logIn);
    }
}