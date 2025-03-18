using AlibabaClone.Domain.Framework.Base;

namespace AlibabaClone.Domain.Aggregates.TransportationAggregates
{
    class Company : Entity<int>
    {
		public required string Title { get; set; }

		#region Navigation Properties
		public virtual ICollection<Transportation> Transportations { get; set; }
		#endregion
	}
}
