namespace AlibabaClone.Domain.Framework.Interfaces.Repositories
{
	public interface IRepository<TEntity, TPrimarayKey> where TEntity : class
	{
		Task InsertAsync(TEntity entity);
		Task<List<TEntity>> GetAllAsync();
		Task<TEntity> GetByIdAsync(TPrimarayKey id);
		void UpdateAsync(TEntity entity);
		Task DeleteAsync(TEntity entity);
		Task DeleteAsync(TPrimarayKey id);
	}
}
