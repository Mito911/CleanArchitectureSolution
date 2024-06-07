using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Presentation.RazorPages.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public CreateModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        public User User { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _userRepository.AddUserAsync(User);
            return RedirectToPage("./Index");
        }
    }
}
