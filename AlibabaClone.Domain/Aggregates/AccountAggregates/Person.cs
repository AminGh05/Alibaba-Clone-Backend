using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
    class Person : Entity<long>
    {
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required string IdNumber { get; set; }
		public DateTime BirthDate { get; set; }
		public short GenderId { get; set; }
		public string? PassportNumber { get; set; }

		#region Navigation Properties
		public virtual Gender Gender { get; set; }
		public virtual ICollection<Account> Accounts { get; set; }
		#endregion
	}
}
