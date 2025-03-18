namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
	class AccountRole
	{
		public required short RoleId { get; set; }
		public required long AccountId { get; set; }
	}
}
