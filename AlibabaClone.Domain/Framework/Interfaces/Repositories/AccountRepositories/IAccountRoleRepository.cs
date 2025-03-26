using AlibabaClone.Domain.Aggregates.AccountAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories
{
	public interface IAccountRoleRepository
	{
		Task InsertAsync(AccountRole entity);
		Task<List<AccountRole>> GetAllAsync();
		Task<AccountRole?> GetByIdAsync(short roleId, long accountId);
		void Update(AccountRole entity);
		void Delete(AccountRole entity);
		Task DeleteAsync(short roleId, long accountId);
	}
}
