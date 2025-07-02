using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.TransportationRepositories
{
	public class SeatRepository : BaseRepository<AlibabaDbContext, Seat, long>, ISeatRepository
	{
		public SeatRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
