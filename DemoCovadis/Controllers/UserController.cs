using DemoCovadis.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DemoCovadis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static List<User> Users = new List<User>
        {
           new User
           {
               Name = "Test",
               Email = "Mail",
               Password = "Secret password"
           }
        };


        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;

            new User();
        }

        [HttpGet(Name = "Users")]
        public IActionResult Get()
        {
            var userDtos = Users.Select(user => new UserDto
            {
                Name = user.Name,
                Email = user.Email
            });
               
            
            return Ok(userDtos);
        }
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            Users.Add(user);
           return Ok();
        }
    }
}


public class User
{
    public string Name { get; set; }
    public string Email { get; set; }

    public string Password { get; set; }
}

