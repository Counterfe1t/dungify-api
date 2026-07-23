using Dungify.Application.Abstractions;
using Dungify.Application.Exceptions;
using Dungify.Application.Security;
using Dungify.Core.Abstractions;
using Dungify.Core.Repositories;
using Dungify.Core.ValueObjects;

namespace Dungify.Application.Commands.Handlers;

internal sealed class UpdateUserHandler(
    ITimeProvider timeProvider,
    IUsersRepository usersRepository,
    IPasswordManager passwordManager) : ICommandHandler<UpdateUser>
{
    public async Task HandleAsync(UpdateUser command)
    {
        var user = await usersRepository.GetAsync(command.Id)
            ?? throw new UserNotFoundException(command.Id);

        if (!string.IsNullOrWhiteSpace(command.Name))
        {
            if (await usersRepository.GetAsync(new UserName(command.Name)) is not null)
                throw new UserNameAlreadyInUseException(command.Name);

            user.ChangeName(command.Name);
        }

        if (!string.IsNullOrWhiteSpace(command.Email))
        {
            if (await usersRepository.GetAsync(new Email(command.Email)) is not null)
                throw new EmailAlreadyInUseException(command.Email);

            user.ChangeEmail(command.Email);
        }

        if (!string.IsNullOrWhiteSpace(command.Password))
            user.ChangePassword(passwordManager.HashPassword(command.Password));

        if (!string.IsNullOrWhiteSpace(command.Role))
            user.ChangeRole(command.Role);

        user.ChangeModifiedAt(timeProvider.UtcNow);

        await usersRepository.UpdateAsync(user);
    }
}