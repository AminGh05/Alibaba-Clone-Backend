using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.TransactionRepositories
{
    public class TicketRepository : BaseRepository<AlibabaDbContext, Ticket, long>, ITicketRepository
	{
		public TicketRepository(AlibabaDbContext context) : base(context)
		{

		}

        public async Task<List<Ticket>> GetTicketsByTicketOrderId(long ticketOrderId)
        {
            var tickets = await DbSet
                .Include(t => t.Traveler)
                .Include(t => t.TicketStatus)
                .Include(t => t.Companion)
                .Include(t => t.Seat)
                .Include(t => t.TicketOrder)
                .Where(t => t.TicketOrderId == ticketOrderId).ToListAsync();
            return tickets;
        }
    }
}
