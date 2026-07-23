using System.Net;

namespace Dungify.Core.Exceptions;

internal sealed class InvalidPasswordException : CustomException
{
    public InvalidPasswordException() : base($"Password is invalid.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
    }
}