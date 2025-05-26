using Expensive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expensive.Persistance.Configuration;

public class UserCategoriesEntityConfiguration : IEntityTypeConfiguration<UserCategories>
{
    public void Configure(EntityTypeBuilder<UserCategories> builder)
    {
        builder.ToTable("UserCategories", "dbo");
        builder.HasKey(uc => uc.UserCategorieId);
        builder.HasIndex(uc => new { uc.UserId, uc.CategorieId }).IsUnique().HasDatabaseName("IX_UserCategories_UserId_CategorieId");
        builder.Property(x => x.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(x => x.RowGuid).IsUnique().HasDatabaseName("IX_UserCategories_RowGuid");
        builder.HasOne(uc => uc.User)
               .WithMany(u => u.UserCategories)
               .HasForeignKey(uc => uc.UserId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(uc => uc.Categorie)
               .WithMany(c => c.UserCategories)
               .HasForeignKey(uc => uc.CategorieId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasData(new UserCategories
        {
            UserCategorieId = 1,
            CategorieId = 1,
            UserId = 1,
            CreatedBy = "Created By Default"
        }, 
        new UserCategories 
        {
            UserCategorieId = 2,
            CategorieId = 2,
            UserId = 1,
            CreatedBy = "Created By Default"
        },
        new UserCategories
        {
            UserCategorieId = 3,
            CategorieId = 3,
            UserId = 1,
            CreatedBy = "Created By Default"
        },
        new UserCategories
        {
            UserCategorieId = 4,
            CategorieId = 4,
            UserId = 1,
            CreatedBy = "Created By Default"
        },
        new UserCategories
        {
            UserCategorieId = 5,
            CategorieId = 5,
            UserId = 1,
            CreatedBy = "Created By Default"
        },
        new UserCategories
        {
            UserCategorieId = 6,
            CategorieId = 6,
            UserId = 1,
            CreatedBy = "Created By Default"
        },
        new UserCategories
        {
            UserCategorieId = 7,
            CategorieId = 7,
            UserId = 1,
            CreatedBy = "Created By Default"
        },
        new UserCategories
        {
            UserCategorieId = 8,
            CategorieId = 8,
            UserId = 1,
            CreatedBy = "Created By Default"
        });
    }
}
