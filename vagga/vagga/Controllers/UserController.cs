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
    public class UserController : ControllerBase
    {

        //[Authorize(Roles = "User")]  - TODO: implementar autorization
        //TODO - criar usuario
        [HttpPost("CreateUser")]
        public ActionResult<BaseOutput> CreateUser(UserInput input)
        {
            var language = Request.Headers["Accept-Language"];
            return Ok("CreateUser nao implementado");
        }

        //TODO - alterar senha
        [HttpPost("ResetPassword")]
        public ActionResult<BaseOutput> ResetPassword(ResetPasswordInput reset)
        {
            var language = Request.Headers["Accept-Language"];
            return Ok("ResetPassword nao implementado");
        }


    }
}