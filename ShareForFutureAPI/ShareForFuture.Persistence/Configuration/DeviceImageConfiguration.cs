namespace ShareForFuture.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareForFuture.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DeviceImageConfiguration : IEntityTypeConfiguration<DeviceImage>
{
    public void Configure(EntityTypeBuilder<DeviceImage> builder)
    {
        builder.HasKey(di => di.Id);

        builder.Property(di => di.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(di => di.Offering).WithMany(o => o.Images)
            .HasForeignKey(di => di.OfferingId).OnDelete(DeleteBehavior.Cascade)
            .IsRequired(true);
    }
}

