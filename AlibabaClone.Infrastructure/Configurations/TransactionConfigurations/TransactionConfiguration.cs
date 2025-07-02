using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TicketConfigurations
{
	public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
	{
		public void Configure(EntityTypeBuilder<Transaction> builder)
		{
			builder.HasKey(t => t.Id);
			// auto-generate id
			builder.Property(t => t.Id)
				.ValueGeneratedOnAdd();

            // transaction-type-id
			builder.Property(t => t.TransactionTypeId)
				.IsRequired();

            // account-id
			builder.Property(t => t.AccountId)
				.IsRequired();

            // base-amount
            builder.Property(t => t.BaseAmount)
				.IsRequired()
				.HasColumnType("decimal(18,2)");

			// final-amount
			builder.Property(t => t.FinalAmount)
				.IsRequired()
				.HasColumnType("decimal(18,2)");

			// serial-number
			builder.Property(t => t.SerialNumber)
				.IsRequired()
				.HasMaxLength(50)
				.IsUnicode(false);

			// ticket-order-id
			builder.Property(t => t.TicketOrderId)
				.IsRequired(false);

			// created date-time
			builder.Property(t => t.CreatedAt)
				.IsRequired();

			// description
			builder.Property(t => t.Description)
				.IsRequired(false)
				.HasMaxLength(500);

            // transaction-type foreign-key
			builder.HasOne(t => t.TransactionType)
				.WithMany()
				.HasForeignKey(t => t.TransactionTypeId)
				.OnDelete(DeleteBehavior.Restrict);

            // account foreign-key
			builder.HasOne(t => t.Account)
				.WithMany(a => a.Transactions)
				.HasForeignKey(t => t.AccountId)
				.OnDelete(DeleteBehavior.Restrict);

            // ticket-order foreign-key
            builder.HasOne(t => t.TicketOrder)
				.WithOne(to => to.Transaction)
                .HasForeignKey<Transaction>(t => t.TicketOrderId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
