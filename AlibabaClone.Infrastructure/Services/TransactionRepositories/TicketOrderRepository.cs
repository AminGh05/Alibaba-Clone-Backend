using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.TransactionRepositories
{
    public class TicketOrderRepository : BaseRepository<AlibabaDbContext, TicketOrder, long>, ITicketOrderRepository
    {
        public TicketOrderRepository(AlibabaDbContext context) : base(context)
        {

        }

        public async Task<List<TicketOrder>> GetAllByBuyerId(long buyerId)
        {
            var ticketOrders = await DbSet
                .Include(to => to.Transaction)
                .Include(to => to.Transportation).ThenInclude(t => t.FromLocation)
                .Include(to => to.Transportation).ThenInclude(t => t.ToLocation)
                .Include(to => to.Transportation).ThenInclude(t => t.Company)
                .Include(to => to.Transportation).ThenInclude(t => t.Vehicle)
                .Where(to => to.BuyerId == buyerId).ToListAsync();
            return ticketOrders;
        }
    }
}
