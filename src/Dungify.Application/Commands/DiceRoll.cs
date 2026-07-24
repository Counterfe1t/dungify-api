using Dungify.Application.Abstractions;
using Dungify.Application.DTO;

namespace Dungify.Application.Commands;

public sealed record DiceRoll(string Formula) : ICommand<DiceRollDto>;
