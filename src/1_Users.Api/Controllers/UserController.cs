using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Users.Api.ViewModels;

namespace Users.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [Route("/api/v1/users")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                return Ok();
            }
            // catch (DomainException ex)
            // {
            //     return BadRequest();
            // }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}