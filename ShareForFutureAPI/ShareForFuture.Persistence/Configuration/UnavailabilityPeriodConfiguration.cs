namespace ShareForFuture.Persistence.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareForFuture.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UnavailabilityPeriodConfiguration : IEntityTypeConfiguration<UnavailabilityPeriod>
{
    public void Configure(EntityTypeBuilder<UnavailabilityPeriod> builder)
    {
        builder.HasKey(u => u.Id);

    }
}
