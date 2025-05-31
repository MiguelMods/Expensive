using Expensive.Application.Services.Contracts;
using Expensive.Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Expensive.Application;

public static class Dependencies
{
    public static void AddApplication(this IServiceCollection services)
    {
        // Register services
        services.AddScoped<IHttpContextUserHelper, HttpContextUserHelper>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IHashPassordService, HashPassordService>();
        services.AddScoped<ICategorieService, CategorieService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IUserCategoriesService, UserCategoriesService>();
        services.AddScoped<IReadOnlyCategorieService, ReadOnlyCategorieService>();
    }
}
