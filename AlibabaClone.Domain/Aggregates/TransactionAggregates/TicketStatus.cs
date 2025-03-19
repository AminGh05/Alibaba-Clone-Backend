using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransactionAggregates
{
    public class TicketStatus : Entity<short>
    {
		public required string Ttile { get; set; }
	}
}
