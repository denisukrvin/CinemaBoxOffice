using System.Linq;
using CinemaBoxOffice.API.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CinemaBoxOffice.API.Interfaces;
using CinemaBoxOffice.API.Models.Common.Api;
using CinemaBoxOffice.API.Models.Reservation;

namespace CinemaBoxOffice.API.Services
{
    public class ReservationService : IReservationService
    {
        private readonly DataContext _dataContext;

        public ReservationService(DataContext context)
        {
            _dataContext = context;
        }

        public List<ReservationModel> All()
        {
            return _dataContext.Reservations.Include(r => r.Session).ToList();
        }

        public ReservationModel Get(int reservationId)
        {
            return _dataContext.Reservations.Include(r => r.Session).FirstOrDefault(r => r.Id == reservationId);
        }

        public OperationResponse Create(int userId, int sessionId)
        {
            var reservation = new ReservationModel
            {
                UserId = userId,
                SessionId = sessionId
            };

            _dataContext.Add(reservation);
            _dataContext.SaveChanges();

            return new OperationResponse { Success = true };
        }

        public OperationResponse Delete(int reservationId)
        {
            var reservation = _dataContext.Reservations.FirstOrDefault(s => s.Id == reservationId);
            if (reservation == null)
                return new OperationResponse { Success = false, Message = "Reservation not found" };

            _dataContext.Reservations.Remove(reservation);
            _dataContext.SaveChanges();

            return new OperationResponse { Success = true };
        }
    }
}