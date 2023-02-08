using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Vagga.Domain.Models.Base;
using Vagga.Domain.Models.Input;
using Vagga.Domain.Models.Output;

namespace vagga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VacancyController : ControllerBase
    {

        //[Authorize(Roles = "User")]  - TODO: implementar autorization
        [HttpGet("GetExampleController")]
        public ActionResult GetExampleController()
        {
            var language = Request.Headers["Accept-Language"];
            return Ok("Api funcionando");
        }

        [HttpGet("GetVacancyById")]
        public ActionResult GetVacancyById()
        {
            return Ok("GetVacancyById nao implementado");
        }

        [HttpGet("GetVacancyByUserId")]
        public ActionResult GetVacancyByUserId()
        {
            return Ok("GetVacancyByUserId nao implementado");
        }

        [HttpPost("SaveVacancy")]
        public ActionResult<BaseOutput> SaveVacancy(SaveVacancyInput input)
        {
            return Ok("GetVacancyByUserId nao implementado");
        }

    }
}