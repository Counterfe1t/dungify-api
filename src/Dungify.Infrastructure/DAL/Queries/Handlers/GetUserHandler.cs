using Dungify.Application.Abstractions;
using Dungify.Application.DTO;
using Dungify.Core.Exceptions;
using Dungify.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Dungify.Infrastructure.DAL.Queries.Handlers;

internal sealed class GetUserHandler(DungifyDbContext dbContext) : IQueryHandler<GetUser, UserDto>
{
    public async Task<UserDto> HandleAsync(GetUser query)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == new EntityId(query.Id))
            ?? throw new UserNotFoundException(query.Id);

        return user.AsDto();
    }
}