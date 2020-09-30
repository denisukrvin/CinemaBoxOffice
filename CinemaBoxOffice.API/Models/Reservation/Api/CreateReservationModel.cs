using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaBoxOffice.API.Models.Reservation.Api
{
    public class CreateReservationModel
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int SessionId { get; set; }
    }
}