namespace app.src.Main_page;

public partial class MainPage : ContentPage
{
    internal List<Song> songs = new List<Song>(); 
    public MainPage()
    {
        Song song = new Song(1, "Just Wanna Know", "Beat Mekanik", "beats", 196, "Beat Mekanik - Just Wanna Know.mp3");
        Song song1 = new Song(2, "No Doubt", "Ketsa", "dir", 142, "Ketsa - No Doubt.mp3");
        Song song2 = new Song(3, "Across the City", "Lobo Loco", "El Loco", 104, "Lobo Loco - Across the City (ID 2119).mp3");
        Song song3 = new Song(4, "Call in the Night", "Lobo Loco", "El Loco", 252, "Lobo Loco - Call in the Night (ID 2141).mp3");
        Song song4 = new Song(5, "Evening at Bonfire", "Lobo Loco", "Man in the river", 158, "Lobo Loco - Evening at Bonfire (ID 2081).mp3");
        Song song5 = new Song(6, "Water Sun and Love", "Lobo Loco", "Man in the river", 118, "Lobo Loco - Water Sun and Love (ID 2091).mp3");
        songs.Add( song);
        songs.Add( song1);
        songs.Add( song2);
        songs.Add( song3);
        songs.Add( song4);
        songs.Add( song5);
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