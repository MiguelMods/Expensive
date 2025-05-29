namespace Expensive.Api.Requests
{
    public record LoginRegisterRequest(string FirtName, string LastName, string UserName, string Email, string Password);
}
