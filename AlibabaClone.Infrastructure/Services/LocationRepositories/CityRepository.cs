using AlibabaClone.Domain.Aggregates.LocationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.LocationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.LocationRepositories
{
	public class CityRepository : BaseRepository<AlibabaDbContext, City, int>, ICityRepository
	{
		public CityRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
