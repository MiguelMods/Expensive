using Expensive.Api.Requests;
using Expensive.Application.Responses;
using Expensive.Application.Services.Contracts;
using Expensive.Common.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Expensive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IUsersService userService, IJwtTokenService jwtTokenService) : ControllerBase
    {
        public IUsersService UserService { get; } = userService;
        public IJwtTokenService JwtTokenService { get; } = jwtTokenService;

        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUsernamePasswordRequest request)
        {
            var user = await UserService.GetByUserNameAndPassword(request.UserName, request.Password);

            if (user == null)
                return Unauthorized(user.Failure("Invalid username or password"));

            var token = await JwtTokenService.GenerateTokenAsync($"{user.FirtsName} {user.LastName}", user.UserName!, user.Email!, "generic");

            return Ok(new { token }.Success());
        }

        [HttpPost("register"), AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] LoginRegisterRequest request)
        {
            var user = await UserService.RegisterAsync(new() {
                FirtsName = request.FirtName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password
            });

            if (user == null)
                return BadRequest(user.Failure("User registration failed"));

            var response = new UserResponse().MapToResponse(user);

            return Ok(response.Success("User registered successfully"));
        }

        [HttpPut("ChangePassword"), Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] AccountChangePasswordRequest request) 
        {            
            var updateResult = await UserService.UpdateOldPasswordToPassword(request.UserName, request.OldPassword, request.NewPassord);

            if (!updateResult)
                return BadRequest(updateResult.Failure("Cannot update user password"));

            return Ok(updateResult.Success("User password updated successfully"));
        }
    }
}
