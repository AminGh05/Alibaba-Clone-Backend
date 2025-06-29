using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AlibabaClone.Infrastructure.Framework.Base;

namespace AlibabaClone.Infrastructure.Services.TransactionRepositories
{
    public class TransactionTypeRepository : BaseRepository<AlibabaDbContext, TransactionType, short>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(AlibabaDbContext context) : base(context)
        {

        }
    }
}
