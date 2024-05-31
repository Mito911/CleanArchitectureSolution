using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order GetOrder(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.AddOrder(order);
        }
    }
}

