using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TransportationConfigurations
{
	public class TransportationConfiguration : IEntityTypeConfiguration<Transportation>
	{
		public void Configure(EntityTypeBuilder<Transportation> builder)
		{
			builder.HasKey(t => t.Id);
			// auto-generate id
			builder.Property(t => t.Id)
				.ValueGeneratedOnAdd();

			// from-location-id
			builder.Property(t => t.FromLocationId)
				.IsRequired();

			// to-location-id
			builder.Property(t => t.ToLocationId)
				.IsRequired();

			// company-id
			builder.Property(t => t.CompanyId)
				.IsRequired();

			// vehicle-id
			builder.Property(t => t.VehicleId)
				.IsRequired();

			// start date-time
			builder.Property(t => t.StartDateTime)
				.IsRequired();

			// end date-time
			builder.Property(t => t.EndDateTime)
				.IsRequired();

			// serial-number
			builder.Property(t => t.SerialNumber)
				.IsRequired()
				.HasMaxLength(50)
				.IsUnicode(false);

			// remaining capacity
			builder.Property(t => t.RemainingCapacity)
				.IsRequired();

			// base price
			builder.Property(t => t.BasePrice)
				.IsRequired()
				.HasColumnType("decimal(18,2)");

			// vip price
			builder.Property(t => t.VIPPrice)
				.HasColumnType("decimal(18,2)");

			// location foreign-key -> from
			builder.HasOne(t => t.FromLocation)
				.WithMany()
				.HasForeignKey(t => t.FromLocationId)
				.OnDelete(DeleteBehavior.Restrict);

			// location foreign-key -> to
			builder.HasOne(t => t.ToLocation)
				.WithMany()
				.HasForeignKey(t => t.ToLocationId)
				.OnDelete(DeleteBehavior.Restrict);

			// company foreign-key
			builder.HasOne(t => t.Company)
				.WithMany(c => c.Transportations)
				.HasForeignKey(t => t.CompanyId)
				.OnDelete(DeleteBehavior.Restrict);

			// vehicle foreign-key
			builder.HasOne(t => t.Vehicle)
				.WithMany(v => v.Transportations)
				.HasForeignKey(t => t.VehicleId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
