using Dungify.Application.DTO;
using Dungify.Core.Entities;

namespace Dungify.Infrastructure.DAL.Queries.Handlers;

internal static class Extensions
{
    public static UserDto AsDto(this User entity)
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
