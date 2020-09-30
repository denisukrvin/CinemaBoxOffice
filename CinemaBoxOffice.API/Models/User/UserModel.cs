using Newtonsoft.Json;
using System.Collections.Generic;
using CinemaBoxOffice.API.Models.Reservation;

namespace CinemaBoxOffice.API.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }

        public ICollection<ReservationModel> Reservations { get; set; }
    }
}