using System.ComponentModel.DataAnnotations;

namespace CinemaBoxOffice.API.Models.Auth
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [StringLength(30, MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}