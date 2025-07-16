using System.ComponentModel.DataAnnotations;

namespace AlibabaClone.Application.DTOs.TransportationDTOs
{
    public class CreateTravellerTicketDto
    {
        public long Id { get; set; }
        public long CreatorId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Id number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "National ID number must be exactly 10 digits")]
        public required string IdNumber { get; set; }

        [Required(ErrorMessage = "Gender should be identified")]
        public required short GenderId { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public required string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Birth date is required")]
        public DateTime BirthDate { get; set; }

        public long? SeatId { get; set; }
        public bool IsVIP { get; set; }
        public string? Description { get; set; }
    }
}
