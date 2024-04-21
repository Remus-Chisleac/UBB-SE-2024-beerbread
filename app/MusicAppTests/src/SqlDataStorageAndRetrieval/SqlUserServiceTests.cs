using Xunit;
using app;
using Moq;
using app.src.SqlDataStorageAndRetrival;
namespace MusicAppTests.src.SqlDataStorageAndRetrieval
{
    public class SqlUserServiceTests
    {

        [Fact]
        public void GetPlaylists_IdNonExisting_ReturnEmptyList()
        {

            // Arrange
            var mockConnection = new Mock<Microsoft.Data.SqlClient.SqlConnection>();
            var mockCommand = new Mock<Microsoft.Data.SqlClient.SqlCommand>();
            var mockReader = new Mock<Microsoft.Data.SqlClient.SqlDataReader>();

            mockReader.SetupSequence(x => x.Read())
                .Returns(false); // No data

            mockConnection.Setup(x => x.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(x => x.ExecuteReader()).Returns(mockReader.Object);

            var userService = new SqlUserService(mockConnection.Object);

            var playlists = userService.GetPlaylists(123); // A non-existing ID

            Assert.Empty(playlists);
        }

    }
}
