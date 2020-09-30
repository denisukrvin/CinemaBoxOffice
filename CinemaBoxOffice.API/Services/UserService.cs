using System.Linq;
using CinemaBoxOffice.API.Data;
using CinemaBoxOffice.API.Interfaces;
using CinemaBoxOffice.API.Models.User;

namespace CinemaBoxOffice.API.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;

        public UserService(DataContext context)
        {
            _dataContext = context;
        }

        public UserModel Get(string email)
        {
            return _dataContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public UserModel Create(UserModel model)
        {
            _dataContext.Add(model);
            _dataContext.SaveChanges();

            return model;
        }
    }
}