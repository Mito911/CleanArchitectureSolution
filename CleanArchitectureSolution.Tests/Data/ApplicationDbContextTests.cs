using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace CleanArchitectureSolution.Tests.Data
{
    public class ApplicationDbContextTests : IDisposable
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
        }

        [Fact]
        public void CanAddOrderToDatabase()
        {
            // Arrange
            var order = new Core.Entities.Order { Id = 1, ProductId = 2, Quantity = 3, UserId = 1 };

            // Act
            _context.Orders.Add(order);
            _context.SaveChanges();

            // Assert
            var savedOrder = _context.Orders.Find(1);
            Assert.NotNull(savedOrder);
            Assert.Equal(1, savedOrder.Id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
