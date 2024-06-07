using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.RazorPages.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public IndexModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = (IList<Product>)await _productRepository.GetAllProductsAsync();
        }
    }
}
