using System.Collections.Generic;
using CinemaBoxOffice.API.Models.Common.Api;
using CinemaBoxOffice.API.Models.Reservation;

namespace CinemaBoxOffice.API.Interfaces
{
    public interface IReservationService
    {
        List<ReservationModel> All();
        ReservationModel Get(int reservationId);
        OperationResponse Create(int userId, int sessionId);
        OperationResponse Delete(int reservationId);
    }
}