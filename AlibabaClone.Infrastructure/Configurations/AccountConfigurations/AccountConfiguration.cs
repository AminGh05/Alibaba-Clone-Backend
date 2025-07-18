﻿using AlibabaClone.Domain.Aggregates.AccountAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlibabaClone.Infrastructure.Configurations.AccountConfigurations
{
	public class AccountConfiguration : IEntityTypeConfiguration<Account>
	{
		public void Configure(EntityTypeBuilder<Account> builder)
		{
			builder.HasKey(a => a.Id);
			// auto-generate id
			builder.Property(a => a.Id)
				.ValueGeneratedOnAdd();
			
			// phone
			builder.Property(a => a.PhoneNumber)
				.IsRequired()
				.IsUnicode(false)
				.HasMaxLength(15);
			
			// password
			builder.Property(a => a.Password)
				.IsRequired()
				.IsUnicode(false)
				.IsFixedLength()
				.HasMaxLength(64);
			
			// email
			builder.Property(a => a.Email)
				.IsRequired()
				.IsUnicode(false)
				.HasMaxLength(50);

			// person-id
			builder.Property(a => a.PersonId)
				.IsRequired(false);

			// balance
			builder.Property(a => a.Balance)
				.HasColumnType("decimal(18,2)");

            // person foreign-key
            builder.HasOne(a => a.Person)
				.WithOne()
				.HasForeignKey<Account>(a => a.PersonId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
