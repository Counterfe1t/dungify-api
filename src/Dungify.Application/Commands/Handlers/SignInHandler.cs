using Dungify.Application.Abstractions;
using Dungify.Application.Exceptions;
using Dungify.Application.Security;
using Dungify.Core.Repositories;
using Dungify.Core.ValueObjects;

namespace Dungify.Application.Commands.Handlers;

internal sealed class SignInHandler(
    IUsersRepository userRepository,
    IPasswordManager passwordManager,
    ITokenStorage tokenStorage,
    IAuthenticator authenticator) : ICommandHandler<SignIn>
{
    public async Task HandleAsync(SignIn command)
    {
        var user = await userRepository.GetAsync(new Email(command.Email))
            ?? throw new InvalidCredentialsException();

        if (!passwordManager.ValidatePassword(command.Password, user.Password))
            throw new InvalidCredentialsException();

        tokenStorage.Set(authenticator.CreateToken(user.Id, user.Role));
    }
}