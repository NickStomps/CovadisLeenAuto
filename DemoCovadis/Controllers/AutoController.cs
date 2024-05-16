using CovadisAPI.Services;
using DemoCovadis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCovadis.Controllers
{
    [Authorize]
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
            var autos = AutoService.getAutos();
            return Ok(autos);
        }
    }
}
