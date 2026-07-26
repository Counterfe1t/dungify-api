using Dungify.Application.Abstractions;
using Dungify.Application.DTO;
using Dungify.Core.Abstractions;

namespace Dungify.Application.Commands.DiceRolls.Handlers;

internal sealed class RollDiceHandler(IDiceEngine diceRoller) : ICommandHandler<RollDice, DiceRollDto>
{
    public Task<DiceRollDto> HandleAsync(RollDice command)
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