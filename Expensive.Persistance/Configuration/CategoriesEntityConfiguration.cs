using Expensive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expensive.Persistance.Configuration;

public class CategoriesEntityConfiguration : IEntityTypeConfiguration<Categories>
{
    public void Configure(EntityTypeBuilder<Categories> builder)
    {
        builder.ToTable("Categories", "dbo");
        builder.HasKey(c => c.CategorieId);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName("IX_Categories_Name");
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasData(new Categories
        {
            CategorieId = 1,
            Name = "Hogar",
            Description = "Categoria de gastos del Hogar",
            CreatedBy = "Created By Default"
        }, 
        new Categories() 
        {
            CategorieId = 2,
            Name = "Automovil",
            Description = "Categoria de gastos del Automovil",
            CreatedBy = "Created By Default"
        },
        new Categories()
        {
            CategorieId = 3,
            Name = "Mascotas",
            Description = "Categoria de gastos del Mascotas",
            CreatedBy = "Created By Default"
        },
        new Categories()
        {
            CategorieId = 4,
            Name = "Salud",
            Description = "Categoria de gastos del Salud",
            CreatedBy = "Created By Default"
        },
        new Categories() 
        {
            CategorieId = 5,
            Name = "Mercado",
            Description = "Categoria de gastos del Mercado",
            CreatedBy = "Created By Default"
        },
        new Categories() 
        {
            CategorieId = 6,
            Name = "Entretenimiento",
            Description = "Categoria de gastos del Entretenimiento",
            CreatedBy = "Created By Default"
        });
    }
}