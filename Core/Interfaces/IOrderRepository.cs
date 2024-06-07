using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(int id);  // Asynchronous method
        Task<IEnumerable<Order>> GetAllOrdersAsync();  // Asynchronous method
        Task AddOrderAsync(Order order);  // Asynchronous method
        Order GetOrderById(int id);  // Synchronous method
        IEnumerable<Order> GetAllOrders();  // Synchronous method
        void AddOrder(Order order);  // Synchronous method
    }
}

