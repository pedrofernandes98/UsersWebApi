using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Services.DTO;

namespace Users.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO user);

        Task<UserDTO> Update(UserDTO user);

        Task Delete(long id);

        Task<UserDTO> Get(long id);

        Task<List<UserDTO>> Get();

        Task<UserDTO> GetByName(string name);

        Task<List<UserDTO>> SearchByName(string name);

        Task<UserDTO> GetByEmail(string email);

        Task<List<UserDTO>> SearchByEmail(string email);
    }
}