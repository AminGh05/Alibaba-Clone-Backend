using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations
{
	internal class TicketStatusConfiguration : IEntityTypeConfiguration<TicketStatus>
	{
		public void Configure(EntityTypeBuilder<TicketStatus> builder)
		{
			builder.HasKey(ts => ts.Id);
			// auto-generate id
			builder.Property(ts => ts.Id)
				.ValueGeneratedOnAdd();

			// title
			builder.Property(ts => ts.Ttile)
				.IsRequired()
				.HasMaxLength(30);

			// index ticket-status titles as unique
			builder.HasIndex(ts => ts.Ttile)
				.IsUnique();
		}
	}
}
