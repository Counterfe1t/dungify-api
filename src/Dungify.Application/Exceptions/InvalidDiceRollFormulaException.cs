using Dungify.Core.Exceptions;
using System.Net;

namespace Dungify.Application.Exceptions;

public sealed class InvalidDiceRollFormulaException : CustomException
{
    public string Formula { get; }

    public InvalidDiceRollFormulaException(string formula)
        : base($"Invalid dice roll formula: '{formula}'. Expected format: '{{count}}d{{sides}}' where count is a positive integer and sides is either 10 or 100.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        Formula = formula;
    }
}