using AlibabaClone.Application.DTOs.AccountDTOs;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
    public interface IPersonService
    {
        Task<Result<long>> UpsertAccountPersonAsync(long accountId, PersonDto dto);
        Task<Result<long>> UpsertPersonAsync(long accountId, PersonDto dto);
    }
}
