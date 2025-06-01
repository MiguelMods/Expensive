namespace Expensive.Api.Requests;

public record CategorieUpdateRequest(long categoryId, string RowGuid, string Name, string Description, string Operation = "Expensive");