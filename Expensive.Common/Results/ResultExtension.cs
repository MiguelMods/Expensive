namespace Expensive.Common.Results;

public static class ResultExtension
{
    public static Result<Type> Success<Type>(this Type? data, string? message = null)
        => Result<Type>.Success(data, message);

    public static Result<Type> Failure<Type>(this Type? data, string? message = null) => 
        Result<Type>.Failure(message);
}
