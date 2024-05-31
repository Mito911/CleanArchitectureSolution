using Application.Services;
using Core.Entities;
using Core.Interfaces;
using Moq;
using Xunit;

namespace CleanArchitectureSolution.Tests.Services
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly OrderService _orderService;

        public OrderServiceTests()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _orderService = new OrderService(_mockOrderRepository.Object);
        }

        [Fact]
        public void GetOrder_ShouldReturnOrder_WhenOrderExists()
        {
            // Arrange
            var orderId = 1;
            var order = new Order { Id = orderId, ProductId = 2, Quantity = 3, UserId = 1 };
            _mockOrderRepository.Setup(repo => repo.GetOrderById(orderId)).Returns(order);

            // Act
            var result = _orderService.GetOrder(orderId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(orderId, result.Id);
        }

        [Fact]
        public void GetOrder_ShouldReturnNull_WhenOrderDoesNotExist()
        {
            // Arrange
            var orderId = 1;
            _mockOrderRepository.Setup(repo => repo.GetOrderById(orderId)).Returns((Order)null);

            // Act
            var result = _orderService.GetOrder(orderId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void CreateOrder_ShouldAddOrder()
        {
            // Arrange
            var order = new Order { Id = 1, ProductId = 2, Quantity = 3, UserId = 1 };
            _mockOrderRepository.Setup(repo => repo.AddOrder(order));

            // Act
            _orderService.CreateOrder(order);

            // Assert
            _mockOrderRepository.Verify(repo => repo.AddOrder(order), Times.Once);
        }
    }
}
