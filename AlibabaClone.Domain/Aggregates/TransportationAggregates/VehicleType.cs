using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransportationAggregates
{
    class VehicleType : Entity<short>
    {
		public required string Title { get; set; }

		#region Navigation Properties
		public virtual ICollection<Vehicle>? Vehicles { get; set; }
		#endregion
	}
}
