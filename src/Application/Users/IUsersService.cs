using Domain;

namespace Application.Users;

public interface IUsersService
{
    Task<User> Create(string name, string password);
    Task<User?> Get(string name, string password);
}