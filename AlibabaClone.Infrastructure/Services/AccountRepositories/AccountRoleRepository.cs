using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AlibabaClone.Infrastructure.Services.AccountRepositories
{
	public class AccountRoleRepository : IAccountRoleRepository
	{
		public AlibabaDbContext DbContext { get; set; }
		public DbSet<AccountRole> DbSet { get; set; }

		public AccountRoleRepository(AlibabaDbContext context)
		{
			DbContext = context;
			DbSet = context.Set<AccountRole>();
		}

		public async Task InsertAsync(AccountRole entity)
		{
			await DbSet.AddAsync(entity);
		}

		public async Task<IEnumerable<AccountRole>> GetAllAsync()
		{
			return await DbSet.ToListAsync();
		}

		public async Task<IEnumerable<AccountRole>> FindAsync(Expression<Func<AccountRole, bool>> predicate)
		{
			return await DbSet.Where(predicate).ToListAsync();
		}

		public async Task<AccountRole?> GetByIdAsync(short roleId, long accountId)
		{
			return await DbSet.SingleOrDefaultAsync(ar => ar.RoleId == roleId && ar.AccountId == accountId);
		}

		public void Update(AccountRole entity)
		{
			DbSet.Update(entity);
		}

		public void Delete(AccountRole entity)
		{
			if (DbSet.Entry(entity).State == EntityState.Detached)
			{
				DbSet.Attach(entity);
			}
			DbSet.Remove(entity);
		}
	}
}
