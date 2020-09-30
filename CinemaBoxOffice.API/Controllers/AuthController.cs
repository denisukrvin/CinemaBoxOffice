using Microsoft.AspNetCore.Mvc;
using CinemaBoxOffice.API.Interfaces;
using CinemaBoxOffice.API.Models.Auth;

namespace CinemaBoxOffice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _authService.Login(model);
            return Ok(result);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _authService.Register(model);
            return Ok(result);
        }
    }
}