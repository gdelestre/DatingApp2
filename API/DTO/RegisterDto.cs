using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [StringLength(10, MinimumLength = 6)]
        public string Password { get; set; }
    }
}