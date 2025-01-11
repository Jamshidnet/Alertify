using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Alertify.Application.Common.Interfaces;
using Alertify.Infrastructure.Services;
using Alertify.Infrastructure.Persistence;
using Alertify.Infrastructure.Persistence.Interceptors;

namespace Alertify.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DbConnect"));
            options.UseLazyLoadingProxies();
        });

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        return services;
    }
}
