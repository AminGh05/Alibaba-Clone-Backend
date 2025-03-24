using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TransportationConfigurations
{
	public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
	{
		public void Configure(EntityTypeBuilder<Vehicle> builder)
		{
			builder.HasKey(v => v.Id);
			// auto-generate id
			builder.Property(v => v.Id)
				.ValueGeneratedOnAdd();

			// title
			builder.Property(v => v.Title)
				.IsRequired()
				.HasMaxLength(100);

			// vehicle-type-id
			builder.Property(v => v.VehicleTypeId)
				.IsRequired();

			// capacity
			builder.Property(v => v.VehicleTypeId)
				.IsRequired();

			// plate number
			builder.Property(v => v.PlateNumber)
				.IsRequired()
				.HasMaxLength(50);

			// index plate-number as unique
			builder.HasIndex(v => v.PlateNumber)
				.IsUnique();

			// vehicle-type foreign-key
			builder.HasOne(v => v.VehicleType)
				.WithMany(vt => vt.Vehicles)
				.HasForeignKey(v => v.VehicleTypeId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
