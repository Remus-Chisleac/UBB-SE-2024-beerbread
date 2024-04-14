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

        // Check the email format
        if (!IsValidEmail(email))
        {
            DisplayAlert("Validation Error", "Invalid email format", "OK");
            return;
        }

        // Perform log in action

        src.Main_page.MainPage mainpage = new src.Main_page.MainPage();
        Navigation.PushAsync(mainpage);

        // Empty the fields
        LogInEntryPassword.Text = "";
        LogInEntryEmail.Text = "";
    }

    // Method to validate email format
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private void SignUpButton_Clicked(object sender, EventArgs e)
    {

        // Navigate to Sign Up page - to user 
        CreateUserAccount createUserAccount = new CreateUserAccount();
        Navigation.PushAsync(createUserAccount);

    }
}
