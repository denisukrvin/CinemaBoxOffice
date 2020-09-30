using CinemaBoxOffice.API.Models.Auth;
using CinemaBoxOffice.API.Models.Common.Api;

namespace CinemaBoxOffice.API.Interfaces
{
    public interface IAuthService
    {
        OperationResponse Login(LoginModel model);
        OperationResponse Register(RegisterModel model);
    }
}