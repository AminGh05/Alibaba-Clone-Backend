using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Infrastructure.Framework.Base;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Services.AccountRepositories
{
	public class PersonRepository : BaseRepository<AlibabaDbContext, Person, long>, IPersonRepository
	{
		public PersonRepository(AlibabaDbContext context) : base(context)
		{

		}

        public async Task<List<Person>> GetAllByCreatorIdAsync(long creatorId)
        {
			return await DbSet.Where(p => p.CreatorId == creatorId).ToListAsync();
        }
    }
}
