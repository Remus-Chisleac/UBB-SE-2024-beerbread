namespace app.src
{
    using app.MVVM.Model.Domain;

    public partial class SinglePlaylistPage : ContentPage
    {
        public SinglePlaylistPage(IPlaylist playlist)
        {
            InitializeComponent();
        }

        //nav bar 
        public void onBackButtonTapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public void onPlaylistDetailButtonTapped(object sender, TappedEventArgs e)
        {
            DisplayAlert("Error", "Not implemented yet", "OK");
            return;
        }

        //main screen
        public void onPlayButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert("Error", "Not implemented yet", "OK");
            return;
        }

        public void onShuffledButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert("Error", "Not implemented yet", "OK");
            return;
        }

        public void SongDetailsDelete(object sender, EventArgs e)
        {
            DisplayAlert("Error", "Not implemented yet", "OK");
            return;
        }
    }
}