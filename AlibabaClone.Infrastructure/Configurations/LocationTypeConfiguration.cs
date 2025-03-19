using AlibabaClone.Domain.Aggregates.LocationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations
{
	internal class LocationTypeConfiguration : IEntityTypeConfiguration<LocationType>
	{
		public void Configure(EntityTypeBuilder<LocationType> builder)
		{
			builder.HasKey(lt => lt.Id);
			// auto-generate id
			builder.Property(lt => lt.Id)
				.ValueGeneratedOnAdd();

			// title
			builder.Property(lt => lt.Title)
				.IsRequired()
				.HasMaxLength(50);

			// index location-type titles as unique
			builder.HasIndex(lt => lt.Title)
				.IsUnique();
		}
	}
}
