namespace Expensive.Common.Results;

public class Result<Type>
{
    public bool IsSuccess { get; set; }
    public string? Messages { get; set; }
    public Type? Data { get; set; }
    public static Result<Type> Success() => new()
    {
        IsSuccess = true,
        Messages = string.Empty,
    };
    public static Result<Type> Success(Type data) => new()
    {
        IsSuccess = true,
        Messages = string.Empty,
        Data = data
    };
    public static Result<Type> Failure(string message) => new()
    {
        IsSuccess = false,
        Messages = message,
        Data = default
    };
    public static Result<Type> Failure(string message, Type data) => new()
    {
        IsSuccess = false,
        Messages = message,
        Data = data
    };
}
