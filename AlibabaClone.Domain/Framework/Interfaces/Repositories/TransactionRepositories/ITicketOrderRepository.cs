using AlibabaClone.Domain.Aggregates.TransactionAggregates;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories
{
    public interface ITicketOrderRepository : IRepository<TicketOrder, long>
    {
        Task<List<TicketOrder>> GetAllByBuyerId(long buyerId);
    }
}
