namespace Expensive.Api.Requests
{
    public record AccountChangePasswordRequest(string UserName, string OldPassword, string NewPassord);
}
