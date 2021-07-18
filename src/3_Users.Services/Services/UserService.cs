using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Users.Core.Exceptions;
using Users.Domain.Entities;
using Users.Infra.Interfaces;
using Users.Services.DTO;
using Users.Services.Interfaces;

namespace Users.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);

            if (userExists != null)
                throw new DomainException($"Já existe um usário cadastrado com o e-mail {userDTO.Email}.");

            var newUser = _mapper.Map<User>(userDTO);
            newUser.Validate();

            var userCreated = await _userRepository.Create(newUser);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.Get(userDTO.Id);

            if (userExists == null)
                throw new DomainException($"O usuário de Id {userDTO.Id} não foi encontrado.");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userUpdated = await _userRepository.Update(user);

            return _mapper.Map<UserDTO>(userUpdated);
        }
        public async Task Delete(long id)
        {
            var userExists = await _userRepository.Get(id);

            if (userExists == null)
                throw new DomainException($"O usuário de Id {id} não foi encontrado.");

            await _userRepository.Delete(id);
        }

        public async Task<UserDTO> Get(long id)
        {
            var user = await _userRepository.Get(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> Get()
        {
            var listUsers = await _userRepository.Get();

            return _mapper.Map<List<UserDTO>>(listUsers);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetByName(string name)
        {
            var user = await _userRepository.GetByName(name);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var listUsers = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(listUsers);
        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var listUsers = await _userRepository.SearchByName(name);

            return _mapper.Map<List<UserDTO>>(listUsers);
        }


    }
}