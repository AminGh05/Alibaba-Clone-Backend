using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.TransactionRepositories
{
	public class TicketStatusRepository : BaseRepository<AlibabaDbContext, TicketStatus, short>, ITicketStatusRepository
	{
		public TicketStatusRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
