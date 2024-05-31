using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        void AddUser(User user);
    }
}


