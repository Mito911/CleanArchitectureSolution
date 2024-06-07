using Application.Services;
using Core.Entities;
using Core.Interfaces;
using Moq;
using Xunit;

namespace CleanArchitectureSolution.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockProductRepository.Object);
        }

        [Fact]
        public void GetProduct_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var productId = 1;
            var product = new Product { Id = productId, Name = "Test Product", Price = 10 };
            _mockProductRepository.Setup(repo => repo.GetProduct(productId)).Returns(product);

            // Act
            var result = _productService.GetProduct(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productId, result.Id);
        }

        [Fact]
        public void GetProduct_ShouldReturnNull_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = 1;
            _mockProductRepository.Setup(repo => repo.GetProduct(productId)).Returns((Product)null);

            // Act
            var result = _productService.GetProduct(productId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void CreateProduct_ShouldAddProduct()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Test Product", Price = 10 };
            _mockProductRepository.Setup(repo => repo.AddProduct(product));

            // Act
            _productService.CreateProduct(product);

            // Assert
            _mockProductRepository.Verify(repo => repo.AddProduct(product), Times.Once);
        }
    }
}

