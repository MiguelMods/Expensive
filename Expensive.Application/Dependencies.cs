using Expensive.Application.Services.Contracts;
using Expensive.Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Expensive.Application;

public static class Dependencies
{
    public static void AddApplication(this IServiceCollection services)
    {
        // Register services
        services.AddScoped<ICategorieService, CategorieService>();
        services.AddScoped<IReadOnlyCategorieService, ReadOnlyCategorieService>();
    }
}
