namespace AlibabaClone.Application.DTOs.AccountDTOs
{
    public class ProfileDto
    {
        // from account
        public string AccountPhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }

        // from person
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string PersonPhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }

        // from bank-account
        public string IBAN { get; set; }
        public string BankAccountNumber { get; set; }
        public int CardNumber { get; set; }
    }
}
