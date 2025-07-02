using AlibabaClone.Domain.Aggregates.TransactionAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories
{
	public interface ITicketStatusRepository : IRepository<TicketStatus, short>
	{
	}
}
