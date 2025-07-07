using System.ComponentModel.DataAnnotations;

namespace AlibabaClone.Application.DTOs.AccountDTOs
{
    public class UpsertBankAccountDto
    {
        [MaxLength(27)]
        [MinLength(27)]
        public string? IBAN { get; set; }

        [MaxLength(16)]
        [MinLength(16)]
        public string? CardNumber { get; set; }

        [MaxLength(15)]
        [MinLength(15)]
        public string? BankAccountNumber { get; set; }
    }
}
