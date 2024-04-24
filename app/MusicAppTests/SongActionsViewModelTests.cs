using Xunit;
using Moq;
using app.MVVM.ViewModel;
using app.MVVM.Model.Domain;
using app.MVVM.Model.Data.ServerHandlers;

namespace MusicAppTests
{
    public class SongActionsViewModelTests
    {
        [Fact]
        public void GetSongImageSource_UrlImageIsEmpty_ReturnsDefaultImage()
        {
            // Arrange
            var song = new Song(1, "Song Name", "Artist", "http://example.com/song.mp3", "");

            var viewModel = new SongActionsViewModel();

            // Act
            var result = viewModel.getSongImageSource(song);

            // Assert
            Assert.Equal("File: song_image.jpeg", result.ToString().Trim()); // Trim to remove any extra whitespace
        }

        [Fact]
        public void GetSongImageSource_UrlImageIsNotEmpty_ReturnsCorrectImageSource()
        {
            // Arrange
            var song = new Song(1, "Song Name", "Artist", "http://example.com/song.mp3", "album_cover.png");

            string expectedImagePath = "Uri: http://localhost:1444/api/source/pngalbum_cover.png";

            var viewModel = new SongActionsViewModel();

            // Act
            var result = viewModel.getSongImageSource(song);

            // Assert
            Assert.Equal(expectedImagePath, result.ToString());
        }
    }
}
