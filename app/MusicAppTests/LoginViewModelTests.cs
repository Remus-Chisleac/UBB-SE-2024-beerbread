using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAppTests
{
    using Xunit;
    using app.MVVM.Model.Domain;
    using app.MVVM.ViewModel;
    using Moq;

    public class LoginViewModelTests
    {
        private readonly Mock<IAccountService> mockAccountService;
        private readonly LoginViewModel loginViewModel;

        public LoginViewModelTests()
        {
            mockAccountService = new Mock<IAccountService>();
            loginViewModel = new LoginViewModel(mockAccountService.Object);
        }
        [Fact]
        public void LoginViewModel_DefaultConstructor_InitializesAccountService()
        {
            // Act
            var loginViewModel = new LoginViewModel();

            // Assert
            Assert.NotNull(loginViewModel); // Object should be created

            // To access private fields or properties, you may need reflection
            var accountServiceField = typeof(LoginViewModel).GetField("accountService", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            var accountService = accountServiceField.GetValue(loginViewModel);

            Assert.NotNull(accountService); // Should not be null
            Assert.IsType<AccountService>(accountService); // Should be of type AccountService
        }
        // Test setting AccountService
        [Fact]
        public void AccountService_Setter_SetsCorrectValue()
        {
            // Arrange
            var loginViewModel = new LoginViewModel();
            var mockAccountService = new Mock<IAccountService>();

            // Act
            loginViewModel.AccountService = mockAccountService.Object;

            // Assert
            Assert.Equal(mockAccountService.Object, loginViewModel.AccountService); // The property should return the set value
        }

        // Test getting AccountService after setting it
        [Fact]
        public void AccountService_Getter_ReturnsSetValue()
        {
            // Arrange
            var loginViewModel = new LoginViewModel();
            var mockAccountService = new Mock<IAccountService>();

            loginViewModel.AccountService = mockAccountService.Object; // Set a value

            // Act
            var accountService = loginViewModel.AccountService;

            // Assert
            Assert.Equal(mockAccountService.Object, accountService); // Should return the set value
        }

        // Test default AccountService value
        [Fact]
        public void AccountService_DefaultConstructor_IsNull()
        {
            // Arrange
            var loginViewModel = new LoginViewModel();

            // Act
            var accountService = loginViewModel.AccountService;

            // Assert
            Assert.Null(accountService); // Default constructor should leave AccountService null
        }

        // Test for valid email format
        [Fact]
        public void IsEmailValid_ValidEmail_ReturnsTrue()
        {
            // Arrange
            string validEmail = "user@example.com";
            mockAccountService.Setup(service => service.IsEmailValid(validEmail)).Returns(true);

            // Act
            bool result = loginViewModel.IsEmailValid(validEmail);

            // Assert
            Assert.True(result); // Email should be valid
        }

        // Test for invalid email format
        [Fact]
        public void IsEmailValid_InvalidEmail_ReturnsFalse()
        {
            // Arrange
            string invalidEmail = "invalid-email";
            mockAccountService.Setup(service => service.IsEmailValid(invalidEmail)).Returns(false);

            // Act
            bool result = loginViewModel.IsEmailValid(invalidEmail);

            // Assert
            Assert.False(result); // Email should be invalid
        }

        // Test for null email
        [Fact]
        public void IsEmailValid_NullEmail_ReturnsFalse()
        {
            // Act
            bool result = loginViewModel.IsEmailValid(null);

            // Assert
            Assert.False(result); // Null email should be invalid
        }

        // Test for empty email
        [Fact]
        public void IsEmailValid_EmptyEmail_ReturnsFalse()
        {
            // Act
            bool result = loginViewModel.IsEmailValid("");

            // Assert
            Assert.False(result); // Empty email should be invalid
        }

        // Test for valid password
        [Fact]
        public void IsPasswordValid_ValidPassword_ReturnsTrue()
        {
            // Arrange
            string validPassword = "SecurePassword123";

            // Act
            bool result = loginViewModel.IsPasswordValid(validPassword);

            // Assert
            Assert.True(result); // Password should be valid
        }

        // Test for invalid password (too short)
        [Fact]
        public void IsPasswordValid_InvalidPassword_ReturnsFalse()
        {
            // Arrange
            string invalidPassword = "12345"; // Too short

            // Act
            bool result = loginViewModel.IsPasswordValid(invalidPassword);

            // Assert
            Assert.False(result); // Password should be invalid
        }

        // Test for null password
        [Fact]
        public void IsPasswordValid_NullPassword_ReturnsFalse()
        {
            // Act
            bool result = loginViewModel.IsPasswordValid(null);

            // Assert
            Assert.False(result); // Null password should be invalid
        }

        // Test for empty password
        [Fact]
        public void IsPasswordValid_EmptyPassword_ReturnsFalse()
        {
            // Act
            bool result = loginViewModel.IsPasswordValid("");

            // Assert
            Assert.False(result); // Empty password should be invalid
        }

        // Test for valid credentials
        [Fact]
        public void AreAuthenticationCredentialsValid_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            string email = "user@example.com";
            string password = "SecurePassword123";
            mockAccountService.Setup(service => service.AreAuthenticationCredentialsValid(email, password)).Returns(true);

            // Act
            bool result = loginViewModel.AreAuthenticationCredentialsValid(email, password);

            // Assert
            Assert.True(result); // Credentials should be valid
        }

        // Test for invalid credentials
        [Fact]
        public void AreAuthenticationCredentialsValid_InvalidCredentials_ReturnsFalse()
        {
            // Arrange
            string email = "user@example.com";
            string password = "WrongPassword";
            mockAccountService.Setup(service => service.AreAuthenticationCredentialsValid(email, password)).Returns(false);

            // Act
            bool result = loginViewModel.AreAuthenticationCredentialsValid(email, password);

            // Assert
            Assert.False(result); // Credentials should be invalid
        }       

        // Test for failed authentication
        [Fact]
        public void AuthenticateAndGetCurrentUser_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            string email = "user@example.com";
            string password = "WrongPassword";
            mockAccountService.Setup(service => service.GetAccountWithCredentials(email, password)).Returns((User)null);

            // Act
            User result = loginViewModel.AuthenticateAndGetCurrentUser(email, password);

            // Assert
            Assert.Null(result); // Should return null due to invalid credentials
        }
    }

}
