using seChat.Server.Models;

namespace seChat.Server.Data
{
    public interface IUserRepository
    {
        User Create(User user);
    }
}
