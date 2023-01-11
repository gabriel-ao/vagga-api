using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Vagga.Domain.Models.Output;

namespace vagga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VacancyController : ControllerBase
    {

        //[Authorize(Roles = "User")]  - TODO: implementar autorization
        [HttpGet("GetExampleController")]
        public IActionResult GetExampleController()
        {
            var language = Request.Headers["Accept-Language"];
            return Ok("Api funcionando");
        }

        [HttpGet("GetVacancyById")]
        public IActionResult GetVacancyById()
        {
            return Ok("GetVacancyById nao implementado");
        }

        [HttpGet("GetVacancyByUserId")]
        public IActionResult GetVacancyByUserId()
        {
            return Ok("GetVacancyByUserId nao implementado");
        }

    }
}