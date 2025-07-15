using System.Reflection;
using Biogenom.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Biogenom.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMappers();

        return services;
    }

    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddProfile<NutritionProfile>());

        return services;
    }
    
}