using Expensive.Application.Services.Contracts;
using Expensive.Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Expensive.Application;

public static class Depencies
{
    public static void AddApplicationDepencies(this IServiceCollection services)
    {
        services.AddScoped<ICategorieService, CategorieService>();
    }
}
