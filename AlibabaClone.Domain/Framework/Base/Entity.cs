using AlibabaClone.Domain.Framework.Interfaces;

namespace AlibabaClone.Domain.Framework.Base
{
	public class Entity<TKey> : IEntity<TKey>
	{
		public required TKey Id { get ; set ; }
	}
}
