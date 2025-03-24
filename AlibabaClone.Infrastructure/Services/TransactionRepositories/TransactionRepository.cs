using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.TransactionRepositories
{
	public class TransactionRepository : BaseRepository<AlibabaDbContext, Transaction, long>, ITransactionRepository
	{
		public TransactionRepository(AlibabaDbContext context) : base(context)
		{

		}
	}
}
