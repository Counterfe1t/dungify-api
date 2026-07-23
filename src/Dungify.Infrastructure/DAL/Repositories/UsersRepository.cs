using Dungify.Core.Entities;
using Dungify.Core.Repositories;
using Dungify.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Dungify.Infrastructure.DAL.Repositories;

internal sealed class UsersRepository : IUsersRepository
{
    private readonly DungifyDbContext _dbContext;

    public UsersRepository(DungifyDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<User?> GetAsync(EntityId id)
        => await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<User?> GetAsync(Email email)
        => await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<User?> GetAsync(UserName name)
        => await _dbContext.Users.FirstOrDefaultAsync(u => u.Name == name);

    public async Task AddAsync(User user)
    {
        _dbContext.Users.Add(user);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _dbContext.Users.Update(user);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _dbContext.Users.Remove(user);

        await _dbContext.SaveChangesAsync();
    }
}