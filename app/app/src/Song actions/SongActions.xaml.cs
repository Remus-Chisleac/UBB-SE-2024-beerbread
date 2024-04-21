using app.Data;
using CommunityToolkit.Maui.Views;

namespace app.src.Song_actions;

public partial class SongActions : ContentPage
{
    public SongActions(Song Song)
    {
        InitializeComponent();
        if (Song.UrlImage != "")
            songImage.Source = SongFilesServerPathGenerator.GetPngPath()+ Song.UrlImage;
        else
            songImage.Source = "song_image.jpeg";
        songName.Text = Song.Name;
        songArtist.Text = Song.Artist;
    }

    private void OnAddToPlaylistTapped(object sender, EventArgs e)
    {
        // Add song to playlist
        DisplayAlert("Alert", "Not implemented yet", "OK");
    }

    private void OnRemoveFromPlaylistTapped(object sender, EventArgs e)
    {
        // Remove song from playlist
        DisplayAlert("Alert", "Not implemented yet", "OK");
    }

    private void OnReportSongTapped(object sender, EventArgs e)
    {
        // Report song
        DisplayAlert("Alert", "Not implemented yet", "OK");
    }

    private void OnBlockSongTapped(object sender, EventArgs e)
    {
        // Block song
        DisplayAlert("Alert", "Not implemented yet", "OK");
    }
    private void onBackButtonTapped(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }



}