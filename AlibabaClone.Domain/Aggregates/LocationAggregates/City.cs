using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.LocationAggregates
{
    class City : Entity<int>
    {
		public required string Title { get; set; }

		#region Navigation Properties
		public virtual ICollection<Location>? Locations { get; set; }
		#endregion
	}
}
