namespace ShareForFuture.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareForFuture.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SharingConfiguration : IEntityTypeConfiguration<Sharing>
{
    public void Configure(EntityTypeBuilder<Sharing> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasOne(s => s.Offering).WithMany(o => o.Sharings)
            .HasForeignKey(s => s.OfferingId).OnDelete(DeleteBehavior.Restrict)
            .IsRequired(true);

        builder.HasOne(s => s.Borrower).WithMany(u => u.Lendings)
            .HasForeignKey(s => s.BorrowerId).OnDelete(DeleteBehavior.Restrict)
            .IsRequired(true);

        builder.HasCheckConstraint("UntilAfterFrom",
            $"[{nameof(Sharing.Until)}] > [{nameof(Sharing.From)}]");

        builder.Property(s => s.AcceptDeclineMessage)
            .HasMaxLength(500);

        builder.Property(s => s.BorrowerRatingNote)
            .HasMaxLength(500);

        builder.Property(s => s.LenderRatingNote)
            .HasMaxLength(500);

        builder.Property(s => s.DeviceRatingNote)
            .HasMaxLength(500);
    }
}
