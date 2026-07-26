namespace Dungify.Core.Abstractions;

public interface IDiceEngine
{
    /// <summary>
    /// Rolls dice according to the provided formula (e.g. "2d100", "3d10").
    /// </summary>
    /// <param name="formula">Dice formula in the format: "{count}d{sides}" where sides can be 10 or 100.</param>
    /// <returns>Array of individual roll results for each dice.</returns>
    int[] Roll(string formula);
}