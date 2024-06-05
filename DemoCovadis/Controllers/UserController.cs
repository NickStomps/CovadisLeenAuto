using CovadisAPI.Entities;
using CovadisAPI.Services;
using DemoCovadis.Shared;
using DemoCovadis.Shared.Enums;
using DemoCovadis.Shared.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CovadisAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(UserService userService) : ControllerBase
{
    private readonly UserService userService = userService;

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = userService.GetUsers();
        return Ok(users);
    }

    // Door het toevoegen van de fallback policy mag je hier niet bij als je niet ingelogd bent
    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = userService.GetUserById(id);
        return Ok(user);
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        var createdUser = userService.CreateUser(user);

        return Ok(createdUser);
    }

    [Authorize(Roles = nameof(UserRole.User))]
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        throw new NotImplementedException();
    }

    [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.User))]
    [HttpPatch("assign-role")]
    public IActionResult AssignRole([FromBody] AssignRoleRequest request)
    {
        var result = userService.AssignRole(request);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
