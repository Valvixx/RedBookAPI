using Application.DTO.Auth;

namespace Application.Services;

public interface IAuthService
{
    Task<LoginResponse> AuthorizeUser(LoginRequest data);
}