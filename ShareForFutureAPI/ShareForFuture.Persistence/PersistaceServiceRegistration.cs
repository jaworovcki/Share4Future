using System;
namespace ShareForFuture.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShareForFuture.Persistence.Data;
using ShareForFuture.Persistence.Repositories;
using ShareForFututre.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class PersistaceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
                   options.UseNpgsql(configuration.GetConnectionString("ShareForFutureConnectionString")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOfferingRepository, OfferingRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISharingRepository, SharingRepository>();

        return services;
    }
}
