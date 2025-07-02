using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.AccountRepositories
{
    public class BankAccountRepository : BaseRepository<AlibabaDbContext, BankAccount, long>, IBankAccountRepository
    {
        public BankAccountRepository(AlibabaDbContext context) : base(context)
        {

        }

        public async Task<BankAccount> GetByAccountIdAsync(long accountId)
        {
            var bankAccount = await DbSet.FirstOrDefaultAsync(ba => ba.AccountId == accountId);
            return bankAccount;
        }
    }
}
