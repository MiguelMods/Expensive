using Microsoft.AspNetCore.Mvc;
using Expensive.Application.Services.Contracts;
using Expensive.Common.Results;

namespace Expensive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(IReadOnlyCategorieService service) : ControllerBase
    {
        public IReadOnlyCategorieService Service { get; } = service;

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var result = await Service.GetAllAsync();
            return result is null ? 
                BadRequest(result.Failure()) : Ok(result.Success());
        }

        [HttpGet("{rowguid}")]
        public async Task<IActionResult> GetByRowGuid(string rowguid)
        {
            var result = await Service.GetByRowGuidAsync(rowguid);
            return result is null ? 
                NotFound(result.Failure($"Value not found for: {rowguid}")) : Ok(result.Success());
        }

        [HttpGet("expression/{parameterName}/{parameterValue}")]
        public async Task<IActionResult> GetByExpression(string parameterName, string parameterValue)
        {
            var result = await Service.GetByParameterNameAndValueAsync(parameterName, parameterValue);
            return result is null ? 
                NotFound(result.Failure($"Value not found for: {parameterName} and {parameterValue}")) : Ok(result.Success());
        }

        [HttpGet("like/{parameterName}/{parameterValue}")]
        public async Task<IActionResult> GetByLikeExpression(string parameterName, string parameterValue)
        {
            var result = await Service.GetByLikeByParameterNameAndValueAsync(parameterName, parameterValue);
            return result is null ? 
                NotFound(result.Failure($"Value not found for: {parameterName} and {parameterValue}")) : Ok(result.Success());
        }
    }
}
