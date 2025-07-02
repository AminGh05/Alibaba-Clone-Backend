using AlibabaClone.Domain.Aggregates.AccountAggregates;
using System.Linq.Expressions;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories
{
	public interface IAccountRoleRepository
	{
		Task InsertAsync(AccountRole entity);
		Task<IEnumerable<AccountRole>> GetAllAsync();
		Task<IEnumerable<AccountRole>> FindAsync(Expression<Func<AccountRole, bool>> predicate);
		Task<AccountRole?> GetByIdAsync(short roleId, long accountId);
		void Update(AccountRole entity);
		void Delete(AccountRole entity);
	}
}
