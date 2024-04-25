using CovadisAPI.Entities;
using CovadisAPI.Services;
using DemoCovadis.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CovadisAPI.Controllers
{
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

        //[HttpGet(Name = "Users")]
        //public IActionResult Get()
        //{
        //    var usersDtos = userService.Select(user => new UserDto
        //    {
        //        Name = user.Name,
        //        Email = user.Email
        //    });
        //    return Ok(usersDtos);
        //}
    }

}




