using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TransportationConfigurations
{
	public class CompanyConfiguration : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder.HasKey(c => c.Id);
			// auto-generate id
			builder.Property(c => c.Id)
				.ValueGeneratedOnAdd();

			// title
			builder.Property(c => c.Title)
				.IsRequired()
				.IsUnicode(false)
				.HasMaxLength(100);

			// index company titles as unique
			builder.HasIndex(c => c.Title)
				.IsUnique();
		}
	}
}
