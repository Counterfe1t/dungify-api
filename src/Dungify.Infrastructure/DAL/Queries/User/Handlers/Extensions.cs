using Dungify.Application.DTO;

namespace Dungify.Infrastructure.DAL.Queries.User.Handlers;

internal static class Extensions
{
    public static UserDto AsDto(this Core.Entities.User entity)
        => new()
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            ModifiedAt = entity.ModifiedAt?.Value,
            Name = entity.Name,
            Email = entity.Email,
            Password = entity.Password,
            Role = entity.Role
        };
}
