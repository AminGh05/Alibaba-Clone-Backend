using AlibabaClone.Domain.Aggregates.LocationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.LocationConfigurations
{
	public class LocationConfiguration : IEntityTypeConfiguration<Location>
	{
		public void Configure(EntityTypeBuilder<Location> builder)
		{
			builder.HasKey(l => l.Id);
			// auto-generate id
			builder.Property(l => l.Id)
				.ValueGeneratedOnAdd();

			// title
			builder.Property(l => l.Title)
				.IsRequired()
				.HasMaxLength(100);

			// city-id
			builder.Property(l => l.CityId)
				.IsRequired();

			// location-type-id
			builder.Property(l => l.LocationTypeId)
				.IsRequired();

			// city foreign-key
			builder.HasOne(l => l.City)
				.WithMany(c => c.Locations)
				.HasForeignKey(l => l.CityId)
				.OnDelete(DeleteBehavior.Restrict);

			// location-type foreign-key
			builder.HasOne(l => l.LocationType)
				.WithMany(c => c.Locations)
				.HasForeignKey(l => l.LocationTypeId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
