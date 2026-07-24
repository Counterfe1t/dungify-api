using Dungify.Application.Exceptions;
using Dungify.Core.Abstractions;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Dungify.Infrastructure.Services;

internal sealed class DiceRoller : IDiceRoller
{
    private static readonly Regex DiceRollFormulaRegex = new(
        @"^(?<count>\d+)d(?<sides>(?:10|100))$",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public int[] Roll(string formula)
    {
        var (count, sides) = ParseFormula(formula);
        var rolls = new int[count];

        for (int i = 0; i < count; i++)
            rolls[i] = RollSingleDice(sides);

        return rolls;
    }

    private static int RollSingleDice(int sides)
    {
        var randomBytes = new byte[4];
        RandomNumberGenerator.Fill(randomBytes);
        var randomValue = BitConverter.ToInt32(randomBytes, 0);

        return Math.Abs(randomValue % sides) + 1;
    }

    private static (int count, int sides) ParseFormula(string formula)
    {
        if (string.IsNullOrWhiteSpace(formula))
            throw new InvalidDiceRollFormulaException(formula);

        var match = DiceRollFormulaRegex.Match(formula.Trim());

        if (!match.Success)
            throw new InvalidDiceRollFormulaException(formula);

        if (!int.TryParse(match.Groups["count"].Value, out var count) || count <= 0)
            throw new InvalidDiceRollFormulaException(formula);

        var sides = int.Parse(match.Groups["sides"].Value);

        return (count, sides);
    }
}