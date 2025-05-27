using Expensive.Api.Requests;
using Expensive.Application.Services.Contracts;
using Expensive.Common.Response;
using Expensive.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace Expensive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategorieService categorieService) : ControllerBase
    {
        public ICategorieService CategorieService { get; } = categorieService;

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var categories = await CategorieService.GetAllAsync();
            return Ok(Result<IEnumerable<CategorieResponse>>.Success(categories));
        }

        [HttpGet("{rowguid}")]
        public async Task<IActionResult> Get(string rowguid)
        {
            var categories = await CategorieService.GetByRowGuidAsync(rowguid);

            if (categories == null)
                return BadRequest(Result<bool>.Failure($"Categoria no encontrada para el identificador: {rowguid}"));

            return Ok(Result<CategorieResponse>.Success(categories));
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CategorieAddRequest request) 
        {
            var result = await CategorieService.AddAsync(new() { Name = request.Name, Description = request.Description, Operation = "EXPENSIVE", CreatedBy = "default" });

            if (result == null)
                return BadRequest(Result<bool>.Failure("No se pudo crear la nueva entidad"));

            return Created("", Result<BaseResponse>.Success(result, $"Nueva Categoria: {result.Name}, creada con Exito"));
        }
    }
}
