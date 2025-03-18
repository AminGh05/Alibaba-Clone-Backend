using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransactionAggregates
{
    class Transaction : Entity<long>
    {
		public decimal BaseAmount { get; set; }
		public decimal FinalAmount { get; set; }
		public required string SerialNumber { get; set; }
		public long TicketId { get; set; }
		public DateTime CreatedAt { get; set; }

		#region Navigation Properties
		public virtual Ticket Ticket { get; set; }
		#endregion
	}
}
