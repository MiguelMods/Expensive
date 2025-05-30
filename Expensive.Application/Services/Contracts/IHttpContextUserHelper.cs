using Expensive.Application.Models;

namespace Expensive.Application.Services.Contracts;

public interface IHttpContextUserHelper
{
    string GetName();
    UserToken GetUserToken();
}
