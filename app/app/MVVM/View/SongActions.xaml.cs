using app.MVVM.Model.Data.ServerHandlers;
using app.MVVM.Model.Domain;
using app.MVVM.ViewModel;
using CommunityToolkit.Maui.Views;

namespace app.src.Song_actions;

public partial class SongActions : ContentPage
{
    ISongActionsViewModel songActionsViewModel;

    public SongActions(Song song)
    {
        InitializeComponent();

        songActionsViewModel = new SongActionsViewModel();
        songImage.Source = songActionsViewModel.getSongImageSource(song);
        songName.Text = song.Name;
        songArtist.Text = song.Artist;
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