using AlibabaClone.Domain.Aggregates.AccountAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories
{
	public interface IAccountRepository : IRepository<Account, long>
	{
		Task<Account> GetByPhoneNumberAsync(string phoneNumber);
		Task<Account> GetByEmailAsync(string email);
        Task<Account> GetProfileAsync(long accountId);
	}
}
