using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.LocationAggregates
{
    class LocationType : Entity<short>
    {
		public required string Title { get; set; }

		#region Navigation Properties
		public virtual ICollection<Location>? Locations { get; set; }
		#endregion
	}
}
