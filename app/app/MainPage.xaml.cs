namespace app
{
    public partial class MainPage : ContentPage
    {

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
