
using LogisticsManagementSystem.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogisticsManagementSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
             .AddHttpContextAccessor()
             .AddServices()
             .AddAuthentication(configuration)
             .AddAuthorization()
             .AddPersistence(configuration);

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IPasswordEncryption, PasswordEncryption>();
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<SoftDeleteInterceptor>();

        services.AddDbContext<AppDbContext>(
            (sp, options) => options
                .UseNpgsql(configuration.GetConnectionString("AppDbContext"))
                .AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>())
            );

        services.AddTransient<SeedDataInitializer>();
        var passwordSettings = new PasswordSettings
        {
            RequiredLength = 8,
            RequireUppercase = false,
            RequireLowercase = true,
            RequireDigit = true,
            RequireNonAlphanumeric = false,
            RequiredUniqueChars = 1
        };

        services.AddSingleton<IPasswordSettings>(passwordSettings);


        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserRolesRepository, UserRolesRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<ICustomerRepository, CustomersRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoleMenusRepository, RoleMenusRepository>();
        services.AddScoped<IRolePermissionRepository, RolePermissionsRepository>();
        services.AddScoped<IRoleCompaniesRepository, RoleCompaniesRepository>();




        return services;
    }

    private static IServiceCollection AddAuthorization(this IServiceCollection services)
    {
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
        services.AddSingleton<IPolicyEnforcer, PolicyEnforcer>();

        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services
            .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
            .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        return services;
    }
}
