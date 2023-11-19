namespace ShareForFuture.Persistence.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareForFuture.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DeviceSubCategoryConfiguration : IEntityTypeConfiguration<DeviceSubCategory>
{
    public void Configure(EntityTypeBuilder<DeviceSubCategory> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Title).HasMaxLength(100);

        // Requirement: Each category consists of a list of subcategories. 
        builder.HasOne(d => d.Category).WithMany(d => d.SubCategories)
            .HasForeignKey(d => d.CategoryId).OnDelete(DeleteBehavior.Restrict)
            .IsRequired(true);
    }
}
