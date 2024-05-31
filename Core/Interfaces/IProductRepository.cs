using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        void AddProduct(Product product);
    }
}
