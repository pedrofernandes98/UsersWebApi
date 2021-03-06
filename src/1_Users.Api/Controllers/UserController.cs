using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.Api.Utilities;
using Users.Api.ViewModels;
using Users.Core.Exceptions;
using Users.Services.DTO;
using Users.Services.Interfaces;

namespace Users.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _userService.Get();
                return Ok(new ResultViewModel
                {
                    Message = "Lista de usuários cadastrados recuperada com sucesso!",
                    IsSuccess = true,
                    Data = users
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (System.Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var user = await _userService.Get(id);
                var message = user == null ? $"Nenhum usuário encontrado com o Id: {id}." : "Usuário encontrado com sucesso!";

                return Ok(new ResultViewModel
                {
                    Message = message,
                    IsSuccess = true,
                    Data = user
                });

            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        [HttpPost]
        [Authorize]
        [Route("/api/v1/users")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var userCreated = await _userService.Create(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso!",
                    IsSuccess = true,
                    Data = userCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Authorize]
        [Route("/api/v1/users")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel updateUserViewModel)
        {
            try
            {
                var userUpdated = await _userService.Update(_mapper.Map<UserDTO>(updateUserViewModel));
                return Ok(new ResultViewModel
                {
                    Message = "Usuário editado com sucesso!",
                    IsSuccess = true,
                    Data = userUpdated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("/api/v1/users/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _userService.Delete(id);
                return Ok(new ResultViewModel
                {
                    Message = "Usuário excluído com sucesso!",
                    IsSuccess = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/getbyname/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var user = await _userService.GetByName(name);
                var message = user == null ? $"Nenhum usuário encontrado com o nome: {name}." : "Usuário encontrado com sucesso!";

                return Ok(new ResultViewModel
                {
                    Message = message,
                    IsSuccess = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/searchbyname/")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var users = await _userService.SearchByName(name);
                var message = users.Count == 0 ? $"Nenhum usuário encontrado com o nome: {name}." : "Lista de usuários recuperada com sucesso!";

                return Ok(new ResultViewModel
                {
                    Message = message,
                    IsSuccess = true,
                    Data = users
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/getbyemail/")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _userService.GetByEmail(email);
                var message = user == null ? $"Nenhum usuário encontrado com o e-mail: {email}." : "Usuário encontrado com sucesso!";

                return Ok(new ResultViewModel
                {
                    Message = message,
                    IsSuccess = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/searchbyemail/")]
        public async Task<IActionResult> SearchByEmail([FromQuery] string email)
        {
            try
            {
                var users = await _userService.SearchByEmail(email);
                var message = users.Count == 0 ? $"Nenhum usuário encontrado com o e-mail: {email}." : "Lista de usuários recuperada com sucesso!";

                return Ok(new ResultViewModel
                {
                    Message = message,
                    IsSuccess = true,
                    Data = users
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}