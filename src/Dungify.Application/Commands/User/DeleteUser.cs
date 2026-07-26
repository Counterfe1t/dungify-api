using Dungify.Application.Abstractions;

namespace Dungify.Application.Commands.User;

public sealed record DeleteUser(Guid Id) : ICommand;