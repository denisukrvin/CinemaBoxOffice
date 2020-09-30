using System.ComponentModel.DataAnnotations;

namespace CinemaBoxOffice.API.Models.Auth
{
    public class RegisterModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(30, MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [StringLength(20, MinimumLength = 6)]
        public string PasswordConfirm { get; set; }
    }
}