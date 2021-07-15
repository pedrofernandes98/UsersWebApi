using Users.Domain.Entities;
using Users.Infra.Interfaces;
using Users.Infra.Context;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Users.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly UsersContext _context;

        public UserRepository(UsersContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> GetByName(string name)
        {
            var user = await _context.Users
                                     .AsNoTracking()
                                     .Where(x => x.Name.ToUpper() == name.ToUpper())
                                     .FirstOrDefaultAsync();

            return user;
        }

        public async Task<List<User>> SearchByName(string name)
        {
            var ListUsers = await _context.Users
                                          .AsNoTracking()
                                          .Where(x => x.Name.ToUpper().Contains(name.ToUpper()))
                                          .ToListAsync();

            return ListUsers;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users
                                     .AsNoTracking()
                                     .Where(x => x.Email.ToUpper() == email.ToUpper())
                                     .FirstOrDefaultAsync();

            return user;
        }

        public async Task<List<User>> SearchByEmail(string email)
        {
            var ListUsers = await _context.Users
                                          .AsNoTracking()
                                          .Where(x => x.Email.ToUpper().Contains(email.ToUpper()))
                                          .ToListAsync();

            return ListUsers;
        }
    }
}