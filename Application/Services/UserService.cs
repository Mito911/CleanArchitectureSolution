using Core.Entities;
using Core.Interfaces;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.AddUserAsync(user);
        }
    }
}





