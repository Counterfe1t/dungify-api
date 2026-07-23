using Dungify.Application.Abstractions;
using Humanizer;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Dungify.Infrastructure.Logging.Decorators;

internal sealed class LoggingCommandHandlerDecorator<TCommand>(
    ILogger<ICommandHandler<TCommand>> logger,
    ICommandHandler<TCommand> commandHandler) : ICommandHandler<TCommand> where TCommand : class, ICommand
{
    public async Task HandleAsync(TCommand command)
    {
        var commandName = typeof(TCommand).Name.Underscore();
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        logger.LogInformation("started handling command: {CommandName}", commandName);

        await commandHandler.HandleAsync(command);

        stopwatch.Stop();
        logger.LogInformation("completed handling command: {CommandName} in {Elapsed}", commandName, stopwatch.Elapsed);
    }
}