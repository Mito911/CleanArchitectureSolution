using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public void CreateUser(User user)
        {
            _userRepository.AddUser(user);
        }
    }
}


