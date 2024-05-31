using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }
    }
}
