namespace Expensive.Api.Requests;

public record CategorieAddRequest(string Name, string Description, string Operation = "Expensive");