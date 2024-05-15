using CovadisAPI.Entities;
using CovadisAPI.Services;
using DemoCovadis.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CovadisAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;

        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = userService.GetUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            var createdUser = userService.CreateUser(user);
            return Ok(createdUser);
        }
    }

}




