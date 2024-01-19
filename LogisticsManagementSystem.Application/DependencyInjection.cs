using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace LogisticsManagementSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));
        services.AddAutoMapper(typeof(DependencyInjection));
        return services;
    }
}
