using Expensive.Common.Results;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Expensive.Api.Filters
{
    public class RequestModelsValidatorsFilter(IServiceProvider serviceProvider) : IAsyncActionFilter
    {
        public IServiceProvider ServiceProvider { get; } = serviceProvider;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument == null)
                {
                    var result = Result<string[]>.Failure("Validation Errors");
                    result.Data = ["Argument cannot be null"];
                    context.Result = new BadRequestObjectResult(result);
                    return;
                }

                var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());

                if (ServiceProvider.GetService(validatorType) is IValidator validator)
                {
                    var validationContext = new ValidationContext<object>(argument);
                    var validationResult = await validator.ValidateAsync(validationContext);

                    if (!validationResult.IsValid)
                    {
                        var result = Result<string[]>.Failure("Validation Errors");
                        result.Data = validationResult.Errors.Select(e => e.ErrorMessage).ToArray();
                        context.Result = new BadRequestObjectResult(result);
                        return;
                    }
                }
            }

            await next();
        }
    }
}
