using System.ComponentModel.DataAnnotations;

namespace SCSMock.API.DTOs
{
    public class LoginDto
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
