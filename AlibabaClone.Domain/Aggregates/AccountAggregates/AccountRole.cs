namespace AlibabaClone.Domain.Aggregates.AccountAggregates
{
    public class AccountRole
    {
        public required short RoleId { get; set; }
        public required long AccountId { get; set; }

        #region Navigation Properties
        public virtual Account Account { get; set; }
        public virtual Role Role { get; set; }
        #endregion
    }
}
