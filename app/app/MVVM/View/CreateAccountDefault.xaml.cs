namespace app;

public partial class CreateAccountDefault : ContentPage
{
    public CreateAccountDefault()
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
        CreateArtistAccount createArtistAccount = new CreateArtistAccount();
        Navigation.PushAsync(createArtistAccount);
    }

    private void LoginButton_Clicked(object sender, EventArgs e)
    {

        src.LogIn logIn = new src.LogIn();
        Navigation.PushAsync(logIn);

    }


}