namespace Dungify.Core.Exceptions;

public abstract class CustomException(string message) : Exception(message)
{
    public int StatusCode { get; protected set; }
}
