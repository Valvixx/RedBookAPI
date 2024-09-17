using Application.DTO.Auth;

namespace Application.Services;

public interface IAuthService
{
    Task<string> AuthorizeUser(AuthLogin authData);
}