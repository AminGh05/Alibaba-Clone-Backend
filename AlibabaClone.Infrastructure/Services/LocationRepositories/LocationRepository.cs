using AlibabaClone.Domain.Aggregates.LocationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.LocationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.LocationRepositories
{
	public class LocationRepository : BaseRepository<AlibabaDbContext, Location, int>, ILocationRepository
	{
		public LocationRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
