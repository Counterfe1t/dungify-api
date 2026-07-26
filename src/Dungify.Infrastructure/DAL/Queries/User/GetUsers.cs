using Dungify.Application.Abstractions;
using Dungify.Application.DTO;

namespace Dungify.Infrastructure.DAL.Queries.User;

public sealed record GetUsers(int PageNumber, int PageSize) : IQuery<IEnumerable<UserDto>>;