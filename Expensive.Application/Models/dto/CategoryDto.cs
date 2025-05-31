using Expensive.Application.Response;
using Expensive.Domain.Entities;

namespace Expensive.Application.Models.dto;

public class CategoryDto : BaseResponse
{
    public long CategorieId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public static explicit operator CategoryDto(Categories categories)
    {
        return new CategoryDto
        {
            CategorieId = categories.CategorieId,
            Name = categories.Name,
            Description = categories.Description,
            CreatedAt = categories.CreatedAt,
            CreatedBy = categories.CreatedBy,
            UpdatedAt = categories.UpdatedAt,
            UpdatedBy = categories.UpdatedBy,
            IsActive = categories.IsActive,
            IsDeleted = categories.IsDeleted,
            RowGuid = categories.RowGuid
        };
    }
}