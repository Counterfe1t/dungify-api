using System.Net;

namespace Dungify.Core.Exceptions;

internal sealed class InvalidEntityIdException : CustomException
{
    public Guid EntityId { get; }

    public InvalidEntityIdException(Guid entityId)
        : base($"Entity ID: '{entityId}' is invalid.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        EntityId = entityId;
    }
}