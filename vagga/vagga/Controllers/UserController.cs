using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Vagga.Domain.Models.Output;

namespace vagga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        //[Authorize(Roles = "User")]  - TODO: implementar autorization
        [HttpGet("GetExampleController")]
        public IActionResult GetExampleController()
        {
            var language = Request.Headers["Accept-Language"];
            return Ok("Api funcionando");
        }

        //TODO - criar usuario
        //TODO - alterar senha

    }
}