using System.Collections.Generic;
using CinemaBoxOffice.API.Models.Session;
using CinemaBoxOffice.API.Models.Common.Api;

namespace CinemaBoxOffice.API.Interfaces
{
    public interface ISessionService
    {
        List<SessionModel> All();
        SessionModel Get(int sessionId);
        OperationResponse CreateOrEdit(SessionModel model);
        OperationResponse Delete(int sessionId);
    }
}