using Dungify.Core.Exceptions;
using System.Net;

namespace Dungify.Application.Exceptions;

internal sealed class InvalidCredentialsException : CustomException
{
    public InvalidCredentialsException() : base($"Invalid credentials.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
    }
}