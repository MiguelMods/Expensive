using Expensive.Api.Requests;
using Expensive.Application.Models;
using Expensive.Application.Models.dto;
using Expensive.Application.Services.Contracts;
using Expensive.Common.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Expensive.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserCategoriesController(IUsersService usersService, IUserCategoriesService userCategoriesService, IHttpContextUserHelper httpContextUserHelper) : ControllerBase
{
    private IUsersService UsersService { get; } = usersService;
    private IUserCategoriesService UserCategoriesService { get; } = userCategoriesService;
    private IHttpContextUserHelper HttpContextUserHelper { get; } = httpContextUserHelper;
    private UserToken UserToken => HttpContextUserHelper.GetUserToken() ?? throw new InvalidOperationException("User token not found in the context.");
    [HttpGet("")]
    public async Task<IActionResult> GetAllUserCategories()
    {
        if (string.IsNullOrEmpty(UserToken.UserName))
            return BadRequest("User ID not found in claims.".Failure());

        var userId = await UsersService.GetByUserNameAsync(UserToken.UserName);

        var categories = await UserCategoriesService.GetAllUserCategories(userId.UserId);

        if (categories == null || !categories.Any())
        {
            var defaultCategories = await UserCategoriesService.AddDefaultUserCategories(userId.UserId);

            if (!defaultCategories)
                return BadRequest("Failed to add default categories for the user.".Failure());

            var addedCategories = await UserCategoriesService.GetAllUserCategories(userId.UserId);

            if (addedCategories == null || !addedCategories.Any())
                return NotFound("No categories found for the user.".Failure());

            return Ok(addedCategories.Success("Default categories added successfully."));
        }

        return Ok(categories.Success());
    }

    [HttpPost("")]
    public async Task<IActionResult> AddNewUserCategorie([FromBody] CategorieAddRequest categorieAddRequest)
    {
        var userId = await UsersService.GetByUserNameAsync(UserToken.UserName);
        
        if (userId == null)
            return BadRequest("User not found.".Failure());
      
        var result = await UserCategoriesService.AddNewCategorieToUser(userId.UserId, new CategoryDto { 
            Name = categorieAddRequest.Name,
            Description = categorieAddRequest.Description
        });

        return result != null 
            ? Ok(result.Success("Category added successfully.")) 
            : BadRequest("Failed to add new category.".Failure());
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserCategorie([FromBody] CategorieUpdateRequest categorieUpdateRequest)
    {
        var userId = await UsersService.GetByUserNameAsync(UserToken.UserName);

        if (userId == null)
            return BadRequest("User not found.".Failure());

        var category = await UserCategoriesService.UpdateUserCategorie(new CategoryDto
        {
            CategorieId = categorieUpdateRequest.categoryId,
            Name = categorieUpdateRequest.Name,
            Description = categorieUpdateRequest.Description
        });

        return category != null 
            ? Ok(category.Success("Category updated successfully.")) 
            : BadRequest("Failed to update category.".Failure());
    }
}
