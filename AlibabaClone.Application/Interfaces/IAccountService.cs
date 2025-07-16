using AlibabaClone.Application.DTOs.AccountDTOs;
using AlibabaClone.Application.DTOs.TransactionDTOs;
using AlibabaClone.Application.DTOs.TransportationDTOs;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Result<ProfileDto>> GetProfileAsync(long accountId);
        Task<Result<List<PersonDto>>> GetAllPeopleAsync(long accountId);
        Task<Result<List<TicketOrderSummaryDto>>> GetTravelsAsync(long accountId);
        Task<Result<List<TransactionDto>>> GetTransactionsAsync(long accountId);
        Task<Result<List<TravellerTicketDto>>> GetTicketOrderDetailsAsync(long accoundId, long ticketOrderid);
        Task<Result<long>> TopUpAsync(long accountId, TopUpDto dto);
        Task<Result<long>> PayForTicketOrderAsync(long accountId, long ticketOrderId, decimal baseAmount, decimal finalAmount);
        Task<Result<long>> UpdateEmailAsync(long accountId, string email);
        Task<Result<long>> UpdatePasswordAsync(long accountId, string oldPassword, string newPassword);
        Task<Result<long>> UpsertBankAccountAsync(long accountId, UpsertBankAccountDto dto);
    }
}
