using Dungify.Application.Exceptions;
using Dungify.Core.Abstractions;
using Dungify.Infrastructure.Services;
using Shouldly;

namespace Dungify.UnitTests.Services;

public class DiceEngineTests
{
    private readonly IDiceEngine _cut;

    public DiceEngineTests()
        => _cut = new DiceEngine();

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("invalid_formula")]
    [InlineData("1d2137")]
    [InlineData("0d10")]
    public void Roll_FormulaIsInvalid_ShouldThrowException(string? formula)
    {
        // act
        var exception = Record.Exception(() => _cut.Roll(formula!));

        // assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidDiceRollFormulaException>();
    }

    [Theory]
    [MemberData(nameof(RollTestData))]
    public void Roll_FormulaIsValid_ShouldReturnValidResult(
        string? formula,
        int amountOfDice,
        int minValue,
        int maxValue)
    {
        // act
        var result = _cut.Roll(formula!);

        // assert
        result.ShouldNotBeNull();
        result.Length.ShouldBe(amountOfDice);

        foreach (var roll in result)
            roll.ShouldBeInRange(minValue, maxValue);
    }

    public static TheoryData<string, int, int, int> RollTestData()
        => new()
        {
            { "1d10", 1, 1, 10 },
            { "69d10", 69, 1, 10 },
            { "1d100", 1, 1, 100 },
            { "2137d100", 2137, 1, 100 },
        };
}