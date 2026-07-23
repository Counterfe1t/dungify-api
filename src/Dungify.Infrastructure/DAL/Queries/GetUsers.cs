using Dungify.Application.Abstractions;
using Dungify.Application.DTO;

namespace Dungify.Infrastructure.DAL.Queries;

public sealed record GetUsers(int PageNumber, int PageSize) : IQuery<IEnumerable<UserDto>>;