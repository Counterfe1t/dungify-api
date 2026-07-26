using Dungify.Application.Abstractions;

namespace Dungify.Application.Commands.Users;

public sealed record SignIn(string Email, string Password) : ICommand;