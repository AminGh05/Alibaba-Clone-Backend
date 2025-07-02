using AlibabaClone.Domain.Framework.Interfaces;

namespace AlibabaClone.Infrastructure.Framework.Base
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AlibabaDbContext _context;

		public UnitOfWork(AlibabaDbContext context)
		{
			_context = context;
		}

		public async Task<int> CompleteAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
