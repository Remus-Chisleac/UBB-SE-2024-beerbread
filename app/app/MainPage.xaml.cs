namespace app
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCreateAccountClicked(object sender, EventArgs e)
        {
            CreateAccountDefault createAccountDefault = new CreateAccountDefault();
            Navigation.PushAsync(createAccountDefault);
            
            //CreateUserAccount createUserAccount = new CreateUserAccount();
            //Navigation.PushAsync(createUserAccount);

        }
    }

}
