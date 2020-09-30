using System.Linq;
using CinemaBoxOffice.API.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CinemaBoxOffice.API.Interfaces;
using CinemaBoxOffice.API.Models.Session;
using CinemaBoxOffice.API.Models.Common.Api;

namespace CinemaBoxOffice.API.Services
{
    public class SessionService : ISessionService
    {
        private readonly DataContext _dataContext;

        public SessionService(DataContext context)
        {
            _dataContext = context;
        }

        public List<SessionModel> All()
        {
            return _dataContext.Sessions.Include(s => s.Reservation).ToList();
        }

        public SessionModel Get(int sessionId)
        {
            return _dataContext.Sessions.Include(s => s.Reservation).FirstOrDefault(s => s.Id == sessionId);
        }

        public OperationResponse CreateOrEdit(SessionModel model)
        {
            SessionModel session = null;

            if (model.Id != 0)
                session = _dataContext.Sessions.FirstOrDefault(s => s.Id == model.Id);
            else
                session = new SessionModel();

            if (session == null)
                return new OperationResponse { Success = false, Message = "Session not found" };

            session.Name = model.Name;
            session.Date = model.Date;

            if (model.Id == 0)
                _dataContext.Sessions.Add(session);

            _dataContext.SaveChanges();
            return new OperationResponse { Success = true };
        }

        public OperationResponse Delete(int sessionId)
        {
            var session = _dataContext.Sessions.FirstOrDefault(s => s.Id == sessionId);
            if (session == null)
                return new OperationResponse { Success = false, Message = "Session not found" };

            _dataContext.Sessions.Remove(session);
            _dataContext.SaveChanges();

            return new OperationResponse { Success = true };
        }   
    }
}