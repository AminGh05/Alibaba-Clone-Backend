using AlibabaClone.Application.DTOs.AccountDTOs;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Result<ProfileDto>> GetProfileAsync(long accountId);
        Task<Result<long>> UpdateEmailAsync(long accountId, string email);
        Task<Result<long>> UpdatePasswordAsync(long accountId, string oldPassword, string newPassword);
    }
}
