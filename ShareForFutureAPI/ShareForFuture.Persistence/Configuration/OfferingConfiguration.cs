namespace ShareForFuture.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareForFuture.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OfferingConfiguration : IEntityTypeConfiguration<Offering>
{
    public void Configure(EntityTypeBuilder<Offering> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasOne(o => o.User).WithMany(u => u.Offerings)
            .HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Restrict)
            .IsRequired(true);

        builder.Property(o => o.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(o => o.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(o => o.Condition).HasConversion<string>();

        builder.HasOne(o => o.SubCategory).WithMany(s => s.Offerings)
            .HasForeignKey(o => o.SubCategoryId).OnDelete(DeleteBehavior.Restrict)
            .IsRequired(true);

        builder.HasMany(o => o.Tags).WithMany(t => t.Offerings).UsingEntity(
            "OfferingsTags",
            j => j.HasOne(typeof(OfferingTag)).WithMany().OnDelete(DeleteBehavior.Restrict),
            j => j.HasOne(typeof(Offering)).WithMany().OnDelete(DeleteBehavior.Cascade));
    }
}

