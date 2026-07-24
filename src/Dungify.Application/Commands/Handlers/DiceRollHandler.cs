using Dungify.Application.Abstractions;
using Dungify.Application.DTO;
using Dungify.Core.Abstractions;

namespace Dungify.Application.Commands.Handlers;

internal sealed class DiceRollHandler(IDiceRoller diceRoller) : ICommandHandler<DiceRoll, DiceRollDto>
{
    public Task<DiceRollDto> HandleAsync(DiceRoll command)
    {
        var rolls = diceRoller.Roll(command.Formula);
        var total = rolls.Sum();

        // TODO Save the dice roll to database for history tracking
        // TODO Broadcast the dice roll result to all connected clients using SignalR

        return Task.FromResult<DiceRollDto>(new()
        {
            Rolls = rolls,
            Total = total
        });
    }
}