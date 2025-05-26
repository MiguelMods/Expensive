using Expensive.Common.Intergace;
using Expensive.Domain.Entities;

namespace Expensive.Common.Response;

public class CategorieResponse : BaseResponse, ICustomMapToResponse<Categories, CategorieResponse>
{
    public int CategorieId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsDefault { get; set; }
    public string? Operation { get; set; }

    public CategorieResponse MapToResponse(Categories entity) => new()
    {
        CategorieId = entity.CategorieId,
        Name = entity.Name,
        Description = entity.Description,
        IsDefault = entity.IsDefault,
        Operation = entity.Operation,
        CreatedAt = entity.CreatedAt,
        CreatedBy = entity.CreatedBy,
        UpdatedAt = entity.UpdatedAt,
        UpdatedBy = entity.UpdatedBy,
        IsActive = entity.IsActive,
        IsDeleted = entity.IsDeleted,
        RowGuid = entity.RowGuid
    };
}
