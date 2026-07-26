using Dungify.Application.Abstractions;

namespace Dungify.Application.Commands.User;

public record UpdateUser(
    Guid Id,
    string? Name,
    string? Email,
    string? Password,
    string? Role) : ICommand;