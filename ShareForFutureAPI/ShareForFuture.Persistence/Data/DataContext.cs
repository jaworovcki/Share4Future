namespace ShareForFuture.Persistence.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShareForFuture.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
        
    }

    public DbSet<Offering> Offerings { get; set; } = null!;

    public DbSet<Sharing> Sharings { get; set; } = null!;

    public DbSet<DeviceCategory> DeviceCategories { get; set; } = null!;

    public DbSet<DeviceSubCategory> DeviceSubCategories { get; set; } = null!;

    public DbSet<OfferingTag> OfferingTags { get; set; } = null!;

    public DbSet<DeviceImage> DeviceImages { get; set; } = null!;

    public DbSet<UnavailabilityPeriod> UnavailabilityPeriods { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        base.OnModelCreating(builder);
    }
}