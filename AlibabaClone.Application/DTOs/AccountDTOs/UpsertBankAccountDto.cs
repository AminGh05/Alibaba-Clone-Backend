using System.ComponentModel.DataAnnotations;

namespace AlibabaClone.Application.DTOs.AccountDTOs
{
    public class UpsertBankAccountDto
    {
        [MinLength(24)]
        [MaxLength(24)]
        public string? IBAN { get; set; }

        [MinLength(16)]
        [MaxLength(16)]
        public string? CardNumber { get; set; }

        [MinLength(8)]
        public string? BankAccountNumber { get; set; }
    }
}
