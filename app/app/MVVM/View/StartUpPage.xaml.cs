using app.src.Song_actions;

namespace app.src.Join_us;

public partial class StartUpPage : ContentPage
{
    public StartUpPage()
    {
        InitializeComponent();
    }

    private void onCreateAccountClicked(object sender, EventArgs e)
    {
        CreateUserAccount createUserAccount = new CreateUserAccount();
        Navigation.PushAsync(createUserAccount);
        //SongActions songActions = new SongActions();
        //Navigation.PushAsync(songActions);
        
    }
    private void onLogInClicked(object sender, EventArgs e)
    {
        src.LogIn logIn = new src.LogIn();
        Navigation.PushAsync(logIn);
    }
}