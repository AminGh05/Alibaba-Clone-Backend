using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations
{
	public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
	{
		public void Configure(EntityTypeBuilder<VehicleType> builder)
		{
			builder.HasKey(vt => vt.Id);
			// auto-generate id
			builder.Property(vt => vt.Id)
				.ValueGeneratedOnAdd();

			// title
			builder.Property(vt => vt.Title)
				.IsRequired()
				.IsUnicode(false)
				.HasMaxLength(100);

			// index role titles as unique
			builder.HasIndex(vt => vt.Title)
				.IsUnique();
		}
	}
}
