using Xunit;
using Moq;
using app.MVVM.ViewModel;

namespace MusicAppTests
{
    public class CreateUserAccountViewModelTests
    {
        [Fact]
        public void IsUsernameLengthValid_ValidUsername_ReturnsTrue()
        {
            // Arrange
            var viewModel = new CreateUserAccountViewModel();

            // Act
            bool result = viewModel.IsUsernameLengthValid("username123");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsUsernameLengthValid_InvalidUsername_ReturnsFalse()
        {
            // Arrange
            var viewModel = new CreateUserAccountViewModel();

            // Act
            bool result = viewModel.IsUsernameLengthValid("user");

            // Assert
            Assert.False(result);
        }

        // Similarly, write tests for IsPasswordLengthValid, IsEmailValid, and CreateUserAccount methods...

        [Fact]
        public void CreateUserAccount_ValidData_ReturnsTrue()
        {
            // Arrange
            var mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(service => service.CreateUserAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            var viewModel = new CreateUserAccountViewModel(mockAccountService.Object);

            // Act
            bool result = viewModel.CreateUserAccount("test@example.com", "username123", "password123");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CreateUserAccount_InvalidData_ReturnsFalse()
        {
            // Arrange
            var mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(service => service.CreateUserAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            var viewModel = new CreateUserAccountViewModel(mockAccountService.Object);

            // Act
            bool result = viewModel.CreateUserAccount("test@example.com", "username123", "password123");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsPasswordLengthValid_ValidPassword_ReturnsTrue()
        {
            // Arrange
            var viewModel = new CreateUserAccountViewModel();

            // Act
            bool result = viewModel.IsPasswordLengthValid("password123");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPasswordLengthValid_InvalidPassword_ReturnsFalse()
        {
            // Arrange
            var viewModel = new CreateUserAccountViewModel();

            // Act
            bool result = viewModel.IsPasswordLengthValid("pass");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsEmailValid_ValidEmail_ReturnsTrue()
        {
            // Arrange
            var mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(service => service.IsEmailValid(It.IsAny<string>())).Returns(true);
            var viewModel = new CreateUserAccountViewModel(mockAccountService.Object);

            // Act
            bool result = viewModel.IsEmailValid("test@example.com");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsEmailValid_InvalidEmail_ReturnsFalse()
        {
            // Arrange
            var mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(service => service.IsEmailValid(It.IsAny<string>())).Returns(false);
            var viewModel = new CreateUserAccountViewModel(mockAccountService.Object);

            // Act
            bool result = viewModel.IsEmailValid("invalidemail");

            // Assert
            Assert.False(result);
        }
    }
}
