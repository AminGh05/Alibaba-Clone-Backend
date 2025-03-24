using AlibabaClone.Domain.Aggregates.AccountAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.AccountConfigurations
{
	public class GenderConfiguration : IEntityTypeConfiguration<Gender>
	{
		public void Configure(EntityTypeBuilder<Gender> builder)
		{
			builder.HasKey(g => g.Id);
			// auto-generate id
			builder.Property(g => g.Id)
				.ValueGeneratedOnAdd();

			// title
			builder.Property(g => g.Title)
				.IsRequired()
				.HasMaxLength(1);

			// index gender titles as unique
			builder.HasIndex(g => g.Title)
				.IsUnique();
		}
	}
}
