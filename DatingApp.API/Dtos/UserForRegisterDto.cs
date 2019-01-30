using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Password needs to be at least 8 characters long")]
        public string Password { get; set; }
    }
}