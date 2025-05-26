using Expensive.Application.Services.Contracts;
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
            return Ok(categories);
        }

        [HttpGet("{rowguid}")]
        public async Task<IActionResult> Get(string rowguid)
        {
            var categories = await CategorieService.GetByRowGuidAsync(rowguid);
            return Ok(categories);
        }
    }
}
