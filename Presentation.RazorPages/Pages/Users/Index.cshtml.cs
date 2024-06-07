using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.RazorPages.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public IndexModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = (IList<User>)await _userRepository.GetAllUsersAsync();
        }
    }
}
