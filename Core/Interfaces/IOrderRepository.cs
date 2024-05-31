using Core.Entities;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        Order GetOrderById(int id);
        void AddOrder(Order order);
    }
}
