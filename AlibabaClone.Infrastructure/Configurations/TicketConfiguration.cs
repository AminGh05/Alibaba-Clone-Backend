using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations
{
	internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
	{
		public void Configure(EntityTypeBuilder<Ticket> builder)
		{
			builder.HasKey(t => t.Id);
			// auto-generate id
			builder.Property(t => t.Id)
				.ValueGeneratedOnAdd();

			// transportation-id
			builder.Property(t => t.TransportationId)
				.IsRequired();

			// seat-id
			builder.Property(t => t.SeatId)
				.IsRequired();

			// traveler-id
			builder.Property(t => t.TravelerId)
				.IsRequired();

			// buyer-id
			builder.Property(t => t.BuyerId)
				.IsRequired();

			// created date-time
			builder.Property(t => t.CreatedAt)
				.IsRequired();

			// ticket-status-id
			builder.Property(t => t.TicketStatusId)
				.IsRequired();

			// serial-number
			builder.Property(t => t.SerialNumber)
				.IsRequired()
				.IsUnicode(false)
				.HasMaxLength(50);

			// description
			builder.Property(t => t.Description)
				.HasMaxLength(1000);

			// transportation foreign-key
			builder.HasOne(t => t.Transportation)
				.WithMany(tr => tr.Tickets)
				.HasForeignKey(t => t.TransportationId)
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

			// buyer foreign-key
			builder.HasOne(t => t.Buyer)
				.WithMany(b => b.BoughtTickets)
				.HasForeignKey(t => t.BuyerId)
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
