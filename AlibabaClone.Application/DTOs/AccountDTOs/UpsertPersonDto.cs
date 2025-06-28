using System.ComponentModel.DataAnnotations;

namespace AlibabaClone.Application.DTOs.AccountDTOs
{
    public class UpsertPersonDto
    {
        public long Id { get; set; }
        public long CreatorId { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "National Id number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "National ID number must be exactly 10 digits")]
        public string IdNumber { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public short GenderId { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Birth date is required")]
        public DateTime BirthDate { get; set; }
    }
}
