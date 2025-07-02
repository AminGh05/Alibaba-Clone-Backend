using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TransportationConfigurations
{
	public class SeatConfiguration : IEntityTypeConfiguration<Seat>
	{
		public void Configure(EntityTypeBuilder<Seat> builder)
		{
			builder.HasKey(s => s.Id);
			// auto-generate id
			builder.Property(s => s.Id)
				.ValueGeneratedOnAdd();

			// vehicle-id
			builder.Property(s => s.VehicleId)
				.IsRequired();

			// row
			builder.Property(s => s.Row)
				.IsRequired();

			// column
			builder.Property(s => s.Column)
				.IsRequired();

			// is-vip
			builder.Property(s => s.IsVIP)
				.IsRequired();

			// is-available
			builder.Property(s => s.IsAvailable)
				.IsRequired();

			// description
			builder.Property(s => s.Description)
				.HasMaxLength(200);

			// vehicle foreign-key
			builder.HasOne(s => s.Vehicle)
				.WithMany(v => v.Seats)
				.HasForeignKey(s => s.VehicleId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
