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
    }
    private void onLogInClicked(object sender, EventArgs e)
    {

    }
}