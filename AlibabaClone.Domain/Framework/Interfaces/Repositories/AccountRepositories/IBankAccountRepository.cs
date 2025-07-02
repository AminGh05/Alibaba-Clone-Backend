using AlibabaClone.Domain.Aggregates.AccountAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories
{
    public interface IBankAccountRepository : IRepository<BankAccount, long>
    {
        Task<BankAccount> GetByAccountIdAsync(long accountId);
    }
}
