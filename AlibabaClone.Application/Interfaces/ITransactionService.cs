using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<Result<long>> CreateTopUpAsync(long accountId, decimal amount);
    }
}
