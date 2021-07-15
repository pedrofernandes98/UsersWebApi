using Users.Domain.Entities;
using Users.Infra.Interfaces;
using Users.Infra.Context;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Users.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly UsersContext _context;

        public BaseRepository(UsersContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Get(long id)
        {
            var obj = _context.Set<T>()
                              .AsNoTracking()
                              .Where(x => x.Id == id)
                              .FirstOrDefaultAsync();

            return obj;
        }

        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            //_context.Entry(obj).State = EntityState.Modified
            _context.Update(obj);
            _context.SaveChangesAsync();

            return obj;
        }

        public virtual async void Remove(long id)
        {
            var obj = _context.Get(id);

            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
    }
}