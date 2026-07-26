using Dungify.Application.Abstractions;

namespace Dungify.Application.Commands.Users;

public sealed record DeleteUser(Guid Id) : ICommand;