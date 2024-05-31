using Application.Services;
using Core.Entities;
using Core.Interfaces;
using Moq;
using Xunit;

namespace CleanArchitectureSolution.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockUserRepository.Object);
        }

        [Fact]
        public void GetUser_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var user = new User { Id = userId, Username = "Test User", Password = "password" };
            _mockUserRepository.Setup(repo => repo.GetUserById(userId)).Returns(user);

            // Act
            var result = _userService.GetUser(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
        }

        [Fact]
        public void GetUser_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = 1;
            _mockUserRepository.Setup(repo => repo.GetUserById(userId)).Returns((User)null);

            // Act
            var result = _userService.GetUser(userId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void CreateUser_ShouldAddUser()
        {
            // Arrange
            var user = new User { Id = 1, Username = "Test User", Password = "password" };
            _mockUserRepository.Setup(repo => repo.AddUser(user));

            // Act
            _userService.CreateUser(user);

            // Assert
            _mockUserRepository.Verify(repo => repo.AddUser(user), Times.Once);
        }
    }
}

