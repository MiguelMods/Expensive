namespace Expensive.Common.Results;

public class Result<Type>
{
    public bool IsSuccess { get; set; }
    public Type? Data { get; set; }
    public string? Message { get; set; }
    public static Result<Type> Success() => new()
    {
        IsSuccess = true,
        Data = default,
        Message = null
    };
    public static Result<Type> Success(Type? data, string? message = null) => new()
    {
        IsSuccess = true,
        Data = data,
        Message = message
    };
    public static Result<Type> Failure(string? message) => new()
    {
        IsSuccess = false,
        Data = default,
        Message = message
    };
}