using AlibabaClone.Domain.Aggregates.AccountAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.AccountConfigurations
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(ba => ba.Id);
            // auto-generate id
            builder.Property(ba => ba.Id)
                .ValueGeneratedOnAdd();

            // bank-name
            builder.Property(ba => ba.BankName)
                .IsRequired(false)
                .IsUnicode(false)
                .HasMaxLength(50);

            // card-number
            builder.Property(ba => ba.CardNumber)
                .IsRequired(false)
                .IsUnicode(false)
                .HasMaxLength(16);

            // iban
            builder.Property(ba => ba.IBAN)
                .IsRequired(false)
                .IsUnicode(false)
                .HasMaxLength(24);

            // bank-account-number
            builder.Property(ba => ba.BankAccountNumber)
                .IsRequired(false)
                .IsUnicode(false)
                .HasMaxLength(50);

            // index account-id as unique
            builder.HasIndex(ba => ba.AccountId)
                .IsUnique();

            // account foreign-key
            builder.HasOne(ba => ba.Account)
                .WithOne(a => a.BankAccount)
                .HasForeignKey<BankAccount>(ba => ba.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
