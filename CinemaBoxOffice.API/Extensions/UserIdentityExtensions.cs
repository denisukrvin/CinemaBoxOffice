using Microsoft.AspNetCore.Http;
using CinemaBoxOffice.API.Models.User;

namespace CinemaBoxOffice.API.Extensions
{
    public static class UserIdentityExtensions
    {
        public static int GetUserId(this HttpContext context)
        {
            var user = (UserModel) context.Items["User"];
            return user.Id;
        }
    }
}