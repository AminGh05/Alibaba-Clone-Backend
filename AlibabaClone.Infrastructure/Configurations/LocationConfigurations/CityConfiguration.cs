using AlibabaClone.Domain.Aggregates.LocationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.LocationConfigurations
{
	public class CityConfiguration : IEntityTypeConfiguration<City>
	{
		public void Configure(EntityTypeBuilder<City> builder)
		{
			builder.HasKey(c => c.Id);
			// auto-generate id
			builder.Property(c => c.Id)
				.ValueGeneratedOnAdd();

			// title
			builder.Property(c => c.Title)
				.IsRequired()
				.HasMaxLength(80);

			// index city titles as unique
			builder.HasIndex(c => c.Title)
				.IsUnique();
		}
	}
}
