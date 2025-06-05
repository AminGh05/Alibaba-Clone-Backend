using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
    public class Account : Entity<long>
    {
		public required string PhoneNumber { get; set; }
		public required string Password { get; set; }
		public required string Email { get; set; }
		public long? PersonId { get; set; }

		#region Navigation Properties
		public virtual Person Person { get; set; }
		public virtual ICollection<Ticket> BoughtTickets { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
        #endregion
    }
}
