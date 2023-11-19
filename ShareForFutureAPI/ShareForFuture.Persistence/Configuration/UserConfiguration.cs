namespace ShareForFuture.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareForFuture.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.MiddleName)
            .HasMaxLength(50);

        builder.Property(u => u.Street)
            .HasMaxLength(100);

        builder.Property(u => u.City)
            .HasMaxLength(50);

        builder.Property(u => u.Country)
            .HasMaxLength(50);

        builder.Property(u => u.ZipCode)
            .HasMaxLength(10);

        builder.HasMany(u => u.Offerings)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId);

        builder.HasMany(u => u.Lendings)
            .WithOne(s => s.Borrower)
            .HasForeignKey(s => s.BorrowerId);
    }
}
