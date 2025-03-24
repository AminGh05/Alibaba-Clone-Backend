using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.AccountRepositories
{
	public class AccountRepository : BaseRepository<AlibabaDbContext, Account, long>, IAccountRepository
	{
		public AccountRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
