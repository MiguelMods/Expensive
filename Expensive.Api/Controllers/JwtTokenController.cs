using Expensive.Application.Services.Contracts;
using Expensive.Common.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Expensive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtTokenController(IJwtTokenService jwtTokenService) : ControllerBase
    {
        public IJwtTokenService JwtTokenService { get; } = jwtTokenService;
        
        [HttpGet("Generate"), AllowAnonymous]
        public async Task<IActionResult> Generate() 
        {
            var token = await JwtTokenService.GenerateTokenAsync("miguelmodd", "miguelmodd@gmail.com", "default", "qwerty");
            return Ok(new { token }.Success("Token generated successfully"));
        }

        [HttpGet("Proof"), Authorize]
        public async Task<IActionResult> Proof() 
        {
            return Ok("Funciona");
        }
    }
}
