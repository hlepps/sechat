using seChat.Server.Models;

namespace seChat.Server.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext context;

        public UserRepository(UserContext context) {
            this.context = context;
        }
        public User? Create(User user)
        {
            if (context.Users.Where(u => u.Name == user.Name).Count() != 0)
                return null;

            context.Users.Add(user);
            context.SaveChanges();
            user.Id = context.Users.Single(u => u.Name == user.Name).Id;

            return user;
        }

        public User? GetByName(string name)
        {
            return context.Users.FirstOrDefault(u => u.Name == name);
        }

        public User? GetById(int id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
