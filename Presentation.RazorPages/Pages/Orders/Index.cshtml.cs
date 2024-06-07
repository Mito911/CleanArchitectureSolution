using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.RazorPages.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        public IndexModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IList<Order> Orders { get; set; }

        public async Task OnGetAsync()
        {
            Orders = (IList<Order>)await _orderRepository.GetAllOrdersAsync();
        }
    }
}
