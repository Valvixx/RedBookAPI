using Domain.Entities;

namespace Application.Services;

public interface IUserService
{
    public User CreateUser();
    public User DeleteUser(); // Если не лень будет сделать
}