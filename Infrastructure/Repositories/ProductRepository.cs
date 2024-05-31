using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Product GetProduct(int productId)
        {
            return _context.Products.Find(productId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        // Implement other methods as needed
    }
}

