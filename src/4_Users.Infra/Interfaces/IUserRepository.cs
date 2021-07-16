using Users.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Users.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByName(string name);

        Task<List<User>> SearchByName(string name);

        Task<User> GetByEmail(string email);

        Task<List<User>> SearchByEmail(string email);
    }
}