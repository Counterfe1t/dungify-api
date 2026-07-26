using Dungify.Application.Abstractions;

namespace Dungify.Application.Commands.User;

public sealed record SignIn(string Email, string Password) : ICommand;