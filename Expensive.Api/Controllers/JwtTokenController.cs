using Expensive.Application.Services.Contracts;
using Expensive.Common.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Expensive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtTokenController(IJwtTokenService jwtTokenService, IHashPassordService hashPassordService) : ControllerBase
    {
        public IJwtTokenService JwtTokenService { get; } = jwtTokenService;
        public IHashPassordService HashPassordService { get; } = hashPassordService;

        [HttpGet("password"), AllowAnonymous]
        public async Task<IActionResult> Password()
        {
            var password = "qwerty";
            var hashedPassword = await HashPassordService.HashPassword(password);
            return Ok(new { password, hashedPassword }.Success("Password hashed successfully"));
        }


        [HttpPost("revealed"), AllowAnonymous]
        public async Task<IActionResult> revealed([FromBody] HashedPasswordRequest hashedPassword)
        {
            var password = "qwerty";
            var revelaed = await HashPassordService.VerifyPassword(hashedPassword.HashedPassword, password);
            return Ok(new { password, hashedPassword, revelaed }.Success("Password hashed successfully"));
        }

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

    public class HashedPasswordRequest 
    {
        public string HashedPassword { get; set; }
    }
}
