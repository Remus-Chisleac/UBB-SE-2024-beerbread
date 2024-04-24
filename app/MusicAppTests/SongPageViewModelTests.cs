using app.MVVM.Model.Data.ServerHandlers;
using Moq;
using app.MVVM.ViewModel;
using CommunityToolkit.Maui.Views;
using app.MVVM.Model.Domain;
using System.Reflection;

namespace MusicAppTests
{
    public class SongPageViewModelTests
    {
        // Wrapper interface for MediaElement to allow mocking
        [Fact]
        public void VerifyAndGetPosition_NullMediaElement_ReturnsDefault()
        {
            // Arrange
            var viewModel = new SongPageViewModel();

            // Act
            var result = viewModel.VerifyAndGetPosition(null);

            // Assert
            Assert.Equal("00:00", result);
        }

        [Fact]
        public void VerifyAndGetPosition_EmptyMediaElement_ReturnsPosition()
        {
            // Arrange
            var mediaElement = new MediaElement();
            var viewModel = new SongPageViewModel();

            // Act
            var result = viewModel.VerifyAndGetPosition(mediaElement);

            // Assert
            Assert.Equal("00:00", result);
        }

        [Fact]
        public void VerifyAndGetDuration_NullMediaElement_ReturnsDefault()
        {
            // Arrange
            var viewModel = new SongPageViewModel();

            // Act
            var result = viewModel.VerifyAndGetDuration(null);

            // Assert
            Assert.Equal("00:00", result);
        }

        
        [Fact]
        public void VerifyAndGetDuration_EmptyMediaElement_ReturnsDuration()
        {
            // Arrange
            var mediaElement = new MediaElement();
            var viewModel = new SongPageViewModel();

            // Act
            var result = viewModel.VerifyAndGetDuration(mediaElement);

            // Assert
            Assert.Equal("00:00", result);
        }

        [Fact]
        public void GetMediaElementSource_NotStartsWithSlash_ReturnsNotNull()
        {
            // Arrange
            var song = new Song(1, "Example Song", "Example Artist", "example.mp3");
            var viewModel = new SongPageViewModel();

            // Act
            var result = viewModel.GetMediaElementSource(song);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetMediaElementSource_StartsWithSlash_ReturnsFromUri()
        {
            // Arrange
            var song = new Song(1, "Example Song", "Example Artist", "/example.mp3");
            var viewModel = new SongPageViewModel();
            var expectedUri = new Uri(SongFilesServerPathGenerator.GetMp3Path() + "/example.mp3");

            // Act
            var result = viewModel.GetMediaElementSource(song) as UriMediaSource;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUri.AbsoluteUri, result.Uri.AbsoluteUri);
        }

        [Fact]
        public void GetSongImageSource_UrlImageNotEmpty_ReturnsUrlImage()
        {
            // Arrange
            var song = new Song(1, "Example Song", "Example Artist", "example.mp3", "song_image.png");
            var viewModel = new SongPageViewModel();
            var expectedFileName = "song_image.png";

            // Act
            var result = viewModel.GetSongImageSource(song);
            var actualFileName = result.ToString().Split(':')[1].Trim(); // Assuming the format is "File: song_image.png"

            // Assert
            Assert.Equal(expectedFileName, actualFileName);
        }

        [Fact]
        public void GetSongImageSource_UrlImageEmpty_ReturnsDefaultImage()
        {
            // Arrange
            var song = new Song(1, "Example Song", "Example Artist", "example.mp3", "");
            var viewModel = new SongPageViewModel();
            var expectedFileName = "song_image.jpeg";

            // Act
            var result = viewModel.GetSongImageSource(song);
            var actualFileName = result.ToString().Split(':').Last().Trim();

            // Assert
            Assert.Equal(expectedFileName, actualFileName);
        }
    }
}