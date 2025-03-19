using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
    public class Gender : Entity<short>
    {
		public char Title { get; set; }
	}
}
