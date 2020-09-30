﻿using CinemaBoxOffice.API.Models.User;

namespace CinemaBoxOffice.API.Interfaces
{
    public interface IUserService
    {
        UserModel Get(string email);
        UserModel Create(UserModel model);
    }
}