using Dungify.Application.Abstractions;
using Dungify.Application.DTO;
using Microsoft.EntityFrameworkCore;

namespace Dungify.Infrastructure.DAL.Queries.Handlers;

internal sealed class GetUsersHandler(DungifyDbContext dbContext) : IQueryHandler<GetUsers, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query)
        => await dbContext.Users
            .AsNoTracking()
            .OrderBy(u => u.CreatedAt)
            .Select(u => u.AsDto())
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();
}