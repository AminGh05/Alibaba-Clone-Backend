using AlibabaClone.Domain.Aggregates.LocationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.LocationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.LocationRepositories
{
	public class LocationTypeRepository : BaseRepository<AlibabaDbContext, LocationType, short>, ILocationTypeRepository
	{
		public LocationTypeRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
