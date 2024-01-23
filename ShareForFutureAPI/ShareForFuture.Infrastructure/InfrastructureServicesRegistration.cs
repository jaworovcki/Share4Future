using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ShareForFuture.Domain.DomainModels;
using ShareForFuture.Infrastructure.Consts;
using ShareForFuture.Infrastructure.Services;
using ShareForFuture.Persistence.Data;
using ShareForFututre.Application.Contracts.Services;

namespace ShareForFuture.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ITokenHandler, Services.TokenHandler>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddIdentity<User, IdentityRole>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.User.AllowedUserNameCharacters = null;
        }).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

        services.AddAuthentication(cfg =>
        {
            cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opts =>
        {
            opts.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy("RequireAdminRole", policy => policy.RequireRole(DbRolesConsts.AdminRole));
            options.AddPolicy("RequireMemberRole", policy => policy.RequireRole(DbRolesConsts.UserRole));
            options.AddPolicy("RequireMemberOrAdminRole", policy => policy.RequireRole(DbRolesConsts.UserRole, DbRolesConsts.AdminRole));
        });

        return services;
    }
}