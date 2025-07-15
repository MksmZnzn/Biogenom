using Biogenom.Application;
using Biogenom.Application.Interfaces;
using Biogenom.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Biogenom.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbServices(configuration);
        services.AddServices();
        services.AddRepository();
        return services;
    }

    public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnectionString"); // Исправлено: опечатка в "Conntection"

        Console.WriteLine(connectionString);
        services.AddDbContextFactory<BiogenomDbContext>(opt => 
            opt.UseNpgsql(connectionString));

        
        services.AddScoped<IBiogenomDbContextFactory, BiogenomDbContextFactory>();
    
        services.AddScoped<IBiogenomDbContext, BiogenomDbContext>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<INutritionService, NutritionService>();

        return services;
    }

    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<INutritionRepository, NutritionRepository>();

        return services;
    }
}