namespace Expensive.Api.Requests
{
    public record CategorieUpdate(string RowGuid, string Name, string Description, string Operation = "Expensive");
}
