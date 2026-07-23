using Dungify.Core.Exceptions;
using System.Net;

namespace Dungify.Application.Exceptions;

public sealed class UserNotFoundException : CustomException
{
    public Guid UserId { get; }

    public UserNotFoundException(Guid userId)
        : base($"User with ID: '{userId}' was not found.")
    {
        StatusCode = (int)HttpStatusCode.NotFound;
        UserId = userId;
    }
}