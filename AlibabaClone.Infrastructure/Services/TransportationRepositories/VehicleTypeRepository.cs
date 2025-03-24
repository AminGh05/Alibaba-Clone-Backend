using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.TransportationRepositories
{
	public class VehicleTypeRepository : BaseRepository<AlibabaDbContext, VehicleType, short>, IVehicleTypeRepository
	{
		public VehicleTypeRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
