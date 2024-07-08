using System.ComponentModel.DataAnnotations;

namespace Slice.WebApi.Models.DTOs
{
    public class UserRegistrationDto
    {

        [Required]
        [StringLength(20, ErrorMessage = "Must be between 3 and 20 characters", 
            MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", 
            ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Must be at least 6 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
         ErrorMessage = "Password must be at least 8 characters long and contain a lowercase, uppercase, digit and special value character")]
        public string Password { get; set; }
    }
}
