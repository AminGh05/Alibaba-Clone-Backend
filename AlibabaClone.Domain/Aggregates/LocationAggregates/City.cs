using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.LocationAggregates
{
    class City : Entity<int>
    {
		public required string Title { get; set; }
	}
}
