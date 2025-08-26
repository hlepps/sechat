using seChat.Server.Models;

namespace seChat.Server.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext context;

        public UserRepository(UserContext context) {
            this.context = context;
        }
        public User Create(User user)
        {
            context.Users.Add(user);
            user.Id = context.SaveChanges();

            return user;
        }
    }
}
