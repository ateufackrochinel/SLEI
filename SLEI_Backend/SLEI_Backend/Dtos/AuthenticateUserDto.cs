using System.ComponentModel.DataAnnotations;

namespace SLEI_Backend.Dtos
{
    public class AuthenticateUserDto
    {
        [Required]
        public string login { get; set; }

        [Required]
        public string Password { get; set; }

        public string? Role { get; set; }

        public string? Name { get; set; }
        public string? Token { get; set; }
    }
}
