using System.ComponentModel.DataAnnotations;

namespace AlibabaClone.Application.DTOs.AccountDTOs
{
    public class EditPasswordDto
    {
        [Required(ErrorMessage = "Old password is required")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New password is required")]
        [MinLength(8, ErrorMessage = "At least 8 chars")]
        public string NewPassword { get; set; }

        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmNewPassword { get; set; }
    }
}
