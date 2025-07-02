using System.ComponentModel.DataAnnotations;

namespace AlibabaClone.Application.DTOs.AuthDTOs
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid Number")]
        public required string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "At least 8 chars")]
        public required string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public required string ConfirmPassword { get; set; }
    }
}
