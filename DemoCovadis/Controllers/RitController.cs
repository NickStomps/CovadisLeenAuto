using DemoCovadis.Entities;
using DemoCovadis.Services;
using DemoCovadis.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoCovadis.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]

public class RitController(RitService ritService) : ControllerBase
{
    private readonly RitService ritService = ritService;
    [HttpGet]
    public IActionResult GetRitten()
    {
        var ritten = ritService.GetRitten();
        return Ok(ritten);
    }

    [HttpGet("{id}")]
    public IActionResult GetRit(int id)
    {
        var rit = ritService.GetRitById(id);
        return Ok(rit);
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPost]
    public IActionResult CreateRit([FromBody] Rit rit)
    {
        var createdUser = ritService.CreateRit(rit);

        return Ok(createdUser);
    }

    [Authorize(Roles = nameof(UserRole.User))]
    [HttpPut("{id}")]
    public IActionResult UpdateRit(int id, [FromBody] Rit rit)
    {
        throw new NotImplementedException();
    }
}
