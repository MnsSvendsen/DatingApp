using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        public AutController(IAuthRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("registrer")]
        public async Task<IActionResult> Resgister(string username, string password)
        {
            //validate the request #endregio

            username = username.ToLower();

            if (await _repository.UserExist(username))
            {
                return BadRequest("Username already exsists");
            }

            var userToCreate = new User
            {
                Username = username
            };

            var createdUser = await _repository.Register(userToCreate,password);

            return StatusCode(201);
        }
    }
}