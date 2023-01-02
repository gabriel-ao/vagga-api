using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Vagga.Domain.Interfaces.Services;
using Vagga.Domain.Models.Input;
using Vagga.Domain.Models.Output;

namespace vagga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("Auth")]
        public IActionResult Auth(LoginInput login)
        {
            //TODO - PASSAR EMAIL E SENHA PELO HEADERS

            //var email = Request.Headers["email"];
            //var password = Request.Headers["password"];

            var email = login.Email;
            var password = login.Password;

            var result = _service.Auth(email, password);

            return Ok(result);
        }
    }
}