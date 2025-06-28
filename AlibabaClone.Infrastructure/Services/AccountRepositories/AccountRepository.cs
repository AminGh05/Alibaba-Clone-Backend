using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.AccountRepositories
{
	public class AccountRepository : BaseRepository<AlibabaDbContext, Account, long>, IAccountRepository
	{
        public AccountRepository(AlibabaDbContext context) : base(context)
        {

        }

        public async Task<Account> GetByPhoneNumberAsync(string phoneNumber)
        {
			var user = await DbSet.Include(a => a.AccountRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
			return user;
        }

        public async Task<Account> GetProfileAsync(long accountId)
        {
            var profile = await DbSet
                .Include(a => a.Person)
                .Include(a => a.BankAccount)
                .FirstOrDefaultAsync(a => a.Id == accountId);

            return profile;
        }

        public async Task<Account> GetByEmailAsync(string email)
        {
            var account = await DbSet.FirstOrDefaultAsync(x => x.Email == email);
            return account;
        }
    }
}
