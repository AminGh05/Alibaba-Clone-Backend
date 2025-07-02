using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.AccountRepositories
{
	public class GenderRepository : BaseRepository<AlibabaDbContext, Gender, short>, IGenderRepository
	{
		public GenderRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
