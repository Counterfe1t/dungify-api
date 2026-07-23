using Dungify.Core.Entities;
using Dungify.Core.Repositories;
using Dungify.Core.ValueObjects;

namespace Dungify.Infrastructure.DAL.Repositories;

internal sealed class InMemoryUsersRepository : IUsersRepository
{
    private readonly HashSet<User> _users =
    [
        new(
            Guid.Parse("00000000-0000-0000-0000-000000002137"),
            DateTimeOffset.UtcNow,
            "admin",
            "admin@dungify.dev",
            "password")
    ];

    public async Task<User?> GetAsync(EntityId id)
        => await Task.FromResult(_users.FirstOrDefault(p => p.Id == id));

    public async Task<User?> GetAsync(UserName name)
        => await Task.FromResult(_users.FirstOrDefault(p => p.Name == name));

    public async Task<User?> GetAsync(Email email)
        => await Task.FromResult(_users.FirstOrDefault(p => p.Email == email));

    public Task AddAsync(User User)
    {
        _users.Add(User);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(User User)
    {
        // Update User

        return Task.CompletedTask;
    }

    public Task DeleteAsync(User User)
    {
        _users.Remove(User);

        return Task.CompletedTask;
    }
}