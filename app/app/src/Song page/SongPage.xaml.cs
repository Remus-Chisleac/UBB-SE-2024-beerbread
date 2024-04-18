using app.src.SqlDataStorageAndRetrival;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using System.Diagnostics;


namespace app.src.Song_page;

public partial class SongPage : ContentPage
{
    bool isPlaying = false;
    bool isLiked = false;
    public string Position
    {
        get
        {
            if (mediaElement != null)
            {
                return mediaElement.Position.ToString(@"mm\:ss");
            }
            return "00:00";
        }
    }
    public string Duration
    {
        get
        {
            if (mediaElement != null)
            {
                return mediaElement.Duration.ToString(@"mm\:ss");
            }
            return "00:00";
        }
    }
    bool noAutoChange = true;
    Song song;
    public SongPage(Song song)
    {
        BindingContext = this;
        InitializeComponent();
        this.song = song;
        song_name.Text = song.name;
        artist_name.Text = song.artist;
        Trace.WriteLine(SourceLoader.GetMp3Path() + song.urlSong);

        if (!song.urlSong.StartsWith("/"))
            mediaElement.Source = MediaSource.FromResource(song.urlSong);
        else
            mediaElement.Source = MediaSource.FromUri(SourceLoader.GetMp3Path() + song.urlSong);
        mediaElement.Volume = 0.75;
        if (song.urlImage != "")
            songImage.Source = song.urlImage;
        else
            songImage.Source = "song_image.jpeg";
        songImage.Source = ImageSource.FromUri(new Uri(SourceLoader.GetPngPath() + song.urlImage));
    }
    private void mediaElement_loaded(object sender, EventArgs e)
    {
        mediaElement.PositionChanged += MediaElement_PositionChanged;
        mediaElement.Source = MediaSource.FromUri(SourceLoader.GetMp3Path() + song.urlSong);
        total_song_time.Text = mediaElement.Duration.ToString(@"mm\:ss");
    }

    private void MediaElement_PositionChanged(object? sender, CommunityToolkit.Maui.Core.Primitives.MediaPositionChangedEventArgs e)
    {
        noAutoChange = false;
        progress_bar.Value = (mediaElement.Position).TotalSeconds / (mediaElement.Duration).TotalSeconds;
        noAutoChange = true;
        OnPropertyChanged(nameof(Position));
        total_song_time.Text = mediaElement.Duration.ToString(@"mm\:ss");
    }
    private void onBackButtonTapped(object sender, EventArgs e)
    {
        mediaElement.Stop();
        Navigation.PopAsync();
    }

    private void onSongDetailButtonTapped(object sender, EventArgs e)
    {
        src.Song_actions.SongActions songActions = new(this.song);
        Navigation.PushAsync(songActions);
    }

    private void onLikedButtonClicked(object sender, TappedEventArgs e)
    {
        if (!isLiked)
        {
            isLiked = true;
            like_button.Source = "liked_button.png";
        }
        else
        {
            isLiked = false;
            like_button.Source = "liked_unpressed_button.png";
        }
    }
    private void goBackSongButton(object sender, EventArgs e)
    {
        if (mediaElement.Position.TotalSeconds > 5)
        {
            mediaElement.SeekTo(TimeSpan.FromSeconds(0));
        }
    }

    private void PlayPauseButton(object sender, TappedEventArgs e)
    {
        if (!isPlaying)
        {
            isPlaying = true;
            play_one_song_button.Source = "pause_song_button";

            try
            {
                mediaElement.Play();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        else
        {
            isPlaying = false;
            play_one_song_button.Source = "play_song_button";
            mediaElement.Pause();
        }

    }


    private void goForwardSongButton(object sender, EventArgs e)
    {
        DisplayAlert("Error", "Not implemented yet..", "OK");
        return;
    }

    private void onDragStartedValueChange(object sender, EventArgs e)
    {
        isPlaying = false;
        mediaElement.Pause();
        progress_bar.ThumbColor = Color.FromArgb("#FF7cffcf");
    }
    private void onDragCompletedValueChange(object sender, EventArgs e)
    {
        mediaElement.SeekTo(TimeSpan.FromSeconds(progress_bar.Value * mediaElement.Duration.TotalSeconds));
        isPlaying = true;
        mediaElement.Play();
        progress_bar.ThumbColor = Color.FromArgb("#FF7cadff");
    }
}