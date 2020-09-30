using CinemaBoxOffice.API.Models.User;
using CinemaBoxOffice.API.Models.Session;

namespace CinemaBoxOffice.API.Models.Reservation
{
    public class ReservationModel
    {
        public int Id { get; set; }

        // user
        public int UserId { get; set; }
        public UserModel User { get; set; }

        // session
        public int SessionId { get; set; }
        public SessionModel Session { get; set; }
    }
}