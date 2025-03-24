using AlibabaClone.Domain.Framework.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlibabaClone.Infrastructure.Framework.Base
{
	internal class BaseRepository<KDbContext, TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
		where TEntity : class
		where KDbContext : DbContext
	{
		public virtual KDbContext DbContext { get; set; }
		public virtual DbSet<TEntity> DbSet { get; set; }

		public BaseRepository(KDbContext context)
		{
			DbContext = context;
			DbSet = context.Set<TEntity>();
		}

		public async Task InsertAsync(TEntity entity)
		{
			await DbSet.AddAsync(entity);
		}
		
		public async Task<List<TEntity>> GetAllAsync()
		{
			return await DbSet.ToListAsync();
		}

		public async Task<TEntity?> GetByIdAsync(TPrimaryKey id)
		{
			return await DbSet.FindAsync(id);
		}

		public void Update(TEntity entity)
		{
			DbSet.Update(entity);
		}

		public void Delete(TEntity entity)
		{
			if (DbSet.Entry(entity).State == EntityState.Detached)
			{
				DbSet.Attach(entity);
			}

			DbSet.Remove(entity);
		}

		public async Task DeleteAsync(TPrimaryKey id)
		{
			var entity = await DbSet.FindAsync(id);

			if (entity != null)
			{
				DbSet.Remove(entity);
			}
		}
	}
}
