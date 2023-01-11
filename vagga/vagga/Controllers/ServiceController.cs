using Microsoft.AspNetCore.Mvc;

namespace Vagga.API.Controllers
{
    public class ServiceController : ControllerBase
    {
        [HttpGet("GetServiceById")]
        public IActionResult GetServiceById()
        {
            var language = Request.Headers["Accept-Language"];
            return Ok("GetServiceById nao foi implementado");
        }

        [HttpGet("GetServiceByUserVehicleId")]
        public IActionResult GetServiceByUserVehicleId()
        {
            return Ok("GetServiceByUserVehicleId nao implementado");
        }

        [HttpGet("GetServiceByUserVacancyId")]
        public IActionResult GetServiceByUserVacancyId()
        {
            return Ok("GetServiceByUserVacancyId nao implementado");
        }

    }
}
