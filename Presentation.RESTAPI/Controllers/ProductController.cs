using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
    }
}

