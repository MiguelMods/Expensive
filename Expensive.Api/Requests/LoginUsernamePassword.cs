namespace Expensive.Api.Requests
{
    public record LoginRequest(string UserName, string Password);
    public record LoginRegisterRequest(string FirtName, string LastName, string UserName, string Email, string Password);
}
