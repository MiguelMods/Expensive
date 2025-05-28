namespace Expensive.Common.Results;

public static class ResultExtension
{
    public static Result<Type> ToResult<Type>(this Type? data, string? message = null)
    {
        if (data is null)
            return Result<Type>.Failure("Data is null");

        return Result<Type>.Success(data, message);
    }
}
