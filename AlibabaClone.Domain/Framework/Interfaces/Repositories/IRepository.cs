namespace AlibabaClone.Domain.Framework.Interfaces.Repositories
{
	public interface IRepository<TEntity, TPrimarayKey> where TEntity : class
	{
		Task InsertAsync(TEntity entity);
		Task<List<TEntity>> GetAllAsync();
		Task<TEntity?> GetByIdAsync(TPrimarayKey id);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		Task DeleteAsync(TPrimarayKey id);
	}
}
