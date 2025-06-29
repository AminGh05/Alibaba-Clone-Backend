using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.TransactionRepositories
{
    public class TicketOrderRepository : BaseRepository<AlibabaDbContext, TicketOrder, long>, ITicketOrderRepository
    {
        public TicketOrderRepository(AlibabaDbContext context) : base(context)
        {

        }
    }
}
