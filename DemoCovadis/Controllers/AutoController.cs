using CovadisAPI.Services;
using DemoCovadis.Entities;
using DemoCovadis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCovadis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoController : ControllerBase
    {
        private readonly AutoService autoService;

        public AutoController(AutoService autoService)
        {
            this.autoService = autoService;

        }
        [HttpGet]
        public IActionResult GetAutos()
        {
            var autos = autoService.GetAutos();
            return Ok(autos);
        }

        [HttpPost]
        public IActionResult SetAuto([FromBody] Auto auto)
        {
            var createdAuto = autoService.CreateAuto(auto);
            return Ok(createdAuto);
        }
    }
}