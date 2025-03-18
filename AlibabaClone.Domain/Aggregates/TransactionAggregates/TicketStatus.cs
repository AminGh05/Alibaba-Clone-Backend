using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransactionAggregates
{
    class TicketStatus : Entity<short>
    {
		public required string Ttile { get; set; }
	}
}
