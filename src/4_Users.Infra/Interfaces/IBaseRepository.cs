using Users.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Users.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base //Interface genérica para uma entidade que herda de Users.Domain.Entities.Base
    {
        Task<T> Get(long id);
        Task<List<T>> Get();
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task Delete(long id);
    }
}