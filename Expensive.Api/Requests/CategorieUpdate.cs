namespace Expensive.Api.Requests
{
    public record CategorieUpdateRequest(string RowGuid, string Name, string Description, string Operation = "Expensive");
}
