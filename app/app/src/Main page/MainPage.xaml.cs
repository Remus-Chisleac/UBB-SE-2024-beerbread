
namespace app.src.Main_page;

public partial class MainPage : ContentPage
{
    internal List<Song> songs;
    public MainPage()
    {
        LoadSongs();
        InitializeComponent();
        DisplaySongs(songs);

    }
    private void LoadSongs()
    {
        songs = new List<Song>();
        Song song = new(1, "Just Wanna Know", "Beat Mekanik", "beats", 196, "Beat Mekanik - Just Wanna Know.mp3");
        Song song1 = new(2, "No Doubt", "Ketsa", "dir", 142, "Ketsa - No Doubt.mp3");
        Song song2 = new(3, "Across the City", "Lobo Loco", "El Loco", 104, "Lobo Loco - Across the City (ID 2119).mp3");
        Song song3 = new(4, "Call in the Night", "Lobo Loco", "El Loco", 252, "Lobo Loco - Call in the Night (ID 2141).mp3");
        Song song4 = new(5, "Evening at Bonfire", "Lobo Loco", "Man in the river", 158, "Lobo Loco - Evening at Bonfire (ID 2081).mp3");
        //Song song5 = new(6, "Water Sun and Love", "Lobo Loco", "Man in the river", 118, "Lobo Loco - Water Sun and Love (ID 2091).mp3");
        Song song5 = new(7, "Raccoons", "Caravan Palace", "Gangbusters", 207, "CaravanPalace-Raccoons.mp3", "caravanpalace_raccoons.png");
        songs.Add(song);
        songs.Add(song1);
        songs.Add(song2);
        songs.Add(song3);
        songs.Add(song4);
        songs.Add(song5);
    }
    private void DisplaySongs(List<Song> songs)
    {
        int row = 0;
        int col = 0;
        int crt = 0;
        foreach (Song song in songs)
        {
            //create song frame
            Frame songFrame = new()
            {
                ClassId = song.id.ToString(),
                Margin = new Thickness(5),
                Padding = new Thickness(0),
                CornerRadius = 15,
                BackgroundColor = Color.FromArgb("#33436369"),
                BorderColor = Color.FromArgb("#00000000")
            };

            //create stack layout
            HorizontalStackLayout stackLayout = new()
            {
                ClassId = crt.ToString(),
            };
            crt++;

            //create image frame
            Frame imageFrame = new()
            {
                CornerRadius = 10,
                HeightRequest = 60,
                WidthRequest = 60,
                BackgroundColor = Color.FromArgb("#00000000"),
                BorderColor = Color.FromArgb("#00000000"),
            };

            //create image
            string img_path = song.img_path;
            if (img_path == "")
                img_path = "song_image.jpeg";
            Image image = new()
            {
                Source = img_path,
                Margin = new Thickness(-20),
                Aspect = Aspect.AspectFill,
            };
            //add image to image frame
            imageFrame.Content = image;
            stackLayout.Add(imageFrame);

            //add song name to stack layout
            Label songName = new()
            {
                Text = song.name,
                FontSize = 12,
                FontFamily = "NunitoSans",
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#ffffffff"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                LineBreakMode = LineBreakMode.WordWrap,
                MaximumWidthRequest = 100

            };
            stackLayout.Add(songName);

            //add tap gesture recognizer to stack layout
            TapGestureRecognizer tap_fn = new();
            tap_fn.Tapped += (s, e) => onSongTap(s, e);
            stackLayout.GestureRecognizers.Add(tap_fn);

            songFrame.Content = stackLayout;

            //add song frame to grid
            songsGrid.SetRow(songFrame, row);
            songsGrid.SetColumn(songFrame, col);
            songsGrid.Children.Add(songFrame);

            col++;
            if (col == 2)
            {
                if (row == 3)
                    break;
                col = 0;
                row++;
            }
        }
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


    //ADDED NEW
    private void onSongTap(object sender, EventArgs e)
    {
        int id = Int32.Parse(((HorizontalStackLayout)sender).ClassId);
        src.Song_page.SongPage songPage = new(songs[id]);
        Navigation.PushAsync(songPage);
    }




}