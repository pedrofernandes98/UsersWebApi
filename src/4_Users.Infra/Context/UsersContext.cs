using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;
using Users.Infra.Mappings;

namespace Users.Infra.Context
{
    public class UsersContext : DbContext
    {
        public UsersContext()
        { }
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}