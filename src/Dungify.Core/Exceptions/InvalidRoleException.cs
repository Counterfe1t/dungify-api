using System.Net;

namespace Dungify.Core.Exceptions;

internal sealed class InvalidRoleException : CustomException
{
    public string Role { get; }

    public InvalidRoleException(string role) : base($"Role: '{role}' is invalid.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        Role = role;
    }
}
