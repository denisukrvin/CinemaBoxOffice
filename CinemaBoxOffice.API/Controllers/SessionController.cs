using Microsoft.AspNetCore.Mvc;
using CinemaBoxOffice.API.Helpers;
using CinemaBoxOffice.API.Interfaces;
using CinemaBoxOffice.API.Models.Session;

namespace CinemaBoxOffice.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var sessions = _sessionService.All();
            return Ok(sessions);
        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get(int sessionId)
        {
            if (sessionId == 0)
                return BadRequest();

            var session = _sessionService.Get(sessionId);
            return Ok(session);
        }

        [HttpPost]
        [Route("createoredit")]
        public IActionResult CreateOrEdit(SessionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _sessionService.CreateOrEdit(model);
            return Ok(result);
        }

        [HttpGet]
        [Route("delete")]
        public IActionResult Delete(int sessionId)
        {
            if (sessionId == 0)
                return BadRequest();

            var result = _sessionService.Delete(sessionId);
            return Ok(result);
        }
    }
}