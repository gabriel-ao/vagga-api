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
         [HttpGet("GetVacancyById")]
        public ActionResult<GetVagancyByIdOutput> GetVacancyById(Guid vacancyId)
        {
            return Ok("GetVacancyById nao implementado");
        }

        [HttpGet("GetVacancyByUserId")]
        public ActionResult<GetVagancyByUserIdOutput> GetVacancyByUserId(Guid userId)
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