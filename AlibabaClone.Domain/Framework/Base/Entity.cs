using AlibabaClone.Domain.Framework.Interfaces;

namespace AlibabaClone.Domain.Framework.Base
{
	class Entity<TKey> : IEntity<TKey>
	{
		public required TKey Id { get ; set ; }
	}
}
