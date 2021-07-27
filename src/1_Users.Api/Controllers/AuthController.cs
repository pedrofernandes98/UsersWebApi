using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Users.Api.Token;
using Users.Api.Utilities;
using Users.Api.ViewModels;

namespace Users.Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        private readonly ITokenGenerator _tokenGenerator;
        public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [Route("/api/v1/auth")]
        public IActionResult Auth([FromBody] AuthViewModel authViewModel)
        {
            try
            {
                var tokenLogin = _configuration["Jwt:Login"];
                var tokenPassword = _configuration["Jwt:Password"];

                if (authViewModel.Login == tokenLogin &&
                    authViewModel.Password == tokenPassword) //Buscar do DB :TODO:
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Usuário autenticado e token gerado com sucesso",
                        IsSuccess = true,
                        Data = new
                        {
                            Token = _tokenGenerator.GenerateToken(),
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                        }
                    });
                }
                else
                {
                    return Unauthorized(Responses.UnauthorizedErrorMessage());
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}