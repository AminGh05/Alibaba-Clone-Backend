using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransportationAggregates
{
	class Vehicle : Entity<int>
	{
		public required string Title { get; set; }
		public short VehicleTypeId { get; set; }
		public int Capacity { get; set; }
		public required string PlateNumber { get; set; }

		#region Navigation Properties
		public virtual VehicleType? VehicleType { get; set; }
		public virtual ICollection<Seat>? Seats { get; set; }
		public virtual ICollection<Transportation>? Transportations { get; set; }
		#endregion
	}
}
