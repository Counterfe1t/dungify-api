using Dungify.Application.Abstractions;

namespace Dungify.Application.Commands;

public sealed record SignIn(string Email, string Password) : ICommand;