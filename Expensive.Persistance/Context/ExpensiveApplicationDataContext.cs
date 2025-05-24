using Expensive.Domain.Entities;
using Expensive.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Expensive.Persistance.Context;

public class ExpensiveApplicationDataContext(DbContextOptions<ExpensiveApplicationDataContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Categories> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoriesEntityConfiguration());
    }
}
