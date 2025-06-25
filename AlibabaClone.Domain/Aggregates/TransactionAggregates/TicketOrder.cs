using AlibabaClone.Domain.Aggregates.AccountAggregates;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransactionAggregates
{
    public class TicketOrder : Entity<long>
    {
        public long TransportationId { get; set; }
        public long BuyerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SerialNumber { get; set; }
        public string? Description { get; set; }

        #region Navigation Properties
        public virtual ICollection<Ticket> Tickets { get; set; } = [];
        public virtual Transportation Transportation { get; set; }
        public virtual Account Buyer { get; set; }
        public virtual Transaction Transaction { get; set; }
        #endregion
    }
}
