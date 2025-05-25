using Expensive.Application.Repository.Contract;
using Expensive.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Expensive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private IUnitOfWork UnitOfWork { get; } = unitOfWork;

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{rowguid}")]
        public async Task<IActionResult> Get(string rowguid)
        {
            var categories = await UnitOfWork.Categories.GetByRowGuidAsync(rowguid);
            return Ok(categories);
        }

        [HttpGet("{parameterName}/{parameterValue}")]
        public async Task<IActionResult> Get(string parameterName, string parameterValue)
        {
            Expression<Func<Categories, bool>> expression = parameterName switch
            {
                "categoriesId" => (x => x.CategorieId == long.Parse(parameterValue)),
                "Description" => x => x.Description == parameterValue,
                _ => throw new ArgumentException("Invalid parameter name")
            };
            var categories = await UnitOfWork.Categories.GetByExpressionAsync(expression);
            return Ok(categories);
        }
    }
}
