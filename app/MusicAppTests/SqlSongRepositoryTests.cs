using Moq;
using app.MVVM.Model.Data.SqlCommandHandlers;
using app.MVVM.Model.Domain;
using app.MVVM.Model.Data.Repositories;

namespace MusicAppTests
{
    public class SqlSongRepositoryTests
    {
        [Fact]
        public void SqlSongRepository_EmptyConstructor()
        {
            var sqlSongRepository = new SqlSongRepository();
            Assert.IsType<SqlSongRepository>(sqlSongRepository);
        }

        [Fact]
        public void GetAllSongIds_Valid_ReturnsAllSongIds()
        {
            // Arrange
            var mockCommandExecutor = new Mock<ISqlSongTableCommandExecutor>();
            var expectedIds = new List<int> { 1, 2, 3 };
            mockCommandExecutor.Setup(e => e.GetAllSongIdsInDatabase()).Returns(expectedIds);
            var songRepository = new SqlSongRepository(mockCommandExecutor.Object);

            // Act
            List<int> result = songRepository.GetAllSongIds();

            // Assert
            Assert.Equal(expectedIds, result);
        }

        [Fact]
        public void GetSongsWithIds_ValidSongIds_ReturnsSongs()
        {
            // Arrange
            var mockCommandExecutor = new Mock<ISqlSongTableCommandExecutor>();
            var songIds = new List<int> { 1, 2, 3 };
            var expectedSongs = new List<Song>
            {
                new Song(1, "Song 1", "Artist 1", "url1", "image1"),
                new Song(2, "Song 2", "Artist 2", "url2", "image2"),
                new Song(3, "Song 3", "Artist 3", "url3", "image3")
            };
            mockCommandExecutor.Setup(e => e.GetSongsWithIds(songIds)).Returns(expectedSongs);
            var songRepository = new SqlSongRepository(mockCommandExecutor.Object);

            // Act
            List<Song> result = songRepository.GetSongsWithIds(songIds);

            // Assert
            Assert.Equal(expectedSongs, result);
        }
    }
}
