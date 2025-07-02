using System.Linq.Expressions;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories
{
	public interface IRepository<TEntity, TPrimarayKey> where TEntity : class
	{
		Task InsertAsync(TEntity entity);
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
		Task<TEntity?> GetByIdAsync(TPrimarayKey id);
		void Update(TEntity entity);
		void Delete(TEntity entity);
	}
}
