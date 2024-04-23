using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using app.MVVM.Model.Data.SqlCommandHandlers;
using app.MVVM.Model.Domain;
using app.MVVM.Model.Data.Repositories;

namespace MusicAppTests
{
    public class SqlUserRepositoryTests
    {
        [Fact]
        public void SqlUserRepository_EmptyConstructor()
        {
            var userRepository = new SqlUserRepository();

            Assert.IsType<SqlUserRepository>(userRepository);
        }
        [Fact]
        public void GetPlaylists_ValidUserId_ReturnsUserPlaylists()
        {
            // Arrange
            int userId = 1;
            var mockCommandExecutor = new Mock<ISqlUserTableCommandExecutor>();
            var expectedPlaylists = new List<IPlaylist>
            {
                new Playlist(1, 1, "History Playlist", false),
                new Playlist(2, 1, "Liked Playlist", true),
                new Playlist(3, 1, "Blocked Playlist", false),
                new Playlist(4, 1, "User Defined Playlist 1", true),
                new Playlist(5, 1, "User Defined Playlist 2", false)
            };
            mockCommandExecutor.Setup(e => e.GetHistoryPlaylistForUserWithId(userId)).Returns(expectedPlaylists[0]);
            mockCommandExecutor.Setup(e => e.GetLikedPlaylistForUserWithId(userId)).Returns(expectedPlaylists[1]);
            mockCommandExecutor.Setup(e => e.GetBlockedPlaylistForUserWithId(userId)).Returns(expectedPlaylists[2]);
            mockCommandExecutor.Setup(e => e.GetUserDefinedPlaylistsForUserWithId(userId, 1, 2, 3)).Returns(new List<IPlaylist> { expectedPlaylists[3], expectedPlaylists[4] });
            var userRepository = new SqlUserRepository(mockCommandExecutor.Object);


            // Act
            List<IPlaylist> result = userRepository.GetPlaylists(userId);

            expectedPlaylists.Sort((x, y) => x.Id.CompareTo(y.Id));
            result.Sort((x, y) => x.Id.CompareTo(y.Id));
            Assert.Equal(expectedPlaylists, result);
        }
    }
}
