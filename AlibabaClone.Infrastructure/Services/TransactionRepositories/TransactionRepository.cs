using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.TransactionRepositories
{
    public class TransactionRepository : BaseRepository<AlibabaDbContext, Transaction, long>, ITransactionRepository
	{
		public TransactionRepository(AlibabaDbContext context) : base(context)
		{

		}

        public async Task<List<Transaction>> GetTransactionsByAccountIdAsync(long accountId)
        {
            var transactions = await DbSet
                .Include(t => t.TransactionType)
                .Include(t => t.TicketOrder)
                .Where(t => t.AccountId == accountId).ToListAsync();
            return transactions;
        }
    }
}
