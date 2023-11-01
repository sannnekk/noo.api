using api.Models.Auth;
using api.Models.DB;
using api.Models.Enums;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {       
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login(LoginModel model)
        {
            var user = _authService.Authenticate(model);

            if(user != null)
            {
                var token = _authService.GenerateJWTToken(user);
                return Ok(token);
            }

            return BadRequest();
        }

        [HttpGet("/admin")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult TestAdmin()
        {

            return Ok($"Login an admin {GetCurrentUserName()}");
        }

        [HttpGet("/teacher")]
        [Authorize(Roles = nameof(UserRole.Teacher))]
        public IActionResult TestTeacher()
        {
            return Ok($"Login an teacher {GetCurrentUserName()}");
        }

        private string GetCurrentUserName()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if(identity != null)
            {
                var userClaims = identity.Claims;

                return userClaims.FirstOrDefault(e => e.Type == ClaimTypes.GivenName).Value.ToString();
            }

            return null;
        }
    }
}
