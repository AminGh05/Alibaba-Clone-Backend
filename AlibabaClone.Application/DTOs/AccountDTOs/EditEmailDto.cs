using System.ComponentModel.DataAnnotations;

namespace AlibabaClone.Application.DTOs.AccountDTOs
{
    public class EditEmailDto
    {
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string NewEmail { get; set; }
    }
}
