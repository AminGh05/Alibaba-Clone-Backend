using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TransactionConfigurations
{
    public class TicketOrderConfiguration : IEntityTypeConfiguration<TicketOrder>
    {
        public void Configure(EntityTypeBuilder<TicketOrder> builder)
        {
            builder.HasKey(to => to.Id);
            // auto-generate id
            builder.Property(to => to.Id)
                .ValueGeneratedOnAdd();

            // transportation-id
            builder.Property(to => to.TransportationId)
                .IsRequired();

            // buyer-id
            builder.Property(to => to.BuyerId)
                .IsRequired();

            // created date-time
            builder.Property(to => to.CreatedAt)
                .IsRequired();

            // serial-number
            builder.Property(to => to.SerialNumber)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(50);
            builder.HasIndex(to => to.SerialNumber)
                .IsUnique();

            // description
            builder.Property(to => to.Description)
                .IsRequired(false)
                .HasMaxLength(500);

            // transportation foreign-key
            builder.HasOne(to => to.Transportation)
                .WithMany(tr => tr.TicketOrders)
                .HasForeignKey(to => to.TransportationId)
                .OnDelete(DeleteBehavior.Restrict);

            // buyer foreign-key
            builder.HasOne(to => to.Buyer)
                .WithMany(b => b.BoughtTicketOrders)
                .HasForeignKey(to => to.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
