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
            CreateUserAccount createUserAccount = new CreateUserAccount();
            Navigation.PushAsync(createUserAccount);

        }
    }

}
