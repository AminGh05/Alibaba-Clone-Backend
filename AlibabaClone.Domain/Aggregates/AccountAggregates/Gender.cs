using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
    class Gender : Entity<short>
    {
		public char Title { get; set; }
	}
}
