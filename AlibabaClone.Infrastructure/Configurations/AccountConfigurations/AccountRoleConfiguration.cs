using AlibabaClone.Domain.Aggregates.AccountAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.AccountConfigurations
{
	public class AccountRoleConfiguration : IEntityTypeConfiguration<AccountRole>
	{
		public void Configure(EntityTypeBuilder<AccountRole> builder)
		{
			builder.HasKey(ar => new { ar.RoleId, ar.AccountId });
			
			// role to account
			builder.HasOne<Role>(ar => ar.Role)
				.WithMany()
				.HasForeignKey(ar => ar.RoleId)
				.OnDelete(DeleteBehavior.Restrict);
			
			// account to role
			builder.HasOne<Account>(ar => ar.Account)
				.WithMany(a => a.AccountRoles)
				.HasForeignKey(ar => ar.AccountId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
