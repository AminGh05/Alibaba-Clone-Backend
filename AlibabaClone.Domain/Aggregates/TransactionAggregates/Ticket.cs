﻿using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransactionAggregates
{
    public class Ticket : Entity<long>
    {
		public long TicketOrderId { get; set; }
		public long SeatId { get; set; }
		public long TravelerId { get; set; }
		public DateTime CreatedAt { get; set; }
        public DateTime? CanceledAt { get; set; }
        public long? CompanionId { get; set; }
		public short TicketStatusId { get; set; }
		public required string SerialNumber { get; set; }
		public string? Description { get; set; }

		#region Navigation Properties
		public virtual TicketOrder TicketOrder { get; set; }
		public virtual Seat Seat { get; set; }
		public virtual Person Traveler { get; set; }
		public virtual Person? Companion { get; set; }
		public virtual TicketStatus TicketStatus { get; set; }
		#endregion
	}
}
