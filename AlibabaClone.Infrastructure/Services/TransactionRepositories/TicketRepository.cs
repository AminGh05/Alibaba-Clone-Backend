using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.TransactionRepositories
{
	public class TicketRepository : BaseRepository<AlibabaDbContext, Ticket, long>, ITicketRepository
	{
		public TicketRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
