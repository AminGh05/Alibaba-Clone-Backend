using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.TransportationRepositories
{
	public class VehicleRepository : BaseRepository<AlibabaDbContext, Vehicle, int>, IVehicleRepository
	{
		public VehicleRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
