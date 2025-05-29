namespace Expensive.Api.Requests
{
    public record CategorieAdd(string Name, string Description, string Operation = "Expensive");
    public record CategorieUpdate(string RowGuid, string Name, string Description, string Operation = "Expensive");
}
