using Dungify.Application.Abstractions;
using Dungify.Application.Exceptions;
using Dungify.Application.Security;
using Dungify.Core.Abstractions;
using Dungify.Core.Repositories;
using Dungify.Core.ValueObjects;

namespace Dungify.Application.Commands.Handlers;

internal sealed class SignUpHandler(
    ITimeProvider timeProvider,
    IUsersRepository usersRepository,
    IPasswordManager passwordManager) : ICommandHandler<SignUp>
{
    public async Task HandleAsync(SignUp command)
    {
        var email = new Email(command.Email);
        var name = new UserName(command.Name);

        if (await usersRepository.GetAsync(email) is not null)
            throw new EmailAlreadyInUseException(email);

        if (await usersRepository.GetAsync(name) is not null)
            throw new UserNameAlreadyInUseException(name);

        await usersRepository.AddAsync(new(
            command.Id,
            timeProvider.UtcNow,
            name,
            email,
            passwordManager.HashPassword(command.Password)));
    }
}
