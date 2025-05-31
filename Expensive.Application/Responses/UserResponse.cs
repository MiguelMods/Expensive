using Expensive.Application.Contracts;
using Expensive.Domain.Entities;

namespace Expensive.Application.Responses;

public class UserResponse : BaseResponse, IMapResponse<Users, UserResponse>
{
    public long UserId { get; set; }
    public string? FirtsName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public UserResponse MapToResponse(Users entity)
        => new() { 
            UserId = entity.UserId,
            FirtsName = entity.FirtsName,
            LastName = entity.LastName,
            Email = entity.Email,
            UserName = entity.UserName,
            Password = entity.Password,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,
            RowGuid = entity.RowGuid,
        };
}
