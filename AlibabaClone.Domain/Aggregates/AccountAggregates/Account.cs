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
        public decimal Balance { get; set; }

        #region Navigation Properties
        public virtual Person? Person { get; set; }
        public virtual BankAccount? BankAccount { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
		public virtual ICollection<TicketOrder> BoughtTicketOrders { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
        public virtual ICollection<Person> PeopleCreated { get; set; }
        #endregion

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Amount must be positive");
            }

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > Balance)
            {
                throw new InvalidOperationException("Invalid withdrawal amount");
            }

            Balance -= amount;
        }
    }
}
