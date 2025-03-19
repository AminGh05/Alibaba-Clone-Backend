using AlibabaClone.Domain.Aggregates.AccountAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations
{
	internal class PersonConfiguration : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.HasKey(p => p.Id);
			// auto-generate id
			builder.Property(p => p.Id)
				.ValueGeneratedOnAdd();

			// first-name
			builder.Property(p => p.FirstName)
				.IsRequired()
				.HasMaxLength(50);

			// last-name
			builder.Property(p => p.LastName)
				.IsRequired()
				.HasMaxLength(50);

			// id-number
			builder.Property(p => p.IdNumber)
				.IsRequired()
				.HasMaxLength(20)
				.IsUnicode(false);
			builder.HasIndex(p => p.IdNumber)
				.IsUnique();

			// birthdate
			builder.Property(p => p.BirthDate)
				.HasColumnType("date");

			// gender-id
			builder.Property(p => p.GenderId)
				.IsRequired();

			// passport
			builder.Property(p => p.PassportNumber)
				.IsUnicode(false)
				.HasMaxLength(30);

			// gender foreign-key
			builder.HasOne(p => p.Gender)
				.WithMany()
				.HasForeignKey(p => p.GenderId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
