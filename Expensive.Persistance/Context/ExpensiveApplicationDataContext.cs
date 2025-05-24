using Microsoft.EntityFrameworkCore;

namespace Expensive.Persistance.Context;

public class ExpensiveApplicationDataContext(DbContextOptions<ExpensiveApplicationDataContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbContextOptions DbContextOptions { get; } = dbContextOptions;
}
