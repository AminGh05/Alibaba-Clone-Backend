using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.TransactionConfigurations
{
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.HasKey(tt => tt.Id);
            // auto-generate id
            builder.Property(tt => tt.Id)
                .ValueGeneratedOnAdd();

            // title
            builder.Property(tt => tt.Title)
                .IsRequired()
                .HasMaxLength(50);

            // index transaction-type titles as unique
            builder.HasIndex(tt => tt.Title)
                .IsUnique();
        }
    }
}
