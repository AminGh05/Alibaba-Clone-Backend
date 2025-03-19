using AlibabaClone.Domain.Aggregates.AccountAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations
{
	internal class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasKey(r => r.Id);
			// auto-generate id
			builder.Property(r => r.Id)
				.ValueGeneratedOnAdd();
			
			// title
			builder.Property(r => r.Title)
				.IsRequired()
				.IsUnicode(false)
				.HasMaxLength(100);
			
			// index role titles as unique
			builder.HasIndex(r => r.Title)
				.IsUnique();
		}
	}
}
