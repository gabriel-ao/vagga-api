using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Vagga.Domain.Interfaces.Services;
using Vagga.Domain.Models.Base;
using Vagga.Domain.Models.Input;
using Vagga.Domain.Models.Output;

namespace vagga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[Authorize(Roles = "User")]  - TODO: implementar autorization
        //TODO - criar usuario
        [HttpPost("CreateUser")]
        public ActionResult<BaseOutput> CreateUser(UserInput input)
        {
            var result = _userService.CreateUser(input);

            return Ok(result);
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