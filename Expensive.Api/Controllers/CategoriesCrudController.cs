using Expensive.Api.Requests;
using Expensive.Application.Responses;
using Expensive.Application.Services.Contracts;
using Expensive.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace Expensive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesCrudController(ICategorieService categorieService) : ControllerBase
    {
        public ICategorieService CategorieService { get; } = categorieService;

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var result = await CategorieService.GetAllAsync();

            var response = result.Select(new CategorieResponse().MapToResponse!);

            return response is null
                ? BadRequest(response.Failure())
                : Ok(response.Success());
        }

        [HttpGet("{rowGuid}")]
        public async Task<IActionResult> GetBy(string rowGuid)
        {
            var result = await CategorieService.GetByRowGuidAsync(rowGuid);

            if (result is null)
                return NotFound(new CategorieResponse().Failure($"Value not found for: {rowGuid}"));

            var response = new CategorieResponse().MapToResponse(result!);

            return Ok(response.Success());
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CategorieAdd request)
        {
            var result = await CategorieService.AddAsync(new()
            {
                Name = request.Name,
                Description = request.Description,
                Operation = request.Operation,
                CreatedBy = "Expensive.Api"
            });
            var response = new CategorieResponse().MapToResponse(result!);

            return response is null
                ? BadRequest(response.Failure())
                : Ok(response.Success());
        }

        [HttpPut("")]
        public async Task<IActionResult> Put([FromBody] CategorieUpdate request)
        {
            var result = await CategorieService.UpdateAsync(new()
            {
                RowGuid = request.RowGuid,
                Name = request.Name,
                Description = request.Description,
                Operation = request.Operation,
                UpdatedBy = "Expensive.Api"
            });
            var response = new CategorieResponse().MapToResponse(result!);

            return response is null
                ? BadRequest(response.Failure())
                : Ok(response.Success());
        }

        [HttpDelete("{rowGuid}")]
        public async Task<IActionResult> Delete(string rowGuid)
        {
            var result = await CategorieService.DeleteAsync(rowGuid);
            return result
                ? Ok(result.Success())
                : NotFound(result.Failure($"Value not found for: {rowGuid}"));
        }
    }
}
