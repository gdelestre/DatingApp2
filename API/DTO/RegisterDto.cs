using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [StringLength(100, ErrorMessage = "The {0} have to be {2} characters.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}