namespace AlibabaClone.Application.DTOs.AccountDTOs
{
    public class AccountDto
    {
        public int Id { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Password { get; set; }
        public string? Email { get; set; }
        public long? PersonId { get; set; }
        public List<string> Roles { get; set; }
    }
}
