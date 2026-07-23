using Dungify.Application.Abstractions;

namespace Dungify.Application.Commands;

public record UpdateUser(
    Guid Id,
    string? Name,
    string? Email,
    string? Password) : ICommand;