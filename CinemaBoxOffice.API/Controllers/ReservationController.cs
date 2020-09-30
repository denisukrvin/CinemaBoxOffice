using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CinemaBoxOffice.API.Helpers;
using CinemaBoxOffice.API.Extensions;
using CinemaBoxOffice.API.Interfaces;
using CinemaBoxOffice.API.Models.Reservation.Api;

namespace CinemaBoxOffice.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]   
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var reservations = _reservationService.All();
            return Ok(reservations);
        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get(int reservationId)
        {
            if (reservationId == 0)
                return BadRequest();

            var reservation = _reservationService.Get(reservationId);
            return Ok(reservation);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateReservationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = HttpContext.GetUserId();
            var result = _reservationService.Create(userId, model.SessionId);
            return Ok(result);
        }

        [HttpGet]
        [Route("delete")]
        public IActionResult Delete(int reservationId)
        {
            if (reservationId == 0)
                return BadRequest();

            var result = _reservationService.Delete(reservationId);
            return Ok(result);
        }
    }
}