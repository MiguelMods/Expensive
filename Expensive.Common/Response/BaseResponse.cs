namespace Expensive.Common.Response;

public abstract class BaseResponse
{
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string? RowGuid { get; set; }
}
