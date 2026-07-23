using Dungify.Application.Abstractions;
using Dungify.Core.Exceptions;
using Dungify.Core.Repositories;

namespace Dungify.Application.Commands.Handlers;

public sealed class DeleteUserHandler(IUsersRepository usersRepository) : ICommandHandler<DeleteUser>
{
    public async Task HandleAsync(DeleteUser command)
    {
        var user = await usersRepository.GetAsync(command.Id)
            ?? throw new UserNotFoundException(command.Id);

        await usersRepository.DeleteAsync(user);
    }
}