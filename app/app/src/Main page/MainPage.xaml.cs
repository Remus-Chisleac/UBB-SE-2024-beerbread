namespace app.src.Main_page;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void onUserAccountTap(object sender, TappedEventArgs e)
    {
        // naivgate to user account page
        DisplayAlert("UserAccountDetails", "Not yet implemented", "OK");
    }

    private void onMusicCreatorTap(object sender, TappedEventArgs e)
    {
        DisplayAlert("MusicCreator", "Not yet linked with other semigroup", "OK");
    }

    private void onHomeTap(object sender, TappedEventArgs e)
    {
        bottomNavbar_LibraryImage.Source = "library.png";
        bottomNavbar_LibraryLabel.TextColor = Color.FromArgb("#ffffff");

        bottomNavbar_ExploreImage.Source = "explore.png";
        bottomNavbar_ExploreLabel.TextColor = Color.FromArgb("#ffffff");

        bottomNavbar_HomeImage.Source = "home_blue.png";
        bottomNavbar_HomeLabel.TextColor = Color.FromArgb("#00c2cb");
    }

    private void onExploreTap(object sender, TappedEventArgs e)
    {
        bottomNavbar_LibraryImage.Source = "library.png";
        bottomNavbar_LibraryLabel.TextColor = Color.FromArgb("#ffffff");

        bottomNavbar_ExploreImage.Source = "explore_blue.png";
        bottomNavbar_ExploreLabel.TextColor = Color.FromArgb("#00c2cb");

        bottomNavbar_HomeImage.Source = "home.png";
        bottomNavbar_HomeLabel.TextColor = Color.FromArgb("#ffffff");
    }

    private void onLibraryTap(object sender, TappedEventArgs e)
    {
        src.PlaylistsPage playlistsPage = new src.PlaylistsPage();
        Navigation.PushAsync(playlistsPage);
    }

    private void onSearchTap(object sender, TappedEventArgs e)
    {

    }

    private void onSearchFocus(object sender, FocusEventArgs e)
    {
        //change the backgroung color of the search bar
        search_frame.BackgroundColor = Color.FromArgb("#aff1ff");
        //replace the search icon ion the botton nav with the blue version
        bottomNavbar_ExploreImage.Source = "explore_blue.png";
        bottomNavbar_ExploreLabel.TextColor = Color.FromArgb("#00c2cb");
        // replace the home with its white version
        bottomNavbar_HomeImage.Source = "home.png";
        bottomNavbar_HomeLabel.TextColor = Color.FromArgb("#ffffff");
    }

    private void onSearchUnFocus(object sender, FocusEventArgs e)
    {
        //change the backgroung color of the search bar
        search_frame.BackgroundColor = Color.FromArgb("#d9d9d9");
        //replace the search icon ion the botton nav with the blue version
        bottomNavbar_ExploreImage.Source = "explore.png";
        bottomNavbar_ExploreLabel.TextColor = Color.FromArgb("#ffffff");
        // replace the home with its white version
        bottomNavbar_HomeImage.Source = "home_blue.png";
        bottomNavbar_HomeLabel.TextColor = Color.FromArgb("#00c2cb");
    }
}