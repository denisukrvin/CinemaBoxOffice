using System;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using CinemaBoxOffice.API.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CinemaBoxOffice.API.Interfaces;
using CinemaBoxOffice.API.Models.User;
using System.IdentityModel.Tokens.Jwt;
using CinemaBoxOffice.API.Models.Auth;
using CinemaBoxOffice.API.Models.Common.Api;

namespace CinemaBoxOffice.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;

        public AuthService(IOptions<AppSettings> appSettings, IUserService userService)
        {
            _appSettings = appSettings.Value;
            _userService = userService;
        }

        public OperationResponse Login(LoginModel model)
        {
            var user = _userService.Get(model.Email);
            if (user == null)
                return new OperationResponse() { Success = false, Message = "User not found" };

            bool isPasswordCorrect = SecurePasswordHasher.Verify(model.Password, user.Password);
            if (!isPasswordCorrect)
                return new OperationResponse() { Success = false, Message = "Invalid password" };

            var token = GenerateJwtToken(user);
            return new OperationResponse { Success = true, Data = new Dictionary<string, object> { { "token", token } } };
        }

        public OperationResponse Register(RegisterModel model)
        {
            var user = _userService.Get(model.Email);
            if (user != null)
                return new OperationResponse() { Success = false, Message = "This email address is already being used" };

            // create user
            var userModel = new UserModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = SecurePasswordHasher.Hash(model.Password)
            };

            var result = _userService.Create(userModel);
            if (result == null)
                return new OperationResponse() { Success = false, Message = "Something went wrong, please try again later" };

            var token = GenerateJwtToken(result);
            return new OperationResponse() { Success = true, Data = new Dictionary<string, object> { { "token", token } } };
        }

        private string GenerateJwtToken(UserModel model)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("user_id", model.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}