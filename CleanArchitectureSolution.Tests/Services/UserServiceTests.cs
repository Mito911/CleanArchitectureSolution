using Application.Services;
using Core.Entities;
using Core.Interfaces;
using Moq;
using Xunit;
using System.Threading.Tasks;

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
        public async Task GetUser_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var user = new User { Id = userId, Username = "Test User", Password = "password" };
            _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(user);

            // Act
            var result = await _userService.GetUser(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
        }

        [Fact]
        public async Task GetUser_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = 1;
            _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync((User)null);

            // Act
            var result = await _userService.GetUser(userId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateUser_ShouldAddUser()
        {
            // Arrange
            var user = new User { Id = 1, Username = "Test User", Password = "password" };
            _mockUserRepository.Setup(repo => repo.AddUserAsync(user)).Returns(Task.CompletedTask);

            // Act
            await _userService.CreateUser(user);

            // Assert
            _mockUserRepository.Verify(repo => repo.AddUserAsync(user), Times.Once);
        }
    }
}



