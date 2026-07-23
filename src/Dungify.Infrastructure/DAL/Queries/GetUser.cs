using Dungify.Application.Abstractions;
using Dungify.Application.DTO;

namespace Dungify.Infrastructure.DAL.Queries;

public sealed record GetUser(Guid Id) : IQuery<UserDto>;