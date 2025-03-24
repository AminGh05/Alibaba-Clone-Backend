using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.AccountRepositories
{
	public class RoleRepository : BaseRepository<AlibabaDbContext, Role, short>, IRoleRepository
	{
		public RoleRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
