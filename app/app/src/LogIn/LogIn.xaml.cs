using app.Data.Repositories;

namespace app.src;

public partial class LogIn : ContentPage
{

    public LogIn()
    {
        InitializeComponent();


    }

    private void LogInButton_Clicked(object sender, EventArgs e)
    {
        // Perform log in action
        string password = LogInEntryPassword.Text;
        string email = LogInEntryEmail.Text;


        // Validate email and password
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            DisplayAlert("Validation Error", "Email and password are required", "OK");
            return;
        }

        AccountService service = new();
        // Check the email format
        if (!service.IsValidEmail(email))
        {
            DisplayAlert("Validation Error", "Invalid email format", "OK");
            return;
        }

        // Perform log in action

        if (!service.Authenticate(email, password))
        {
            DisplayAlert("Error", "Invalid email or password", "OK");
            return;
        }

        ISqlAccountRepository sqlAccountRepository = new SqlAccountRepository();
        try
        {
            src.Main_page.MainPage mainpage = new src.Main_page.MainPage(new User(sqlAccountRepository.GetAccount(email)));

            Navigation.PushAsync(mainpage);

        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.ToString());
        }

        Navigation.RemovePage(this);
    }

    // Method to validate email format

    private void SignUpButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
