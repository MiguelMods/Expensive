using Expensive.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Expensive.Persistance;

public static class Dependencies
{
    public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ExpensiveApplicationDataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ExpansiveApiDatabaseConnection")));
    }   
}
