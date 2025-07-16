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

        public Task<TicketOrder?> FindAndLoadAllDetailsAsync(long id)
        {
            var ticketOrder = DbSet
                .Include(to => to.Transportation).ThenInclude(t => t.FromLocation).ThenInclude(fl => fl.City)
                .Include(to => to.Transportation).ThenInclude(t => t.ToLocation).ThenInclude(tl => tl.City)
                .Include(to => to.Tickets).ThenInclude(t => t.Traveler)
                .Where(to => to.Id == id).FirstOrDefaultAsync();

            return ticketOrder;
        }

        public async Task<List<TicketOrder>> GetAllByBuyerIdAsync(long buyerId)
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
