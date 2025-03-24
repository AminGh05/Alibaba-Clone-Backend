using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.TransportationRepositories
{
	public class TransportationRepository : BaseRepository<AlibabaDbContext, Transportation, long>, ITransportationRepository
	{
		public TransportationRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
