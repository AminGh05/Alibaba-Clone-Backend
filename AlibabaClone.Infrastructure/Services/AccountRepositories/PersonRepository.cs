using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.AccountRepositories
{
	public class PersonRepository : BaseRepository<AlibabaDbContext, Person, long>, IPersonRepository
	{
		public PersonRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
