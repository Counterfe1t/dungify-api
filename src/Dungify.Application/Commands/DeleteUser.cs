using Dungify.Application.Abstractions;

namespace Dungify.Application.Commands;

public sealed record DeleteUser(Guid Id) : ICommand;