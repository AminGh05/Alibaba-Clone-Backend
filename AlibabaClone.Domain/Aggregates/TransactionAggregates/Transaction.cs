using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransactionAggregates
{
    public class Transaction : Entity<long>
    {
        public short TransactionTypeId { get; set; }
        public long AccountId { get; set; }
        public long? TicketOrderId { get; set; }
        public decimal BaseAmount { get; set; }
		public decimal FinalAmount { get; set; }
		public required string SerialNumber { get; set; }
		public DateTime CreatedAt { get; set; }
        public string? Description { get; set; }

        #region Navigation Properties
        public virtual TransactionType TransactionType { get; set; }
        public virtual Account Account { get; set; }
        public virtual TicketOrder TicketOrder { get; set; }
        #endregion
	}
}
