using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransportationAggregates
{
    public class Seat : Entity<long>
    {
		public int VehicleId { get; set; }
		public int Row { get; set; }
		public int Column { get; set; }
		public bool IsVIP { get; set; }
		public bool IsAvailable{ get; set; }
		public string? Description { get; set; }

		#region Navigation Properties
		public virtual Vehicle Vehicle { get; set; }
		public virtual ICollection<Ticket> Tickets { get; set; }
		#endregion
	}
}
