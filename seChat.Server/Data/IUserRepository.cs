using seChat.Server.Models;

namespace seChat.Server.Data
{
    public interface IUserRepository
    {
        User? Create(User user);
        User? GetByName(string name);
        User? GetById(int id);
    }
}
