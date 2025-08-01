﻿using AlibabaClone.Domain.Aggregates.LocationAggregates;
using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransportationAggregates
{
	public class Transportation : Entity<long>
	{
		public int FromLocationId { get; set; }
		public int ToLocationId { get; set; }
		public int CompanyId { get; set; }
		public int VehicleId { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public required string SerialNumber { get; set; }
		public int RemainingCapacity => Vehicle.Capacity -
			TicketOrders?.SelectMany(to => to.Tickets)
			.Count(t => t.TicketStatusId == 1) ?? 0;
		public decimal BasePrice { get; set; }
		public decimal? VIPPrice { get; set; }

		#region Navigation Properties
		public virtual Location FromLocation { get; set; }
		public virtual Location ToLocation { get; set; }
		public virtual Company Company { get; set; }
		public virtual Vehicle Vehicle { get; set; }
		public virtual ICollection<TicketOrder> TicketOrders { get; set; }
		#endregion
	}
}
