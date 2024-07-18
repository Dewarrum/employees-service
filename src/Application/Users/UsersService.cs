using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Users;

internal sealed class UsersService(AppDbContext dbContext, IPasswordHasher hasher) : IUsersService
{
    public async Task<User> Create(string name, string password)
    {
        var user = new User(name, hasher.Hash(password));
        var entry = await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<User?> Get(string name, string password)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Name == name);
        if (user is null)
        {
            return null;
        }

        if (!hasher.Verify(password, user.Password))
        {
            return null;
        }

        user.LastActiveAt = DateTime.UtcNow;
        await dbContext.SaveChangesAsync();
        return user;
    }
}