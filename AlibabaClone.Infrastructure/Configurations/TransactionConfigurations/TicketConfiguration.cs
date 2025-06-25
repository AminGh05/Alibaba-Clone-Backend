using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TicketConfigurations
{
	public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
	{
		public void Configure(EntityTypeBuilder<Ticket> builder)
		{
			builder.HasKey(t => t.Id);
			// auto-generate id
			builder.Property(t => t.Id)
				.ValueGeneratedOnAdd();

			// ticket-order-id
			builder.Property(t => t.TicketOrderId)
				.IsRequired();

			// seat-id
			builder.Property(t => t.SeatId)
				.IsRequired();

			// traveler-id
			builder.Property(t => t.TravelerId)
				.IsRequired();

			// created date-time
			builder.Property(t => t.CreatedAt)
				.IsRequired();

            // canceled date-time
			builder.Property(t => t.CanceledAt)
				.IsRequired(false);

            // companion-id
			builder.Property(t => t.CompanionId)
				.IsRequired(false);

            // ticket-status-id
            builder.Property(t => t.TicketStatusId)
				.IsRequired();

			// serial-number
			builder.Property(t => t.SerialNumber)
				.IsRequired()
				.IsUnicode(false)
				.HasMaxLength(50);
			builder.HasIndex(t => t.SerialNumber)
				.IsUnique();

            // description
            builder.Property(t => t.Description)
				.HasMaxLength(500);

			// ticket-order foreign-key
			builder.HasOne(t => t.TicketOrder)
				.WithMany(to => to.Tickets)
				.HasForeignKey(t => t.TicketOrderId)
				.OnDelete(DeleteBehavior.Restrict);

			// seat foreign-key
			builder.HasOne(t => t.Seat)
				.WithMany(s => s.Tickets)
				.HasForeignKey(t => t.SeatId)
				.OnDelete(DeleteBehavior.Restrict);

			// traveler foreign-key
			builder.HasOne(t => t.Traveler)
				.WithMany(tr => tr.TraveledTickets)
				.HasForeignKey(t => t.TravelerId)
				.OnDelete(DeleteBehavior.Restrict);

			// companion foreign-key
			builder.HasOne(t => t.Companion)
				.WithMany()
				.HasForeignKey(t => t.CompanionId)
				.OnDelete(DeleteBehavior.Restrict);

			// ticket-status foreign-key
			builder.HasOne(t => t.TicketStatus)
				.WithMany()
				.HasForeignKey(t => t.TicketStatusId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
