using Dungify.Application.Abstractions;
using Dungify.Application.DTO;

namespace Dungify.Infrastructure.DAL.Queries.Users;

public sealed record GetUser(Guid Id) : IQuery<UserDto>;