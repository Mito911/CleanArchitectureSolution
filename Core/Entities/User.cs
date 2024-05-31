using System.Collections.Generic;

namespace Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}


