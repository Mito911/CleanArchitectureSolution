using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        public void CreateProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }
        public async Task CreateProductAsync(Product product)
        {
            await _productRepository.AddProductAsync(product);
        }
    }
}
