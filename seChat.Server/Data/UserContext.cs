using Microsoft.EntityFrameworkCore;
using seChat.Server.Models;
using System.Reflection.Emit;

namespace seChat.Server.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(u =>
            {
                u.HasIndex(u => u.Name).IsUnique();
            });
        }
    }
}
