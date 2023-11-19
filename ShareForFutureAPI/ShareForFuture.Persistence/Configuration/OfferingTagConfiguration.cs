namespace ShareForFuture.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareForFuture.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OfferingTagConfiguration : IEntityTypeConfiguration<OfferingTag>
{
    public void Configure(EntityTypeBuilder<OfferingTag> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Tag).HasMaxLength(50);
        builder.HasIndex(t => t.Tag).IsUnique();
    }
}
